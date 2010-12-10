using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace WebsiteGPS.Library
{
    public class ReadXML
    {

        /*Load XML
         * 
         * pXMLURL: director of XML
         * pNode:Father node
         * pNameNode: Name of Node containt Name
         * pValueNode: Name of NOde containt Value
         * pName: value of NodeName
         * return: pValue :return value of NodeValue
         * 
         * 
         */
 
        public string SelectNode(string pXMLURL,string pNode,string pNameNode,string pValueNode,string pName) {
            
            XmlDocument xml = new XmlDocument();
            xml.Load(pXMLURL); 

            string strValue=null;
            XmlNodeList xnList = xml.SelectNodes(pNode);//"/Pages/Page");
            //search Node 
            foreach (XmlNode xn in xnList)
            {
                if (pName == xn[pNameNode].InnerText)
                {
                    strValue = xn[pValueNode].InnerText;
                    break;
                }
                
            }
            return strValue;
        }
    }
}
