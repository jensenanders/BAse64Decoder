using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Base64DecoderCL.EDI
{
   public class EDIfileInfo
    {
       public List<string> GetextensionOffile(string patch)
       {
           List<string> returListe = new List<string>();

          string FileasString = System.IO.File.ReadAllText(patch);

        List<int> PosListe = EDIStringmatch.GetPositionOfRes(FileasString, @":91+");

          for (int i = 0; i < PosListe.Count; i++)
          {
              string extension = FileasString.Substring(PosListe[i] - 3, 3);
              returListe.Add(extension);
          }
          
          return returListe;
       }
       public List<string> GetFileName(string patch)
       {
           List<string> returListe = new List<string>();

           string FileasString = System.IO.File.ReadAllText(patch);

          List<int> PosListe = EDIStringmatch.GetPositionOfRes(FileasString, @"AID:");

           for (int i = 0; i < PosListe.Count; i++)
           {
               string extension = FileasString.Substring(PosListe[i]+5,3);
               returListe.Add(extension);
           }

           return returListe;
       }
    }
}
