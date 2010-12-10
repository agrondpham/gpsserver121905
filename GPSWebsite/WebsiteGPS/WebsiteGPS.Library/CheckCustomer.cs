using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteGPS.Library
{
    class CheckCustomer
    { 
        private string _strUsername;
        private string _strPassword;
        private int _errorCode;
        //set get Username and password
        public void setUsername(string strUsername) {
            _strUsername = strUsername;
        }
        public string getUsername() {
            return _strUsername;
        }
        public void setPassword(string strPassword) {
            _strPassword = strPassword;
        }
        public string getPassword() {
            return _strPassword;
        }

        
        //check User
        public void CheckingCust(string username,string password) {
            Validate validate = new Validate();
            string[] strArrayData = new string[] { username, password };
            if (validate.NullData(strArrayData) == true) {
                _errorCode = 401;
            }else{
                _errorCode=0;
                //check UsernamePassword
            }

        }
    }
}
