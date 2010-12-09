using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteGPS.Library
{
    class Validate
    {
        //check null
        public Boolean NullData(string value)
        {
            if (value == "" || value == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //check null
        public Boolean NullData(string[] value)
        {
            for (int i = 0; i <= value.Length; i++)
            {
                if (value[i] == "" || value[i] == null)
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
