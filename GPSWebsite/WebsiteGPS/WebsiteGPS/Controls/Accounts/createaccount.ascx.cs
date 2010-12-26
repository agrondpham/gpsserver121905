using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using WebsiteGPS.BUS;

namespace WebsiteGPS.Controls.Accounts
{
    public partial class createaccount : System.Web.UI.UserControl
    {
        UsersControl _UsersControl;
        EmailClass _Email;
        DTO.UsersInfo _UsersInfo;
        string sErr = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                _UsersControl = new BUS.UsersControl();
                GetDataFrom();                
                _Email = new EmailClass();
                if (_Email.Send_Email(  _UsersInfo.Email,
                                        _UsersInfo.Fullname,
                                        "Username & Password new",
                                        "Username : " + _UsersInfo.Username + " ; " + "Password: " + tbxPassword.Text.Trim() + " ;", 
                                        Path.Combine(Request.PhysicalApplicationPath,"App_Data\\WebConfig.xml"))
                                        == true)
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