using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLWebKunden
{
    public partial class AddWorkPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		    if (Session["User"] == null) Response.Redirect("Login.aspx");
        }

        protected void btnAddWorkPackageMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnAddWorkPackageMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnAddWorkPackageUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnAddWorkPackageLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}