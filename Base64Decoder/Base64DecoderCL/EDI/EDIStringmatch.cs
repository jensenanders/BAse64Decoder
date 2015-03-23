using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Base64DecoderCL.EDI
{
   public static class EDIStringmatch
    {
       //Find position of string pattern
      public static List<int> GetPositionOfRes(string sentence,string pattern)
      {
          List<int> returListe = new List<int>();

            foreach (Match match in Regex.Matches(sentence, pattern))
                returListe.Add(match.Index);

            return returListe;
      }
      
    }
}
