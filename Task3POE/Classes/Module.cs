using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using TaskLibrary;

namespace Task3POE
{
    class Module
    {
        //Object for the class library
        static ModuleLib modLib = new ModuleLib();
        SqlConnection conn = modLib.getConnection();

        public int studentNo { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public double credits { get; set; }
        public double classHours { get; set; }
        public double selfStudyHours { get; set; }
        public string hoursSpentDate { get; set; }
        public string startDate { get; set; }
        public double hoursSpent { get; set; }
        public double hoursRemaining { get; set; }
        public double numOfWeeks { get; set; }
        public Register Tag { get; internal set; }

        public Module()
        {
            this.studentNo = 0;
            this.code = "None";
            this.name = "None";
            this.credits = 0;
            this.classHours = 0;
            this.selfStudyHours = 0;
            this.hoursSpentDate = "None";
            this.startDate = "None";
            this.hoursSpent = 0;
            this.hoursRemaining = 0;
        }

        public Module(int studentNo,string code, string name, double credits, double classHours, double selfStudyHours, string hoursSpentDate,
               double hoursSpent, double hoursRemaining)
        {
            this.studentNo = studentNo;
            this.code = code;
            this.name = name;
            this.credits = credits;
            this.classHours = classHours;
            this.selfStudyHours = selfStudyHours;
            this.hoursSpentDate = hoursSpentDate;
            this.hoursSpent = hoursSpent;
            this.hoursRemaining = hoursRemaining;
        }
        //Used to calculate self study hours
        public void addModule(ref int rowCount, ref string errorMsg)
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand($"INSERT INTO ModuleTB(StudentNum, ModuleCode, Modulename, Credits, ClassHours, SelfStudyHours, StudyHoursDate, HoursToStudy, HoursRemaining) values('{studentNo}','{code}', '{name}', '{credits}', '{classHours}', '{selfStudyHours.ToString().Replace(",", ".")}', '{hoursSpentDate}', '{hoursSpent}', '{hoursRemaining.ToString().Replace(",", ".")}')", conn);

                conn.Open();
                rowCount = insertCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                errorMsg = ex.Message;
            }
            
        }
        //Deletes a record based on the student number and module code.
        public void delete(int studNum, string moduleC, ref int rowCount, ref string errorMsg)
        {
            try
            {
                SqlCommand deleteCmd = new SqlCommand($"DELETE FROM ModuleTB WHERE StudentNum={studNum} and ModuleCode='{moduleC}'", conn);
                conn.Open();
                rowCount = deleteCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                errorMsg = ex.Message;
            }

        }
        //Updates a record based on the student number and module code
        public void update(int studNum, string moduleC, ref int rowCount, ref string errorMsg)
        {
            try
            {
                SqlCommand updateCmd = new SqlCommand($"UPDATE ModuleTB SET ModuleName='{name}', Credits='{credits}', ClassHours='{classHours}', SelfStudyHours='{selfStudyHours.ToString().Replace(",", ".")}', StudyHoursDate='{hoursSpentDate}', HoursToStudy='{hoursSpent}', HoursRemaining='{hoursRemaining.ToString().Replace(",", ".")}' WHERE StudentNum={studNum} and ModuleCode='{moduleC}'", conn);
                conn.Open();
                rowCount = updateCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                errorMsg = ex.Message;
            }
            
        }
        //Get data from ModuleTB based on the student number and module code
        public void getData(int studNum, string moduleC)
        {

            SqlCommand selectCmd = new SqlCommand($"SELECT * FROM ModuleTB WHERE StudentNum={studNum} and ModuleCode='{moduleC}'", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd);
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            conn.Open();
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                dataRow = dataTable.Rows[0];

                studentNo = (int)dataRow[0];
                code = (string)dataRow[1];
                name = (string)dataRow[2];
                credits = Convert.ToDouble(dataRow[3]);
                classHours = Convert.ToDouble(dataRow[4]);
                selfStudyHours = Convert.ToDouble(dataRow[5]);
                hoursSpentDate = (string)dataRow[6];
                hoursSpent = Convert.ToDouble(dataRow[7]);
                hoursRemaining = Convert.ToDouble(dataRow[8]);
            }
            else
            {
                this.studentNo = 0;
                this.code = "None";
                this.name = "None";
                this.credits = 0;
                this.classHours = 0;
                this.selfStudyHours = 0;
                this.hoursSpentDate = "None";
                this.hoursSpent = 0;
                this.hoursRemaining = 0;
            }
            conn.Close();
        }
        //Returns a datatable of modules for a specific student.
        public DataTable allModules(int studNum)
        {
            SqlDataAdapter selectLine = new SqlDataAdapter($"SELECT ModuleCode, ModuleName, Credits, ClassHours, SelfStudyHours, StudyHoursDate, HoursToStudy, HoursRemaining FROM ModuleTB WHERE StudentNum={studNum}", conn);
            DataTable dTable = new DataTable();

            conn.Open();
            selectLine.Fill(dTable);
            conn.Close();

            return dTable;
        }
        //Method used get values from ModuleTB for a chart
        public DataTable chartData(int studNum)
        {
            SqlDataAdapter selectLine = new SqlDataAdapter($"SELECT ModuleCode, SelfStudyHours FROM ModuleTB WHERE StudentNum={studNum}", conn);
            DataTable dTable = new DataTable();

            conn.Open();
            selectLine.Fill(dTable);
            conn.Close();

            return dTable;
        }
        //Method used to get all modules based on a student number.
        public DataTable getAllModules(DropDownList list, int sudNum)
        {
            SqlDataAdapter selectLine = new SqlDataAdapter($"SELECT ModuleCode, ModuleName FROM ModuleTB WHERE StudentNum={sudNum}", conn);
            DataTable dTable = new DataTable();
            DataRow dataRow;


            conn.Open();
            selectLine.Fill(dTable);

            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                dataRow = dTable.Rows[i];

                list.Items.Add(dataRow[0].ToString());
            }
            conn.Close();

            return dTable;
        }

    }
}
