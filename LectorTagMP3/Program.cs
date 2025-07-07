using System;
using System.IO;
using System.Text;
using EspacioClases;
      string path;
      Console.WriteLine("Ingrese el directorio del archivo MP3 que desea buscar:");
      path = Console.ReadLine();
      while(!File.Exists(path)){
          Console.WriteLine("Error:Ingrese nuevamente");
          path = Console.ReadLine();
          
      }
      using (FileStream Archivo = new FileStream(path, FileMode.Open, FileAccess.Read)) //FileStream es para analizar un archivos por bytes
      using (BinaryReader binario = new BinaryReader(Archivo)) // facilita la lectura de los bytes
      {
            // Nos posicionamos en los últimos 128 bytes, SeekOrigin.End indica que desde el final empezara, y -128 que se mueve para atras esa cantidad de bytes 
            Archivo.Seek(-128, SeekOrigin.End);

            // Leemos esos 128 bytes y los guarda en un arreglo de bytes, siendo ya esto la etiqueta
            byte[] tagData = binario.ReadBytes(128);

            // Validamos que empiece con "TAG" 
            string tagHeader = System.Text.Encoding.ASCII.GetString(tagData, 0, 3); 
            if (tagHeader != "TAG")
            {
                Console.WriteLine("El archivo no contiene una etiqueta ID3v1 válida.");
                return;
            }

            Id3v1Tag etiqueta = new Id3v1Tag(tagData); // insticio la clase ID3v1Tag con la etiqueta ya obtenida siendo esta el arreglo de bytes

            Console.WriteLine($"Informacion del MP3\n\n Titulo: {etiqueta.Titulo} ---\n Artista: {etiqueta.Artista} ---\n Album: {etiqueta.Album} ---\n Año: {etiqueta.Anio} ---"); 

        }