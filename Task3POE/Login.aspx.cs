using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskLibrary;


namespace Task3POE
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Module mod = new Module();
            Register reg = new Register();

            reg.getRegisterInfo(Convert.ToInt32(txtStudNum.Text));

            if (Convert.ToInt32(txtStudNum.Text) == reg.studentNum)
            {
                if (txtPassword.Text == reg.decodeFrom64(reg.password))
                {
                    Session["studNo"] = reg.studentNum;
                    Session["studName"] = reg.name;
                    Session["studSurname"] = reg.surname;
                    Response.Redirect("~/AddModule.aspx");
                }
                else
                {
                    Response.Write($"<script>alert('Student number or Password is incorrect.')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Student number or Password is incorrect.')</script>");
            }
        }
    }
}