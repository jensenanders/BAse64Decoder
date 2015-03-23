using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Folder management  for users output folder 
namespace Base64DecoderCL
{
  public  class Folderman
    {
      public void CreateApplicationfolder(string folderPatch)
      {
          bool exists = System.IO.Directory.Exists(folderPatch);

          if (!exists)
          {
              System.IO.Directory.CreateDirectory(folderPatch);
              
          }
        }
      public void SaveUserFilePatch(string userinputPatch)
      {
          CreateApplicationfolder(@"C:\Base64decoder\");
          System.IO.File.WriteAllText(@"C:\Base64decoder\userdata.txt", userinputPatch );

      }
      public string GetUserFilePatch()
      {
          return System.IO.File.ReadAllText(@"C:\Base64decoder\userdata.txt");
      }

      public string IniUSerinputPatch()
      {
       if(System.IO.File.Exists(@"C:\Base64decoder\userdata.txt"))
       {
           return GetUserFilePatch();
       }
       SaveUserFilePatch(@"C:\Base64decoder\temp\");
       return @"C:\Base64decoder\temp\";

      }
}
}
