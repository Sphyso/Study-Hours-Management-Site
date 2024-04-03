using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskLibrary;

namespace Task3POE
{
    public partial class DeleteAndEditModule : System.Web.UI.Page
    {
        static Module mod = new Module();
        static ModuleLib modLib = new ModuleLib();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = Convert.ToString(Session["studName"] + " " + Session["studSurname"]);
            mod.getAllModules(ddlModule, getStudentNo());
        }
        //Used to get student number from the login session
        public int getStudentNo()
        {
            int studNum = Convert.ToInt32(Session["studNo"]);
            return studNum;
        }
        //Method used to delete a module
        protected void btnDeleteModule_Click(object sender, EventArgs e)
        {
            string mCode = txtCodeDelete.Text;
            string errorMsg = string.Empty;
            int rowCount = 0;
            mod.delete(getStudentNo(), mCode, ref rowCount, ref errorMsg);

            if (string.IsNullOrEmpty(errorMsg))
            {
                if (rowCount > 0)
                {
                    Response.Write($"<script>alert('One module deleted.')</script>");
                    txtCodeDelete.Text = "";
                }
                else
                {
                    Response.Write($"<script>alert('No module has been deleted.')</script>");
                    txtCodeDelete.Text = "";
                }
            }
            else
            {
                Response.Write($"<script>alert('Error! Could not delete a Module')</script>");
            }

        }
        //nethod used to update a module.
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string mCode = ddlModule.SelectedValue.ToString();
            string mName = txtName.Text;
            double mCredits = Convert.ToDouble(txtCredits.Text);
            double mClasshours = Convert.ToDouble(txtClassHours.Text);
            double weeks = Convert.ToDouble(txtWeeks.Text);
            string mHoursSpentDate = txtStudyDate.Text;
            double mhoursSpent = Convert.ToDouble(txtHoursToStudy.Text);
            double mSelfStudyHours = modLib.selfStudyCalculation(mCredits, weeks, mClasshours);
            double mHoursRemaining = mSelfStudyHours - mhoursSpent;
            int rowCount = 0;
            string errorMsg = string.Empty;

            mod = new Module(getStudentNo(), mCode, mName, mCredits, mClasshours, mSelfStudyHours, mHoursSpentDate, mhoursSpent, mHoursRemaining);

            mod.update(getStudentNo(), mCode, ref rowCount, ref errorMsg);

            if (string.IsNullOrEmpty(errorMsg))
            {
                if (rowCount > 0)
                {
                    Response.Write($"<script>alert('A module has been updated.')</script>");
                    txtName.Text = "";
                    txtCredits.Text = "";
                    txtClassHours.Text = "";
                    txtWeeks.Text = "";
                    txtStudyDate.Text = "";
                    txtHoursToStudy.Text = "";
                }
                else
                {
                    Response.Write($"<script>alert('No module updated.')</script>");
                    txtName.Text = "";
                    txtCredits.Text = "";
                    txtClassHours.Text = "";
                    txtWeeks.Text = "";
                    txtStudyDate.Text = "";
                    txtHoursToStudy.Text = "";
                }
            }
            else
            {
                Response.Write($"<script>alert('Error! Could not update a Module')</script>");
            }

        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mCode = ddlModule.SelectedValue.ToString();
            mod.getAllModules(ddlModule, getStudentNo());
            mod.getData(getStudentNo(), mCode);

            txtName.Text = mod.name;
            txtCredits.Text = mod.credits.ToString();
            txtClassHours.Text = mod.classHours.ToString();
            txtHoursToStudy.Text = mod.hoursSpent.ToString();
        }
        //Used to display module information based on which module was selected.
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            string mCode = ddlModule.SelectedValue.ToString();
            mod.getData(getStudentNo(), mCode);

            txtName.Text = mod.name;
            txtCredits.Text = mod.credits.ToString();
            txtClassHours.Text = mod.classHours.ToString();
            txtHoursToStudy.Text = mod.hoursSpent.ToString();
        }
        //Logs out user
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}