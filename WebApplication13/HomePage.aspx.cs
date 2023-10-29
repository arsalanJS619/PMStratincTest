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
    public partial class HomePage : System.Web.UI.Page
    {
        const string CryptoKey = "pkn12byheni090eraszx2ea2315a1916";
        
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
                Response.Redirect("ForgetPassword.aspx");
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

                Response.Redirect("HomePage.aspx");
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
                            //            UsrSettlement.Visible  = false;
                            //UsrStudent.Visible     = false;
                            //          UsrImmigration.Visible = false;
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
                            //        UsrSettlement.Visible = true;
                            //UsrStudent.Visible = true;
                            //      UsrImmigration.Visible = true;
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
                        Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");

                    }
                }
            }
            catch(Exception ex)
            {

            }

            //else
            //{
            //  //  labelmsg.InnerText = "Email is empty or invalid";
            //}
        }
        protected void RegisterUser(object sender, EventArgs e)
        {
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
                        Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");


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
                            //  string DEC = AesOperation.DecryptString("GFTSFDGHHSABJAN",ENC);
                            #region send mail
                            SmtpMail oMail = new SmtpMail("TryIt");

                            // Set sender email address, please change it to yours
                            oMail.From = "admin1_user@pmstratinc.com";

                            // Set recipient email address, please change it to yours
                            oMail.To = RegEmail.Value;// "arsalanjawed619@gmail.com";

                            // Set email subject
                            oMail.Subject = "Registration Email";// test email from c#, ssl, 465 port";

                            // Set email body
                            string body = "Hello " + ",";
                            body += "<br /><br />Please click the following link to register";
                            body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
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


                            Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");

                            //RegLabel.Text = "Email sent with Registration Link";

                            //   return false;
                        }
                    }
                    #endregion

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

        protected void Page_Load(object sender, EventArgs ce)
        {
            try
            {
                labelmsg.InnerText = "";
                RegLabel.Text = "";

                if (Session["User"] == null)
                {
                    LoginHeader.Visible = true;
                    UserLogged.Visible = false;
                    LogoutHeader.Visible = false;
                    UsrStuInfo.Visible = false;

                }

                else
                {
                    UsrStuInfo.Visible = true;
                }

                if (Session["User"] != null)
                {
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
            catch(Exception ex)
            {

            }
            if (!IsPostBack)
            {
                
                    //  AboutMenu.Visible = false;
          //          string host = HttpContext.Current.Request.Url.Host;

                //   string AbsPath = HttpContext.Current.Request.Url.AbsolutePath;

                //     string AbsUri = HttpContext.Current.Request.Url.AbsoluteUri;


                //   List<string> countries = GetCountryList();
                //     countries.Sort();
                //    ClientScript.GetPostBackEventReference(this, "");
                //     string Password = AesOperation.EncryptString("0c6da1977tc590eraszx2ea2315a1916", RegPassword.Value);
            }


        }

        
    }
}