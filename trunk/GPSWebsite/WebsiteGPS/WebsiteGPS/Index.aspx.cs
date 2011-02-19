using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;

namespace WebsiteGPS
{
    public partial class Index : System.Web.UI.Page
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
        public string getStrErrorFileURL()
        {
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
        private string _strLanguage;
        public string getStrLanguage()
        {
            return _strLanguage;
        }
        public void setStrLanguage(string pStrLanguage)
        {
            _strLanguage = pStrLanguage;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            setStrErrFileURL(Path.Combine(Request.PhysicalApplicationPath, "App_Data\\ErrorCode.xml"));
            setStrControlURL(Path.Combine(Request.PhysicalApplicationPath, "App_Data\\ControlURL.xml"));
            setStrWebCofigURL(Path.Combine(Request.PhysicalApplicationPath, "App_Data\\WebConfig.xml"));
            setStrThemeURL(Path.Combine(Request.PhysicalApplicationPath, "Themes\\_default\\_default.template"));
            setStrLanguage("vi-vn");
            LoadPages();
        }
        public void LoadPages()
        {
            //Issue
            //strParameterURL can be null if load with nomal direct
            //if XML do not contain data ctrMain canbe get error

            if (RouteData.Route == null)
            {
                Response.RedirectToRoute("Login_Page", new { pages = "index.html" });
            }
            else
            {
                string strParameterURL = RouteData.Values["pages"].ToString().ToLower();
                ConnectPages(strParameterURL);
            }
        }

        private void ConnectPages(string strParameterURL)
        {
            Control ctrMain = null;
            string[] strArrayControlInfo = _ControlBLL.loadControls(strParameterURL, _strControlURL);
            ctrMain = LoadControl(strArrayControlInfo[0].ToString());//load URL Control
            Page.Title = strArrayControlInfo[1].ToString();//Load Title of Control
            BodyHolder.Controls.Add(ctrMain);
            ThemeConfig();
        }

        private void ThemeConfig()
        {
            _ThemeConfig = _ConfigBLL.loadConfigs("_default", _strWebConfigURL);
            //setThemeConfig(getTheme.GetThemeConfig(, "Website.config / Config","Theme","name"));     
        }
    }
}