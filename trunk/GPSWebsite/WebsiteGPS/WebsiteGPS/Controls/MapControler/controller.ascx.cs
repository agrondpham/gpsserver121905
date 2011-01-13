using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteGPS.BUS;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace WebsiteGPS.Controls.Controler
{
    public partial class controller : System.Web.UI.UserControl
    {
        #region localvariable
        BUS.LanguageBLL _LanguageBLL = new BUS.LanguageBLL();
        Default _MainPage;
        DevicesControl _DevicesControl = new DevicesControl();
        GPS_DataControl _GPS_DataControl = new GPS_DataControl();
        #endregion
        string sErr = "";
        string dataGPS = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Username"] = "daiduong";
            if (Session["Username"] != null)
            {
                LoadCombo();
                LoadCombo2();
            }
            _MainPage = (Default)this.Page;
            LoadLanguage();
        }
        public void LoadLanguage()
        {
            XElement Modules = _LanguageBLL.loadLanguageForModule("controller", _MainPage.getStrThemeURL(), _MainPage.getStrLanguage());
            var components = from xmlModule in Modules.Elements("Component") select xmlModule;
            foreach (var cmpn in components)
            {
                switch (cmpn.Element("type").Value)
                {
                    case "label":
                        Label label = (Label)FindControl(cmpn.Element("idComponent").Value);
                        label.Text = cmpn.Element("Content").Value;
                        break;
                    case "button":
                        Button button = (Button)FindControl(cmpn.Element("idComponent").Value);
                        button.Text = cmpn.Element("Content").Value;
                        break;
                    case "hyberlink":
                        HyperLink hyperlink = (HyperLink)FindControl(cmpn.Element("idComponent").Value);
                        hyperlink.Text = cmpn.Element("Content").Value;
                        break;
                }
            }
        }
        private void LoadCombo2()
        {
            drdDevices2.DataSource = _DevicesControl.Search("Username", "'" + Session["Username"].ToString() + "'", "=", ref sErr);
            drdDevices2.DataValueField = "IMED_Device";
            drdDevices2.DataTextField = "IMED_Device";
            drdDevices2.DataBind();
        }

        private void LoadCombo()
        {

            drdDevices.DataSource = _DevicesControl.Search("Username", "'" + Session["Username"].ToString()+ "'", "=", ref sErr);
            drdDevices.DataValueField = "IMED_Device";
            drdDevices.DataTextField = "IMED_Device";
            drdDevices.DataBind();
            
        }

        private void LoadData()
        {
            string IDDevices = drdDevices.SelectedValue;
            DataTable dt = new DataTable();
            dt = _GPS_DataControl.Getdata(IDDevices, tbxStartTime.Text, tbxStopTime.Text, ref sErr);
            ConvertDatatableToJson ConvertDatatableToJson = new ConvertDatatableToJson();
            dataGPS=ConvertDatatableToJson.ConvertDSToJSON(dt);
        }

        protected void btnShowMarkers_Click(object sender, EventArgs e)
        {
            LoadData();
            //string scriptData = "var data={'marker':[{'longitude':'106.684866666667','latitude':'10.8284666666667'},{'longitude':'106.6843','latitude':'10.82865'},{'longitude':'106.683733333333','latitude':'10.8288333333333'},{'longitude':'106.681716666667','latitude':'10.8295166666667'},{'longitude':'106.677833333333','latitude':'10.8307833333333'},{'longitude':'106.675','latitude':'10.8318'},{'longitude':'106.670383333333','latitude':'10.8334333333333'},{'longitude':'106.6664','latitude':'10.83485'},{'longitude':'106.665766666667','latitude':'10.8350833333333'},{'longitude':'106.663','latitude':'10.8352'},{'longitude':'106.6595','latitude':'10.8361166666667'},{'longitude':'106.656116666667','latitude':'10.83705'},{'longitude':'106.6522','latitude':'10.838'},{'longitude':'106.647766666667','latitude':'10.83915'},{'longitude':'106.64445','latitude':'10.8413833333333'},{'longitude':'106.640383333333','latitude':'10.84415'},{'longitude':'106.638533333333','latitude':'10.8417666666667'},{'longitude':'106.636483333333','latitude':'10.83775'},{'longitude':'106.634966666667','latitude':'10.8345'},{'longitude':'106.634133333333','latitude':'10.8323'},{'longitude':'106.639166666667','latitude':'10.8292833333333'},]};setMap(map)";
            string scriptData = "var data=" + dataGPS + "setMap(map)";
            if (ScriptManager1.IsInAsyncPostBack)//check is postback
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Setmap", scriptData, true);
            }
        }
    }
}