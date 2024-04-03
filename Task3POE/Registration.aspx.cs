using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task3POE
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Method used to register a student
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name, surname, password;
            int studNum, age;
            int rowCount = 0;
            string errorMsg = string.Empty;

            studNum = Convert.ToInt32(txtStudNum.Text);
            name = txtName.Text;
            surname = txtSurname.Text;
            age = Convert.ToInt32(txtAge.Text);
            password = hashingPassword(txtPassword.Text);

            Register reg = new Register(studNum, name, surname, age, password);

            reg.addStudent(ref rowCount, ref errorMsg);

            if (string.IsNullOrEmpty(errorMsg))
            {
                if (rowCount > 0)
                {
                    Response.Write($"<script>alert('New student registered.')</script>");
                    txtStudNum.Text = "";
                    txtName.Text = "";
                    txtSurname.Text = "";
                    txtAge.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    Response.Write($"<script>alert('No data added')</script>");
                    txtStudNum.Text = "";
                    txtName.Text = "";
                    txtSurname.Text = "";
                    txtAge.Text = "";
                    txtPassword.Text = "";
                }
            }
            else
            {
                Response.Write($"<script>alert('Error! Could not register student')</script>");
            }
        }
        //Method that encrypst the password
        public static string hashingPassword(string password)
        {
            try
            {
                byte[] hashData = new byte[password.Length];
                hashData = System.Text.Encoding.UTF8.GetBytes(password);
                string hashedData = Convert.ToBase64String(hashData);
                return hashedData;
            }
            catch (Exception ex)
            {

                throw new Exception("Error in 64Encode" + ex.Message);
            }
        }
        //Method that goes back to the login page
        protected void btnBackLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}