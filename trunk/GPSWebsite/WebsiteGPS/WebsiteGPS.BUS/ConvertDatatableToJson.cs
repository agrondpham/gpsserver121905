using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace WebsiteGPS.BUS
{
    public class ConvertDatatableToJson
    {
        public string ConvertDSToJSON(DataTable dtbl)
        {
            string header = "{'marker':[";
            string longitude = "'longitude':'";
            string latitude = "','latitude':'";
            string speed = "','speed':'";
            string receiptedDay = "','date':'";
            string footer = "]};";
            string jquery = "";
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                string longitudeValue = dtbl.Rows[i]["longitude"].ToString();
                string latitudeValue = dtbl.Rows[i]["latitude"].ToString();
                string speedValue = dtbl.Rows[i]["speed"].ToString();
                string receiptedDayValue = dtbl.Rows[i]["Received_Data"].ToString();
                jquery = jquery + "{" + longitude + longitudeValue + latitude + latitudeValue +speed+speedValue+receiptedDay+receiptedDayValue+ "'},";
            }
            jquery = header + jquery + footer;
            return jquery;
        }
    }
}
