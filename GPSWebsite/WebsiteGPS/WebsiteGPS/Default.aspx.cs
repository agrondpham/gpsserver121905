using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebsiteGPS.Library;
using System.IO;
namespace WebsiteGPS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPages();
        }
        public void LoadPages()
        {
            //Issue
            //strParameterURL can be null if load with nomal direct
            //if XML do not contain data ctrMain canbe get error


            //string strParameterURL = Request.QueryString["uc"];
            string strParameterURL = RouteData.Values["pages"].ToString().ToLower();
            ReadXML readXML = new ReadXML();
            Control ctrMain = LoadControl(
                readXML.SelectNode(
                    Path.Combine(
                        Request.PhysicalApplicationPath,
                        "App_Data\\ControlURL.xml"),
                        "Pages/Page",
                        "NameUC",
                        "URL", strParameterURL)
                        );
            BodyHolder.Controls.Add(ctrMain);
        }
    }
}