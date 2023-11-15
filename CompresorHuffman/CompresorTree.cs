using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace CompresorHuffman
{
    //Clase de codigo de Huffman para generacion de arbol
    /*  Se tuvo como base la documentacion que se encuentra en:
     *  https://www.csharpstar.com/csharp-huffman-coding-using-dictionary/#:~:text=Huffman%20coding%20is%20a%20lossless,character%20gets%20the%20largest%20code.
     */
    internal class CompresorTree
    {
        private List<Node> nodos = new List<Node>();
        public Node Root { get; set; }
        public List<Node> diccionario = new List<Node>();

        public Dictionary<char, int> Frecuencias = new Dictionary<char, int>();

        //Funcion la cual cuenta cuantas veces se repite una letra en el archivo
        public void contarFrecuencias(string textoArchivo)
        {
            //Recorremos el archivo y contamos cuantas veces se repite cada letra y la guardamos en un arreglo
            for (int i = 0; i < textoArchivo.Length; i++)
            {
                if (!Frecuencias.ContainsKey(textoArchivo[i]))
                {
                    Frecuencias.Add(textoArchivo[i], 0);
                }

                Frecuencias[textoArchivo[i]]++;
            }

            //Recorremos el arreglo con las frecuencias de letras y generamos un nuevo nodo para el arbol
            foreach (KeyValuePair<char, int> simbolo in Frecuencias)
            {
                nodos.Add(new Node() { Simbolo = simbolo.Key, Frecuencia = simbolo.Value });
            }

            //Clonamos los nodos ordenandolos de menos a mayor frecuencia para posteriormente imprimir en el archivo
            diccionario = nodos.OrderBy(node => node.Frecuencia).ToList<Node>();
            //Llamamos al metodo para contruir el arbol con los nodos generados
            ConstruirArbol();
        }

        //Construccion del arbol de Huffman
        private void ConstruirArbol()
        {
            //Recorre cada uno de los nodos
            while (nodos.Count > 1)
            {
                //Ordenamos los nodos de menor a mayor frecuencia
                List<Node> orderedNodes = nodos.OrderBy(node => node.Frecuencia).ToList<Node>();

                //Vamos generando el arbol segun la frecuencia de cada letra
                if (orderedNodes.Count >= 2)
                {
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    Node parent = new Node()
                    {
                        Simbolo = '*',
                        Frecuencia = taken[0].Frecuencia + taken[1].Frecuencia,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    nodos.Remove(taken[0]);
                    nodos.Remove(taken[1]);
                    nodos.Add(parent);
                }

                this.Root = nodos.FirstOrDefault();

            }

        }

        //Funcion la cual comprime el texto a binario segun el arbol de huffman
        public BitArray Comprimir(string source)
        {
            //Recorremos el texto y vamos convirtiendolo en binario segun el arbol
            List<bool> encodedSource = new List<bool>();
            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }
            //Concatenamos todos los binarios y retornan
            BitArray bits = new BitArray(encodedSource.ToArray());
            return bits;
        }

        //Funcion la cual descomprime un binario a texto segun el arbol de Huffman
        public string Descomprimir(BitArray bits, ProgressBar barraProgreso)
        {
            //Inicializamos variables en las cuales esta tambien la barra de progreso la cual cargara paso por paso mientras se descomprime
            Node current = this.Root;
            string decoded = "";
            barraProgreso.Maximum = bits.Length;
            barraProgreso.Value = 1;

            //Recorremos el binario y obtenemos la letra segun su posicion en el arbol
            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Simbolo;
                    current = this.Root;
                }
                //Vamos aumentando la barra de progreso
                barraProgreso.PerformStep();
            }
            //Retornamos el texto ya descomprimido
            return decoded;
        }

        public bool IsLeaf(Node node)
        {
            return (node.Left == null && node.Right == null);
        }

        //Funcion la cual retorna el directirio del arbol de huffman
        public List<Node> obtenerDirectorio()
        {
            //Recorremos el diccionario y vamos obteniendo su valor binario solo por cuestiones visuales
            foreach (Node nodo in diccionario)
            {
                //obtenmos el binario de cada letra
                BitArray codigo = Comprimir(nodo.Simbolo.ToString());
                foreach (bool bit in codigo)
                {
                    nodo.Codigo += (bit ? 1 : 0) + "";
                }
            }

            return diccionario;
        }

        //Funcion que genera los nodos para el arbol de huffman segun el directorio del archivo comprimido
        public void generarDirectorio(string texto)
        {
            //Instanciamos la clase nodo
            Node nodoClass = new Node();
            //Separamos el texto del archivo primero con el caracter Yen(¥) donde antes del Yen estan los directorios
            //Y luego separamos por salto de linea para obtener cada uno de los simbolos del directorio
            string diccionario = texto.Split('¥')[0];
            string[] textoSeparado = diccionario.Split('\n');
            //Recorremos cada uno de los simbolos
            for (int i = 0; i < textoSeparado.Length-1; i++)
            {
                //Obtenemos posiciones para obtener la letra y la frecuencia
                int posicionParentesisAbierto = textoSeparado[i].LastIndexOf('(');
                int posicionParentesisCerrado = textoSeparado[i].LastIndexOf(')') - (posicionParentesisAbierto + 1);
                string Simbolo = nodoClass.traductor(textoSeparado[i].Substring(0, posicionParentesisAbierto));
                string Frecuencia = textoSeparado[i].Substring(posicionParentesisAbierto+1, posicionParentesisCerrado);

                //Generamos un nuevo nodo segun la letra y la frecuencia obtenida de cada linea
                nodos.Add(new Node() { Simbolo = char.Parse(Simbolo), Frecuencia = int.Parse(Frecuencia) });
            }
            //Llamamos al metodo para contruir el arbol con los nodos generados
            ConstruirArbol();
        }

        //Ciframos en Caracteres los bytes con la libreria Enconding de System
        /*  Para cifrar o descifrar el contenido se oriento segun la siguiente documentación
         *  https://social.msdn.microsoft.com/Forums/vstudio/en-US/d1273b61-1402-4902-aa91-2862fa1351df/binary-to-ascii-character-conversion?forum=csharpgeneral
         *  https://stackoverflow.com/questions/6006425/binary-to-corresponding-ascii-string-conversion
         *  https://stackoverflow.com/questions/12355084/c-sharp-encoding-ascii-getstring-returns-instead-of-actual-string-why
         *  https://techhelpnotes.com/c-encoding-ascii-getstring-returns-instead-of-actual-string-why/
         *  https://github.com/dotnet/standard/issues/260
         *  Usamos el Default encoding, la cual toma la codificación por defecto de la maquina que normalmente es UTF8
         */
        public string generarASCII(byte[] comprimidoBytes)
        {
            return Encoding.Default.GetString(comprimidoBytes);
        }

        //Ciframos en bytes y luego en binario los carecteres enviados con la libreria Enconding de System
        public BitArray transformarBinario(string texto)
        {
            //Dividimos el texto con el simbolo Yen(¥) donde todo lo que esta despues de la primera posicion lo tomamos como el texto cifrado
            string[] textoSeparado = texto.Split('¥');
            string textoCifrado = textoSeparado[1];
            if (textoSeparado.Length > 2)
            {
                textoCifrado = string.Join("¥", textoSeparado.Skip(1));
            }

            //Obtenemos los bytes y los convertimos inmediatament despues en bits y retornamos ese valor
            byte[] bytes = Encoding.Default.GetBytes(textoCifrado);
            return new BitArray(bytes);
        }
    }
}
