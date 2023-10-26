using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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

            Response.Redirect("HomePage.aspx");
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