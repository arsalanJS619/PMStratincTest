using System;
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
    public partial class PasswordReset : System.Web.UI.Page
    {
        const string CryptoKey = "pkn12byheni090eraszx2ea2315a1916";

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
        }

        protected void SendUrlPaswdReset(object sender, EventArgs e)
        {
            Label1.InnerText = "";
            if(TxtEmail.Value == "" || TxtPaswd.Value == "" || TxtCnfmPaswd.Value == "" || (TxtPaswd.Value != TxtCnfmPaswd.Value))
            {
                Label1.InnerText = "Please Enter all values correctly";
            }
            else
            {
                BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();

                string Password = AesOperation.EncryptString(CryptoKey, TxtPaswd.Value);

                long lrt = UI.UpdatePasswordReset(TxtEmail.Value, Password);
                if(lrt>0)
                {
                    Label1.InnerText = "Password has been reset, please login";
                }
            }

        }

        private bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                //      LoginHeader.Visible = true;
                UserLogged.Visible = false;
                LogoutHeader.Visible = false;
                UsrStuInfo.Visible = false;

            }
            if (Session["User"] != null)
            {
                if (Session["IsAdmin"].ToString() == "1")
                {
                    //AdminUsrMng.Visible = true;
                    //  AdmProgress.Visible = true;
                    //    AdmQueries.Visible = true;
                    //      AdmReports.Visible = true;

                    UsrProgress.Visible = false;
                    UsrAbout.Visible = false;
                    //        UsrStudent.Visible = false;
                    //          UsrSettlement.Visible = false;
                    //            UsrImmigration.Visible = false;
                    UsrContact.Visible = false;
                }
                else
                {
                    //    AdminUsrMng.Visible = false;
                    //           AdmProgress.Visible = false;
                    //         AdmQueries.Visible = false;
                    //       AdmReports.Visible = false;

                    UsrProgress.Visible = true;
                    UsrAbout.Visible = true;
                    //    UsrStudent.Visible = true;
                    //      UsrSettlement.Visible = true;
                    //        UsrImmigration.Visible = true;
                    UsrContact.Visible = true;
                }


                UserLogged.Visible = true;
                UserLogged.InnerText = "Hi " + Session["User"].ToString();
                LogoutHeader.Visible = true;
            }
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


            var Url_string = HttpContext.Current.Request.Url.AbsoluteUri.Split('?');

            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            string Email = UI.fetchEmailByPasswordCode(Url_string[1]);
            TxtEmail.Value = Email;


        }

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
    }
}