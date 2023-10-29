using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication13
{
    public partial class ContactPage : System.Web.UI.Page
    {
        protected void LogoutUser(object sender, EventArgs e)
        {
            Session["User"] = null;

            UserLogged.Visible = false;
            LogoutHeader.Visible = false;
            //   LoginHeader.Visible = true;
            UserLogged.InnerText = "";// DR["Email"].ToString();

            //UsrSettlement.Visible = true;
            //UsrStudent.Visible = true;
            //UsrImmigration.Visible = true;
            //UsrContact.Visible = true;
            //UsrAbout.Visible = true;

            //AdminUsrMng.Visible = false;
            //AdmProgress.Visible = false;
            //AdmQueries.Visible = false;
            //AdmReports.Visible = false;

            Response.Redirect("HomePage.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
              //  LoginHeader.Visible = true;
                UserLogged.Visible = false;
                LogoutHeader.Visible = false;

            }
            if (Session["User"] != null)
            {
                if (Session["IsAdmin"].ToString() == "1")
                {
                    AdminUsrMng.Visible = true;
                    AdmProgress.Visible = true;
                    AdmQueries.Visible = true;
                    AdmReports.Visible = true;

                    UsrAbout.Visible = false;
                    UsrStudent.Visible = false;
                    UsrSettlement.Visible = false;
                    UsrImmigration.Visible = false;
                    UsrContact.Visible = false;
                }

                else
                {
                    AdminUsrMng.Visible = false;
                    AdmProgress.Visible = false;
                    AdmQueries.Visible  = false;
                    AdmReports.Visible  = false;

                    UsrAbout.Visible = true;
                    UsrStudent.Visible = true;
                    UsrSettlement.Visible = true;
                    UsrImmigration.Visible = true;
                    UsrContact.Visible = true;
                }


             //   LoginHeader.Visible = false;
                UserLogged.Visible = true;
                UserLogged.InnerText = Session["User"].ToString();
                LogoutHeader.Visible = true;

            }

        }
    }
}