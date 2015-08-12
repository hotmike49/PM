using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class TaskDetail : System.Web.UI.Page
    {
        static string referrer;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (Session["User"] == null) Response.Redirect("Login.aspx");

            if (!IsPostBack) referrer = Request.UrlReferrer.GetComponents(UriComponents.Path, UriFormat.Unescaped);

            Task t = (Task)Session["selectedTask"];
            lblTaskDetailTaskname.Text = t.Name;
            lblTaskDetailDescription.Text = t.Description;
            lblTaskDetailEndDate.Text = t.EndDate.ToShortDateString();
            lblTaskDetailStatus.Text = t.Status;

        }

        protected void btnTaskDetailMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnTaskDetailMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnTaskDetailUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnTaskDetailLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void btnTaskDetailBack_Click(object sender, EventArgs e)
        {            
            if (referrer == "MyTasks.aspx") Response.Redirect("MyTasks.aspx");
            else if (referrer == "Tasks.aspx") Response.Redirect("Tasks.aspx");            
        }
    }
}