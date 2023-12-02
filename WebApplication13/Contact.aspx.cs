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

namespace WebApplication13
{
    public partial class Contact : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    LoginHeader.Visible = false;
                    UserLogged.Visible = false;
                    LogoutHeader.Visible = false;
                    UsrStuInfo.Visible = false;

                }
                if (Session["User"] != null)
                {
                    if (Session["IsAdmin"].ToString() == "True")
                    {
                        //   AdminUsrMng.Visible = true;
                        //           AdmProgress.Visible = true;
                        //         AdmQueries.Visible = true;
                        //       AdmReports.Visible = true;

                        UsrAbout.Visible = false;
                        UsrProgress.Visible = false;
                        UsrStuInfo.Visible = false;
                        //UsrStudent.Visible = false;
                        // UsrSettlement.Visible = false;
                        //   UsrImmigration.Visible = false;
                        UsrContact.Visible = false;
                    }
                    else
                    {
                        //     AdminUsrMng.Visible = false;
                        //            AdmProgress.Visible = false;
                        //     AdmQueries.Visible = false;
                        //   AdmReports.Visible = false;

                        UsrAbout.Visible = true;
                        UsrProgress.Visible = true;
                        UsrStuInfo.Visible = true;
                        //     UsrStudent.Visible = true;
                        //     UsrSettlement.Visible = true;
                        //   UsrImmigration.Visible = true;
                        UsrContact.Visible = true;
                    }


                    //     LoginHeader.Visible = false;
                    UserLogged.Visible = true;
                    UserLogged.InnerText = "Hi " + Session["User"].ToString();
                    LogoutHeader.Visible = true;

                }
            }
            catch(Exception ex)
            { }

        }

        protected void LogoutUser(object sender, EventArgs e)
        {
            try
            {
                Session["User"] = null;

                UserLogged.Visible = false;
                LogoutHeader.Visible = false;
                //   LoginHeader.Visible = true;
                UserLogged.InnerText = "";// DR["Email"].ToString();

                //          UsrSettlement.Visible = true;
                //        UsrStudent.Visible = true;
                //      UsrImmigration.Visible = true;
                UsrContact.Visible = true;
                UsrAbout.Visible = true;

                //    AdmAdmin.Visible = false;
                //  AdmProgress.Visible = false;
                //AdmQueries.Visible = false;
                //   AdmReports.Visible = false;

                Response.Redirect("~/HomePage.aspx");
            }
            catch(Exception ex)
            { }
        }

        private const string SMTP_SERVER = "http://schemas.microsoft.com/cdo/configuration/smtpserver";
        private const string SMTP_SERVER_PORT = "http://schemas.microsoft.com/cdo/configuration/smtpserverport";
        private const string SEND_USING = "http://schemas.microsoft.com/cdo/configuration/sendusing";
        private const string SMTP_USE_SSL = "http://schemas.microsoft.com/cdo/configuration/smtpusessl";
        private const string SMTP_AUTHENTICATE = "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate";
        private const string SEND_USERNAME = "http://schemas.microsoft.com/cdo/configuration/sendusername";
        private const string SEND_PASSWORD = "http://schemas.microsoft.com/cdo/configuration/sendpassword";

        protected void SubmitForm(object sender, EventArgs e)
        {

            //      DataTable dt1 = UI.GetUserStudentData(ApplicantIDs.Text);
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Set sender email address, please change it to yours
                oMail.From = "admin1_user@pmstratinc.com";

                // Set recipient email address, please change it to yours
                oMail.To = "admin2_user@pmstratinc.com";// email.Value;// dt1.Rows[0]["Email"].ToString();// RegEmail.Value;// "arsalanjawed619@gmail.com";
                oMail.Cc = "admin1_user@pmstratinc.com";

                // Set email subject
                oMail.Subject = "New Student Lead";// subject.Value;// "Your Academic Progress";// test email from c#, ssl, 465 port";

                // Set email body
                string body = "User Name : " + name.Value + ", " + " Email : " + email.Value + " ,subject : " + subject.Value + " , comments : " + comment.Value;// "Hello " + dt1.Rows[0]["FName"].ToString() + ",";
                                                                                                                                                                 //      body += "<br /><br />";
                //                                                                                                                                                 //     body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
                //                                                                                                                                                 //   body += "<br /><br />Thanks";// "blah blah <a href='http://www.example.com'>blah</a>";
                //oMail.HtmlBody = body;

                //SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");

                //oServer.User = "admin1_user@pmstratinc.com";
                //oServer.Password = "USer@1600";
                //oServer.Port = 465;
                //oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                //EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                //oSmtp.SendMail(oServer, oMail);
                //Session["Message"] = "MailSent";
                //   DataTable dt1 = UI.GetUserStudentData(ApplicantID.Text);
                System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();

                //   mail.IsBodyHtml = true;
                mail.Fields[SMTP_SERVER] = "mail.pmstratinc.com";
                mail.Fields[SMTP_SERVER_PORT] = 465;
                mail.Fields[SEND_USING] = 2;
                mail.Fields[SMTP_USE_SSL] = true;
                mail.Fields[SMTP_AUTHENTICATE] = 1;
                mail.Fields[SEND_USERNAME] = "admin2_user@pmstratinc.com";
                mail.Fields[SEND_PASSWORD] = "USer2@1600";


           //     string body = "Please click the link to reset password : '" + RedirectRegPage + "'";
                //   body += "<br /><a href = '" + RedirectRegPage + "'>Click here</a>.";
                //    body += "<br /><br />Thanks";
                // oMail.HtmlBody = body;


                mail.Body = body;
                mail.To = "admin1_user@pmstratinc.com";//  TxtEmail.Value;// "arsalanjawed619@yahoo.com";// user.Email;
                mail.Cc = "admin2_user@pmstratinc.com";
                mail.From = "admin2_user@pmstratinc.com";
                mail.Subject = "New Query";// Registration Email Test";



                System.Web.Mail.SmtpMail.Send(mail);
                Session["Message"] = "MailSent";



                name.Value = email.Value = subject.Value = comment.Value = "";
                //     SmtpMail oMail = new SmtpMail("TryIt");

                //     // Set sender email address, please change it to yours
                //     oMail.From = "admin1_user@pmstratinc.com";

                // // Set recipient email address, please change it to yours

                //     oMail.To = email.Value;// dt1.Rows[0]["Email"].ToString();// RegEmail.Value;// "arsalanjawed619@gmail.com";

                // // Set email subject
                // oMail.Subject = subject.Value;// "Your Academic Progress";// test email from c#, ssl, 465 port";

                // // Set email body
                // string body = comment.Value;// "Hello " + dt1.Rows[0]["FName"].ToString() + ",";
                ////     body += "<br /><br />Please check your Updated status for Student Stage 2.";
                //     //     body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
                //     //   body += "<br /><br />Thanks";// "blah blah <a href='http://www.example.com'>blah</a>";
                //     oMail.HtmlBody = body;

                //     SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");

                //     oServer.User = "admin1_user@pmstratinc.com";
                //     oServer.Password = "USer@1600";
                //     oServer.Port = 465;
                //     oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                //     EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                //     oSmtp.SendMail(oServer, oMail);
                //     Session["Message"] = "MailSent";
                //  Response.Redirect("RegistrationPage.aspx", true);

            }
            catch(Exception ex)
            { }
            //   Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");
        }


        

    }
}