
      string path;
      Console.WriteLine("Ingrese el path que desea buscar:");
      path = Console.ReadLine();
      while(!System.IO.Directory.Exists(path)){
          Console.WriteLine("Error:Ingrese nuevamente el path");
          path = Console.ReadLine();
          
      }
      
      //get files devuelve los nombres de los archivos y el get directory los nombres de las carpetas
    
      
      Console.WriteLine("Carpetas:\n");
      string[] carpetas = Directory.GetDirectories(path); //devuelve un arreglo y su tamaño 

      Console.WriteLine("Archivos:\n");
      string[] archivos = Directory.GetFiles(path);
     
     

      foreach (var list1 in archivos)
      {
        FileInfo info = new FileInfo(list1);
        long tamaño = info.Lenght;
        Console.WriteLine(Path.GetFileName(list1)+" Tamaño: " + tamaño);
      }
     
      
 