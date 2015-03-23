using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DecoderCL.EDI
{
    public class BinRipper
    {
        //get binary object out of edi file
        public List<byte[]> ExstractBinFromEDI(string filepatch)
        {
            byte[] starpat = new byte[] { 58, 49, 52, 58, 49, 58, 65, 39 };
            byte[] slutpat = new byte[] { 85, 78, 80, 43 };
            byte[] fileBytes = File.ReadAllBytes(filepatch);
            List<int> startPos = IndexOf(fileBytes, starpat);
            List<int> slutPos = IndexOf(fileBytes, slutpat);
            List<byte[]> returlist = new List<byte[]>();

            for (int Y = 0; Y < startPos.Count; Y++)
            {
                byte[] produkt = new byte[slutPos[Y] - startPos[Y]+8];
                for (int i = 0; i < slutPos[Y] - startPos[Y]+8; i++)
                {
                    produkt[i] = fileBytes[startPos[Y]+8 + i];
                }
                returlist.Add(produkt);
            }

            return returlist;
        }

        //Find byte pattern in EDI file
        private List<int> IndexOf(byte[] arrayToSearchThrough, byte[] patternToFind)
        {
            List<int> posresultat = new List<int>();
            int foundAt = 0;
            if (patternToFind.Length > arrayToSearchThrough.Length)
                return posresultat;
            for (int i = 0 + foundAt; i < arrayToSearchThrough.Length - patternToFind.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < patternToFind.Length; j++)
                {
                    if (arrayToSearchThrough[i + j] != patternToFind[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    posresultat.Add(i);
                    foundAt = i;
                    
                }
            }
            
            return posresultat;
        }

    }
}
