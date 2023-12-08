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
using System.Text.RegularExpressions;
//using System.Net.Mail;
using EASendMail;
//using AuthorizeNet;
using System.Globalization;
using Outlook = Microsoft.Office.Interop.Outlook;

//using Microsoft.Office.Interop.Outlook;

namespace WebApplication13
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void LogoutUser(object sender, EventArgs e)
        {
            Session["User"] = null;

            //   UserLogged.Visible = false;
            //   LogoutHeader.Visible = false;
            ////   LoginHeader.Visible = true;
            //   UserLogged.InnerText = "";// DR["Email"].ToString();

            //   UsrSettlement.Visible = true;
            //   UsrStudent.Visible = true;
            //   UsrImmigration.Visible = true;
            //   UsrContact.Visible = true;
            //   UsrAbout.Visible = true;

            //   AdmAdmin.Visible = false;
            //   AdmProgress.Visible = false;
            //   AdmQueries.Visible = false;
            //   AdmReports.Visible = false;

            Response.Redirect("~/HomePage.aspx");
        }
        private bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        private const string SMTP_SERVER = "http://schemas.microsoft.com/cdo/configuration/smtpserver";
        private const string SMTP_SERVER_PORT = "http://schemas.microsoft.com/cdo/configuration/smtpserverport";
        private const string SEND_USING = "http://schemas.microsoft.com/cdo/configuration/sendusing";
        private const string SMTP_USE_SSL = "http://schemas.microsoft.com/cdo/configuration/smtpusessl";
        private const string SMTP_AUTHENTICATE = "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate";
        private const string SEND_USERNAME = "http://schemas.microsoft.com/cdo/configuration/sendusername";
        private const string SEND_PASSWORD = "http://schemas.microsoft.com/cdo/configuration/sendpassword";

        //private void Email()
        //{
        //    try
        //    {
        //        ///////////////////----------------------------Email------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        //        //Email
        //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

        //        //string SE_From = System.Configuration.ConfigurationManager.AppSettings["Email_CrAddress"];
        //        ////string SE_From = "authen@habibmodaraba.com";
        //        //string SE_TO = "azhar.hussain@habibmodaraba.com";
        //        //string SE_CC = "fazal@habibmodaraba.com;intisar@habibmodaraba.com;zahid@habibmodaraba.com;m.ayaz@habibmodaraba.com";
        //        //string SE_BCC = "m.ayaz@habibmodaraba.com";
        //        //string SE_SUB = "";

        //      //  SE_SUB = "Client Name : " + ddlCompCode.SelectedItem.Text.Trim() + " Risk Category is " + ddlRisk.SelectedItem.Text.Trim();

        //        string ebody = "";
        //        ebody = "<html>";
        //        ebody = ebody + "<STYLE TYPE=text/css>";
        //        ebody = ebody + "<!--";
        //        ebody = ebody + "BODY";
        //        ebody = ebody + "   {";
        //        ebody = ebody + "   font-family:Calibri;font-size: 9pt;";
        //        ebody = ebody + "   }";
        //        ebody = ebody + " A:link{color:white}";
        //        ebody = ebody + " A:visited{color:yellow}";
        //        ebody = ebody + " TH{font-family: calibri; font-size: 9pt;font-weight: bold;background:#659EC7;color: white;border: 1px solid black;border-collapse:collapse;}";
        //        ebody = ebody + " TD{font-family: calibri; font-size: 9pt;border: 1px solid black;border-collapse:collapse;}";
        //        ebody = ebody + " Table{border: 1px double black;border-collapse:collapse;}";
        //        ebody = ebody + "-->";
        //        ebody = ebody + "</STYLE>";
        //        ebody = ebody + "<head>";
        //        ebody = ebody + "</head>";
        //        ebody = ebody + "<body>";
        //        ebody = ebody + "<p>Dear ,</p>";
        //        ebody = ebody + "<p></p>";
        //        ebody = ebody;// + "<p> " + Session["LoginID"].ToString() + " changed risk category from <b> to <b> </b></p>";
        //        //ebody = ebody + "<p>This is to inform you that Rent has been reversed. Kindly note down reversal detail.</p>";
        //        ebody = ebody + "<p></p>";
        //        ebody = ebody + "<p></p>";

        //        ebody = ebody + "<p></p>";

        //        ebody = ebody + "<p>Regards</p>";
        //        ebody = ebody + "<p>System Support Department</p>";

        //        //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //        //mail.To.Add(SE_TO.Replace(';', ','));
        //        //mail.CC.Add(SE_CC.Replace(';', ','));
        //        //mail.Bcc.Add(SE_BCC.Replace(';', ','));
        //        //mail.From = new MailAddress(SE_From, "Client Name : " + ddlCompCode.SelectedItem.Text.Trim() + " Risk Category is " + ddlRisk.SelectedItem.Text.Trim(), System.Text.Encoding.UTF8);
        //        //mail.Subject = "Client Name : " + ddlCompCode.SelectedItem.Text.Trim() + " Risk Category is " + ddlRisk.SelectedItem.Text.Trim();// SE_SUB;
        //        //mail.SubjectEncoding = System.Text.Encoding.UTF8;
        //        //mail.Body = ebody;
        //        mail.From = new System.Net.Mail.MailAddress("admin1_user@pmstratinc.com");
        //        mail.To.Add("arsalanjawed619@yahoo.com".Replace(';', ','));
        //        mail.BodyEncoding = System.Text.Encoding.UTF8;
        //        mail.IsBodyHtml = true;
        //        //    mail.Priority = MailPriority.High;admin1_user@pmstratinc.com
        //     //   USer@1600
        //        //SmtpClient client = new SmtpClient();
        //   //     string CrAddress = System.Configuration.ConfigurationManager.AppSettings["Email_CrAddress"];
        //     //   string CrAddressPassword = System.Configuration.ConfigurationManager.AppSettings["Email_CrAddressPassword"];
        //      //  int SMTP_Port = 26;// objFunc.toInt(System.Configuration.ConfigurationManager.AppSettings["SMTP_Port"].ToString());
        //        string SMTP_Server =  "mail.pmstratinc.com";// System.Configuration.ConfigurationManager.AppSettings["SMTP_Server"];
        //        bool EnableSSL = false;// Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSSL"]);

        //        client.Credentials = new System.Net.NetworkCredential("admin1_user@pmstratinc.com", "USer@1600");
        //        client.Port = 465;
        //        client.Host = SMTP_Server;
        //        //client.UseDefaultCredentials = true;
        //        client.EnableSsl = EnableSSL;
        //        try
        //        {
        //            client.Send(mail);
        //            //Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');</script>");
        //        }
        //        catch (Exception ex)
        //        {
        //            Exception ex2 = ex;
        //            string errorMessage = string.Empty;
        //            while (ex2 != null)
        //            {
        //                errorMessage += ex2.ToString();
        //                ex2 = ex2.InnerException;
        //            }
        //            //Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');</script>");
        //        }

        //        ////////////////-------------------Email Code End---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        protected void SendUrlPaswdReset(object sender, EventArgs e)
        {
          
            //  Outlook.Accounts accounts = new Outlook.Accounts();

            //OutlookBarGroupsClass aa = new OutlookBarGroupsClass();

            //     SmtpMail omail1 = new SmtpMail("TryIt");
            //   omail1.HtmlBody = "test";
        //    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage("admin1_user@pmstratinc.com", "arsalanjawed619@yahoo.com");// System.Net.Mail.MailMessage("EmailMessage.msg");
        //    msg.Subject = "test";
        //    msg.Body = "test body";
        //    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.pmstratinc.com",465);
        ////    client.EnableSsl = true;           
        //    client.Credentials = new System.Net.NetworkCredential("admin2_user@pmstratinc.com", "USer2@1600");  // Username = "username";
        //  //  client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //    client.Timeout = 14400000;
          //  client.DeliveryMethod = System.Net.Mail.SmtpPermissionAttribute;//.SpecifiedPickupDirectory;
           // try
           // {
           //     // Send this email
           //     System.Net.ServicePointManager.Expect100Continue = true;
           //     client.Send(msg);//.HtmlBody.ToString());
           // }
           // catch (Exception ex)
           // {
           ////     Trace.WriteLine(ex.ToString());
           // }
            //       Email();
            try
            {
                if (TxtEmail.Value != "" && IsValidEmail(TxtEmail.Value) == true)
                {
                    Random rs = new Random();
                    string PaswdResetCode = rs.Next().ToString() + rs.Next().ToString();
                    var Url_string = HttpContext.Current.Request.Url.AbsoluteUri.Split('/');

                    string RedirectRegPage = Url_string[0] + "//" + Url_string[2] + "/PasswordReset?" + PaswdResetCode;

                    BusinessLogic.UserInfo UI = new UserInfo();

                    long value = UI.UpdateUserDataPasswordReset(TxtEmail.Value, PaswdResetCode);

                    if (value > 0)
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

               //         string body = "Hello, Click the link to register " + RedirectRegPage;
                        string body = "Please click the link to reset password : " + RedirectRegPage ;
                     //   body += "<br /><a href = '" + RedirectRegPage + "'>Click here</a>.";
                    //    body += "<br /><br />Thanks";
                        // oMail.HtmlBody = body;
                        

                        mail.Body = body;
                        mail.To = TxtEmail.Value;// "arsalanjawed619@yahoo.com";// user.Email;
                        mail.From = "admin2_user@pmstratinc.com";
                        mail.Subject = "Reset Password";// Registration Email Test";



                        System.Web.Mail.SmtpMail.Send(mail);
                        Session["Message"] = "MailSent";

                        //#region send mail
                        //SmtpMail oMail = new SmtpMail("TryIt");

                        //oMail.From = "admin1_user@pmstratinc.com";
                        //oMail.To = TxtEmail.Value;
                        //oMail.Subject = "Password Reset";

                        //SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");
                        //oServer.User = "admin1_user@pmstratinc.com"; oServer.Password = "USer@1600";
                        //oServer.ConnectType = SmtpConnectType.ConnectDirectSSL;// SmtpConnectType.ConnectSSLAuto;

                        //oServer.Port = 465;
                        //EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                        //oSmtp.SendMail(oServer, oMail);
                        Label1.InnerText = "Password Reset Link has been sent to your mail.";
                    }
                    else
                    {
                        Label1.InnerText = "Unable to send Password as user doesnot exist.";

                    }

                }
                else
                {
                    Label1.InnerText = "Email is either empty or not in correct format";
                }
                //RegLabel.Text = "Email sent with Registration Link";
            }
            catch(Exception ex)
            { }


                //   return false;
            }

       // #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                //      LoginHeader.Visible = true;
                UserLogged.Visible = false;
                LogoutHeader.Visible = false;
           //     UsrStuInfo.Visible = false;

            }
            //if (Session["User"] != null)
            //{
            //    if (Session["IsAdmin"].ToString() == "1")
            //    {
            //        //AdminUsrMng.Visible = true;
            //        //  AdmProgress.Visible = true;
            //        //    AdmQueries.Visible = true;
            //        //      AdmReports.Visible = true;

            //        UsrProgress.Visible = false;
            //        UsrAbout.Visible = false;
            //        //        UsrStudent.Visible = false;
            //        //          UsrSettlement.Visible = false;
            //        //            UsrImmigration.Visible = false;
            //        UsrContact.Visible = false;
            //    }
            //    else
            //    {
            //        //    AdminUsrMng.Visible = false;
            //        //           AdmProgress.Visible = false;
            //        //         AdmQueries.Visible = false;
            //        //       AdmReports.Visible = false;

            //        UsrProgress.Visible = true;
            //        UsrAbout.Visible = true;
            //        //    UsrStudent.Visible = true;
            //        //      UsrSettlement.Visible = true;
            //        //        UsrImmigration.Visible = true;
            //        UsrContact.Visible = true;
            //    }


            //    UserLogged.Visible = true;
            //    UserLogged.InnerText = "Hi " + Session["User"].ToString();
            //    LogoutHeader.Visible = true;
            //}
            //  Session["User"] = DR["Name"].ToString();
            //Session["IsStudent"] = DR["IsStudent"].ToString();
            if (Session["User"] == null)
            {
                UserLogged.Visible = false;
                UserLogged.InnerText = "";// Session["User"].ToString();
                LogoutHeader.Visible = false;

                //     Progress.Visible = false;
                //     StuInfo.Visible = false;
            }

            //TxtEmail.Value = Session["Email"].ToString();

            //if (HttpContext.Current.Request.Url.AbsoluteUri.Contains('?'))
            //{
            //    var Value = HttpContext.Current.Request.Url.AbsoluteUri.Split('?');


            //    BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();

            //    DataTable dt = UI.CheckRegCode(Value[1].ToString());
            //    if (dt.Rows.Count == 1)
            //    {
            //        long val = UI.ActivateUser(Value[1].ToString());
            //        if (val == 1)
            //        {
            //            RegHeading.InnerText = "Registration Successful. Please Login";
            //        }

            //        else
            //        {
            //            RegHeading.InnerText = "Registration UnSuccessful. Please Register";
            //        }


            //    }
            //}

            //else
            //{

            //    if (Session["Message"].ToString() == "InvalidUser")
            //    {
            //        RegHeading.InnerText = "User Authentication Failed";
            //        // Session["Message"] = null;
            //    }

            //    if (Session["Message"].ToString() == "UserExist")
            //    {
            //        RegHeading.InnerText = "User Already Exist";
            //        //   Session["Message"] = null;
            //        //  Session["RegMailMsg"] = "false";
            //    }

            //    if (Session["Message"].ToString() == "MailSent")
            //    {
            //        RegHeading.InnerText = "Mail Sent with Registration URL";
            //        //   Session["Message"] = null;
            //    }

            //}
            //    }

        }
    }
}