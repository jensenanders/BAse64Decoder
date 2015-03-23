using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DecoderCL.EDI
{
public class EDIControler
    {

    //exstract file from EDIfact files
    public void ExtractEDIFIle(string EDIfilepatch,string outputFolder)
    {
        BinRipper BinRip = new BinRipper();
        ToFile Tofil = new ToFile();
        EDIfileInfo EDIinf = new EDIfileInfo();

        List<string> extensions = EDIinf.GetextensionOffile(EDIfilepatch);
       List<string> fileName =  EDIinf.GetFileName(EDIfilepatch);
         List<byte[]> binarydata=  BinRip.ExstractBinFromEDI(EDIfilepatch);
        for(int i = 0; i <extensions.Count; i++)
        {
            Tofil.Base64ToImageEDI(binarydata[i],extensions[i],fileName[i],outputFolder);
        }
      
       
    }
    }
}
