using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Text.RegularExpressions;
using System.Net.Mail;
using EASendMail;

namespace WebApplication13
{
    public partial class HomePage : System.Web.UI.Page
    {
        
        private bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
        }
       
        protected void btnBack_Click(object sender, EventArgs e)
        {         
            if(txtEmail.Value != "" && txtPassword.Value != "")
            {
                if(IsValidEmail(txtEmail.Value))
                {
                    
                }
            }
        }

        protected void TestMe(object sender, EventArgs e)
        { }

        //protected void TestMe(object sender, EventArgs e)
        //{
        //    BusinessLogic.UserInfo BU = new UserInfo();

        //    long value = BU.InsertUserData(txtEmail.Value, txtPassword.Value);

        //    if(value!=0)
        //    {
        //        SmtpClient smtpClient = new SmtpClient("mail.pmstratinc.com", 465);

        //        smtpClient.Credentials = new System.Net.NetworkCredential("admin1_user", "USer@1600");
        //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtpClient.EnableSsl = true;
        //        MailMessage mail = new MailMessage();

        //        //Setting From , To and CC
        //        mail.From = new MailAddress("admin1_user@pmstratinc.com", "Arsalan Site");
        //        mail.To.Add(new MailAddress(txtEmail.Value));
        //        smtpClient.Send(mail);
        //       // mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));
        //    }
        //}
        protected void Page_Load(object sender, EventArgs ce)
        {
            ClientScript.GetPostBackEventReference(this, "");


            ////////////////////////////////////////
            ///
            SmtpMail oMail = new SmtpMail("TryIt");

            // Set sender email address, please change it to yours
            oMail.From = "admin1_user@pmstratinc.com";

            // Set recipient email address, please change it to yours
            oMail.To = "arsalanjawed619@gmail.com";

            // Set email subject
            oMail.Subject = "test email from c#, ssl, 465 port";

            // Set email body
            oMail.TextBody = "this is a test email sent from c# project, do not reply";

            // Your SMTP server address
            SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");

            // User and password for ESMTP authentication, if your server doesn't require
            // User authentication, please remove the following codes.

            //mail.From = new MailAddress("admin1_user@pmstratinc.com", "Arsalan Site");
            oServer.User = "admin1_user@pmstratinc.com";
            oServer.Password = "USer@1600";

            // Set 465 SMTP port
            oServer.Port = 465;

            // Enable SSL connection
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            Console.WriteLine("start to send email ...");

            EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient(); 
            oSmtp.SendMail(oServer, oMail);

            //////////////////////////////////////////

            //string str = "arsalanjawed619@gmail.com";

            
            //SmtpClient smtpClient = new SmtpClient("mail.pmstratinc.com", 465);

            //smtpClient.Credentials = new System.Net.NetworkCredential("admin1_user@pmstratinc.com", "USer@1600");
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Timeout = 100;// 0000000;
            //smtpClient.EnableSsl = true;
            //MailMessage mail = new MailMessage();

            ////Setting From , To and CC
            //mail.From = new MailAddress("admin1_user@pmstratinc.com", "Arsalan Site");
            //mail.To.Add(new MailAddress(str));
            //smtpClient.Send(mail);
            //string trst = "";

         //   BusinessLogic.UserInfo BU = new UserInfo();
         //   string data = BU.GetData();//.UserInfo();

        }
    }
}