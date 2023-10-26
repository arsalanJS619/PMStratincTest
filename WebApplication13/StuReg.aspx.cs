using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication13
{
    public partial class StuReg : System.Web.UI.Page
    {

      


        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();

            if (!IsPostBack)
            {
                if (DDLCountry.Items.Count == 1 || DDLCountry.Items.Count == 0)
                {
                    // BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
                    DataTable DT = UI.FetchCountry("");
                    DDLCountry.DataSource = DT;
                    DDLCountry.DataBind();

                    //  DDLCountry.DataTextField = "CountryValue";
                    //   DDLCountry.SelectedValue = "CountryCode";
                    DDLCountry.DataTextField = "CountryName";
                    DDLCountry.DataValueField = "CountryName";

                    //    DDLCountry.Text = "arsalan";
                    // var code = DDLCountry.DataTextField.Split('/');
                    //   CountryCode.Text = code[0];
                    //    var s = DDLCountry.SelectedValue.Split('-');
                    //      DDLCountry.SelectedValue = s[0];// DDLCountry.SelectedValue.Split
                    // var s = DDLCountry.SelectedValue.Split('-');
                    //  DDLCountry.DataValueField = s[0];//

                    DDLCountry.DataBind();
                }
            
            if (Session["IsAdmin"] != null)
            {
                if (Session["IsAdmin"].ToString() == "True")
                {
                    APPIDLabel.Visible = true;
                    DDLProgress.Enabled = true;
                    StuRegRemarks.Disabled = false;
                    UsrProgress.Visible = false;

                    AppID.Visible = true;
                    //    BtnSubmit.Visible = false;
                    //    BtnUpdate.Visible = true;
                }

                else
                {
                    APPIDLabel.Visible = false;
                    UsrProgress.Visible = true;
                    DDLProgress.Enabled = false;
                    StuRegRemarks.Disabled = true;
                    //   BtnSubmit.Visible = true;
                    //  BtnUpdate.Visible = false;
                }

                if (Session["User"] != null)
                {
                    UserLogged.Visible = true;
                    UserLogged.InnerText = Session["User"].ToString();
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
                    //   StuInfo.Visible = false;
                }

                //else if (Session["IsStudent"].ToString() == "0")
                //{
                //    Progress.Visible = false;
                //    StuInfo.Visible = false;
                //}
                DataTable dt = new DataTable();
                if (Session["IsAdmin"].ToString() != "True")
                {
                    
                    dt = UI.GetStuInfoByUserID(Session["UserID"].ToString());
                    Name.Value = Session["User"].ToString();
                    FName.Value = Session["Father"].ToString();
                    email3.Value = Session["Email"].ToString();
                }
                if(dt.Rows.Count>0)
                {
                    BtnUpdate.Visible = true;
                    BtnSubmit.Visible = false;
                    CountryC.Value = dt.Rows[0]["Country"].ToString();

                    //ListItem listItem = DDLCountry.Items.IndexOf(.FindByText(UI.GetCountryByCode(CountryC.Text));
                    //if(listItem!=null)
                    //{
                    //    DDLCountry.ClearSelection();
                    //    listItem.Selected = true;
                    //}
                //    DDLCountry.SelectedItem.Text = "Australia";
         //           DDLCountry.SelectedValue = "1046";

                   DDLCountry.SelectedItem.Text = UI.GetCountryByCode(CountryC.Value);
               //   DDLCountry.Items.FindByValue(UI.GetCountryByCode(CountryC.Text)).Selected=true;
                  
                  HQual_Acqrd.Text = dt.Rows[0]["HQual_Acqrd"].ToString();
                  Maj_Subj.Text = dt.Rows[0]["Maj_Subj"].ToString();
                  Grade.Text = dt.Rows[0]["Grade"].ToString();
                  GPA.Text = dt.Rows[0]["GPA"].ToString();
                  Eng_yrs_studied.Value = dt.Rows[0]["EngYrStudied"].ToString();
                  Eng_spoken.Text = dt.Rows[0]["EngSpoken"].ToString();
                  Eng_written.Text = dt.Rows[0]["EngWritten"].ToString();
                  French_yrs_studied.Value = dt.Rows[0]["FrenchYrsStudied"].ToString();
                  FrenchSpoken.Text = dt.Rows[0]["FrenchSpoken"].ToString();
                  FrenchWritten.Text = dt.Rows[0]["FrenchWritten"].ToString();
                  EngTestPrepReq.Text = dt.Rows[0]["EngTestPrepServiceReqd"].ToString();
                  Field_of_study.Text = dt.Rows[0]["FieldOfStudy"].ToString();
                  Qualif_to_acquire.SelectedValue = dt.Rows[0]["QualifToAcquire"].ToString();
                  Start_Semester.SelectedValue = dt.Rows[0]["StartSemester"].ToString();
                  Start_Semester_Yr.Text = dt.Rows[0]["StartSemesterYr"].ToString();
                  LastInstAttend.Value = dt.Rows[0]["LastAcadInsAttended"].ToString();
                  TotalYrStudy.Value = dt.Rows[0]["TotalYrStudied"].ToString();
                  DDLProgress.SelectedValue = dt.Rows[0]["Progress"].ToString();
                  StuRegRemarks.Value = dt.Rows[0]["Comments"].ToString();
                  StreetAddress.Value = dt.Rows[0]["StreetAddress"].ToString();
                  HouseAddress.Value = dt.Rows[0]["HouseAddress"].ToString();
                }
                else
                {
                    BtnSubmit.Visible = true;
                    BtnUpdate.Visible = false;
                }

                //UserLogged.Visible = true;
                //UserLogged.InnerText = "Hi " + Session["User"].ToString();
                //LogoutHeader.Visible = true;
                //DDLCountry.SelectedIndex = -1;
               
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
            }
            //  string s = Name.Value;
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

        bool btnsubmitclick = false;

        //private void BtnSubmit_Click(object sender, EventArgs e)
        //{
        //    btnsubmitclick = true;
        //  //  button1WasClicked = true;
        //}

        protected void UpdateForm(object sender, EventArgs e)
        {
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            long lrt = 0;
            string addr = HouseAddress.Value;
          
                string ENgTestPrepReq = EngTestPrepReq.SelectedValue.ToString() == "Yes" ? "1" : "0";
                lrt = UI.UpdateStudent(Session["UserID"].ToString(), Session["UserID"].ToString() + "-" + CountryC.Value, Name.Value, FName.Value, StreetAddress.Value + HouseAddress.Value, CountryC.Value,
                    email3.Value, HQual_Acqrd.SelectedValue, Maj_Subj.SelectedValue, Grade.SelectedValue, GPA.Text, TotalYrStudy.Value, LastInstAttend.Value, Eng_yrs_studied.Value,
                    Eng_written.SelectedValue, Eng_spoken.SelectedValue, French_yrs_studied.Value, FrenchSpoken.SelectedValue.ToString(), FrenchWritten.SelectedValue.ToString(), ENgTestPrepReq,
                     Field_of_study.SelectedValue.ToString(), Qualif_to_acquire.SelectedValue.ToString(), Start_Semester.SelectedValue.ToString(), Start_Semester_Yr.SelectedValue.ToString(), LastInstAttend.Value, TotalYrStudy.Value, DDLProgress.SelectedItem.Text, DateTime.Now.ToString("dd-MMM-yyyy"), StuRegRemarks.Value, StreetAddress.Value, HouseAddress.Value);
           // }
         //   DDLCountry.Visible = false;
            //  countrySpan.Visible = false;

            if (lrt > 0)
            {
                Response.Redirect(string.Format("ErrorPage.aspx?id={0}", "Record Submitted successfully"));
            }


        }

        protected void SubmitForm(object sender, EventArgs e)
        {
           
                // btnsubmitclick = true;
              
                    BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
                    long lrt = 0;

                    if (Session["IsAdmin"].ToString() == "True")
                    {
                        lrt = UI.UpdateForms(AppID.Text, DDLProgress.SelectedValue, StuRegRemarks.Value);

                    }
                    else
                    {
                string ENgTestPrepReq = EngTestPrepReq.SelectedValue.ToString() == "Yes" ? "1" : "0";
                        lrt = UI.InsertStudent(Session["UserID"].ToString(), Session["UserID"].ToString() + "-" + CountryC.Value, Name.Value, FName.Value, StreetAddress.Value + HouseAddress.Value, CountryC.Value,
                            email3.Value, HQual_Acqrd.SelectedValue, Maj_Subj.SelectedValue, Grade.SelectedValue, GPA.Text, TotalYrStudy.Value, LastInstAttend.Value, Eng_yrs_studied.Value,
                            Eng_written.SelectedValue, Eng_spoken.SelectedValue, French_yrs_studied.Value, FrenchSpoken.SelectedValue.ToString(), FrenchWritten.SelectedValue.ToString(), ENgTestPrepReq,
                             Field_of_study.SelectedValue.ToString(), Qualif_to_acquire.SelectedValue.ToString(), Start_Semester.SelectedValue.ToString(), Start_Semester_Yr.SelectedValue.ToString(), LastInstAttend.Value, TotalYrStudy.Value, DDLProgress.SelectedItem.Text,DateTime.Now.ToString("dd-MMM-yyyy"),StuRegRemarks.Value,StreetAddress.Value,HouseAddress.Value);
                    }
                    DDLCountry.Visible = false;
                  //  countrySpan.Visible = false;

                    if (lrt > 0)
                    {
                        Response.Redirect(string.Format("ErrorPage.aspx?id={0}", "Record Submitted successfully"));
                    }
               
            //    btnsubmitclick = false;
            
        }

        //private void BtnUpdate_Click(object sender, EventArgs e)
        //{
        //    button1WasClicked = true;
        //}

   
        protected void GetApplicationData(object sender, EventArgs e)
        {

            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            DataTable dt = UI.GetUserStudentData(AppID.Text);

            Name.Value = dt.Rows[0]["FName"].ToString();
            FName.Value = dt.Rows[0]["LName"].ToString();
    //  dt.Rows[0]["City"]
            dt.Rows[0]["Country"].ToString();
            dt.Rows[0]["Email"].ToString();
         HQual_Acqrd.SelectedValue =   dt.Rows[0]["HQual_Acqrd"].ToString();
         Maj_Subj.SelectedValue =   dt.Rows[0]["Maj_Subj"].ToString();
         Grade.SelectedValue =   dt.Rows[0]["Grade"].ToString();
         GPA.Text =   dt.Rows[0]["GPA"].ToString();
         Eng_yrs_studied.Value =   dt.Rows[0]["EngYrStudied"].ToString();
         Eng_spoken.SelectedValue =   dt.Rows[0]["EngSpoken"].ToString();
         Eng_written.SelectedValue =   dt.Rows[0]["EngWritten"].ToString();
         French_yrs_studied.Value=   dt.Rows[0]["FrenchYrsStudied"].ToString();
         FrenchSpoken.SelectedValue =   dt.Rows[0]["FrenchSpoken"].ToString();
         FrenchWritten.SelectedValue=   dt.Rows[0]["FrenchWritten"].ToString();
         EngTestPrepReq.SelectedValue =   dt.Rows[0]["EngTestPrepServiceReqd"].ToString();
         Field_of_study.SelectedValue=   dt.Rows[0]["FieldOfStudy"].ToString();
         Qualif_to_acquire.SelectedValue=   dt.Rows[0]["QualifToAcquire"].ToString();
          Start_Semester.SelectedValue=  dt.Rows[0]["StartSemester"].ToString();
         Start_Semester_Yr.SelectedValue=   dt.Rows[0]["StartSemesterYr"].ToString();
         LastInstAttend.Value=   dt.Rows[0]["LastAcadInsAttended"].ToString();
         TotalYrStudy.Value=   dt.Rows[0]["TotalYrStudied"].ToString();
         DDLProgress.SelectedValue=   dt.Rows[0]["Progress"].ToString();
         //   dt.Rows[0]["CreateDate"].ToString();
         StuRegRemarks.Value=   dt.Rows[0]["Comments"].ToString();
            //  dt.Rows[0]["StreetAddress"]
            //   dt.Rows[0]["HouseAddress"]

            DDLCountry.Visible = false;
        //    countrySpan.Visible = false;

            //if (lrt > 0)
            //{
            //    Response.Redirect(string.Format("ErrorPage.aspx?id={0}", "Record Submitted successfully"));
            //}
        }

            protected void CallMe(object sender, EventArgs e)
        {
            BusinessLogic.UserInfo UI = new BusinessLogic.UserInfo();
            DataTable dt = UI.FetchCountry(DDLCountry.SelectedValue);
            //    var s = DDLCountry.SelectedValue.Split('-');
            CountryC.Value = dt.Rows[0]["CountryCode"].ToString();// s[1];
           
         //   CountryCode.Text = s[0];// DDLCountry.SelectedValue.spl "CountryCode";
        }
    }
}