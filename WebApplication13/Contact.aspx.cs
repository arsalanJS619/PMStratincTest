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

                Response.Redirect("HomePage.aspx");
            }
            catch(Exception ex)
            { }
        }

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

                // Set email subject
                oMail.Subject = subject.Value;// "Your Academic Progress";// test email from c#, ssl, 465 port";

                // Set email body
                string body = "User Name : " + name.Value + ", " + " Email : " + email.Value + " ,subject : " + subject.Value + " , comments : " + comment.Value;// "Hello " + dt1.Rows[0]["FName"].ToString() + ",";
                                                                                                                                                                 //      body += "<br /><br />";
                                                                                                                                                                 //     body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
                                                                                                                                                                 //   body += "<br /><br />Thanks";// "blah blah <a href='http://www.example.com'>blah</a>";
                oMail.HtmlBody = body;

                SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");

                oServer.User = "admin1_user@pmstratinc.com";
                oServer.Password = "USer@1600";
                oServer.Port = 465;
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);
                Session["Message"] = "MailSent";
                //   DataTable dt1 = UI.GetUserStudentData(ApplicantID.Text);

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