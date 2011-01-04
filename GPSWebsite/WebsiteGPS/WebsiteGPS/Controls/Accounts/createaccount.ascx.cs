using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Linq;
using WebsiteGPS.BUS;
using System.IO;

namespace WebsiteGPS.Controls.Accounts
{
    public partial class createaccount : System.Web.UI.UserControl
    {
        UsersControl _UsersControl;
        EmailClass _Email;
        DTO.UsersInfo _UsersInfo;
        BUS.LanguageBLL _LanguageBLL = new BUS.LanguageBLL();
        BUS.ErrorsBLL _ErrorBLL = new BUS.ErrorsBLL();
        Default _MainPage; 
        string sErr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            _MainPage = (Default)this.Page;
            LoadLanguage();
        }
        public void LoadLanguage()
        {
            //need move this variable to global variable
            XElement Modules = _LanguageBLL.loadLanguageForModule("createaccount", _MainPage.getStrThemeURL(), "VI-VN");
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
            try
            {
                _UsersControl = new BUS.UsersControl();
                GetDataFrom();                
                _Email = new EmailClass();
                if (_Email.Send_Email("BodyCreate",Path.Combine(Request.PhysicalApplicationPath, "App_Data\\InfoMailServer"), _UsersInfo.Email, _UsersInfo.Fullname, "Username : " + _UsersInfo.Username + " ; " + "Password: " + tbxPassword.Text.Trim() + " ;") == true)
                {
                    _UsersControl.Add(_UsersInfo, ref sErr);                    
                    Reset();lblErr.Text = "successfull";
                }
                else
                {
                    lblErr.Text = "error";
                }
            }
            catch (Exception ex)
            { lblErr.Text = "error" + ex.ToString(); }
        }

        private void GetDataFrom()
        {
            _UsersInfo = new DTO.UsersInfo();
            _UsersInfo.Username = tbxUserName.Text.Trim();
            _UsersInfo.Password = _UsersControl.EncodePassword(tbxPassword.Text.Trim());
            _UsersInfo.Email = tbxEmail.Text.Trim();
            _UsersInfo.Fullname = tbxFullName.Text.Trim();
            _UsersInfo.Status = 1;
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            tbxUserName.Text = "";
            tbxPassword.Text = "";
            tbxEmail.Text = "";
            tbxFullName.Text = "";
            lblErr.Text = "";
        }
    }
}