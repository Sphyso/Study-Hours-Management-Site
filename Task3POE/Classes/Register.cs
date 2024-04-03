using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TaskLibrary;

namespace Task3POE
{
    class Register
    {
        //Class library object
        static ModuleLib modLib = new ModuleLib();
        SqlConnection conn = modLib.getConnection();

        public int studentNum { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string password { get; set; }

        public Register()
        {
            studentNum = 0;
            name = "none";
            surname = "none";
            age = 0;
            password = "none";
        }
        public Register(int StudentNo, string Name, string Surname, int Age, string Password)
        {
            studentNum = StudentNo;
            name = Name;
            surname = Surname;
            age = Age;
            password = Password;
        }
        //Registering students
        public void addStudent(ref int rowCount, ref string exceptionMsg)
        {
            try
            {
                SqlCommand insertCom = new SqlCommand($"INSERT INTO RegistrationTB(StudentNum,Name,Surname,Age,Password) VALUES({studentNum}, '{name}', '{surname}', {age}, '{password}')", conn);

                conn.Open();
                rowCount = insertCom.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                exceptionMsg = ex.Message;
            }

        }
        //Gets registration information from RegistrationTB based on the student number
        public void getRegisterInfo(int studNo)
        {
            SqlDataAdapter selectLine = new SqlDataAdapter($"SELECT * FROM RegistrationTB WHERE StudentNum = {studNo}", conn);
            DataTable dTable = new DataTable();
            DataRow dRow;

            try
            {
                conn.Open();
                selectLine.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    dRow = dTable.Rows[0];
                    studentNum = (int)dRow[0];
                    name = (string)dRow[1];
                    surname = (string)dRow[2];
                    age = (int)dRow[3];
                    password = (string)dRow[4];
                }
                else
                {
                    studentNum = 0;
                    name = "none";
                    surname = "none";
                    age = 0;
                    password = "none";
                }
                conn.Close();
            }
            catch (Exception )
            {

                throw;
            }
        }
        //Decryps password
        public string decodeFrom64(string hashedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(hashedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
