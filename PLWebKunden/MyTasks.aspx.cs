using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class MyTasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		 if (Session["User"] == null) Response.Redirect("Login.aspx");
		 User u = (User)Session["User"];
         BO_PM.Tasks t = u.MyTasks;            
         MyTasksView.DataSource = t;
         MyTasksView.DataBind(); 
        }

        protected void btnMyTasksMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnMyTasksUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnMyTasksLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}