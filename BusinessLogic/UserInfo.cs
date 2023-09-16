using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using System.Threading.Tasks;

namespace  BusinessLogic
{
    public class UserInfo
    {
        public string GetData()
        {
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string str = "select * from User_Info";
            DB.OpenDataBase();
            DataTable dt =  DB.ExecuteDataTable(str);
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

        public long  InsertUserData(string UserName,string Email, string strPassword, string IsStu, string IsImig, string IsSett)
        {
            long lrt = 0;
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();

            string dates = "2023-09-10";
       //     string _strPassword =  EncodePasswordToBase64(strPassword);


            string str = "insert into User_Info (Name,FName,Email,DOB,IsStudent,IsMigration,IsSettlement,AdminUser,Passwrd,CreateDate,UpdateDate,UserStatus)" +
                //,DOB,IsMigration,IsStudent,IsSettlement,AdminUser,,CreateDate,UpdateDate,UserStatus)" +
                " values( "+"'"+UserName+"'"+",'Test'," +"'"+ Email +"'"+ ",'2023-09-10'," +IsStu+","+IsImig+","+IsSett+",0,"+"'"+strPassword+"'"+",'2023-09-10','2023-09-10'," + 0+")";
            DB.OpenDataBase();
            lrt = DB.ExecuteNonQuery(str);
            //foreach (DataRow row in dt.Rows)
            //{
            //    string s1 = row[0].ToString();
            //}
         //   return false;// "";
            return lrt;
        }

        public bool AuthenticateUser(string Email,string strPassword)
        {
            string pas = string.Empty;
            clsDataAccessLayer DB = new clsDataAccessLayer();

            for (int i = 0; i < strPassword.Length; i++)
            {
                char[] characters = strPassword.ToCharArray();
                pas = EncodePasswordToBase64(strPassword);             

            }
            string str = "select * from User_Info where Email= "+Email+ " and Passwrd= "+ pas;
            DB.OpenDataBase();
            DataTable dt = DB.ExecuteDataTable(str);
            foreach (DataRow row in dt.Rows)
            { 
                string s1 = row[0].ToString();
            }
            return false;// "";
        }
    }
}
