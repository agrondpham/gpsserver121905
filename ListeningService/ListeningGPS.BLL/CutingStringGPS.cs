using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
namespace ListeningGPS.BLL
{
    public class CutingString
    {
        public ArrayList CutStringGPSData(string strGPSData,string strGPSType) {
            ArrayList strArrayGPSData = new ArrayList();
            ArrayList strCutGPSData = new ArrayList();
            //cat chuoi o day
            
            //Add string Array to ArrayList
            strArrayGPSData.AddRange(strGPSData.Split(','));
            
            int indexOfGPRMC = 0;
            int endIndexOfGPRMC=0;
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
                if (value.StartsWith("imei")) {
                    indexImei = strArrayGPSData.IndexOf(value);
                }
            }
            //Bad code need to update??????/////////////////////////////
            for (int i = 0; indexOfGPRMC <= endIndexOfGPRMC; i++, indexOfGPRMC++)
            {
                strCutGPSData.Add(strArrayGPSData[indexOfGPRMC]);
            }
            strCutGPSData.Add(strArrayGPSData[indexImei]);
            return strCutGPSData;
        }
    }
}
