using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication13
{
    public partial class AdminQueries : System.Web.UI.Page
    {
        protected void SubmitForm(object sender, EventArgs e)
        {
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            //       UI.InsertStudent(Session["UserID"].ToString(), Session["UserID"].ToString() + "-" + CountryC.Text, Name.Value, FName.Value, City.Value, CountryC.Text, email3.Value, HQual_Acqrd.SelectedValue, Maj_Subj.SelectedValue, Grade.SelectedValue, GPA.Text, TotalYrStudy.Value, LastInstAttend.Value, Eng_yrs_studied.Value, Eng_written.SelectedValue, Eng_spoken.SelectedValue);

            //     DDLCountry.Visible = false;
            //   countrySpan.Visible = false;
        }
        protected void LogoutUser(object sender, EventArgs e)
        {
            Session["User"] = null;

            UserLogged.Visible = false;
            LogoutHeader.Visible = false;
       //     LoginHeader.Visible = true;
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
            if (Session["User"] != null)
            {
                if (Session["IsAdmin"].ToString() == "True")
                {
                    AdminUsrMng.Visible = true;
                    AdmProgress.Visible = true;
                    AdmQueries.Visible = true;
                    AdmReports.Visible = true;

                    //     UsrAbout.Visible = false;
                    //   UsrStudent.Visible = false;
                    //      UsrSettlement.Visible = false;
                    //    UsrImmigration.Visible = false;
                    //  UsrContact.Visible = false;
                }
                else
                {
                    AdminUsrMng.Visible = false;
                    AdmProgress.Visible = false;
                    AdmQueries.Visible = false;
                    AdmReports.Visible = false;

                    //        UsrAbout.Visible = true;
                    //      UsrStudent.Visible = true;
                    //    UsrSettlement.Visible = true;
                    //  UsrImmigration.Visible = true;
                    //UsrContact.Visible = true;
                }


                //   LoginHeader.Visible = false;
               

            }

            UserLogged.Visible = true;
            UserLogged.InnerText = Session["User"].ToString();
            LogoutHeader.Visible = true;
        }
    }
}