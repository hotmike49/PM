﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLWebKunden
{
    public partial class MyProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		 if (Session["User"] == null) Response.Redirect("Login.aspx");
        }

        protected void btnMyProjectsMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnMyProjectsUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnMyProjectsLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void btnMyProjectsAddProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProject.aspx");
        }
    }
}