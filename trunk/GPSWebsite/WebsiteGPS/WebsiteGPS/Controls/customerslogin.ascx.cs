using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteGPS.Library;
using System.Data;
using System.IO;
using System.Collections;
using System.Xml;
using WebsiteGPS.BUS;
using WebsiteGPS.DTO;

namespace WebsiteGPS.Controls
{
    public partial class CustomersLogin : System.Web.UI.UserControl
    {
        UsersControl _UsersControl;
        UsersInfo _UsersInfo;
        string sErr;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList aaaa;
            //Default defaultPage = new Default();
            Default mainPage =(Default) this.Page;      //get Page Content UC Control
            aaaa = mainPage.getThemeConfig();           //get variable from main Page
            LoadLanguage();
        }
        public void LoadLanguage()
        {
            //Code ben no ben do xu ly.
            //Thay doi ngon ngu ben UC thi code UC xu ly
            //Thay doi ngon ngu ben Default page thi code default page xu ly
            //GetTheme getTheme = new GetTheme();
            //DataSet ds = getTheme.LoadTheme("customerslogin", Path.Combine(
            //                 Request.PhysicalApplicationPath,
            //                 "Themes\\_default\\_default.template"));


            string pModuleName = "customerslogin";
            string pTemplateURL = Path.Combine(Request.PhysicalApplicationPath, "Themes\\_default\\_default.template");

            //ReadXML readXML = new ReadXML();
            //DataSet ds = readXML.XMLToDataSet(pTemplateURL);
            //ds.Tables[0].DefaultView.RowFilter = "PageName='" + pPageName + "'";
            //DataView dv = ds.Tables[0].DefaultView;
            ////string Page_Id = ds.Tables[0].Rows[0]["Page_Id"].ToString();
            //string Page_Id = dv.Table.Rows[0]["Page_Id"].ToString();
            //ds.Tables[1].DefaultView.RowFilter = "Page_Id='" + Page_Id + "'";
            ////GridView1.DataSource = ds.Tables[1];
            //GridView1.DataSource = dv.Table;
            //GridView1.DataBind();
            //foreach (DataRow drow in ds.Tables[1].Rows)
            //{
            //    switch (drow["type"].ToString())
            //    {
            //        case "label":
            //            string abc = drow["idCompoment"].ToString();
            //            Label label = (Label)Page.FindControl(drow["idCompoment"].ToString());
            //            label.Text = drow["Content"].ToString();
            //            break;
            //        case "button":
            //            Button button = (Button)Page.FindControl(drow["idCompoment"].ToString());
            //            button.Text = drow["Content"].ToString();
            //            break;
            //        case "hyberlink":
            //            HyperLink hyperlink = (HyperLink)Page.FindControl(drow["idCompoment"].ToString());
            //            hyperlink.Text = drow["Content"].ToString();
            //            break;
            //    }

            //}

            XmlDocument xml = new XmlDocument();
            xml.Load(pTemplateURL);

            ArrayList strValue = new ArrayList();
            XmlNodeList xnList = xml.SelectNodes("Theme/Module");//"/Pages/Page");
            //search Node 
            foreach (XmlNode xn in xnList)
            {
                if (pModuleName == xn.FirstChild.InnerText)
                {

                    for (int i = 1; i < xn.ChildNodes.Count; i++)//More element need to increase size of string array
                    {
                        //for (int x = 1; x < xn.ChildNodes[i].ChildNodes.Count; x++)
                        //{
                        switch (xn.ChildNodes[i].FirstChild.InnerText.ToString())
                        {
                            case "label":
                                Label label = (Label)FindControl(xn.ChildNodes[i].ChildNodes[1].InnerText.ToString());
                                label.Text = xn.ChildNodes[i].ChildNodes[2].InnerText.ToString();
                                break;
                            case "button":
                                Button button = (Button)FindControl(xn.ChildNodes[i].ChildNodes[1].InnerText.ToString());
                                button.Text = xn.ChildNodes[i].ChildNodes[2].InnerText.ToString();
                                break;
                            case "hyberlink":
                                HyperLink hyperlink = (HyperLink)FindControl(xn.ChildNodes[i].ChildNodes[1].InnerText.ToString());
                                hyperlink.Text = xn.ChildNodes[i].ChildNodes[2].InnerText.ToString();
                                break;
                            //}
                            //strValue.Add(xn.ChildNodes[i].ChildNodes[x].InnerText);//add data to ArrayList
                        }
                    }
                    break;
                }

            }

        }
		
		protected void btnLogin_Click(object sender, EventArgs e)
        {
            _UsersControl = new UsersControl();
            GetDataFrom();
            UsersInfo info = new UsersInfo();
            info = _UsersControl.Get(_UsersInfo.Username, ref sErr);
            if (_UsersInfo.Username == "")
            {
                lblErr.Text = "The user does not exist or password do not use !!! ";
            }
            else if (_UsersInfo.Password != info.Password)
            {
                lblErr.Text = "The user does not exist or password do not use !!!";
            }
            else if (_UsersInfo.Password == info.Password)
            {
                Session["User"] = info.Fullname;
                Response.Redirect("~/Page/googlemap.html");
            }
        }

        private void GetDataFrom()
        {
            _UsersInfo = new UsersInfo();
            _UsersInfo.Username = tbxUsername.Text.Trim();
            _UsersInfo.Password = _UsersControl.EncodePassword(tbxPassword.Text.Trim());
        }
    }
}