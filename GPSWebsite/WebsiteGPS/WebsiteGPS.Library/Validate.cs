using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteGPS.Library
{
    class Validate
    {
        //check null
        public Boolean NullData(string strValue)
        {
            if (strValue == "" || strValue == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //check null
        public Boolean NullData(string[] strValues)
        {
            for (int i = 0; i <= strValues.Length; i++)
            {
                if (strValues[i] == "" || strValues[i] == null)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }
            return false;
        }
    }
}
