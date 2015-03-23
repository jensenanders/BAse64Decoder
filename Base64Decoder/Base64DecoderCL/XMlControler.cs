using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DecoderCL
{
   public class XMlControler
    {
       
       public void DecodeBase64(string xmlfilepatch,string outputFolder)
       {
           
           Folderman folman = new Folderman();
           folman.CreateApplicationfolder(outputFolder);
           folman.SaveUserFilePatch(outputFolder);

           Base64Ripper ripper = new Base64Ripper();
           ToFile tofile = new ToFile();

           Base64Element base64object = ripper.FindBase64Code(xmlfilepatch);
           
           for (int i = 0; i < base64object.ObjectExtensionCodeList.Count; i++)
			{
                tofile.Base64ToImage(base64object.Object_Base64EncodedList[i].InnerXml.ToString(), base64object.ObjectExtensionCodeList[i].InnerXml.ToString(), base64object.ObjectCodeList[i].InnerXml.ToString(), outputFolder);
			}
           
       }
    }
}
