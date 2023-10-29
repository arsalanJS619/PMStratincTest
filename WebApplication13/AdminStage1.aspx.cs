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
    public partial class AdminStage1 : System.Web.UI.Page
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

            //AdmAdmin.Visible = false;
            //AdmProgress.Visible = false;
            //AdmQueries.Visible = false;
            //AdmReports.Visible = false;

            Response.Redirect("HomePage.aspx");
        }

        protected void GetStuStage1Data(object sender, EventArgs e)
        {
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            DataTable dt1 = UI.GetUserStudentData(ApplicantIDs.Text);
            ApplicantName.Text = dt1.Rows[0]["FName"].ToString();
            Country.Text = UI.GetCountryByCode(dt1.Rows[0]["Country"].ToString());
        //    = dt1.Rows[0]["Country"].ToString();
            SubmissionDates.Text = DateTime.Parse(dt1.Rows[0]["CreateDate"].ToString()).ToString("dd-MM-yyyy");
            DataTable dt= UI.CheckRecordStuStage1(ApplicantIDs.Text);
            Session["Stage1Data"] = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
               
                onlinForm.Checked = dt.Rows[0]["onlinForm"].ToString().ToLower() == "true" ? true:false;
                SupportingDoc.Checked = dt.Rows[0]["SupportingDoc"].ToString().ToLower() == "true" ? true : false;
                IELTSScore.Checked = dt.Rows[0]["IELTSScore"].ToString().ToLower() == "true" ? true : false;
                ProcessingFee.Checked = dt.Rows[0]["ProcessingFee"].ToString().ToLower() == "true" ? true : false;
                OurAction.SelectedValue = dt.Rows[0]["OurAction"].ToString();
                Stage1Remarks.Value = dt.Rows[0]["Remarks"].ToString();
            }
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
                UserLogged.Visible = true;
                UserLogged.InnerText = "Hi " + Session["User"].ToString();
                LogoutHeader.Visible = true;

            }


            UserLogged.Visible = true;
            UserLogged.InnerText = "Hi " +Session["User"].ToString();
            LogoutHeader.Visible=true;
            CESubmission.StartDate = System.DateTime.Now;
        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            long lrt = 0;
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            DataTable dt = UI.CheckRecordStuStage1(ApplicantIDs.Text);
            if (dt.Rows.Count > 0 )
            { 
                lrt = UI.InsertUpdateStuStage1(ApplicantIDs.Text, SubmissionDates.Text,(onlinForm.Checked ? 1 : 0).ToString(), (SupportingDoc.Checked ? 1 : 0).ToString(), (IELTSScore.Checked ? 1 : 0).ToString(), (ProcessingFee.Checked ? 1 : 0).ToString(), OurAction.SelectedValue.ToString(), Stage1Remarks.Value, "Update");
            }
            
            else if(dt.Rows.Count == 0)
            {
                lrt = UI.InsertUpdateStuStage1(ApplicantIDs.Text, SubmissionDates.Text, (onlinForm.Checked?1:0).ToString(), (SupportingDoc.Checked?1:0).ToString(), (IELTSScore.Checked?1:0).ToString(), (ProcessingFee.Checked?1:0).ToString(), OurAction.SelectedValue.ToString(), Stage1Remarks.Value, "Insert");

            }

            if(lrt>0)
            {
                DataTable dt1 = UI.GetUserStudentData(ApplicantIDs.Text);
                
                SmtpMail oMail = new SmtpMail("TryIt");

                // Set sender email address, please change it to yours
                oMail.From = "admin1_user@pmstratinc.com";

                // Set recipient email address, please change it to yours
                oMail.To = dt1.Rows[0]["Email"].ToString();// RegEmail.Value;// "arsalanjawed619@gmail.com";

                // Set email subject
                oMail.Subject = "Your Academic Progress";// test email from c#, ssl, 465 port";

                // Set email body
                string body = "Hello " + dt1.Rows[0]["FName"].ToString() + ",";
                body += "<br /><br />Please check your Updated status for Student Stage 1.";
           //     body += "<br /><a href = '" + RedirectRegPage + "'>Click here for Sign up</a>.";
             //   body += "<br /><br />Thanks";// "blah blah <a href='http://www.example.com'>blah</a>";
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


             //   Response.Redirect(Url_string[0] + "//" + Url_string[2] + "/RegistrationPage.aspx");
            }

         //   UI.CheckRecordStuStage1();

          //  long lrt = UI.InsertUpdateStuStage1(ApplicantID.Value,SubmissionDates.Text,onlinForm.Value,SupportingDoc.Value,IELTSScore.Value,ProcessingFee.Value,OurAction.SelectedValue.ToString(),Stage1Remarks.Value);
            
          //  if(lrt>0)
          //  { }
            //       UI.InsertStudent(Session["UserID"].ToString(), Session["UserID"].ToString() + "-" + CountryC.Text, Name.Value, FName.Value, City.Value, CountryC.Text, email3.Value, HQual_Acqrd.SelectedValue, Maj_Subj.SelectedValue, Grade.SelectedValue, GPA.Text, TotalYrStudy.Value, LastInstAttend.Value, Eng_yrs_studied.Value, Eng_written.SelectedValue, Eng_spoken.SelectedValue);

            //     DDLCountry.Visible = false;
            //   countrySpan.Visible = false;
        }
    }
}