﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Listener.BLL
{
     public class ConvertGPS
    {
        #region Convert Data
         public string CutStrDateTime(string pDateTimeData, char pSeparate,char pType)
        {
            string strCutDateTime = "";
            for (int i = 0; i < 6; i = i + 2)
            {
                if (i == 0)
                {
                    if (pType == 't')
                    {
                        Int32 tempTime = Convert.ToInt32(pDateTimeData.Substring(i, 2)) + 7;
                        if (tempTime < 10)
                        {
                            strCutDateTime = '0' + tempTime.ToString();
                        }
                        else
                        {
                            if (tempTime >= 17)
                            {
                                strCutDateTime = '0' + (tempTime - 24).ToString();
                            }
                            else
                            {
                                strCutDateTime = tempTime.ToString();
                            }
                        }
                    }
                    else{
                        strCutDateTime = pDateTimeData.Substring(i, 2);
                    }
                }
                else
                {
                    if (i == 4 && pType == 'd')
                    {
                        strCutDateTime = strCutDateTime + pSeparate + (Convert.ToInt32(pDateTimeData.Substring(i, 2)) + 2000).ToString();
                    }
                    else
                    {
                        strCutDateTime = strCutDateTime + pSeparate + pDateTimeData.Substring(i, 2);
                    }
                }
            }
            return strCutDateTime;
        }
         public string CutStrCoordinates(string pCoordinates, string pType)
        {
            string strCoordinates = "";
            int strDegrees;
            float strMinimutes;
            int strLength = 0;
            switch (pType.ToLower())
            {
                case "longitude":
                    strLength = 3;
                    break;
                case "latitude":
                    strLength = 2;
                    break;
            }
            strDegrees = Int32.Parse(pCoordinates.Substring(0, strLength));
            strMinimutes = float.Parse(pCoordinates.Substring(strLength));
            if (strDegrees > 180 || strDegrees < 0)
            {
                //alert("Degrees should be between 0 and 180.");
            }
            else if (strMinimutes > 60 || strMinimutes < 0)
            {
                //alert("Minutes should be between than 0 and 60.");
            }
            else
            {
                strCoordinates = ((strDegrees * 1.0) + strMinimutes / 60.0).ToString();
            }
            return strCoordinates;
        }
         public string ConvertSpeed(string pSpeed)
        {
            double KmPerHr = float.Parse(pSpeed) * 1.852;
            return Convert.ToInt32(KmPerHr).ToString();
        }
         public string ConvertIMEI(string pimei) {
             string imei = pimei.Substring(5);
             return imei;
         }
        #endregion
    }
}
