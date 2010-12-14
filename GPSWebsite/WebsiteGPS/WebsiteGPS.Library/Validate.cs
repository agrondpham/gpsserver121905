using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteGPS.Library
{
    public class Validate
    {
        /// <summary>
        /// Check value null of simple data.
        /// </summary>
        /// <param name="strValue">Simple data in String type.</param>
        /// <returns>Return True if data is null or none
        /// and return False in other case.
        /// </returns>
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
        /// <summary>
        /// Check value null of array data.
        /// </summary>
        /// <param name="strValues">Array data</param>
        /// <returns>Return True if data is null or none
        /// and return False in other case.
        /// </returns>
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
