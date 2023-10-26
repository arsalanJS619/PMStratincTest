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

            Response.Redirect("HomePage.aspx");
        }
        private bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        protected void SendUrlPaswdReset(object sender, EventArgs e)
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

                    #region send mail
                    SmtpMail oMail = new SmtpMail("TryIt");

                    // Set sender email address, please change it to yours
                    oMail.From = "admin1_user@pmstratinc.com";

                    // Set recipient email address, please change it to yours
                    oMail.To = TxtEmail.Value;// RegEmail.Value;// "arsalanjawed619@gmail.com";

                    // Set email subject
                    oMail.Subject = "Password Reset";// test email from c#, ssl, 465 port";

                    // Set email body
                    string body = "Hello " + ",";
                    body += "<br /><br />Please click the following link to reset password";
                    body += "<br /><a href = '" + RedirectRegPage + "'>Click here</a>.";
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


                    //Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/PasswordReset.aspx");
                }
                Label1.InnerText = "Password Reset Link has been sent to your mail.";
            }
            else
            {
                Label1.InnerText = "Email is either empty or not in correct format";
            }
            //RegLabel.Text = "Email sent with Registration Link";

            //   return false;
        }

        #endregion

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