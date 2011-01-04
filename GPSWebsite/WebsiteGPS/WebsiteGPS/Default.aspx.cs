using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using WebsiteGPS.Library;
using System.IO;
using System.Collections;
using System.Data;

using System.Xml.Linq;

namespace WebsiteGPS
{
    public partial class Default : System.Web.UI.Page
    {
        #region localVariable
        BUS.ControlBLL _ControlBLL = new BUS.ControlBLL();
        BUS.ConfigBLL _ConfigBLL = new BUS.ConfigBLL();
        private ArrayList _ThemeConfig;
        public ArrayList getThemeConfig()
        {
            return _ThemeConfig;
        }
        public void setThemeConfig(ArrayList pThemeConfig)
        {
            _ThemeConfig = pThemeConfig;
        }
        private string _strErrorFileURL;
        public string getStrErrorFileURL() {
            return _strErrorFileURL;
        }
        public void setStrErrFileURL(string pStrErrFileURL)
        {
            _strErrorFileURL = pStrErrFileURL;
        }
        private string _strControlURL;
        public string getStrControlURL()
        {
            return _strControlURL;
        }
        public void setStrControlURL(string pStrControlURL)
        {
            _strControlURL = pStrControlURL;
        }
        private string _strWebConfigURL;
        public string getStrWebConfigURL()
        {
            return _strWebConfigURL;
        }
        public void setStrWebCofigURL(string pStrWebConfigURL)
        {
            _strWebConfigURL = pStrWebConfigURL;
        }
        private string _strThemeURL;
        public string getStrThemeURL()
        {
            return _strThemeURL;
        }
        public void setStrThemeURL(string pStrThemeURL)
        {
            _strThemeURL = pStrThemeURL;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            setStrErrFileURL(Path.Combine(Request.PhysicalApplicationPath, "App_Data\\ErrorCode.xml"));
            setStrControlURL(Path.Combine(Request.PhysicalApplicationPath, "App_Data\\ControlURL.xml"));
            setStrWebCofigURL(Path.Combine(Request.PhysicalApplicationPath,"App_Data\\WebConfig.xml"));
            setStrThemeURL(Path.Combine(Request.PhysicalApplicationPath, "Themes\\_default\\_default.template"));
            LoadPages();
        }
        public void LoadPages() {
            //Issue
            //strParameterURL can be null if load with nomal direct
            //if XML do not contain data ctrMain canbe get error

            if (RouteData.Route == null)
            {
                Response.RedirectToRoute("Login_Page", new { pages = "index.html" });
            }
            else
            {
                Control ctrMain=null;
                
                string strParameterURL = RouteData.Values["pages"].ToString().ToLower();
                string[] strArrayControlInfo = _ControlBLL.loadControls(strParameterURL,_strControlURL);
                ctrMain = LoadControl(strArrayControlInfo[0].ToString());//load URL Control
                Page.Title = strArrayControlInfo[1].ToString();//Load Title of Control
                BodyHolder.Controls.Add(ctrMain);
                ThemeConfig();
                //LoadLanguage();
            }
        }

        
        private void ThemeConfig() {
            _ThemeConfig= _ConfigBLL.loadConfigs("_default", _strWebConfigURL);
            //setThemeConfig(getTheme.GetThemeConfig(, "Website.config / Config","Theme","name"));     
        }
        #region oldCode
        //public void LoadPages()
        //{
        //    //Issue
        //    //strParameterURL can be null if load with nomal direct
        //    //if XML do not contain data ctrMain canbe get error
        //    Library.Validate validate =new Validate();
        //    if (RouteData.Route == null)
        //    {
        //        Response.RedirectToRoute("Login_Page", new { pages = "index.html" });
        //    }
        //    else
        //    {
        //        //string strParameterURL = Request.QueryString["uc"];   //Get varible in URL old URL(not routing)
        //        string strParameterURL = RouteData.Values["pages"].ToString().ToLower();
        //        ReadXML readXML = new ReadXML();
        //        ArrayList strValue = readXML.SelectNode(
        //                Path.Combine(
        //                    Request.PhysicalApplicationPath,
        //                    "App_Data\\ControlURL.xml"),
        //                    "Pages/Page", strParameterURL);
        //        Control ctrMain = LoadControl(strValue[1].ToString());//load URL Control(Convert from Array to string)
        //        Page.Title = strValue[2].ToString();//Load Title of Control
        //        /*
        //         * <note> old code</note>
        //         * 
        //         * 
        //         * 
        //         * Control ctrMain = LoadControl(
        //            readXML.SelectNode(
        //                Path.Combine(
        //                    Request.PhysicalApplicationPath,
        //                    "App_Data\\ControlURL.xml"),
        //                    "Pages/Page",
        //                    "NameUC",
        //                    "URL", strParameterURL)
        //                    );*/
        //        BodyHolder.Controls.Add(ctrMain);
        //        ThemeConfig();
        //        //LoadLanguage();
        //    }
            
        //}
        //private ArrayList Theme;    
        //public void LoadLanguage()
        //{
        //    //Code ben no ben do xu ly.
        //    //Thay doi ngon ngu ben UC thi code UC xu ly
        //    //Thay doi ngon ngu ben Default page thi code default page xu ly
        //    GetTheme getTheme = new GetTheme();
        //    DataSet ds=getTheme.LoadTheme("Default",Path.Combine(
        //                    Request.PhysicalApplicationPath,
        //                    "Themes\\_default\\_default.template"));           
        //    foreach(DataRow drow in ds.Tables[1].Rows){
        //        Label control = (Label)Page.FindControl(drow["idComponent"].ToString());
        //        control.Text = drow["Content"].ToString();
        //    }
        //}
        #endregion
    }
}