using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class WorkPackages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		    if (Session["User"] == null) Response.Redirect("Login.aspx");

            Project sp = (Project)Session["editProject"];
            lblWorkPackagesProjectname.Text = sp.Name;
        }

        protected void btnWorkPackagesAddProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddWorkPackage.aspx");
        }

        protected void btnWorkPackagesMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnWorkPackagesMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnWorkPackagesUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnWorkPackagesLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}