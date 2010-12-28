﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteGPS.BUS;
using WebsiteGPS.DTO;
using System.Data;


namespace WebsiteGPS.Controls.Manager
{
    public partial class accountmanager : System.Web.UI.UserControl
    {
        UsersControl _UsersControl = new UsersControl();
        UsersInfo _UsersInfo = new UsersInfo();
        string sErr = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserName"] != "")
            //{
            LoadGrid();

            //}
        }

        private void LoadGrid()
        {

            dtgrid.DataSource = _UsersControl.GetAll(ref sErr);
            dtgrid.DataBind();
        }

        protected void dtgrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dtgrid.CurrentPageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void dtgrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string _user = dtgrid.Items[e.Item.ItemIndex].Cells[0].Text.Trim();

            if (Session["Username"].ToString() != _user)
            {
                _UsersControl.Delete(_user);
                LoadGrid();
            }
            else                
                lblErr.Text = "UserName dag su dung";

        }



    }
}