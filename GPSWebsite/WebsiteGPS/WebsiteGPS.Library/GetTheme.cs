using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace WebsiteGPS.Library
{
    public class GetTheme
    {
        public string[] GetThemeConfig(string pConfigURL,string pFNode,string pStringNode,string pName) { 
            ReadXML readXML=new ReadXML();
            string[] strArrayThemeConfig=readXML.SelectNode(pConfigURL,pFNode,pStringNode,pName);
            return strArrayThemeConfig;
        }
        public DataSet LoadTheme(string pPageName,string pTemplateURL)
        {
            ReadXML readXML = new ReadXML();
            DataSet ds = readXML.XMLToDataSet(pTemplateURL);

            //GridView1.DataKeys
            ds.Tables[0].DefaultView.RowFilter = "PageName='" + pPageName + "'";
            string Page_Id = ds.Tables[0].Rows[0]["Module_Id"].ToString();
            //GridView1.DataMember = "Compoment";//get ta from member
            ds.Tables[1].DefaultView.RowFilter = "Module_Id='" + Page_Id + "'";
            //GridView1.DataSource = ds.Tables[1].DefaultView;
            //GridView1.DataBind();
            return(ds);
        }
    }
}
