using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteGPS.Controls
{
    public partial class CustomersLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] aaaa;
            //Default defaultPage = new Default();
            Default mainPage =(Default) this.Page;      //get Page Content UC Control
            aaaa = mainPage.getThemeConfig();           //get variable from main Page
        }
        public void test() { 
        
        }
    }
}