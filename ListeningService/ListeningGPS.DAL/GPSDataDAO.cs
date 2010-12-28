using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace ListeningGPS.DAL
{
    public class GPSDataDAO
    {   
        #region local varible
        DTO.GPSDataVO GPSDataVO = new DTO.GPSDataVO();
        #endregion

        public Boolean InsertData(ArrayList data) {
            string strResuls="";
            //get data
            GPSDataVO.setStrDateTime(data[9].ToString(),data[1].ToString());
            GPSDataVO.setStrLatitude(data[3].ToString());
            GPSDataVO.setStrLongitude(data[5].ToString());
            GPSDataVO.setStrSpeed(data[7].ToString());
            GPSDataVO.setStrImei(data[13].ToString());
            //cau lenh Insert nam o day
            
            
            if (strResuls.ToLower()=="true")
            {
                return true;
            }
            else { return false; }
        }
    }
}
