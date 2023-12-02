using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using System.Threading.Tasks;
//using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class UserInfo
    {
        public string GetData()
        {
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string str = "select * from User_Info";
            DB.OpenDataBase();
            DataTable dt =  DB.ExecuteDataTable(str);
            DB.CloseDataBase();
            foreach (DataRow row in dt.Rows)
            {

            // String s2 = ""; 
               string s1 = row[0].ToString();
            }
            return "";
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        public DataTable CheckRegCode(string _RegCode)
        {
            
            string str = "select * from User_Info where RegCode = " + "'"+ _RegCode+"'";
            clsDataAccessLayer DB = new clsDataAccessLayer();
            DB.OpenDataBase();
            DataTable dt = DB.ExecuteDataTable(str);
            DB.CloseDataBase();
            return dt;


        }

        public long  InsertUserData(string UserName,string Email, string strPassword, string IsStu, string IsImig, string IsSett,string RegCode)
        {
            long lrt = 0;
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            
            string dates = "2023-09-10";
            
       //     string _strPassword =  EncodePasswordToBase64(strPassword);


            string str = "insert into User_Info (Name,Email,DOB,IsStudent,IsMigration,IsSettlement,AdminUser,Passwrd,CreateDate,UpdateDate,UserStatus,RegCode)" +
                //,DOB,IsMigration,IsStudent,IsSettlement,AdminUser,,CreateDate,UpdateDate,UserStatus)" +
                " values( "+"'"+UserName+"'"+","+"'"+ Email +"'"+ ","+"'"+ System.DateTime.Now + "'" + "," +IsStu+","+IsImig+","+IsSett+",0,"+"'"+strPassword+"'"+","+"'"+System.DateTime.Now+"'"+"," + "'"+ System.DateTime.Now + "'" +","+ 0+ "," +RegCode+")";
            DB.OpenDataBase();
            lrt = DB.ExecuteNonQuery(str);
            DB.CloseDataBase();
            //foreach (DataRow row in dt.Rows)
            //{
            //    string s1 = row[0].ToString();
            //}
            //   return false;// "";
            return lrt;
        }

        public long UpdateUserDataPasswordReset(string Email,string SetPaswdCode)
        {
            long lrt = 0;
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string dates = "2023-09-10";
            //     string _strPassword =  EncodePasswordToBase64(strPassword);


            string str = "update User_Info set ForgetPaswd = " + "'" + SetPaswdCode + "'" + " where Email = " + "'"+ Email + "'"; 
            DB.OpenDataBase();
            lrt = DB.ExecuteNonQuery(str);
            DB.CloseDataBase();
            //foreach (DataRow row in dt.Rows)
            //{
            //    string s1 = row[0].ToString();
            //}
            //   return false;// "";
            return lrt;
        }

        public DataTable AuthenticateLoginUser(string LEmail, string LPaswd)
        {
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string str = "select * from User_Info where Email= " + "'" + LEmail + "'" + " and Passwrd = " + "'" +LPaswd+"'" + " and UserStatus = 1";
            DB.OpenDataBase();
            DataTable dt = DB.ExecuteDataTable(str);
            DB.CloseDataBase();
            return dt;
            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public DataTable CheckRecordStuStage2(string _ApplicantID)
        {
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string str1 = "select * from StudentStage2 where ApplicantID = " + "'" + _ApplicantID + "'";
            DB.OpenDataBase();
            DataTable dt = DB.ExecuteDataTable(str1);
            return dt;

        }

        public DataTable CheckRecordStuStage3(string _ApplicantID)
        {
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string str1 = "select * from StudentStage3 where ApplicantID = " + "'" + _ApplicantID + "'";
            DB.OpenDataBase();
            DataTable dt = DB.ExecuteDataTable(str1);
            return dt;

        }



        public DataTable CheckRecordStuStage1(string _ApplicantID)
        {
            clsDataAccessLayer DB = new clsDataAccessLayer();
            string str = "select CI.CountryName as Country,US.FName as Name,SI.ApplicantID,SubmissionDate,SI.onlinForm,SI.SupportingDoc,SI.IELTSScore, "+
          "SI.ProcessingFee,SI.OurAction,SI.Remarks from StudentStage1 SI INNER JOIN UserStud_Info US on US.SIN_No = SI.ApplicantID inner join "+
          "Country_Info CI on CI.CountryCode = US.Country where SI.ApplicantID = " + "'" + _ApplicantID + "'";
            DB.OpenDataBase();
            DataTable dt = DB.ExecuteDataTable(str);
            return dt;
            
        }

        public long ExecuteQuery(string query)
        {
            clsDataAccessLayer DB = new clsDataAccessLayer();
            long lrt = 0;

            try
            {
              //  string str = "update UserStud_Info set Progress = " + "'" + _Progress + "'" + ", Comments = " + "'" + _comments + "'" + " where SIN_No = " + "'" + _SIN + "'";
                //    "(UserID, SIN_NO, FName, LName, City, Country, Email, HQual_Acqrd, Maj_Subj, Grade, GPA, TotalYrStudied, LastAcadInsAttended, EngYrStudied, Engwritten, Engspoken,FrenchYrsStudied,FrenchSpoken,FrenchWritten,EngTestPrepServiceReqd,FieldOfStudy,QualifToAcquire,StartSemester,StartSemesterYr,LastAcadInsAttended,TotalYrStudied,Progress,CreateDate)" +
                //" values (" + _UID + "," + "'" + _SIN + "'" + "," + "'" + _Name + "'" + "," + "'" + _FName + "'" + "," + "'" + _City + "'" + "," + "'" + _CountryC + "'" + "," + "'" + _email3 + "'" + "," + "'" + _HQual_Acqrd + "'" + "," + "'" + _Maj_Subj + "'" + "," + "'" + _Grade + "'" + "," + "'" + _GPA + "'" + "," + "'" + _TotalYrStudy + "'" + "," + "'" + _LastInstAttend + "'" + "," + "'" + _Eng_yrs_studied + "'" + "," + "'" + _Eng_written + "'" + "," + "'" + _Eng_spoken + "'" + "," + "'" + _FrenchYrsStudied + "'" + "," + "'" + _FrenchSpoken + "'" + "," + "'" + _FrenchWritten + "'" + "," + a + "," + "'" + _FieldOfStudy + "'" + "," + "'" + _QualifToAcquire + "'" + "," + "'" + _StartSemester + "'" + "," + "'" + _StartSemesterYr + "'" + "," + "'" + _LastAcadInsAttended + "'" + "," + "'" + _TotalYrStudied + "'" + "," + "'" + _Progress + "'" + "," + "'" + System.DateTime.Now.ToString("dd-MM-yyyy") + "'" + ")";
                DB.OpenDataBase();
                lrt = DB.ExecuteNonQuery(query);
                DB.CloseDataBase();
            }
            catch (Exception ex)
            {

            }
            return lrt;
        }

        public long InsertUpdateStuStage3(string _ApplicantID, string _AcceptanceDate,string _LetterIssued,string _SemesterStartDate,string _FeeToBePaidBy,string _Remarks,string Command)
        {
            long lrt = 0;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            Dictionary<string, object> dicObjParams = new Dictionary<string, object>();
            try
            {
                if (Command == "Insert")
                {
                    string str = "insert into StudentStage3 (ApplicantID,AcceptanceDate,LetterIssued,SemesterStartDate,FeeToBePaidBy,Remarks) " +
                             " values(" + "'" + _ApplicantID + "'" + "," + "'" + _AcceptanceDate + "'" + "," + "'" + _LetterIssued + "'" + "," + "'" + _SemesterStartDate + "'" + "," + "'" + _FeeToBePaidBy + "'" + "," + "'" + _Remarks + "'" + ")";
                    DB.OpenDataBase();
                    lrt = DB.ExecuteNonQuery(str);
                    DB.CloseDataBase();
                }

                else if (Command == "Update")
                {
                    string str = "update StudentStage3 set AcceptanceDate = " + "'" + _AcceptanceDate + "'" + ", LetterIssued = " + "'" + _LetterIssued + "'" + " ,SemesterStartDate = " + "'" + _SemesterStartDate + "'"
                        + " ,FeeToBePaidBy = " + "'" + _FeeToBePaidBy + "'" + " ,Remarks = " + "'" + _Remarks + "'" + " where ApplicantID = "+"'"+_ApplicantID+"'";
                    DB.OpenDataBase();
                    lrt = DB.ExecuteNonQuery(str);
                    DB.CloseDataBase();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.CloseDataBase();
            }

            return lrt;
        }

        public long InsertUpdateStuStage2(string _ApplicantID, string _InstSubmissionDate, string _InPrgress, string _Status, string _Remarks, string Command)
        {
      //      InstSubmissionDate]
      //,[InPrgress]
      //,[Status]
            long lrt = 0;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            Dictionary<string, object> dicObjParams = new Dictionary<string, object>();
            try
            {
                if (Command == "Insert")
                {
                    string str = "insert into StudentStage2 (ApplicantID,InstSubmissionDate,InPrgress,Status,Remarks) " +
                             " values(" + "'" + _ApplicantID + "'" + "," + "'" + _InstSubmissionDate + "'" + "," + "'" + _InPrgress + "'" + "," + "'" + _Status + "'" + "," + "'" + _Remarks  + "'" + ")";
                    DB.OpenDataBase();
                    lrt = DB.ExecuteNonQuery(str);
                    DB.CloseDataBase();
                }

                else if (Command == "Update")
                {
                    string str = "update StudentStage2 set InstSubmissionDate = " + "'" + _InstSubmissionDate + "'" + ", InPrgress = " + "'" + _InPrgress + "'" + " ,Status = " + "'" + _Status + "'"
                        + " ,Remarks = " + "'" + _Remarks + "'" + " where ApplicantID = "+ "'"+_ApplicantID+"'";
                    DB.OpenDataBase();
                    lrt = DB.ExecuteNonQuery(str);
                    DB.CloseDataBase();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.CloseDataBase();
            }

            return lrt;
        }

        public long InsertUpdateStuStage1(string _ApplicantID,string _SubmissionDate,string _onlinForm,string _SupportingDoc,string _IELTSScore,string _ProcessingFee,string _OurAction,string _Remarks,string Command)
        {
            long lrt = 0;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            Dictionary<string, object> dicObjParams = new Dictionary<string, object>();
            try
            {
                if (Command == "Insert")
                {
                    string str = "insert into StudentStage1 (ApplicantID,SubmissionDate,onlinForm,SupportingDoc,IELTSScore,ProcessingFee,OurAction,Remarks) " +
                             " values(" + "'" + _ApplicantID + "'" + ","  + "'" + _SubmissionDate + "'" + ","+ "'" + _onlinForm + "'" + "," + "'" + _SupportingDoc + "'" + "," + "'" + _IELTSScore + "'" + "," + "'" + _ProcessingFee + "'" + "," + "'" + _OurAction + "'" + "," + "'" + _Remarks + "'"+ ")";
                    DB.OpenDataBase();
                    lrt = DB.ExecuteNonQuery(str);
                    DB.CloseDataBase();
                }

                else if(Command=="Update")
                {
                    string str = "update StudentStage1 set SubmissionDate = " + "'" + _SubmissionDate + "'"  + ", onlinForm = " + "'"+ _onlinForm+ "'" + " ,SupportingDoc = " + "'"+ _SupportingDoc +"'"
                        + " ,IELTSScore = " + "'"+_IELTSScore+"'"+  " ,ProcessingFee = " +"'"+  _ProcessingFee +"'"+ " ,OurAction = " + "'"+ _OurAction + "'" + " ,Remarks = " + "'" + _Remarks +"'"+ " where ApplicantID ="+ "'"+_ApplicantID+"'";
                    DB.OpenDataBase();
                    lrt = DB.ExecuteNonQuery(str);
                    DB.CloseDataBase();
                }
               
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.CloseDataBase();
            }

            return lrt;
        }

        public DataTable GetUserStudentData(string _ApplicantID)
        {
            //  Dictionary<string, object> dicObjParams = new Dictionary<string, object>();
            DataTable dt = null;
            clsDataAccessLayer DB = new clsDataAccessLayer();

            try
            {
             //   int a = _EngTestPrepServiceReqd.ToString() == "Yes" ? 1 : 0;
                string str = "select * from  UserStud_Info where SIN_NO = " + "'" + _ApplicantID + "'";
                DB.OpenDataBase();
                dt = DB.ExecuteDataTable(str);
                DB.CloseDataBase();
            }
            catch(Exception ex)
            {

            }
            return dt;
        }
        
        public DataTable GetStuInfoByUserID(string UID)
        {
            clsDataAccessLayer DB = new clsDataAccessLayer();
            DataTable dt = null;
            try
            {
                //   int a = _EngTestPrepServiceReqd.ToString() == "Yes" ? 1 : 0;
                string str = "select * from  UserStud_Info where UserID = " + "'" + UID + "'";
                DB.OpenDataBase();
                dt = DB.ExecuteDataTable(str);
                DB.CloseDataBase();
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public long UpdateForms(string _SIN, string _Progress, string _comments)
        {
            long lrt = 0;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            Dictionary<string, object> dicObjParams = new Dictionary<string, object>();
            try
            {
                //   int a = _EngTestPrepServiceReqd.ToString() == "Yes" ? 1 : 0;
                string str = "update UserStud_Info set Progress = " + "'" + _Progress + "'" + ", Comments = " + "'" + _comments + "'" + " where SIN_No = " + "'" + _SIN + "'";
                //    "(UserID, SIN_NO, FName, LName, City, Country, Email, HQual_Acqrd, Maj_Subj, Grade, GPA, TotalYrStudied, LastAcadInsAttended, EngYrStudied, Engwritten, Engspoken,FrenchYrsStudied,FrenchSpoken,FrenchWritten,EngTestPrepServiceReqd,FieldOfStudy,QualifToAcquire,StartSemester,StartSemesterYr,LastAcadInsAttended,TotalYrStudied,Progress,CreateDate)" +
                //" values (" + _UID + "," + "'" + _SIN + "'" + "," + "'" + _Name + "'" + "," + "'" + _FName + "'" + "," + "'" + _City + "'" + "," + "'" + _CountryC + "'" + "," + "'" + _email3 + "'" + "," + "'" + _HQual_Acqrd + "'" + "," + "'" + _Maj_Subj + "'" + "," + "'" + _Grade + "'" + "," + "'" + _GPA + "'" + "," + "'" + _TotalYrStudy + "'" + "," + "'" + _LastInstAttend + "'" + "," + "'" + _Eng_yrs_studied + "'" + "," + "'" + _Eng_written + "'" + "," + "'" + _Eng_spoken + "'" + "," + "'" + _FrenchYrsStudied + "'" + "," + "'" + _FrenchSpoken + "'" + "," + "'" + _FrenchWritten + "'" + "," + a + "," + "'" + _FieldOfStudy + "'" + "," + "'" + _QualifToAcquire + "'" + "," + "'" + _StartSemester + "'" + "," + "'" + _StartSemesterYr + "'" + "," + "'" + _LastAcadInsAttended + "'" + "," + "'" + _TotalYrStudied + "'" + "," + "'" + _Progress + "'" + "," + "'" + System.DateTime.Now.ToString("dd-MM-yyyy") + "'" + ")";
                DB.OpenDataBase();
                lrt = DB.ExecuteNonQuery(str);
                DB.CloseDataBase();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.CloseDataBase();
            }

            return lrt;
        }

        //private bool IsValidEmail(string email)
        //{
        //    const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        //    var regex = new Regex(pattern, RegexOptions.IgnoreCase);
        //    return regex.IsMatch(email);
        //}

        public string fetchEmailByPasswordCode(string PaswdCode)
        {
            clsDataAccessLayer DB = new clsDataAccessLayer();
            DataTable dt = null;
            try
            {
                //   int a = _EngTestPrepServiceReqd.ToString() == "Yes" ? 1 : 0;
                string str = "select * from User_Info where ForgetPaswd = " + "'" + PaswdCode + "'";
                DB.OpenDataBase();
                dt = DB.ExecuteDataTable(str);
                DB.CloseDataBase();
            }
            catch (Exception ex)
            {

            }
            return dt.Rows[0]["Email"].ToString();
        }

        public long UpdatePasswordReset(string Email, string Paswd)
        {
           
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string str = "update User_Info set Passwrd = " + "'" + Paswd + "'" + " where Email = " + "'" + Email + "'";
            DB.OpenDataBase();
            long lrt = DB.ExecuteNonQuery(str);
            DB.CloseDataBase();
            
            return lrt;
        }

        public long UpdateStudent(string _UID, string _SIN, string _Name, string _FName, string _City, string _CountryC, string _email3, string _HQual_Acqrd, string _Maj_Subj, string _Grade, string _GPA, string _TotalYrStudy, string _LastInstAttend, string _Eng_yrs_studied, string _Eng_written, string _Eng_spoken, string _FrenchYrsStudied, string _FrenchSpoken, string _FrenchWritten, string _EngTestPrepServiceReqd, string _FieldOfStudy, string _QualifToAcquire, string _StartSemester, string _StartSemesterYr, string _LastAcadInsAttended, string _TotalYrStudied, string _Progress, string _CreateDate, string _Comments, string _StreetAddress, string _HouseAddress)
        {
            long lrt = 0;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            Dictionary<string, object> dicObjParams = new Dictionary<string, object>();
            try
            {
                int a = _EngTestPrepServiceReqd.ToString() == "Yes" ? 1 : 0;
                string str = "update UserStud_Info set FName = " + "'"+ _FName + "'" +", LName = " + "'" + _Name + "'" + ", City = "+"'" + _City +"'"+ " , Country = "+"'"+_CountryC+"'"+ 
                    " , Email = "+ "'"+_email3+"'"+ " , HQual_Acqrd = " +"'"+_HQual_Acqrd+"'"+ " ,Maj_Subj = "+"'"+_Maj_Subj+"'"+ " , Grade = "+"'"+_Grade+"'"+ " , GPA = "+"'"+_GPA+"'"+" , EngYrStudied = "+
                    "'"+_Eng_yrs_studied+"'"+ " , Engwritten = "+"'"+_Eng_written+"'"+" , Engspoken = "+"'"+_Eng_spoken+"'"+  " , FrenchYrsStudied = "+ "'" +_FrenchYrsStudied +"'"+ " ,FrenchSpoken = "+ "'" +_FrenchSpoken+"'"+ " ,FrenchWritten = " + "'" +_FrenchWritten +"'"+
                    " , EngTestPrepServiceReqd = "+ "'"+_EngTestPrepServiceReqd+"'"+ " , FieldOfStudy = "+"'"+_FieldOfStudy+"'"+ " , QualifToAcquire = "+"'"+_QualifToAcquire+"'"+ " , StartSemester ="+"'"+_StartSemester+"'"+
                    " , StartSemesterYr = "+"'"+_StartSemesterYr+"'"+ " , LastAcadInsAttended = " + "'" + _LastAcadInsAttended + "'" + " , TotalYrStudied = " + "'" + _TotalYrStudied + "'" + " , Progress = " + "'" + _Progress + "'" +
                    " ,CreateDate = " + "'" + System.DateTime.Now.ToString("yyyy-MMM-dd") + "'" + " ,Comments = " + "'" + _Comments + "'" + " ,StreetAddress = " + "'" + _StreetAddress + "'" + " ,HouseAddress = " +
                    "'" + _HouseAddress + "'" +" where USERID = "+_UID; 
               
              

                DB.OpenDataBase();
                lrt = DB.ExecuteNonQuery(str);
                DB.CloseDataBase();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.CloseDataBase();
            }

            return lrt;
        }

        public long InsertStudent(string _UID,string _SIN, string _Name,string _FName,string _City,string _CountryC,string _email3,string _HQual_Acqrd,string _Maj_Subj,string _Grade, string _GPA, string _TotalYrStudy, string _LastInstAttend, string _Eng_yrs_studied, string _Eng_written,string _Eng_spoken, string _FrenchYrsStudied, string _FrenchSpoken, string _FrenchWritten, string _EngTestPrepServiceReqd, string _FieldOfStudy, string _QualifToAcquire, string _StartSemester, string _StartSemesterYr, string _LastAcadInsAttended, string _TotalYrStudied, string _Progress,string _CreateDate, string _Comments, string _StreetAddress, string _HouseAddress)
        {
            long lrt = 0;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            Dictionary<string, object> dicObjParams = new Dictionary<string, object>();
            try
            {
                int a = _EngTestPrepServiceReqd.ToString() == "Yes" ? 1 : 0;
                string str = "insert into UserStud_Info " +
                    "(UserID, SIN_NO, FName, LName, City, Country, Email, HQual_Acqrd, Maj_Subj, Grade, GPA, EngYrStudied, Engwritten, Engspoken,FrenchYrsStudied,FrenchSpoken,FrenchWritten,EngTestPrepServiceReqd,FieldOfStudy,QualifToAcquire,StartSemester,StartSemesterYr,LastAcadInsAttended,TotalYrStudied,Progress,CreateDate,Comments,StreetAddress,HouseAddress)" +
                " values (" + _UID + "," + "'" + _SIN + "'" + "," + "'" + _Name + "'" + "," + "'" + _FName + "'" + "," + "'" + _City + "'" + "," + "'" + _CountryC + "'" + "," + "'" + _email3 + "'" + "," + "'" + _HQual_Acqrd + "'" + "," + "'" + _Maj_Subj + "'" + "," + "'" + _Grade + "'" + "," + "'" + _GPA + "'" + "," + "'" + _Eng_yrs_studied + "'" + "," + "'" + _Eng_written + "'" + "," + "'" + _Eng_spoken + "'" + "," + "'" + _FrenchYrsStudied + "'" + "," + "'" + _FrenchSpoken + "'" + "," + "'" + _FrenchWritten + "'" + ","  + a + "," + "'" + _FieldOfStudy + "'" + "," + "'" + _QualifToAcquire + "'" + "," + "'" + _StartSemester + "'" + "," +
                "'" + _StartSemesterYr + "'" + "," + "'" +_LastAcadInsAttended + "'" + "," + "'" + _TotalYrStudied + "'" + "," + "'" + _Progress + "'" + "," + "'" + System.DateTime.Now.ToString("yyyy-MM-dd")+"'"+","+"'"+ _Comments + "'" + "," +"'"+ _StreetAddress+"'"+","+"'"+ _HouseAddress+"'"+")";
        
                DB.OpenDataBase();
               lrt = DB.ExecuteNonQuery(str);
                DB.CloseDataBase();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.CloseDataBase();
            }

            return lrt;
        }
        public DataTable FetchCountry(string Country)
        {
            string str = "";
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            if (Country != "")
            {
                str = " and CountryName = " + "'" + Country + "'";
            }
            string str1 = "select CountryCode, CountryName, concat(CountryName, '-', CountryCode ) as CountryValue from Country_Info where 1=1 " +str+"  order by CountryName asc ";
            DB.OpenDataBase();
            DataTable dt = DB.ExecuteDataTable(str1);
            DB.CloseDataBase();
            return dt;
            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public string GetCountryByCode(string CountryCode)
        {
            DataTable dt = new DataTable();
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();
            string val = "";

            try
            {
                string str = "select CountryName from Country_Info where CountryCode = " + "'"+CountryCode+"'";
                DB.OpenDataBase();
                dt = DB.ExecuteDataTable(str);
                DB.CloseDataBase();


                val = dt.Rows[0]["CountryName"].ToString();
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.CloseDataBase();
            }
            return val;
        }

        public void insertCountry(int CC,string CN)
        {
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();

            try
            {
                string str = "insert into Country_Info (CountryCode,CountryName) values (" + CC + "," + "'" + CN + "')";
                DB.OpenDataBase();
                DB.ExecuteNonQuery(str);
                DB.CloseDataBase();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                DB.CloseDataBase();
            }
           

        }
        public long ActivateUser(string Code)
        {
            long lrt = 0;
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string str = "update User_Info set UserStatus=1 where RegCode = " + "'"+ Code+"'";

            DB.OpenDataBase();
            lrt = DB.ExecuteNonQuery(str);
            DB.CloseDataBase();
            return lrt;

        }



        public bool CheckForDuplicateEmail(string Email)
        {
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();
           
            string str = "select * from User_Info where Email= "+"'"+Email+"'";
            DB.OpenDataBase();
            DataTable dt = DB.ExecuteDataTable(str);
            DB.CloseDataBase();
            if (dt.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
