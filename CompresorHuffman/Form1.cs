using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace CompresorHuffman
{
    public partial class Form1 : Form
    {
        //Variable para instancear la clase Archivo la cual lee y guarda los textos
        private Archivo archivoClass;

        //Consturtor del formulario, iniciamos los componentes, instaciamos la clase Archivo y ponemos algunos valores por defecto
        public Form1()
        {
            InitializeComponent();
            archivoClass = new Archivo();
            //Configuracion inicial para la barra de progreso
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            progressBar.Step = 1;
        }

        //Funcion para abrir el cuadro de dialogo para seleccionar archivo
        private void seleccionarArchivo_Click(object sender, EventArgs e)
        {
            abrirRecuadro.ShowDialog();
        }

        //Funcion una vez selecciono el archivo del cuadro de dialogo
        private void seleccionarArchivo_FileOk(object sender, CancelEventArgs e)
        {
            //Obtenemos nombre y extencion del archivo seleccionado
            string nombreArchivo = abrirRecuadro.FileName;
            string tipoArchivo = Path.GetExtension(nombreArchivo);
            textoArchivoSelec.Text = nombreArchivo;
            
            //verificamos que tipo de archivo es para habilitar los botones de comprimir o descomprimir segun el tipo
            switch (tipoArchivo)
            {
                case ".txt":
                    comprimirBtn.Enabled = true;
                    descomprimirBtn.Enabled = false;
                    break;
                case ".cositas":
                    comprimirBtn.Enabled = false;
                    descomprimirBtn.Enabled = true;
                    break;
                default:
                    comprimirBtn.Enabled = false;
                    descomprimirBtn.Enabled = false;
                    break;
            }
            //Obtenemos el texto del archivo y lo mostramos en pantalla
            string texto = archivoClass.leerArchivo(nombreArchivo);
            textoEntradaInput.Text = texto;
            textoSalidaInput.Text = "";
            archivoGeneradoLbl.Text = "";
            progressBar.Value = 0;
        }

        //Funcion del boton de comprimir
        private void comprimirBtn_Click(object sender, EventArgs e)
        {
            //Generamos variables iniciales y obtenemos el texto del archivo
            string textoEntrada = archivoClass.leerArchivo(abrirRecuadro.FileName);
            string textoSalida = "";
            string textoArchivo = "";
            string textoASCII;

            //Instanceamos y llamamos la clase para generar el arbol de Huffman
            CompresorTree compresorTree = new CompresorTree();
            compresorTree.contarFrecuencias(textoEntrada);

            //Convertimos el texto en binario segun el arbol generado anteriormente y guardamos el diccionario creado con el arbol
            //Posteriormente convertimos el binario en bytes
            BitArray comprimido = compresorTree.Comprimir(textoEntrada);
            byte[] comprimidoBytes = BitArrayToByteArray(comprimido);
            List<Node> diccionario = compresorTree.obtenerDirectorio();

            //Establecemos los valores para la barra de progreso que se mostrara mientras se comprime el texto
            progressBar.Maximum = comprimido.Length + diccionario.Count();
            progressBar.Value = 1;

            //Recorremos el diccionario y lo vamos guardando en la variable que guardara en el archivo
            textoSalida += "Diccionario:\n";
            foreach (Node nodo in diccionario)
            {
                textoArchivo += $"{nodo.traductor(nodo.Simbolo.ToString())}({nodo.Frecuencia}) => {nodo.Codigo}\n";
                // Aumenta la barra de progreso
                progressBar.PerformStep();
            }
            textoSalida += textoArchivo + "Cifrado Binario:\n";

            // Se recorre el binario y se guarda solo para mostrar en pantalla
            foreach (bool bit in comprimido)
            {
                textoSalida += (bit ? 1 : 0) + "";
                progressBar.PerformStep();
            }

            //Convertimos los bytes en texto ASCII, usamos el carater Yen (¥) para dividir el directorio del texto comprimido
            textoASCII = compresorTree.generarASCII(comprimidoBytes);
            textoSalida += "\nTexto comprimido:\n" + textoASCII;
            textoArchivo += "¥" + textoASCII;

            //Mostramos en pantalla y generamos el archivo comprimido
            mostrarSalida(textoSalida, textoArchivo);
        }

        //Funcion de boton de abrir arhicvo el cual a los procesos de windows para abrir el archivo
        private void abrirArchivoGenerado_Click(object sender, EventArgs e)
        {
            Process proceso = new Process();
            proceso.StartInfo.FileName = archivoGeneradoLbl.Text;
            proceso.Start();
        }

        //Funcion del boton de descomprimir
        private void descomprimirBtn_Click(object sender, EventArgs e)
        {
            //Leemos el texto comprimido y lo guardamos
            string textoEntrada = archivoClass.leerArchivo(abrirRecuadro.FileName);

            //Instanceamos la clase del arbol de huffman, generamos el directorio y el arbol con lo que esta en el archivo antes del simbolo Yen(¥)
            CompresorTree compresorTree = new CompresorTree();
            compresorTree.generarDirectorio(textoEntrada);
            //Convertimos de ASCII a binario y luego descomprimimos el binario segun el arbol de huffman
            BitArray textoComprimido = compresorTree.transformarBinario(textoEntrada);
            string textoSalida = compresorTree.Descomprimir(textoComprimido, progressBar);

            //Mostramos en pantalla y generamos el archivo descomprimido
            mostrarSalida(textoSalida, textoSalida);
        }

        //Funcion para mostrar en pantalla y guardar archivo
        private void mostrarSalida(string textoSalida, string textoArchivo)
        {
            //Mostramos en pantalla el texto generado ya sea comprimido o descomprimido
            textoSalidaInput.Text = textoSalida;
            //Generamos la ruta donde guardara el archivo nuevo
            string nuevaRuta = archivoClass.generarRuta(abrirRecuadro.FileName, abrirRecuadro.SafeFileName);
            archivoGeneradoLbl.Text = nuevaRuta;
            //llamamos el metodo para guardar el archivo
            archivoClass.guardarArchivo(nuevaRuta, textoArchivo);

            abrirArchivoGenerado.Enabled = true;
        }

        //Funcion para convertir de binario a byte separandolo de 8 en 8
        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
    }
}
