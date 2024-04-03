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
    public partial class AddModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = Convert.ToString(Session["studName"]+ " " + Session["studSurname"]);
        }
        //Used to get student number from the login session
        public int getStudentNo()
        {
            int studNum = Convert.ToInt32(Session["studNo"]);
            return studNum;
        }
        //Button to add modules to the database.
        protected void btnAddModule_Click(object sender, EventArgs e)
        {
            ModuleLib modLib = new ModuleLib();
            Module mod = new Module();
            string mCode, mName, mHoursSpentDate, sStartDate;
            double mCredits, mClasshours, mSelfStudyHours, mhoursSpent, mHoursRemaining, weeks;
            int rowCount = 0;
            string errorMsg = string.Empty;

            mCode = txtCode.Text;
            mName = txtName.Text;
            mCredits = Convert.ToDouble(txtCredits.Text);
            mClasshours = Convert.ToDouble(txtClassHours.Text);
            weeks = Convert.ToDouble(txtWeeks.Text);
            sStartDate = txtStartDate.Text;
            mHoursSpentDate = txtStudyDate.Text;
            mhoursSpent = Convert.ToDouble(txtHoursToStudy.Text);
            mSelfStudyHours = modLib.selfStudyCalculation(mCredits, weeks, mClasshours);
            mHoursRemaining = mSelfStudyHours - mhoursSpent;

            mod = new Module(getStudentNo(), mCode, mName, mCredits, mClasshours, mSelfStudyHours, mHoursSpentDate, mhoursSpent, mHoursRemaining);

            mod.addModule(ref rowCount, ref errorMsg);

            if (string.IsNullOrEmpty(errorMsg))
            {
                if (rowCount > 0)
                {
                    Response.Write($"<script>alert('New module added.')</script>");
                    txtCode.Text = "";
                    txtName.Text = "";
                    txtCredits.Text = "";
                    txtClassHours.Text = "";
                    txtWeeks.Text = "";
                    txtStartDate.Text = "";
                    txtStudyDate.Text = "";
                    txtHoursToStudy.Text = "";
                }
                else
                {
                    Response.Write($"<script>alert('No module data added.')</script>");
                    txtCode.Text = "";
                    txtName.Text = "";
                    txtCredits.Text = "";
                    txtClassHours.Text = "";
                    txtWeeks.Text = "";
                    txtStartDate.Text = "";
                    txtStudyDate.Text = "";
                    txtHoursToStudy.Text = "";
                }
            }
            else
            {
                Response.Write($"<script>alert('Error! Could not add a Module')</script>");
            }

        }
        //Logs user out
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}