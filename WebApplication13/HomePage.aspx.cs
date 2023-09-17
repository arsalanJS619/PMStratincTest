using System;
using System.Security.Cryptography;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Text.RegularExpressions;
using System.Net.Mail;
using EASendMail;
using AuthorizeNet;
using System.Globalization;
using Stripe;

namespace WebApplication13
{
    public partial class HomePage : System.Web.UI.Page
    {
        const string CryptoKey = "pkn12byheni090eraszx2ea2315a1916";

        public static List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Contains(region.EnglishName)))
                {
                    cultureList.Add(region.EnglishName);
                }
            }
            return cultureList;
        }
        public class AesOperation
        {
            public static string EncryptString(string key, string plainText)
            {
                byte[] iv = new byte[16];
                byte[] array;

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
    


    private bool IsValidEmail(string email)
        {
            
            
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
        }
       
        protected void btnBack_Click(object sender, EventArgs e)
        {         
            
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            BusinessLogic.UserInfo UI = new UserInfo();

            string _Paswd = AesOperation.EncryptString(CryptoKey, LoginPassword.Value);
            DataTable dt = UI.AuthenticateLoginUser(LoginEmail.Value, _Paswd);

            if (dt.Rows.Count>0)
            {
                Session["User"] = "";
            }
        }

        protected void RegisterUser(object sender, EventArgs e)
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

                long val = UI.InsertUserData(RegUserName.Value, RegEmail.Value, Password, ChkEdu.Checked ? "1" : "0", ChkImg.Checked ? "1" : "0", ChkSett.Checked ? "1" : "0", _RegCode);

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

            //////////////////////////////////




          //  return false;



           
          
        }

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
            if (!IsPostBack)
            {
              //  AboutMenu.Visible = false;
                string host = HttpContext.Current.Request.Url.Host;

             //   string AbsPath = HttpContext.Current.Request.Url.AbsolutePath;

           //     string AbsUri = HttpContext.Current.Request.Url.AbsoluteUri;


             //   List<string> countries = GetCountryList();
           //     countries.Sort();
                //    ClientScript.GetPostBackEventReference(this, "");
           //     string Password = AesOperation.EncryptString("0c6da1977tc590eraszx2ea2315a1916", RegPassword.Value);
            }
           

          }

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