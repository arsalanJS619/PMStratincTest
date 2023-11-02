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
    public partial class StudentReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"]!=null)
            {
                UserLogged.Visible = true;
                UserLogged.InnerText = Session["User"].ToString();
                LogoutHeader.Visible = true;
            }
          //  Session["User"] = DR["Name"].ToString();
            //Session["IsStudent"] = DR["IsStudent"].ToString();
           if (Session["User"]==null)
           {
                UserLogged.Visible = false;
                UserLogged.InnerText = "";// Session["User"].ToString();
                LogoutHeader.Visible = false;

                Progress.Visible = false;
                StuInfo.Visible = false;
           }

           else if(Session["IsStudent"].ToString()=="0")
            {
                Progress.Visible = false;
                StuInfo.Visible = false;
            }
               
        }

        protected void LogoutUser(object sender, EventArgs e)
        {
            Session["User"] = null;

            //UserLogged.Visible = false;
            //LogoutHeader.Visible = false;
            //LoginHeader.Visible = true;
            //UserLogged.InnerText = "";// DR["Email"].ToString();

            //UsrSettlement.Visible = true;
            //UsrStudent.Visible = true;
            //UsrImmigration.Visible = true;
            //UsrContact.Visible = true;
            //UsrAbout.Visible = true;

            //AdmAdmin.Visible = false;
            //AdmProgress.Visible = false;
            //AdmQueries.Visible = false;
            //AdmReports.Visible = false;

            Response.Redirect("HomePage.aspx");
        }

        //protected void LoginUser(object sender, EventArgs e)
        //{
        //    BusinessLogic.UserInfo UI = new UserInfo();

        //    string _Paswd = AesOperation.EncryptString(CryptoKey, LoginPassword.Value);
        //    DataTable dt = UI.AuthenticateLoginUser(LoginEmail.Value, _Paswd);

        //    if (dt.Rows.Count == 1)
        //    {

        //        DataRow DR = dt.Rows[0];
        //        Session["User"] = DR["Name"].ToString();
        //        Session["IsStudent"] = DR["IsStudent"].ToString();
        //        if (DR["AdminUser"].ToString() == "True")
        //        {
        //            AdmAdmin.Visible = true;
        //            AdmProgress.Visible = true;
        //            AdmQueries.Visible = true;
        //            AdmReports.Visible = true;

        //            UsrSettlement.Visible = false;
        //            UsrStudent.Visible = false;
        //            UsrImmigration.Visible = false;
        //            UsrContact.Visible = false;
        //            UsrAbout.Visible = false;
        //        }
        //        else
        //        {
        //            AdmAdmin.Visible = false;
        //            AdmProgress.Visible = false;
        //            AdmQueries.Visible = false;
        //            AdmReports.Visible = false;

        //            UsrSettlement.Visible = true;
        //            UsrStudent.Visible = true;
        //            UsrImmigration.Visible = true;
        //            UsrContact.Visible = true;
        //            UsrAbout.Visible = true;
        //        }
        //        UserLogged.Visible = true;
        //        LogoutHeader.Visible = true;
        //        LoginHeader.Visible = false;
        //        UserLogged.InnerText = DR["Email"].ToString();


        //    }
        //    if (dt.Rows.Count == 0)
        //    {
        //        var Url_string = HttpContext.Current.Request.Url.AbsoluteUri.Split('/');
        //        Session["Message"] = "InvalidUser";
        //        Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");

        //    }
        //}
        //protected void RegisterUser(object sender, EventArgs e)
        //{
        //    var Url_string = HttpContext.Current.Request.Url.AbsoluteUri.Split('/');

        //    BusinessLogic.UserInfo UI = new UserInfo();
        //    bool UserExists = UI.CheckForDuplicateEmail(RegEmail.Value);

        //    if (UserExists == true)
        //    {
        //        // RegLabel.Text = "User Already Exists";
        //        Session["Message"] = "UserExist";
        //        Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");


        //        //    return false;
        //    }

        //    else
        //    {


        //        //   string RedirectRegPage = Url_string + "RegistrationPage?";

        //        Random rs = new Random();
        //        string _RegCode = rs.Next().ToString() + rs.Next().ToString();

        //        string RedirectRegPage = Url_string[0] + "//" + Url_string[2] + "/RegistrationPage?" + _RegCode;

        //        string Password = AesOperation.EncryptString(CryptoKey, RegPassword.Value);

        //        long val = UI.InsertUserData(RegUserName.Value, RegEmail.Value, Password, ChkEdu.Checked ? "1" : "0", ChkImg.Checked ? "1" : "0", ChkSett.Checked ? "1" : "0", _RegCode);

        //        if (val > 0)
        //        {
        //            //  string DEC = AesOperation.DecryptString("GFTSFDGHHSABJAN",ENC);
        //            #region send mail
        //            SmtpMail oMail = new SmtpMail("TryIt");

        //            // Set sender email address, please change it to yours
        //            oMail.From = "admin1_user@pmstratinc.com";

        //            // Set recipient email address, please change it to yours
        //            oMail.To = RegEmail.Value;// "arsalanjawed619@gmail.com";

        //            // Set email subject
        //            oMail.Subject = "Registration Email";// test email from c#, ssl, 465 port";

        //            // Set email body
        //            string body = "Hello " + ",";
        //            body += "<br /><br />Please click the following link to register";
        //            body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
        //            body += "<br /><br />Thanks";// "blah blah <a href='http://www.example.com'>blah</a>";
        //            oMail.HtmlBody = body;

        //            SmtpServer oServer = new SmtpServer("mail.pmstratinc.com");

        //            oServer.User = "admin1_user@pmstratinc.com";
        //            oServer.Password = "USer@1600";
        //            oServer.Port = 465;
        //            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
        //            EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
        //            oSmtp.SendMail(oServer, oMail);
        //            Session["Message"] = "MailSent";
        //            //  Response.Redirect("RegistrationPage.aspx", true);


        //            Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");

        //            //RegLabel.Text = "Email sent with Registration Link";

        //            //   return false;
        //        }
        //    }
        //    #endregion



        //}


        protected void CallFunction(object sender, EventArgs e)
        {
            
        }
    }
}