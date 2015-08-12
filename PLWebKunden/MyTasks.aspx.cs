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
        BO_PM.Tasks ts;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["selectedTask"] = null;
		    if (Session["User"] == null) Response.Redirect("Login.aspx");
		    User u = (User)Session["User"];
            ts = u.MyTasks;           
            MyTasksView.DataSource = ts;
            MyTasksView.DataBind();
            lblMyTasksUsername.Text = u.Username;
        }

        protected void btnMyTasksMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnMyTasksUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnMyTasksLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void MyTasksView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedTask"] = ts[MyTasksView.SelectedIndex];
            Response.Redirect("TaskDetail.aspx");
        }
    }
}