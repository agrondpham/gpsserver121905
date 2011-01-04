using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Listener.DTO;
using System.Collections;
namespace Listener.BLL
{
    public class CutingString
    {
        GPS_DataInfo _GPS_DataInfo = new GPS_DataInfo();
        ConvertGPS _ConvertGPS = new ConvertGPS();
        public GPS_DataInfo CutStringGPSData(string strGPSData,string strGPSType) {
            ArrayList strArrayGPSData = new ArrayList();
            ArrayList strCutGPSData = new ArrayList();
            //cat chuoi o day
            try//use try catch to filter error "difference string".It is bad.need to find other method
            {
                //Add string Array to ArrayList
                strArrayGPSData.AddRange(strGPSData.Split(','));

                int indexOfGPRMC = 0;
                int endIndexOfGPRMC = 0;
                int indexImei = 0;
                foreach (string value in strArrayGPSData)
                {
                    if (value == strGPSType)
                    {
                        indexOfGPRMC = strArrayGPSData.IndexOf(value);
                    }
                    if (value.StartsWith("A*"))
                    {
                        endIndexOfGPRMC = strArrayGPSData.IndexOf(value);
                    }
                    if (value.StartsWith("imei"))
                    {
                        indexImei = strArrayGPSData.IndexOf(value);
                    }
                }
                for (int i = 0; indexOfGPRMC <= endIndexOfGPRMC; i++, indexOfGPRMC++)
                {
                    strCutGPSData.Add(strArrayGPSData[indexOfGPRMC]);
                }
                strCutGPSData.Add(strArrayGPSData[indexImei]);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            return resultObj(strCutGPSData);
        }

        private GPS_DataInfo resultObj(ArrayList strCutGPSData)
        {
            _GPS_DataInfo.Received_Data = _ConvertGPS.CutStrDateTime(strCutGPSData[9].ToString(),'/') + "@" + _ConvertGPS.CutStrDateTime(strCutGPSData[9].ToString(), ':');
            _GPS_DataInfo.Latitude = _ConvertGPS.CutStrCoordinates(strCutGPSData[3].ToString(), "latitude");
            _GPS_DataInfo.Longitude = _ConvertGPS.CutStrCoordinates(strCutGPSData[5].ToString(), "longtitude");
            _GPS_DataInfo.Speed = _ConvertGPS.ConvertSpeed(strCutGPSData[7].ToString());
            _GPS_DataInfo.IMED_Device = strCutGPSData[13].ToString();
            _GPS_DataInfo.Status = 1;

            return _GPS_DataInfo;
            
        }


    }
}
