using System;
using System.Net;
using System.Net.Mail;


namespace WebsiteGPS.BUS
{
    public class EmailClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info">thong tin gui mail co 3 thuoc tinh: BodyCreate | BodyForgot | BodyChangePass</param>
        /// <param name="strPath"></param>
        /// <param name="SendTo"></param>
        /// <param name="NameTo"></param>
        /// <param name="Body"></param>
        /// <returns></returns>
        public bool Send_Email(string info,string strPath, string SendTo, string NameTo, string Body) 
       {
           TXTdll _txtdll = new TXTdll();
           _txtdll.LineArgs = _txtdll.LoadFileToArray(strPath);
           SmtpClient client = new SmtpClient(_txtdll.LineArgs[0],int.Parse(_txtdll.LineArgs[1]));
           client.EnableSsl = true;
           MailAddress from = new MailAddress(_txtdll.LineArgs[2], _txtdll.LineArgs[3]);
           MailAddress to = new MailAddress(SendTo, NameTo);
           MailMessage message = new MailMessage(from, to);
           if (info == "BodyCreate")
                message.Body = _txtdll.LineArgs[6] + "\n " +Body;
           if (info == "BodyForgot")
               message.Body = _txtdll.LineArgs[7] + "\n " + Body;
           if (info == "BodyChangePass")
               message.Body = _txtdll.LineArgs[8] + "\n " + Body;
           message.Subject = _txtdll.LineArgs[5];
           NetworkCredential myCreds = new NetworkCredential(_txtdll.LineArgs[2], _txtdll.LineArgs[4], "");
           client.Credentials = myCreds;
           try
           {
               client.Send(message);
               return true;
           }
           catch (Exception ex)
           {
               return false;
           }
       }  
       public string Send_Email_With_Attachment(string SendTo, string SendFrom, string Subject, string Body, string AttachmentPath) 
       { 
           try 
           { 
               System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"); 
               string from = SendFrom; 
               string to = SendTo; 
               string subject = Subject; 
               string body = Body; 
               bool result = regex.IsMatch(to); 
               if (result == false) 
               { 
                   return "Địa chỉ email không hợp lệ."; 
               } 
               else 
               { 
                   try 
                   { 
                       MailMessage em = new MailMessage(from, to,subject, body); 
                       Attachment attach = new Attachment(AttachmentPath); 
                       em.Attachments.Add(attach); 
                       em.Bcc.Add(from);  
                       System.Net.Mail.SmtpClient smtp = new SmtpClient(); 
                       smtp.Host = "smtp.gmail.com";//Ví dụ xử dụng SMTP của gmail   
                       smtp.Port = 587;
                       smtp.Send(em);  
                       return ""; 
                   } 
                   catch (Exception ex) 
                   { 
                       return ex.Message; 
                   } 
               } 
           } 
           catch (Exception ex) 
           { 
               return ex.Message; 
           } 
       } 
       public string Send_Email_With_BCC_Attachment(string SendTo, string SendBCC, string SendFrom, string Subject, string Body, string AttachmentPath) 
       {  
           try 
           { 
               System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");  
               string from = SendFrom; 
               string to = SendTo; //Danh sách email được ngăn cách nhau bởi dấu ";" 
               string subject = Subject; 
               string body = Body; 
               string bcc = SendBCC;  
               bool result = true; 
               String[] ALL_EMAILS = to.Split(';'); 
               foreach (string emailaddress in ALL_EMAILS) 
               { 
                   result = regex.IsMatch(emailaddress); 
                   if (result == false) 
                   { 
                       return "Địa chỉ email không hợp lệ."; 
                   } 
              } 
               if (result == true) 
               { 
                   try 
                   { 
                       MailMessage em = new MailMessage(from, to, subject, body); 
                       Attachment attach = new  Attachment(AttachmentPath); 
                       em.Attachments.Add(attach); 
                       em.Bcc.Add(bcc); 

                       System.Net.Mail.SmtpClient smtp = new SmtpClient(); 
                       smtp.Host = "smtp.gmail.com";//Ví dụ xử dụng SMTP của gmail 
                       smtp.Send(em); 

                       return ""; 
                   } 
                   catch (Exception ex) 
                   { 
                       return ex.Message; 
                   } 
               } 
               else 
               { 
                   return ""; 
               } 
           } 
           catch (Exception ex) 
           { 
               return ex.Message; 
           } 
       } 
    }
}
