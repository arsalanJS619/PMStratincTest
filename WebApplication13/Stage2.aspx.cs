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

namespace WebApplication13
{
    public partial class Stage2 : System.Web.UI.Page
    {

        protected void LogoutUser(object sender, EventArgs e)
        {
            try
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

                //AdmAdmin.Visible = false;
                //AdmProgress.Visible = false;
                //AdmQueries.Visible = false;
                //AdmReports.Visible = false;

                Response.Redirect("~/HomePage.aspx");
            }
            catch(Exception ex)
            { }
        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            //       UI.InsertStudent(Session["UserID"].ToString(), Session["UserID"].ToString() + "-" + CountryC.Text, Name.Value, FName.Value, City.Value, CountryC.Text, email3.Value, HQual_Acqrd.SelectedValue, Maj_Subj.SelectedValue, Grade.SelectedValue, GPA.Text, TotalYrStudy.Value, LastInstAttend.Value, Eng_yrs_studied.Value, Eng_written.SelectedValue, Eng_spoken.SelectedValue);

            //     DDLCountry.Visible = false;
            //   countrySpan.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] != null)
                {
                    if (Session["IsAdmin"].ToString() == "1")
                    {
                        //   AdminUsrMng.Visible = true;
                        AdmProgress.Visible = true;
                        //AdmQueries.Visible = true;
                        //AdmReports.Visible = true;

                        UsrProgress.Visible = false;
                        //UsrAbout.Visible = false;
                        //UsrStudent.Visible = false;
                        //UsrSettlement.Visible = false;
                        //UsrImmigration.Visible = false;
                        //UsrContact.Visible = false;
                    }
                    else
                    {
                        //  AdminUsrMng.Visible = false;
                        AdmProgress.Visible = false;
                        //AdmQueries.Visible = false;
                        //AdmReports.Visible = false;

                        UsrProgress.Visible = true;
                        //UsrAbout.Visible = true;
                        //UsrStudent.Visible = true;
                        //UsrSettlement.Visible = true;
                        //UsrImmigration.Visible = true;
                        //UsrContact.Visible = true;
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
                UserLogged.Visible = true;
                UserLogged.InnerText = "Hi " + Session["User"].ToString();
                LogoutHeader.Visible = true;

                BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
                DataTable dt = UI.GetStuInfoByUserID(Session["UserID"].ToString());
                DataTable dt1 = new DataTable();
                if (dt.Rows.Count > 0)
                {
                    dt1 = UI.CheckRecordStuStage2(dt.Rows[0]["SIN_No"].ToString());
                }
                Session["Stage2Data"] = dt.Rows.Count;
                if (dt1.Rows.Count > 0)
                {
                    ApplicantID.Value = dt1.Rows[0]["ApplicantID"].ToString();
                    InstSubmissionDate.Value = DateTime.Parse(dt1.Rows[0]["InstSubmissionDate"].ToString()).ToString("dd-MMM-yyyy");//DateTime.Parse(dt1.Rows[0]["SubmissionDate"].ToString()).ToString("dd-MMM-yyyy");
                    InPrgress.Checked = dt1.Rows[0]["InPrgress"].ToString().ToLower() == "true" ? true : false;
                    Status.SelectedValue = dt1.Rows[0]["Status"].ToString();//.ToLower() == "true" ? true : false;
                    Stage2Remarks.Value = dt1.Rows[0]["Remarks"].ToString();//.ToLower() == "true" ? true : false;

                }
            }
            catch(Exception ex)
            {

            }




        }
    }
}