using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteGPS.BUS;
using WebsiteGPS.DTO;
using System.Data;

namespace WebsiteGPS.Controls.Accounts
{
    public partial class Forgotpassword : System.Web.UI.UserControl
    {
        UsersControl _UsersControl;
        AutoPassword _AutoPassword;
        UsersInfo _UsersInfo;
        EmailClass _EmailClass;
        string sErr = "";
        string Password = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSummit_Click(object sender, EventArgs e)
        {
            _UsersControl = new UsersControl();
            _AutoPassword = new AutoPassword();
            _UsersInfo = new UsersInfo();
            DataTable dt = new DataTable();
            dt = _UsersControl.Search("Email", "'" + tbxEmail.Text.Trim() + "'" , "=", ref sErr);
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
                    if (_EmailClass.Send_Email("ggg","dsaiduong19051986@gmail.com", _UsersInfo.Email, _UsersInfo.Fullname, "Username: " + _UsersInfo.Username + " ; " + "Password: " + Password + " ;") == true)
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
        }



    }
}