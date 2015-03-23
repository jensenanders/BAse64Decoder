using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base64DecoderCL;
using System.Xml;
using Base64DecoderCL.EDI;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = "again";//@"\b\w+es\b";
            //string sentence = "again Who writes these notes again and one more time again?";

            //foreach (Match match in Regex.Matches(sentence, pattern))
            //    Console.WriteLine("Found '{0}' at position {1}",
            //                      match.Value, match.Index);

            //byte[] ba = new byte[20];
            //using (FileStream br = File.OpenRead(@"c:\temp\testfile"))
            //{
            //    br.Read(ba, 0, ba.Length);
            //}
            byte[] fileBytes = File.ReadAllBytes(@"c:\Temp\MCMZip.edi");
            List<char> clist = new List<char>();
            foreach (byte b in fileBytes)
                clist.Add((char)b);
            char[] ca = clist.ToArray();
            string test = new string(ca);

            //Regex rx = new Regex(@"[\x00-\xFF]");
            //foreach (Match mx in rx.Matches(test))
            //{
            //    Console.WriteLine("{0}", (int)(mx.Value[0]));
            //}
            //string pattern = "5849525849586539";
            //foreach (Match match in Regex.Matches(test, pattern))
            //    Console.WriteLine("Found '{0}' at position {1}",
            //                      match.Value, match.Index);





            //R();
            #region
            //byte[] fileBytesedi = File.ReadAllBytes(@"c:\Temp\MCMZip.edi");
            ////string bitstring =  fileBytesedi.ToString();
            ////  //bitstring.IndexOf()


            //// 1.
            //using (BinaryReader b = new BinaryReader(File.Open(@"c:\Temp\MCMZip.edi", FileMode.Open)))
            //{
            //    // 2.
            //    // Position and length variables.
            //    int pos = 0;
            //    // 2A.
            //    // Use BaseStream.
            //    int length = (int)b.BaseStream.Length;
            //    while (pos < 100)
            //    {
            //        // 3.
            //        // Read integer.
            //        byte v = b.ReadByte();
            //        Console.WriteLine(v);

            //        // 4.
            //        // Advance our position variable.
            //        pos += sizeof(int);
            //    }
            //}



            //MemoryStream ms = new MemoryStream(fileBytes, 0,
            // fileBytes.Length);
            //string path = @"c:\Temp\out\hof\binaryhofte.bin";

            //// Create the file. 
            //using (FileStream fs = File.Create(path))
            //{
            //    //Byte[] info = fileBytes; 
            //    Byte[] infoedi = fileBytesedi;
            //    // Add some information to the file.
            //    //fs.Write(info, 0, info.Length);
            //    fs.Write(infoedi, 0, infoedi.Length);

            //}
            //using (FileStream fs = File.Create(@"c:\Temp\out\hof\binhoftefraedi.bin"))
            //{
            //    Byte[] info = fileBytesedi;
            //    Byte[] infoedi = fileBytesedi;
            //    // Add some information to the file.
            //    fs.Write(info, 0, info.Length);
            //    fs.Write(infoedi, 0, infoedi.Length);

            //}

            #endregion
            Console.Write("Færdig");
            Console.Read();

        }
        static void R()
        {
            //start mønster: 00110001001101000011101000110001001110100100000100100111
            //slutmønster:   01010101010011100101000000101011

            byte[] starpat = new byte[] { 58, 49,52,58,49,58,65,39 };
            byte[] slutpat = new byte[] { 85, 78, 80, 43};
            byte[] fileBytes = File.ReadAllBytes(@"c:\Temp\MCMZip.edi");
            int startPos = IndexOf(fileBytes, starpat) +8;
            int slutPos = IndexOf(fileBytes, slutpat);
            Console.Write(startPos+ " slut: " + slutPos);

            byte[] produkt = new byte[slutPos-startPos];
            for (int i = 0; i < slutPos-startPos; i++)
            {
                produkt[i] = fileBytes[startPos + i];
            }
            Createfile(produkt);
        }




        static void Createfile(byte[] value)
        {
            //// indsæt data byte[] data = 
            using (FileStream fs = File.Create(@"c:\Temp\out\binhoftefraedizip.zip"))
            {

                // Add some information to the file.
                fs.Write(value, 0, value.Length);


            }
        }
        public static int IndexOf(byte[] arrayToSearchThrough, byte[] patternToFind)
        {
            if (patternToFind.Length > arrayToSearchThrough.Length)
                return -1;
            for (int i = 0; i < arrayToSearchThrough.Length - patternToFind.Length; i++)
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
                    return i;
                }
            }
            return -1;
        }
        }

    
        }
    
