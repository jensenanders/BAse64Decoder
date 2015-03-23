using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Base64DecoderCL
{
   public class ToFile
    {
      //Write base64 object to users output folder
       public void Base64ToImage(string base64String, string fileExstension, string filename, string outputFolder)
       {
           // Convert Base64 String to byte[]
           byte[] imageBytes = Convert.FromBase64String(base64String);
           MemoryStream ms = new MemoryStream(imageBytes, 0,
             imageBytes.Length);
           string path = outputFolder + filename + "." + fileExstension.ToString();

           path = CHeckFIleextension(outputFolder + filename, "." + fileExstension.ToString());
           
           // Create the file. 
           using (FileStream fs = File.Create(path))
           {
               Byte[] info = imageBytes; 
               // Add  information to the file.
               fs.Write(info, 0, info.Length);
               
           }
          
       }
       private static int n = 0;
       private string CHeckFIleextension(string pathTodot, string extension)
       {
           if (File.Exists(pathTodot + extension))
           {

               string last = pathTodot.Last().ToString();
               bool IsNo = int.TryParse(last, out n);
               if (!IsNo)
               {
                   string retst = pathTodot + "1";
                   return CHeckFIleextension(retst, extension);
               }
               else
               {
                   n++;
                   string editstring = pathTodot.Remove(pathTodot.Length - 1, 1);
                   editstring = editstring + n.ToString();
                   return CHeckFIleextension(editstring, extension);
               }
           }
           else
               n = 0;
               return pathTodot + extension;
       }
       //write file from Bin object EDI
       public void Base64ToImageEDI(byte[] value, string fileExstension, string filename, string outputFolder)
       {
           string path = outputFolder + filename + "." + fileExstension.ToString();
         using (FileStream fs = File.Create(path))
            {

                // Add  information to the file.
                fs.Write(value, 0, value.Length);


            }

           }

       }
    }

