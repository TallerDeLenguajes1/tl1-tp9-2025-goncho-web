using System;
using System.IO;
using System.Text;
      string path;
      Console.WriteLine("Ingrese el path que desea buscar:");
      path = Console.ReadLine();
      while(!System.IO.Directory.Exists(path)){
          Console.WriteLine("Error:Ingrese nuevamente el path");
          path = Console.ReadLine();
          
      }
      

string [] Carpetas = Directory.GetDirectories(path); // Directory.GetDirectories(path) obtiene todas las carpetas dentro de la rutaArgumento en este caso la variable path y las guarda en un arreglo de string
string[] Archivos = Directory.GetFiles(path); // Directory.GetDirectories(path) obtiene todas los archivos dentro de la rutaArgumento en este caso la variable path y las guarda en un arreglo de string

foreach (var items in Carpetas)
{
    Console.WriteLine($" Nombre de Carpetas: {Path.GetFileName(items)}"); // Path.GetFilesName() Muestra solo el nombre de la carpeta/archivo, no el path completo

}
    
foreach (var item in Archivos)
{
    FileInfo info = new FileInfo(item); 
    double peso = info.Length / 1024.0; // obtengo el tamaño y lo divido para obtenerlo en KB, ya que el tamaño siempre viene en bytes
    Console.WriteLine($" Nombre del Archivo: {Path.GetFileName(item)} /---/ Peso en KB: {peso:F2}" ); // muestro los datos solicitados, el metodo Path.GetFileName() devuelve el nombre del archivo sin toda la ruta 
}



string RutaCsv = Path.Combine(path, "reporte_archivos.csv"); // el metodo Path.Combine() une dos rutas para asi no tener problemas de "\", devuelve un string y sus argumentos claramente son 2 rutas para unirlas 

using (StreamWriter escribir = new StreamWriter(RutaCsv, false, new UTF8Encoding(true))) 
{
    escribir.WriteLine("Nombre del Archivo;Tamaño (KB);Fecha de Última Modificación");

    foreach (var Archivitos in Archivos)
    {
        FileInfo info = new FileInfo(Archivitos);
        double peso = Math.Round(info.Length / 1024.0, 2);
        string fecha = info.LastWriteTime.ToString("dd/MM/yyyy-HH:mm"); 
        escribir.WriteLine($"{info.Name};{peso};{fecha}");
    }

}

