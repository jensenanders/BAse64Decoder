using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Base64DecoderCL
{
    public class Base64Ripper
    {
        public string FileExtension { get; private set; }
        public string FileName { get; private set; }
        public string Base64Encoding { get; private set; }

        public Base64Element FindBase64Code(string filepatch)
        {

            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(filepatch); //(@"c:\Temp\XBIN_fundus.xml");

            //create base64 object for
            XmlNodeList Object_Base64EncodedList = doc.GetElementsByTagName("Object_Base64Encoded");
            XmlNodeList ObjectCodeList = doc.GetElementsByTagName("ObjectCode");
            XmlNodeList ObjectExtensionCodeList = doc.GetElementsByTagName("ObjectExtensionCode");


            //create base64 object for fnx filer format
            XmlNodeList Object_Base64EncodedListFNX = doc.GetElementsByTagName("FilIndholdData");
            XmlNodeList ObjectCodeListFNX = doc.GetElementsByTagName("ObjectReference");
            XmlNodeList ObjectExtensionCodeListFNX = doc.GetElementsByTagName("FilTypeKode");
            


            //create base64 object for fnx filer ploformat
            XmlNodeList Object_Base64EncodedListPLO = doc.GetElementsByTagName("plo:FilIndholdData");
            XmlNodeList ObjectCodeListPLO = doc.GetElementsByTagName("plo:ObjectReference");
            XmlNodeList ObjectExtensionCodeListPLO = doc.GetElementsByTagName("plo:FilTypeKode");

            //create base64 object for xml Fødselsanmeldelse
            XmlNodeList Object_Base64Encodedfoedselsan = doc.GetElementsByTagName("Data");
            XmlNodeList ObjectCodeListfoedselsan = doc.GetElementsByTagName("Identifier");
            XmlNodeList ObjectExtensionCodeListfoedselsan = doc.GetElementsByTagName("Format");


            Base64Element Base64ele = new Base64Element();
            //Retur fil with 3 lists
            if(Object_Base64EncodedList.Count >0)
                Base64ele = new Base64Element(Object_Base64EncodedList, ObjectCodeList, ObjectExtensionCodeList);

            if (Object_Base64EncodedListFNX.Count > 0)
                Base64ele = new Base64Element(Object_Base64EncodedListFNX, ObjectCodeListFNX, ObjectExtensionCodeListFNX);

            if (Object_Base64EncodedListPLO.Count > 0)
                Base64ele = new Base64Element(Object_Base64EncodedListPLO, ObjectCodeListPLO, ObjectExtensionCodeListPLO);

            if (Object_Base64Encodedfoedselsan.Count > 0)
                Base64ele = new Base64Element(Object_Base64Encodedfoedselsan, ObjectCodeListfoedselsan, ObjectExtensionCodeListfoedselsan);

            return Base64ele;
        }
    }
}
