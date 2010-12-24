using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteGPS.Controls.Controler
{
    public partial class HistoricTracking : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowMarkers_Click(object sender, EventArgs e)
        {
            string strStartTime=tbxStartTime.Text;
            string strStopTime = tbxStopTime.Text;
            string strDevice = drdDevices.SelectedValue;            
            
            //ScriptManager scriptMng=(ScriptManager)Page.FindControl("ScriptManager1");
            //if (scriptMng.IsInAsyncPostBack)
            string scriptData = "var data={'marker':[{'longitude':'106.684866666667','latitude':'10.8284666666667'},{'longitude':'106.6843','latitude':'10.82865'},{'longitude':'106.683733333333','latitude':'10.8288333333333'},{'longitude':'106.681716666667','latitude':'10.8295166666667'},{'longitude':'106.677833333333','latitude':'10.8307833333333'},{'longitude':'106.675','latitude':'10.8318'},{'longitude':'106.670383333333','latitude':'10.8334333333333'},{'longitude':'106.6664','latitude':'10.83485'},{'longitude':'106.665766666667','latitude':'10.8350833333333'},{'longitude':'106.663','latitude':'10.8352'},{'longitude':'106.6595','latitude':'10.8361166666667'},{'longitude':'106.656116666667','latitude':'10.83705'},{'longitude':'106.6522','latitude':'10.838'},{'longitude':'106.647766666667','latitude':'10.83915'},{'longitude':'106.64445','latitude':'10.8413833333333'},{'longitude':'106.640383333333','latitude':'10.84415'},{'longitude':'106.638533333333','latitude':'10.8417666666667'},{'longitude':'106.636483333333','latitude':'10.83775'},{'longitude':'106.634966666667','latitude':'10.8345'},{'longitude':'106.634133333333','latitude':'10.8323'},{'longitude':'106.639166666667','latitude':'10.8292833333333'},]};setMap(map)";
            if(ScriptManager1.IsInAsyncPostBack)//check is postback
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Setmap", scriptData, true);
            }

        }
    }
}