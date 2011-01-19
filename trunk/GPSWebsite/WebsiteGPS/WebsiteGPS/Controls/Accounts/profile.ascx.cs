using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using WebsiteGPS.BUS;
using WebsiteGPS.DTO;

namespace WebsiteGPS.Controls.Accounts
{
    public partial class profile : System.Web.UI.UserControl
    {
        #region localvariable
        UsersInfo _UsersInfo;
        UsersControl _UsersControl = new UsersControl();
        BUS.LanguageBLL _LanguageBLL = new BUS.LanguageBLL();
        Default _MainPage;
        string sErr;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _MainPage = (Default)this.Page;
            LoadLanguage();
            Loadprofile();
        }

        private void Loadprofile()
        {
            if (Session["Username"] != null)
            {
                _UsersInfo = _UsersControl.Get(Session["Username"].ToString(), ref sErr);
                tbxFullName.Text = _UsersInfo.Fullname;
                lblUser.Text = _UsersInfo.Username;
                tbxEmail.Text = _UsersInfo.Email;
            }
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

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            _UsersInfo.Username = Session["Username"].ToString();
            _UsersInfo.Email = tbxEmail.Text.Trim();
            _UsersInfo.Fullname = tbxEmail.Text.Trim();
            _UsersInfo.Status = 1;
            _UsersControl.Update(_UsersInfo);
        }
    }
}