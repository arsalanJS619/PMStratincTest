using System;
using System.Security.Cryptography;
using System.Data;
using System.Collections.Generic;
//using System.Collections;
//using System.Linq;
using System.IO;
using System.Text;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using BusinessLogic;
//using WebApplication13;
using System.Text.RegularExpressions;
//using System.Net.Mail;
using EASendMail;
//using AuthorizeNet;
using System.Globalization;
using System.Web.UI;
using System.Net.Mail;
//using MailKit.Net.Smtp;
//using MimeKit;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
//using Stripe;

namespace WebApplication13
{
    public partial class HomePage : System.Web.UI.Page
    {
        GeneralFunctions.clsGeneralFunctions cGF = new GeneralFunctions.clsGeneralFunctions();
        const string CryptoKey = "pkn12byheni090eraszx2ea2315a1916";

        public Int64 UserID = 0;


        //public static List<string> GetCountryList()
        //{
        //    BusinessLogic.UserInfo UI = new UserInfo();

        //    int CountryCode = 1001;
        //    List<string> cultureList = new List<string>();

        //    CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        //    foreach (CultureInfo culture in cultures)
        //    {

        //        RegionInfo region = new RegionInfo(culture.LCID);

        //        if (!(cultureList.Contains(region.EnglishName)))
        //        {
        //            cultureList.Add(region.EnglishName);

        //        }
        //        // 1;
        //    }
        //    for(int i=0;i<cultureList.Count;i++)
        //    {
        //        UI.insertCountry(CountryCode, cultureList[i]);
        //        CountryCode++;
        //    }
        //    return cultureList;
        //}
        public class AesOperation
        {

            public static string EncryptString(string key, string plainText)
            {
                byte[] iv = new byte[16];
                byte[] array=null;

                try
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = Encoding.UTF8.GetBytes(key);
                        aes.IV = iv;

                        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                                {
                                    streamWriter.Write(plainText);
                                }

                                array = memoryStream.ToArray();
                            }
                        }
                    }
                }
                catch(Exception ex)
                { }
                return Convert.ToBase64String(array);
            }

            public static string DecryptString(string key, string cipherText)
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
        //protected void CheckEmptyValue(object sender, EventArgs e)
        //{
        //    if(RegUserName.Value == "" || RegPassword.Value == "" && RegEmail.Value == "")
        //    {
                
        //    }


           
        //}

        protected void RedirectToForgetPaswd(object sender, EventArgs e)
        {
            try
            {
                if (LoginEmail.Value == "")
                {
                    labelmsg.InnerText = "Please ENter Email";
                }
                Session["Email"] = LoginEmail.Value;
                Response.Redirect("~/ForgetPassword.aspx");
            }
            catch(Exception ex)
            {

            }
        }
        private bool IsValidEmail(string email)
        {
            bool IsEmail = false;
            try
            {

                const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                IsEmail = regex.IsMatch(email);
            }
            catch(Exception ex)
            { }
            
            return IsEmail;
            
        }
        //protected void btnBack_Click(object sender, EventArgs e)
        //{

        //}
        protected void LogoutUser(object sender, EventArgs e) 
        {
            try
            {

                Session["User"] = null;

                UserLogged.Visible = false;
                LogoutHeader.Visible = false;
                LoginHeader.Visible = true;
                UserLogged.InnerText = "";// DR["Email"].ToString();

                //            UsrSettlement.Visible = true;
                //UsrStudent.Visible = true;
                //          UsrImmigration.Visible = true;
                UsrContact.Visible = true;
                UsrAbout.Visible = true;

                AdminUsrMng.Visible = false;
                AdmProgress.Visible = false;
                AdmQueries.Visible = false;
                AdmReports.Visible = false;

                Response.Redirect("~/HomePage.aspx");
            }
            catch(Exception ex)
            {

            }
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            try
            {
                if (IsValidEmail(LoginEmail.Value))
                {
                    BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();

                    string _Paswd = AesOperation.EncryptString(CryptoKey, LoginPassword.Value);
                    DataTable dt = UI.AuthenticateLoginUser(LoginEmail.Value, _Paswd);

                    if (dt.Rows.Count == 1)
                    {

                        DataRow DR = dt.Rows[0];
                        Session["User"] = DR["Name"].ToString();
                        Session["IsStudent"] = DR["IsStudent"].ToString();
                        Session["IsAdmin"] = DR["AdminUser"].ToString();
                        Session["UserID"] = DR["ID"].ToString();
                        Session["Father"] = DR["FName"].ToString();
                        Session["Email"] = DR["Email"].ToString();

                        if (Session["IsAdmin"].ToString() == "True")
                        {
                            AdminUsrMng.Visible = true;
                            AdmProgress.Visible = true;
                            AdmQueries.Visible = true;
                            AdmReports.Visible = true;
                            UsrStuInfo.Visible = true;
                            UsrProgress.Visible = false;
                            UsrContact.Visible = false;
                            UsrAbout.Visible = false;
                        }
                        else
                        {
                            AdminUsrMng.Visible = false;
                            AdmProgress.Visible = false;
                            AdmQueries.Visible = false;
                            AdmReports.Visible = false;
                            UsrStuInfo.Visible = true;

                            UsrProgress.Visible = true;
                            UsrContact.Visible = true;
                            UsrAbout.Visible = true;
                        }
                        UserLogged.Visible = true;
                        LogoutHeader.Visible = true;
                        LoginHeader.Visible = false;
                        UserLogged.InnerText = "Hi " +Session["User"].ToString();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        var Url_string = HttpContext.Current.Request.Url.AbsoluteUri.Split('/');
                        Session["Message"] = "InvalidUser";
                        //Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");
                        Response.Redirect("~/RegistrationPage.aspx");
                    }
                }
            }
            catch(Exception ex)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", ex.InnerException.Message, true) ;
                cGF.MessageBox(ex.Message, this);
            }
        }

        //private const string SMTP_SERVER = "http://schemas.microsoft.com/cdo/configuration/smtpserver";
        //private const string SMTP_SERVER_PORT = "http://schemas.microsoft.com/cdo/configuration/smtpserverport";
        //private const string SEND_USING = "http://schemas.microsoft.com/cdo/configuration/sendusing";
        //private const string SMTP_USE_SSL = "http://schemas.microsoft.com/cdo/configuration/smtpusessl";
        //private const string SMTP_AUTHENTICATE = "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate";
        //private const string SEND_USERNAME = "http://schemas.microsoft.com/cdo/configuration/sendusername";
        //private const string SEND_PASSWORD = "http://schemas.microsoft.com/cdo/configuration/sendpassword";

        protected void RegisterUser(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            //if (ChkEdu.Checked || ChkImg.Checked || ChkSett.Checked)
            //{
            try
            {
                if (IsValidEmail(RegEmail.Value))
                {
                    var Url_string = HttpContext.Current.Request.Url.AbsoluteUri.Split('/');

                    BusinessLogic.UserInfo UI = new UserInfo();
                    bool UserExists = UI.CheckForDuplicateEmail(RegEmail.Value);

                    if (UserExists == true)
                    {
                        // RegLabel.Text = "User Already Exists";
                        Session["Message"] = "UserExist";
                        //Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx",false);
                        Response.Redirect("~/RegistrationPage.aspx");


                        //    return false;
                    }

                    else
                    {
                       


                        //   string RedirectRegPage = Url_string + "RegistrationPage?";

                        Random rs = new Random();
                        string _RegCode = rs.Next().ToString() + rs.Next().ToString();

                        string RedirectRegPage = Url_string[0] + "//" + Url_string[2] + "/RegistrationPage?" + _RegCode;

                        string Password = AesOperation.EncryptString(CryptoKey, RegPassword.Value);

                        //long val = UI.InsertUserData(RegUserName.Value, RegEmail.Value, Password, ChkEdu.Checked ? "1" : "0", ChkImg.Checked ? "1" : "0", ChkSett.Checked ? "1" : "0", _RegCode);

                        long val = UI.InsertUserData(RegUserName.Value, RegEmail.Value, Password, ChkEdu.Checked ? "1" : "0", "0", "0", _RegCode);


                        if (val > 0)
                        {
                            System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();

                            //   mail.IsBodyHtml = true;
                            mail.Fields[SMTP_SERVER] = "mail.pmstratinc.com";
                            mail.Fields[SMTP_SERVER_PORT] = 465;
                            mail.Fields[SEND_USING] = 2;
                            mail.Fields[SMTP_USE_SSL] = true;
                            mail.Fields[SMTP_AUTHENTICATE] = 1;
                            mail.Fields[SEND_USERNAME] = "admin2_user@pmstratinc.com";
                            mail.Fields[SEND_PASSWORD] = "USer2@1600";


                      //      string body = "Please click the link to reset password : '" + RedirectRegPage + "'";
                            //   body += "<br /><a href = '" + RedirectRegPage + "'>Click here</a>.";
                            //    body += "<br /><br />Thanks";
                            // oMail.HtmlBody = body;


                            string body = "Hello, Click the link to register " + RedirectRegPage;
                            mail.Body = body;
           //                 body += "<br /><br />Please click the following link to register";
             //               body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
               //             body += "<br /><br />Thanks";// "blah blah <a href='http://www.example.com'>blah</a>";                            mail.To = RegEmail.Value;// "arsalanjawed619@yahoo.com";// user.Email;
                            mail.To = RegEmail.Value;
                            mail.From = "admin2_user@pmstratinc.com";
                            mail.Subject = "User Registration";// Registration Email Test";



                            System.Web.Mail.SmtpMail.Send(mail);
                            Session["Message"] = "MailSent";
                            //  string DEC = AesOperation.DecryptString("GFTSFDGHHSABJAN",ENC);
                  //          #region send mail
                    //        SmtpMail oMail = new SmtpMail("TryIt");

                            // Set sender email address, please change it to yours
                      //      oMail.From = "admin1_user@pmstratinc.com";

                            // Set recipient email address, please change it to yours
                        //    oMail.To = RegEmail.Value;// "arsalanjawed619@gmail.com";
                         //   oMail.Cc = "admin1_user@pmstratinc.com";

                            // Set email subject
                          //  oMail.Subject = "Registration Email";// test email from c#, ssl, 465 port";

                            // Set email body
                     //       string body = "Hello " + ",";
                     //       body += "<br /><br />Please click the following link to register";
                     //       body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
                     //       body += "<br /><br />Thanks";// "blah blah <a href='http://www.example.com'>blah</a>";
                     ////       oMail.HtmlBody = body;
                            
                     //       SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");
                           
                     //       oServer.User = "admin1_user@pmstratinc.com";
                     //       oServer.Password = "USer@1600";
                     //       oServer.Port = 465;
                     //       oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                     //       EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                     //       System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                     //       oSmtp.SendMail(oServer, oMail);
                     //       Session["Message"] = "MailSent";
                            //  Response.Redirect("RegistrationPage.aspx", true);


                            Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx",false);

                            //RegLabel.Text = "Email sent with Registration Link";

                            //   return false;
                        }
                    }
              //      #endregion

                }
                else
                {
                    RegLabel.Text = "email empty or invalid format";
                }
            }
            catch(Exception ex)
            {

            }

        }

        //protected void ChkValue(object sender, EventArgs e)
        //{

        //}
        private const string SMTP_SERVER = "http://schemas.microsoft.com/cdo/configuration/smtpserver";
        private const string SMTP_SERVER_PORT = "http://schemas.microsoft.com/cdo/configuration/smtpserverport";
        private const string SEND_USING = "http://schemas.microsoft.com/cdo/configuration/sendusing";
        private const string SMTP_USE_SSL = "http://schemas.microsoft.com/cdo/configuration/smtpusessl";
        private const string SMTP_AUTHENTICATE = "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate";
        private const string SEND_USERNAME = "http://schemas.microsoft.com/cdo/configuration/sendusername";
        private const string SEND_PASSWORD = "http://schemas.microsoft.com/cdo/configuration/sendpassword";


        protected void Page_Load(object sender, EventArgs ce)
        {
            try
            
            {
                ///////////////////////////////////////////////////////////
              

                //System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();

                //mail.Fields[SMTP_SERVER] = "mail.pmstratinc.com";
                //mail.Fields[SMTP_SERVER_PORT] = 465;
                //mail.Fields[SEND_USING] = 2;
                //mail.Fields[SMTP_USE_SSL] = true;
                //mail.Fields[SMTP_AUTHENTICATE] = 1;
                //mail.Fields[SEND_USERNAME] = "admin2_user@pmstratinc.com";
                //mail.Fields[SEND_PASSWORD] = "USer2@1600";

                //mail.To = "arsalanjawed619@yahoo.com";// user.Email;
                //mail.From = "admin2_user@pmstratinc.com";
                //mail.Subject = "Registration Email Test";

                //System.Web.Mail.SmtpMail.Send(mail);
                //////////////////////////////////////////////////////////////
                //SmtpMail oMail = new SmtpMail("TryIt");

                //// Set sender email address, please change it to yours
                //oMail.From = "admin2_user@pmstratinc.com";
                //// Set recipient email address, please change it to yours
                //oMail.To = "arsalanjawed619@gmail.com";

                //// Set email subject
                //oMail.Subject = "test email from c# project";
                //// Set email body
                //oMail.TextBody = "this is a test email sent from c# project, do not reply";

                //// SMTP server address
                //SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");
                //oServer.ConnectType = SmtpConnectType.ConnectDirectSSL;
                //// User and password for ESMTP authentication
                //oServer.User = "admin2_user@pmstratinc.com";
                //oServer.Password =  "USer2@1600";

                //// Most mordern SMTP servers require SSL/TLS connection now.
                //// ConnectTryTLS means if server supports SSL/TLS, SSL/TLS will be used automatically.
                
                //oServer.HeloDomain = "mail.pmstratinc.com";
                //oServer.UseDefaultCredentials = false;
            //    oServer.HeloDomain = "mail.pmstratinc.com";
                // If your SMTP server uses 587 port
                // oServer.Port = 587;

                // If your SMTP server requires SSL/TLS connection on 25/587/465 port
//                oServer.Port = 465; // 25 or 587 or 465
//                // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

//                Console.WriteLine("start to send email ...");
//                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;

//                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
//                oSmtp.DnsServerIP = "148.72.158.229";
//                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate,
//X509Chain chain, SslPolicyErrors sslPolicyErrors)
//{ return true; };
//                oSmtp.SendMail(oServer, oMail);
                //    var mailMessage = new MimeMessage();// MimeMailMessage();
                //    mailMessage.From.Add(new InternetAddress EASendMail.MailAddress("test@tes.com"));
                ////    var address = new InternetAddress;
                //    mailMessage.From.Add(new InternetAddress("test@test.com"));//"new MimeMailAddress(mailAddress);

                //    mailMessage.From = new MimeMailAddress(mailAddress);

                //    mailMessage.To.Add(userTo);

                //    mailMessage.Subject = subject;

                //    mailMessage.Body = message;

                //    //Create Smtp Client

                //    var mailer = new mim MimeKitMimeMailer(host, 465);

                //    mailer.User = userName;

                //    mailer.Password = password;

                //    mailer.SslType = SslMode.Ssl;

                //    mailer.AuthenticationMode = AuthenticationType.Base64;

                //    //Set a delegate function for call back

                //    mailer.SendCompleted += compEvent;

                //    mailer.SendMailAsync(mailMessage);

                //   var client = new MailKit.Net.Smtp.SmtpClient();
                //   client.Connect("mail.pmstratinc.com", 465, true);

                //   // Note: since we don't have an OAuth2 token, disable the XOAUTH2 authentication mechanism.
                //   client.AuthenticationMechanisms.Remove("XOAUTH2");

                // //  if (needsUserAndPwd)
                ////   {
                //       // Note: only needed if the SMTP server requires authentication
                //       client.Authenticate("admin1_user@pmstratinc.com", "USer@1600");
                //   // }
                //   MailboxAddress To = new MailboxAddress();
                //   var msg = new MimeMessage();
                //   msg.From.Add(new m = "";//.Add(new MailboxAddress());
                //   msg.To.Add(new MailboxAddress("target@ema.il"));
                //   msg.Subject = "This is a test subject";

                //   msg.Body = new TextPart("plain")
                //   {
                //       Text = "This is a sample message body"
                //   };

                //   client.Send(msg);
                //   client.Disconnect(true);
                //////////////////////////////////////////////////////////////////////////////////////
                //System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage("admin1_user@pmstratinc.com", "arsalanjawed619@yahoo.com");// System.Net.Mail.MailMessage("EmailMessage.msg");
                //msg.Subject = "test";
                //msg.Body = "test body";
                //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.pmstratinc.com", 465);
                //client.EnableSsl = false;           
                //client.UseDefaultCredentials = false;
               
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.Credentials = new System.Net.NetworkCredential("admin1_user@pmstratinc.com", "USer@1600");  // Username = "username";
                
                ////  client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //client.Timeout = 14400;
                ////  client.DeliveryMethod = System.Net.Mail.SmtpPermissionAttribute;//.SpecifiedPickupDirectory;
                //try
                //{
                //    // Send this email
                //    System.Net.ServicePointManager.Expect100Continue = true;
                //    client.Send(msg);//.HtmlBody.ToString());
                //}
                //catch (Exception ex)
                //{
                //    //     Trace.WriteLine(ex.ToString());
                //}

                //        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                //        message.From = new System.Net.Mail.MailAddress("admin1_user@pmstratinc.com");
                //        message.To.Add(new System.Net.Mail.MailAddress("arsalanjawed619@yahoo.com"));
                //        message.Subject = "Test";
                //        message.IsBodyHtml = true; //to make message body as html
                //        message.Body = "Hello ";
                //        smtp.Port = 465;
                //        smtp.Host = "148.72.158.229"; //for gmail host mail.pmstratinc.com
                //                                           // = true;
                //smtp.Timeout = 100000;
                //        smtp.UseDefaultCredentials = false;
                //        smtp.Credentials = new System.Net.NetworkCredential("admin1_user@pmstratinc.com", "USer@1600");
                //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network; 22
                //        smtp.Send(message);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (Session["User"]!=null)
                {
                    UserID = Convert.ToInt64(Session["UserID"].ToString());
                    if (!IsPostBack)
                    {
                        labelmsg.InnerText = "";
                        RegLabel.Text = "";

                        if (Session["IsAdmin"].ToString() == "True")
                        {
                            AdminUsrMng.Visible = true;
                            AdmProgress.Visible = true;
                            AdmQueries.Visible = true;
                            AdmReports.Visible = true;

                            UsrAbout.Visible = false;
                            UsrProgress.Visible = false;
                            UsrStuInfo.Visible = true;

                            UsrContact.Visible = false;
                        }
                        else
                        {
                            AdminUsrMng.Visible = false;
                            AdmProgress.Visible = false;
                            AdmQueries.Visible = false;
                            AdmReports.Visible = false;

                            UsrAbout.Visible = true;
                            UsrProgress.Visible = true;
                            UsrStuInfo.Visible = true;

                            UsrContact.Visible = true;
                        }


                        LoginHeader.Visible = false;
                        UserLogged.Visible = true;
                        UserLogged.InnerText = "Hi " + Session["User"].ToString();
                        LogoutHeader.Visible = true;
                    }
                }
                else
                {
                    LoginHeader.Visible = true;
                    UserLogged.Visible = false;
                    LogoutHeader.Visible = false;
                    UsrStuInfo.Visible = false;
                }              
            }
            catch(Exception ex)
            {
                cGF.MessageBox(ex.Message, this);
            }


        }

        
    }
}