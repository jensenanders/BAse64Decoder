using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Base64DecoderCL;

namespace testXMLbladring
{
    class Program
    {
        static void Main(string[] args)
        {
            XMlControler dd = new XMlControler();
            dd.DecodeBase64(@"c:\Temp\XBIN_fundus.xml", @"c:\Temp\out\");
            Console.WriteLine("Finish");

        }
    }
}
