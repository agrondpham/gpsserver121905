using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Data;
using System.IO;
using System.Collections;
//using System.Data.SqlClient;

namespace WebsiteGPS.Library
{
    public class ReadXML
    {
        ///<summary>  
        ///<para>This function search element in xml file 
        ///with couple data String&Value.</para>    
        /// </summary>  
        /// <param name="pXMLURL">The xml's url on Server.</param>  
        /// <param name="pNode">Father Node.</param>  
        /// <param name="pStringNode">name of String Node.</param>  
        /// <param name="pValueNode">name of Value Node.</param>  
        /// <param name="pName">value of String Node to search.</param>  
        /// <returns>value of Value Node.</returns>  
        public string SelectNode(string pXMLURL,string pNode,string pStringNode,string pValueNode,string pName) {
            XmlDocument xml = new XmlDocument();
            xml.Load(pXMLURL);

            string strValue=null; 
            XmlNodeList xnList = xml.SelectNodes(pNode);//"/Pages/Page");
            //search Node 
            foreach (XmlNode xn in xnList)
            {
                if (pName == xn[pStringNode].InnerText)
                {
                    strValue = xn[pValueNode].InnerText;
                    break;
                }

            }
            return strValue;

        }
        public ArrayList SelectNode(string pXMLURL, string pNode, string pName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(pXMLURL);

            ArrayList strValue = new ArrayList();
            XmlNodeList xnList = xml.SelectNodes(pNode);//"/Pages/Page");
            //search Node 
            foreach (XmlNode xn in xnList)
            {
                if (pName == xn.FirstChild.InnerText)
                {
                    
                    for (int i = 0; i < xn.ChildNodes.Count; i++)//More element need to increase size of string array
                    {
                        strValue.Add(xn.ChildNodes[i].InnerText);//add data to ArrayList
                        
                    }
                    break;
                }

            }
            return strValue;

        }
        public string[] SelectNode(string pXMLURL, string pNode, string pStringNode, string pName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(pXMLURL);

            string[] strValue = new string[2];
            XmlNodeList xnList = xml.SelectNodes(pNode);//"/Pages/Page");
            //search Node 
            foreach (XmlNode xn in xnList)
            {
                //if (pName == xn[pStringNode].Name)
                //{
                    strValue[0] = xn[pStringNode].Attributes[pName].Value;
                    strValue[1] = xn[pStringNode].InnerText;
                    break;
                //}

            }
            return strValue;

        }
        /// <summary>
        /// Function bind xml to dataset
        /// </summary>
        /// <param name="pXMLURL">URL of XML file on Server</param>
        /// <returns>dataset containt data of XML file</returns>
        public DataSet XMLToDataSet(string pXMLURL) { 
            DataSet ds = new DataSet();
            ds.ReadXml(pXMLURL);
            return ds;
        }
        public ArrayList ReadXMLTemplate(string pXMLURL, string pNode, string pModuleName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(pXMLURL);

            ArrayList strValue = new ArrayList();
            XmlNodeList xnList = xml.SelectNodes(pNode);//"/Pages/Page");
            //search Node 
            foreach (XmlNode xn in xnList)
            {
                if (pModuleName == xn.FirstChild.InnerText)
                {

                    for (int i = 0; i < xn.ChildNodes.Count; i++)//More element need to increase size of string array
                    {
                        for(int x=0;x<xn.ChildNodes[i].ChildNodes.Count;x++){
                            strValue.Add(xn.ChildNodes[i].ChildNodes[x].InnerText);//add data to ArrayList
                        }
                    }
                    break;
                }

            }
            return strValue;
        
        }
    }
}
