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
    public partial class AdminStage2 : System.Web.UI.Page
    {
        protected void GetStuStage2Data(object sender, EventArgs e)
        {
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            DataTable _dt = UI.CheckRecordStuStage1(ApplicantID.Text);
            CESubmission.StartDate = DateTime.Parse(_dt.Rows[0]["SubmissionDate"].ToString());


            DataTable dt = UI.CheckRecordStuStage2(ApplicantID.Text);
            Session["Stage2Data"] = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                InstSubmissionDate.Text = dt.Rows[0]["SubmissionDate"].ToString();
                InPrgress.Checked = dt.Rows[0]["InPrgress"].ToString().ToLower() == "true" ? true : false;
                Status.SelectedValue = dt.Rows[0]["Status"].ToString();//.ToLower() == "true" ? true : false;
                Stage2Remarks.Value = dt.Rows[0]["Stage2Remarks"].ToString();//.ToLower() == "true" ? true : false;
        
                            }
        }
        protected void SubmitForm(object sender, EventArgs e)
        {            
            long lrt = 0;
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            //    DataTable dt = UI.CheckRecordStuStage1(ApplicantIDs.Text);
            DataTable dt = UI.CheckRecordStuStage2(ApplicantID.Text);
            if (dt.Rows.Count > 0)
            {
                lrt = UI.InsertUpdateStuStage2(ApplicantID.Text, InstSubmissionDate.Text, (InPrgress.Checked ? 1 : 0).ToString(), Status.SelectedValue.ToString(), Stage2Remarks.Value, "Update");
            }

            else if (dt.Rows.Count == 0)
            {
                lrt = UI.InsertUpdateStuStage2(ApplicantID.Text, InstSubmissionDate.Text, (InPrgress.Checked ? 1 : 0).ToString(), Status.SelectedValue.ToString(), Stage2Remarks.Value, "Insert");

            }

            if (lrt > 0)
            {
                DataTable dt1 = UI.GetUserStudentData(ApplicantID.Text);

                SmtpMail oMail = new SmtpMail("TryIt");

                // Set sender email address, please change it to yours
                oMail.From = "admin1_user@pmstratinc.com";

                // Set recipient email address, please change it to yours
                oMail.To = dt1.Rows[0]["Email"].ToString();// RegEmail.Value;// "arsalanjawed619@gmail.com";

                // Set email subject
                oMail.Subject = "Your Academic Progress";// test email from c#, ssl, 465 port";

                // Set email body
                string body = "Hello " + dt1.Rows[0]["FName"].ToString() + ",";
                body += "<br /><br />Please check your Updated status for Student Stage 2.";
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

            
        }



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
            UserLogged.InnerText = Session["User"].ToString();
            LogoutHeader.Visible = true;

        }
    }
}