﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Linq;
using WebsiteGPS.BUS;
using WebsiteGPS.DTO;
using System.Data;
using System.IO;

namespace WebsiteGPS.Controls.Accounts
{
    public partial class Forgotpassword : System.Web.UI.UserControl
    {
        #region localVariable
        UsersControl _UsersControl;
        AutoPassword _AutoPassword;
        UsersInfo _UsersInfo;
        EmailClass _EmailClass;
        BUS.LanguageBLL _LanguageBLL = new BUS.LanguageBLL();
        Default _MainPage; 
        #endregion
        string sErr = "";
        string Password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _MainPage = (Default)this.Page;
            LoadLanguage();
        }
        public void LoadLanguage()
        {
            XElement Modules = _LanguageBLL.loadLanguageForModule("forgotpassword", _MainPage.getStrThemeURL(), "VI-VN");
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
        protected void btnSummit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                _UsersControl = new UsersControl();
                _AutoPassword = new AutoPassword();
                _UsersInfo = new UsersInfo();
                DataTable dt = new DataTable();
                dt = _UsersControl.Search("Email", "'" + tbxEmail.Text.Trim() + "'", "=", ref sErr);
                if (dt.Rows.Count == 1)
                {
                    try
                    {
                        Password = _AutoPassword.Generate(8, 10);
                        _UsersInfo.Password = _UsersControl.EncodePassword(Password.Trim());
                        _UsersInfo.Username = dt.Rows[0]["Username"].ToString();
                        _UsersInfo.Email = dt.Rows[0]["Email"].ToString();
                        _UsersInfo.Fullname = dt.Rows[0]["Fullname"].ToString();
                        _EmailClass = new EmailClass();
                        if (_EmailClass.Send_Email("BodyForgot", Path.Combine(Request.PhysicalApplicationPath, "App_Data\\InfoMailServer"), _UsersInfo.Email, _UsersInfo.Fullname, "Username : " + _UsersInfo.Username + " ; " + "Password: " + Password.Trim() + " ;") == true)
                        {
                            _UsersControl.Update(_UsersInfo);
                        }
                        else
                        {
                            lblErr.Text = "error";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblErr.Text = "error";
                    }

                }
                else
                {
                    lblErr.Text = "Email not exist. Please contact your administrator user";
                }
            }else{
                lblErr.Text = "wrong captcha";
            }
        }



    }
}