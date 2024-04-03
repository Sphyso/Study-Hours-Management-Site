using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task3POE
{
    public partial class SearchModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = Convert.ToString(Session["studName"] + " " + Session["studSurname"]);
        }
        //Used to get student number from the login session
        public int getStudentNo()
        {
            int studNum = Convert.ToInt32(Session["studNo"]);
            return studNum;
        }
        //Displayes the module information based on the module code.
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Module mod = new Module();

            string mCode = txtCode.Text;
            mod.getData(getStudentNo(), mCode);

            txtName.Text = mod.name;
            txtCredits.Text = Convert.ToString(mod.credits);
            txtClassHours.Text = Convert.ToString(mod.classHours);
            txtSelfStudyHours.Text = Convert.ToString(mod.selfStudyHours);
            txtStudyDate.Text = mod.hoursSpentDate;
            txtHoursToStudy.Text = Convert.ToString(mod.hoursSpent);
            txtHoursRemaining.Text = Convert.ToString(mod.hoursRemaining);

        }
        //Logs the user out
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}