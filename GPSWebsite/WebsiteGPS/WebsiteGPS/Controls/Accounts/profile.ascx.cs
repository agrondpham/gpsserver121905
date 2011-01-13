using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace WebsiteGPS.Controls.Accounts
{
    public partial class profile : System.Web.UI.UserControl
    {
        #region localvariable
        BUS.LanguageBLL _LanguageBLL = new BUS.LanguageBLL();
        Default _MainPage;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _MainPage = (Default)this.Page;
            LoadLanguage();
        }
        public void LoadLanguage()
        {
            XElement Modules = _LanguageBLL.loadLanguageForModule("profile", _MainPage.getStrThemeURL(), _MainPage.getStrLanguage());
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
    }
}