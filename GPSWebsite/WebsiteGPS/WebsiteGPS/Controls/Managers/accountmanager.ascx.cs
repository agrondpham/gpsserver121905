using System;
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
            //lview_Accounts.DataSource = _UsersControl.GetAll(ref sErr);
            //lview_Accounts.DataBind();
        }

        protected void dtgrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dtgrid.CurrentPageIndex = e.NewPageIndex;
            LoadGrid();
        }
        //[WebMethod]
        protected void dtgrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string _user = dtgrid.Items[e.Item.ItemIndex].Cells[0].Text.Trim();

            if (Session["Username"] != _user)
            {
                _UsersControl.Delete(_user);
                LoadGrid();
            }
            else
                lblErr.Text = "UserName dag su dung";

        }

        //Listview

        //protected void lview_Accounts_DeleteCommand(object source, ListViewDeleteEventArgs e)
        //{
        //    string _user = lis.Items[e.Item.ItemIndex].Cells[0].Text.Trim();

        //    if (Session["Username"] != _user)
        //    {
        //        _UsersControl.Delete(_user);
        //        LoadGrid();
        //    }
        //    else
        //        lblErr.Text = "UserName dag su dung";

        //}
        //protected void DataPager1_PreRender(object sender, EventArgs e)
        //{

        //    //lview_Accounts.DataSource = _UsersControl.GetAll(ref sErr);

        //    //lview_Accounts.DataBind();

        //}
        //Code to choice Page
        //int CurrentPage = 0;
        //protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    DropDownList ddl = sender as DropDownList;

        //    CurrentPage = int.Parse(ddl.SelectedValue);

        //    int PageSize = DataPager1.PageSize;

        //    DataPager1.SetPageProperties(CurrentPage * PageSize, PageSize, true);

        //}

    }
}