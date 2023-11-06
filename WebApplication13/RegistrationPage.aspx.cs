using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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
//using Stripe;

namespace WebApplication13
{
    public partial class RegistrationPage : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null)
            {
                //      LoginHeader.Visible = true;
                UserLogged.Visible = false;
                LogoutHeader.Visible = false;
                //     UsrStuInfo.Visible = false;

            }

            if (HttpContext.Current.Request.Url.AbsoluteUri.Contains('?'))
            {
                var Value = HttpContext.Current.Request.Url.AbsoluteUri.Split('?');


                BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();

                DataTable dt = UI.CheckRegCode(Value[1].ToString());
                if (dt.Rows.Count == 1)
                {
                    long val = UI.ActivateUser(Value[1].ToString());
                    if (val.ToString() == "1")
                    {
                        /////////////////////
                        ///
                        #region send mail
                        SmtpMail oMail = new SmtpMail("TryIt");

                        // Set sender email address, please change it to yours
                        oMail.From = "admin1_user@pmstratinc.com";

                        // Set recipient email address, please change it to yours
                        oMail.To = "admin1_user@pmstratinc.com"; ;// "arsalanjawed619@gmail.com";
                                                                  //   oMail.Cc = "admin1_user@pmstratinc.com";

                        // Set email subject
                        oMail.Subject = "Registration Successful ";// test email from c#, ssl, 465 port";

                        // Set email body
                        string body = "Hello Registration Successful " + ",";
                        body += "<br /><br />for " + dt.Rows[0]["Name"].ToString() + " ,Email is " + dt.Rows[0]["Email"].ToString();
                        //   body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
                        body += "<br /><br />Thanks";// "blah blah <a href='http://www.example.com'>blah</a>";
                        oMail.HtmlBody = body;

                        SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");

                        oServer.User = "admin1_user@pmstratinc.com";
                        oServer.Password = "USer@1600";
                        oServer.Port = 465;
                        oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                        EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                        oSmtp.SendMail(oServer, oMail);
                        Session["Message"] = "MailSent";
                        //  Response.Redirect("RegistrationPage.aspx", true);


                        //       Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");

                        //RegLabel.Text = "Email sent with Registration Link";

                        //   return false;
                   
                #endregion
                //////////////////////////////
                RegHeading.InnerText = "Registration Successful. Please Login";
                    }

                    else
                    {
                        RegHeading.InnerText = "Registration UnSuccessful. Please Register";
                    }


                }
            }

            else
            {

                if (Session["Message"].ToString() == "InvalidUser")
                {
                    RegHeading.InnerText = "User Authentication Failed";
                   // Session["Message"] = null;
                }

                if (Session["Message"].ToString() == "UserExist")
                {
                    RegHeading.InnerText = "User Already Exist";
                 //   Session["Message"] = null;
                    //  Session["RegMailMsg"] = "false";
                }

                if (Session["Message"].ToString() == "MailSent")
                {
                    RegHeading.InnerText = "Mail Sent with Registration URL";
                 //   Session["Message"] = null;
                }

            }
            //    }

        }
    }
}