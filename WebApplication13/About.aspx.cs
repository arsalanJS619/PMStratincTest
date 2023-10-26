using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication13
{
    public partial class About : Page
    {
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

            //else if (Session["IsStudent"].ToString() == "0")
            //{
            //    Progress.Visible = false;
            //    StuInfo.Visible = false;
            //}

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