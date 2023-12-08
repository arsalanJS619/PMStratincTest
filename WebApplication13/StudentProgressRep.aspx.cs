using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace WebApplication13
{
    public partial class StudentProgressRep : System.Web.UI.Page
    {
        protected void LogoutUser(object sender, EventArgs e)
        {
            try
            {
                Session["User"] = null;

                //     UserLogged.Visible = false;
                //     LogoutHeader.Visible = false;
                //     LoginHeader.Visible = true;
                //   UserLogged.InnerText = "";// DR["Email"].ToString();

                //UsrSettlement.Visible = true;
                //UsrStudent.Visible = true;
                //UsrImmigration.Visible = true;
                //UsrContact.Visible = true;
                //UsrAbout.Visible = true;

                //AdminUsrMng.Visible = false;
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
            BusinessLogic.UserInfo BI = new BusinessLogic.UserInfo();

        //    BI.RunDirectQuery();


            GeneralFunctions.clsGeneralFunctions cGF = new GeneralFunctions.clsGeneralFunctions();
         //   string msConnectionString = "Data Source = DESKTOP - OB15B6M\MSSQLSERVERTEST; Initial Catalog = dbo; Integrated Security = True";
            string msConnectionString = "Data Source=SQL5073.site4now.net;Initial Catalog=db_a7d988_pmstratinc;User Id=db_a7d988_pmstratinc_admin;Password=Allah@786@";
           SqlConnection con1 = new SqlConnection(msConnectionString);
        //          SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-OB15B6M\MSSQLSERVERTEST;Initial Catalog=dbo;Integrated Security=True;");
            //if (!IsPostBack)
            //{. 
            //        string strQry = "select SIN_NO,CountryName from StudDetailsView";
            //     string strQry = "select *  anfrom UserStud_Info";
            //  string strQry = "select *,CI.CountryName from UserStud_Info UI inner join  Country_Info CI on CI.CountryCode = UI.Country";
            string strQry = "";
            if (OurAction.SelectedValue == "All")
            {
                strQry = "select SIN_No,CountryName,StartSemesterYr,GPA,HQual_Acqrd,LastAcadInsAttended,QualifToAcquire,FieldOfStudy from StudDetailsView where CreateDate >= '" + DateTime.Parse(FromDate.Text).ToString("dd-MMM-yyyy") + "' and CreateDate <= '" + DateTime.Parse(ToDates.Text).ToString("dd-MMM-yyyy") + "'";

            }
            else
            {
                strQry = "select SIN_No,CountryName,StartSemesterYr,GPA,HQual_Acqrd,LastAcadInsAttended,QualifToAcquire,FieldOfStudy from StudDetailsView where Progress = " + OurAction.SelectedValue+" CreateDate >= '" + DateTime.Parse(FromDate.Text).ToString("dd-MMM-yyyy") + "' and CreateDate <= '" + DateTime.Parse(ToDates.Text).ToString("dd-MMM-yyyy") + "'";

            }
            //   string strQuery = "SELECT * FROM UserStud_Info US inner join Country_Info CI on CI.CountryCode = US.Country";
            SqlDataAdapter da = new SqlDataAdapter(strQry, con1);
                DataTable dt = new DataTable();
                da.Fill(dt);
            //   DataSet1 ds = new DataSet1();
            //   DataSet1
            //  dboDataSet ds  = new dboDataSet();

            //  
            DataSetTest ds = new DataSetTest();
       //     DataSet1 ds1 = new DataSet1();
           // dboDataSet4 ds = new dboDataSet4();
            ds.EnforceConstraints = false;
            ds.Tables["StudDetailsView"].Merge(dt);
              //  ds.Tables["StudDetailsView"].Merge(dt);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables["StudDetailsView"]);
            ReportViewer1.LocalReport.DataSources.Clear();
            
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("FromDate", FromDate.Text));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("ToDate", ToDates.Text));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("Status", OurAction.SelectedItem.Text));

            ReportViewer1.LocalReport.DataSources.Add(datasource);
            //}
    //        try
    //        {

    //            //CrystalDecisions.CrystalReports.Engine.ReportDocument rph = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
    //            //string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Stud2.rpt");

    //            //string Num = "17-1117";// "test";
    //            ////string _Status = "";
    //            ////string _FromDates = "";
    //            ////string _ToDates = "";

    //            //string msConnectionString = @"Server = DESKTOP-OB15B6M\MSSQLSERVERTEST; Database = dbo; Integrated Security = True;";
    //            string msConnectionString = "Data Source=SQL5073.site4now.net;Initial Catalog=db_a7d988_pmstratinc;User Id=db_a7d988_pmstratinc_admin;Password=Allah@786@";

    //            string _FromDates = FromDate.Text != "" ? " and CreateDate >= " + "'" + FromDate.Text + "'" : "";

    //            string _ToDates = ToDates.Text != "" ? " and CreateDate <= " + "'" + ToDates.Text + "'" : "";

    //            string _Status = OurAction.SelectedValue.ToString() != "All" ? " and Progress = " + "'" + OurAction.SelectedValue + "'" : "";

    //            SqlConnection Con = new SqlConnection(msConnectionString);
    //            //    SqlCommand command = new SqlCommand("Select * from UserStud_Info where FName = " + "'" + ApplicantName.Text + "'", Con);
    //            SqlCommand command = new SqlCommand(("Select ROW_NUMBER() OVER(order by CreateDate desc) AS SrNo,US.SIN_No,US.Progress,CC.CountryName,US.HQual_Acqrd,US.FieldOfStudy,US.LastAcadInsAttended,US.GPA,US.QualifToAcquire,US.StartSemester+' '+US.StartSemesterYr as Semester from UserStud_Info US " +
    //"inner join Country_Info CC on CC.CountryCode = US.Country " +
    // "where 1 = 1 " + _FromDates + _ToDates + _Status), Con);

    //            //
    //            //           Select ROW_NUMBER() OVER(order by CreateDate desc) AS SrNo, UserStud_Info.SIN_No,UserStud_Info.Progress,CC.CountryName,UserStud_Info.HQual_Acqrd,UserStud_Info.FieldOfStudy,UserStud_Info.LastAcadInsAttended,UserStud_Info.GPA,UserStud_Info.QualifToAcquire,UserStud_Info.CreateDate from  UserStud_Info
    //            //            inner join Country_Info CC on CC.CountryCode = UserStud_Info.Country
    //            //where 1 = 1 and UserStud_Info.CreateDate > {?FromDate}
    //            //           and UserStud_Info.CreateDate < {?ToDate}
    //            //           and UserStud_Info.Progress = {?Status}

    //            SqlDataAdapter sd = new SqlDataAdapter(command);
    //            DataSet s = new DataSet();
    //            sd.Fill(s);

    //            ReportDocument crp = new ReportDocument();
    //            crp.Load(Server.MapPath("~/Reports/StudentsReports.rpt"));
    //            // crp.SetDataSource(s.Tables["table"]);  // if its a same one table
    //            crp.SetDataSource(s.Tables["Table"]);
    //            crp.SetParameterValue("FromDate", FromDate.Text == "" ? "NIL" : DateTime.Parse(FromDate.Text).ToString("dd-MMM-yyyy"));
    //            crp.SetParameterValue("FDate", FromDate.Text == "" ? "NIL" : DateTime.Parse(FromDate.Text).ToString("dd-MMM-yyyy"));
    //            crp.SetParameterValue("ToDate", ToDates.Text == "" ? "NIL" : DateTime.Parse(ToDates.Text).ToString("dd-MMM-yyyy"));
    //            crp.SetParameterValue("TDate", FromDate.Text == "" ? "NIL" : DateTime.Parse(ToDates.Text).ToString("dd-MMM-yyyy"));
    //            //  crp.SetParameterValue("CreateDate", FromDate.Text == "" ? "NIL" : DateTime.Parse(CreateDate.Text).ToString("dd-MMM-yyyy"));

    //            crp.SetParameterValue("TStatus", OurAction.SelectedValue);

    //            crp.SetParameterValue("Status", OurAction.SelectedValue);


    //            //   Response.Redirect("ErrorPage.aspx");

    //            // CR1.ReportSource = crp;
    //            //  crp.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("aa.pdf"));

    //            crp.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Student");
    //            //    ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('aa.pdf');popup.focus();", true);

               

    //            //rph.Load(strRptPath);
    //            //rph.SetDataSource(s);
    //            //rph.SetParameterValue("FName", "");

    //            //     rph.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

    //            //    rph.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
    //            //  rph.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
    //            //rph.PrintToPrinter(1, false, 0, 0);


    //            //  string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Stud2.rpt");




    //            //      rph.SetParameterValue("FName", name);
    //            //     rph.RecordSelectionFormula();

    //            //Response.Write("<script>");
    //            //Response.Write("window.open('page.html','_blank')");
    //            //Response.Write("</script>");


    //            //    string name = "tahir";
    //            //    string msConnectionString = @"Server = DESKTOP-OB15B6M\MSSQLSERVERTEST; Database = dbo; Integrated Security = True;";
    //            //   // CrystalReport2 CR = new CrystalReport2();
    //            //    SqlConnection Con = new SqlConnection(msConnectionString);
    //            //    SqlCommand command = new SqlCommand("Select * from UserStud_Info where FName = "+ "'"+name+"'", Con);
    //            //    SqlDataAdapter sd = new SqlDataAdapter(command);
    //            //    DataSet s = new DataSet();
    //            //    sd.Fill(s);

    //            //   CrystalDecisions.CrystalReports.Engine.ReportDocument rph = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
    //            //   string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Stud1.rpt");
    //            //  //  rph.SetParameterValue("FName", name);
    //            //    rph.Load(strRptPath);

    //            //    rph.SetDataSource(s);
    //            //    rph.SetParameterValue("FName", name);


    //            ////  Response.Redirect("~/Reports/Stud1.rpt");
    //            //    rph.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "aaa");
    //            //    Response.End();
    //            //      rph.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("Reports"));
    //            //    ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('Reports/StudentReport.rpt');popup.focus();", true);

    //            //  rph.v
    //            //    rph.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Crystal");
    //            //     Response.End();


    //            //  Stream ss = rph.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
    //            //   ss.Flush();
    //            //     rph.Close();
    //            //   rph.Dispose();
    //            //  Response.Redirect("message.aspx");
    //            //  return File(ss, System.Net.Mime.MediaTypeNames.Application.Pdf);

    //            //CrystalReport2 CR2 = new CrystalReport2();
    //            //CR2.SetDataSource(s.Tables["table"]);
    //            //CrystalReportViewer1.ReportSource = CR2;
    //        }
    //        catch(Exception ex)
    //        {
    //            cGF.MessageBox(ex.Message, this);
    //        }

    //        finally
    //        {
    //            Response.End();
    //        }
        
                 }

        protected void Set_ToDate(object sender, EventArgs e)
        {
            try
            {
                if (FromDate.Text != "")
                {
                    CalendarExtender1.StartDate = Convert.ToDateTime(FromDate.Text);
                }
                else
                {
                    CalendarExtender1.StartDate = null;// Convert.ToDateTime(FromDate.Text) ;
                }
            }
            catch(Exception ex)
            {

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null)
                {
                    LoginHeader.Visible = true;
                    UserLogged.Visible = false;
                    LogoutHeader.Visible = false;

                }
                if (Session["User"] != null)
                {
                    if (Session["IsAdmin"].ToString() == "True")
                    {
                        AdminUsrMng.Visible = true;
                        AdmProgress.Visible = true;
                        AdmQueries.Visible = true;
                        AdmReports.Visible = true;

                        //     UsrAbout.Visible = false;
                        //   UsrProgress.Visible = false;
                        // UsrStuInfo.Visible = false;
                        //UsrStudent.Visible = false;
                        // UsrSettlement.Visible = false;
                        //   UsrImmigration.Visible = false;
                        //  UsrContact.Visible = false;
                    }
                    else
                    {
                        AdminUsrMng.Visible = false;
                        AdmProgress.Visible = false;
                        AdmQueries.Visible = false;
                        AdmReports.Visible = false;

                        //    UsrAbout.Visible = true;
                        //  UsrProgress.Visible = true;
                        //UsrStuInfo.Visible = true;
                        //     UsrStudent.Visible = true;
                        //     UsrSettlement.Visible = true;
                        //   UsrImmigration.Visible = true;
                        //  UsrContact.Visible = true;
                    }


                    LoginHeader.Visible = false;
                    UserLogged.Visible = true;
                    UserLogged.InnerText = "Hi " + Session["User"].ToString();
                    LogoutHeader.Visible = true;

                }
            }
            catch(Exception ex)
            { }
        }
    }
}