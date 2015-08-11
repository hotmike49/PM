using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLWebKunden
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		 if (Session["User"] == null) Response.Redirect("Login.aspx");
        }

        protected void btnAddTaskSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddTaskCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddTaskMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnAddTaskMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnAddTaskUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnAddTaskLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}