using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Base64DecoderCL
{
   public class Base64Element
    {
     public  XmlNodeList Object_Base64EncodedList;
     public XmlNodeList ObjectCodeList;
     public XmlNodeList ObjectExtensionCodeList;
    
     public Base64Element(XmlNodeList base64encodinglist, XmlNodeList codelist, XmlNodeList extensionCodeList )
     {
         this.Object_Base64EncodedList = base64encodinglist;
         this.ObjectCodeList = codelist;
         this.ObjectExtensionCodeList = extensionCodeList;
         
     }
     public Base64Element()
     {
        
     }
}     
}
