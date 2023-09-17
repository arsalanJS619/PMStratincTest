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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Message"] == "UserExist")
            {
                RegHeading.InnerText = "User Already Exist";
                Session["Message"] = null;
                //  Session["RegMailMsg"] = "false";
            }

            if (Session["Message"] == "MailSent")
            {
                RegHeading.InnerText = "Mail Sent with Registration URL";
                Session["Message"] = null;
            }

            if (HttpContext.Current.Request.Url.AbsoluteUri.Contains('?'))
            {
                var Value = HttpContext.Current.Request.Url.AbsoluteUri.Split('?');


                BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();

                DataTable dt = UI.CheckRegCode(Value[1].ToString());
                if (dt.Rows.Count == 1)
                {
                    long val = UI.ActivateUser(Value[1].ToString());
                    if (val == 1)
                    {
                        RegHeading.InnerText = "Registration Successful. Please Login";
                    }

                    else
                    {
                        RegHeading.InnerText = "Registration UnSuccessful. Please Register";
                    }


                }
            }
            //    }

        }
    }
}