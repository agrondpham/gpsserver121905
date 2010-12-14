using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebsiteGPS.Library;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace WebsiteGPS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPages();

        }
        public void LoadPages()
        {
            //Issue
            //strParameterURL can be null if load with nomal direct
            //if XML do not contain data ctrMain canbe get error
            Library.Validate validate =new Validate();
            if (RouteData.Route == null)
            {
                Response.RedirectToRoute("Login_Page", new { pages = "index.html" });
            }
            else
            {
                //string strParameterURL = Request.QueryString["uc"];   //Get varible in URL old URL(not routing)
                string strParameterURL = RouteData.Values["pages"].ToString().ToLower();
                ReadXML readXML = new ReadXML();
                ArrayList strValue = readXML.SelectNode(
                        Path.Combine(
                            Request.PhysicalApplicationPath,
                            "App_Data\\ControlURL.xml"),
                            "Pages/Page", strParameterURL);
                Control ctrMain = LoadControl(strValue[1].ToString());//load URL Control(Convert from Array to string)
                Page.Title = strValue[2].ToString();//Load Title of Control
                /*
                 * <note> old code</note>
                 * 
                 * 
                 * 
                 * Control ctrMain = LoadControl(
                    readXML.SelectNode(
                        Path.Combine(
                            Request.PhysicalApplicationPath,
                            "App_Data\\ControlURL.xml"),
                            "Pages/Page",
                            "NameUC",
                            "URL", strParameterURL)
                            );*/
                BodyHolder.Controls.Add(ctrMain);
                //LoadLanguage();
                ThemeConfig();
                Theme();
            }
            
        }
        //private ArrayList Theme;
        private string[] _ThemeConfig;
        public string[] getThemeConfig()
        {
            return _ThemeConfig;
        }
        public void setThemeConfig(string[] pThemeConfig)
        {
            _ThemeConfig = pThemeConfig;
        }
        private void ThemeConfig() {
            GetTheme getTheme = new GetTheme();
            setThemeConfig(getTheme.GetThemeConfig(Path.Combine(
                            Request.PhysicalApplicationPath,
                            "App_Data\\WebConfig.xml"), "Website.config / Config","Theme","name"));     
        }
        //public void LoadLanguage()
        //{
        //    //Code ben no ben do xu ly.
        //    //Thay doi ngon ngu ben UC thi code UC xu ly
        //    //Thay doi ngon ngu ben Default page thi code default page xu ly
        //    ReadXML readXML = new ReadXML();
        //    ArrayList strContent = readXML.SelectNode(
        //                Path.Combine(
        //                    Request.PhysicalApplicationPath,
        //                    "Themes\\_default\\_default.template"),
        //                    "website.config/Compoment", "lblWebTitle");
        //    Label control= (Label)Page.FindControl(strContent[0].ToString());
        //    control.Text = strContent[1].ToString();
        //}
        private void Theme() {
            ReadXML readXML = new ReadXML();
            DataSet ds = readXML.XMLToDataSet(Path.Combine(
                            Request.PhysicalApplicationPath,
                            "Themes\\_default\\_default.template"));
            GridView1.DataMember = "Compoment";//get ta from member
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}