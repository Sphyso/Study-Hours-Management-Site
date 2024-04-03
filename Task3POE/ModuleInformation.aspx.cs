using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task3POE
{
    public partial class ModuleInformation : System.Web.UI.Page
    {
        //Used to get student number from the login session
        public int getStudentNo()
        {
            int studNum = Convert.ToInt32(Session["studNo"]);
            return studNum;
        }
        //Used to display all modules for a specific student and a chart
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = Convert.ToString(Session["studName"] + " " + Session["studSurname"]);
            Module mod = new Module();
            DataTable dTable = mod.allModules(getStudentNo());

            gvDisplayModules.DataSource = dTable;
            gvDisplayModules.DataBind();

            chtModuleData.DataSource = mod.chartData(getStudentNo());
            chtModuleData.DataBind();
        }
        //Logs the user out
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}