using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompresorHuffman
{
    //Clase Archivo la cual lee o guarda los archivos
    internal class Archivo
    {
        //Funcion que usa la libreria File de System para leer el contneido del archivo seleccionado
        public string leerArchivo(string ruta)
        {
            return File.ReadAllText(ruta);
        }

        //Funcion la cual usa la libreria File de System para escribir y guardar un archivo
        public void guardarArchivo(string ruta, string texto)
        {
            File.WriteAllText(ruta, texto);
        }

        //Funcion para generar la ruta nueva del archivo comprimido o descomprimido
        public string generarRuta(string ruta, string nombreArchivo)
        {
            //Obtenemos la ruta del archivo actualmente abierte y la extension
            string path = ruta.Replace(nombreArchivo, "");
            string tipoArchivo = Path.GetExtension(nombreArchivo);

            //Creamos la nueva extension segun la extension del archivo abierto
            string nuevoTipo = ".txt";
            if(tipoArchivo == ".txt")
            {
                nuevoTipo = ".cositas";
            }

            //Genera la nueva ruta del archivo con la nueva extension
            string nuevoArchivo = nombreArchivo.Replace(tipoArchivo, nuevoTipo);
            path += nuevoArchivo;
            return path;
        }
    }
}
