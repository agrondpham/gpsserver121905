using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;
using System.Net;


namespace WebsiteGPS.BUS
{
    public class EmailClass
    {
        public bool Send_Email(string SendFrom,string SendTo,string NameTo, string Subject, string Body) 
       {  
           //try 
           //{ 
           //    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
           //    string from = SendFrom;
           //    string to = SendTo;
           //    string subject = Subject;
           //    string body = Body;
           //    bool result = regex.IsMatch(to); 
           //    if (result == false) 
           //    { 
           //        return "Địa chỉ email không hợp lệ."; 
           //    } 
           //    else 
           //    { 
           //        System.Net.Mail.SmtpClient smtp = new SmtpClient(); 
           //        System.Net.Mail.MailMessage msg = new MailMessage(SendFrom,SendTo,Subject,Body); 
           //        msg.IsBodyHtml = true; 
           //        smtp.Host = "smtp.gmail.com";//Sử dụng SMTP của gmail 
           //        smtp.Port = 587;
           //        smtp.Send(msg); 
           //        return "Email đã được gửi đến: " + SendTo + "."; 
           //    } 
           //} 
           //catch 
           //{ 
           //    return ""; 
           //} 
           SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
           client.EnableSsl = true;
           MailAddress from = new MailAddress(SendFrom, "daiduong");
           MailAddress to = new MailAddress(SendTo, NameTo);
           MailMessage message = new MailMessage(from, to);
           message.Body = Body;
           message.Subject = Subject;
           NetworkCredential myCreds = new NetworkCredential(SendFrom, "thuthuy", "");
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
