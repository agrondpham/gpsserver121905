﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace ListeningGPS.DAL
{
    public class GPSDataDAO
    {   
        #region local varible
        private string _strLatitude;
        private string _strLongitude;
        private string _strSpeed;
        private string _strDateTime;
        private string _strImei;
        #endregion
        #region set/get data
        //time
        public string getStrDateTime() { return _strDateTime; }
        public void setStrDateTime(string pDate,string pTime)
        {
            _strDateTime = CutStrDateTime(pDate,'/');
            _strDateTime = _strDateTime + '@' + CutStrDateTime(pTime, ':');
        }
        //Longitude
        public string getStrLongitude() { return _strLongitude; }
        public void setStrLongitude(string pLongitude)
        {
            _strLongitude = CutStrCoordinates(pLongitude,"longtitude");
        }
        //Latitude
        public string getStrLatitude() { return _strLatitude; }
        public void setStrLatitude(string pLatitude){
            _strLatitude= CutStrCoordinates(pLatitude,"latitude");
        }
        //Speed
        public string getStrSpeed() { return _strSpeed; }
        public void setStrSpeed(string pSpeed)
        {
            _strSpeed = ConvertSpeed(pSpeed);
        }
        #endregion
        #region Convert Data
        public string CutStrDateTime(string pDateTimeData, char separate)
        {
            string strCutDateTime = "";
            for (int i = 0; i < pDateTimeData.Length; i = i + 2)
            {
                if (i == 0)
                {
                    strCutDateTime = pDateTimeData.Substring(i, 2);
                }
                else
                {
                    strCutDateTime = strCutDateTime + separate + pDateTimeData.Substring(i, 2);
                }
            }
            return strCutDateTime;
        }
        public string CutStrCoordinates(string pCoordinates,string pType) {
            string strCoordinates="";
            int strDegrees;
            float strMinimutes;
            int strLength=0;
            switch (pType.ToLower())
            {
                case "longtitude":
                strLength=3;
                    break;
                case "latitude":
                strLength=2;
                break;
            }
            strDegrees = Int32.Parse(pCoordinates.Substring(0, strLength));
            strMinimutes = float.Parse(pCoordinates.Substring(2));
	        if (strDegrees > 180 || strDegrees < 0){
			        //alert("Degrees should be between 0 and 180.");
	        }
	        else if (strMinimutes > 60 || strMinimutes < 0){
				        //alert("Minutes should be between than 0 and 60.");
	        }
	        else {
                strCoordinates = ((strDegrees*1.0) + strMinimutes/60.0).ToString();
            }
            return strCoordinates;
        }
        public string ConvertSpeed(string pSpeed) {
            double KmPerHr = float.Parse(pSpeed)*1.852;
            return Convert.ToInt32(KmPerHr).ToString();
        }
        #endregion
        public Boolean InsertData(ArrayList data) {
            string strResuls="";
            //get data
            setStrDateTime(data[9].ToString(),data[1].ToString());
            setStrLatitude(data[3].ToString());
            setStrLongitude(data[5].ToString());
            setStrSpeed(data[7].ToString());
            //cau lenh Insert nam o day
            
            
            if (strResuls.ToLower()=="true")
            {
                return true;
            }
            else { return false; }
        }
    }
}
