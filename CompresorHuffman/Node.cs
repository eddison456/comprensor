using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompresorHuffman
{
    //Clase Node el cual tendra la funcion de generar los nodos y el cifrado binario recorriendo el arbol
    /*  Se tuvo como base la documentacion que se encuentra en:
     *  https://www.csharpstar.com/csharp-huffman-coding-using-dictionary/#:~:text=Huffman%20coding%20is%20a%20lossless,character%20gets%20the%20largest%20code.
     */
    internal class Node
    {
        private static Dictionary<string, string> traducciones;
        public char Simbolo { get; set; }
        public int Frecuencia { get; set; }
        public string Codigo { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        static Node()
        {
            //Traducciones solo para temas visuales y mostrar en ves de un " " => Espacio... etc
            traducciones = new Dictionary<string, string>
            {
                [" "] = "Espacio",
                ["Espacio"] = " ",
                ["\n"] = "Salto \\n",
                ["Salto \\n"] = "\n",
                ["\r"] = "Salto \\r",
                ["Salto \\r"] = "\r"
            };
        }

        //Funcion la cual recorre el arbol y devuelve el binario segun la posicion si es izquierda o derecha
        public List<bool> Traverse(char symbol, List<bool> data)
        {
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.Simbolo))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = Left.Traverse(symbol, leftPath);
                }

                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.Traverse(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }

        // Funcion la cual retorna el texto traducido para casos especiales como Espacio o Salto de linea
        public string traductor (string simbolo)
        {
            try
            {
                return traducciones[simbolo];
            } catch (KeyNotFoundException e)
            {
                return simbolo;
            }
        }
    }
}
