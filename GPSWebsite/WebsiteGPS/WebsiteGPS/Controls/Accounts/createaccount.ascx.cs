using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteGPS.Controls.Accounts
{
    public partial class createaccount : System.Web.UI.UserControl
    {
        BUS.UsersControl _UsersControl;
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
                _UsersControl.Add(_UsersInfo, ref sErr);
                lblErr.Text = "successfull";
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
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            tbxUserName.Text = "";
            tbxPassword.Text = "";
            tbxEmail.Text = "";
        }
    }
}