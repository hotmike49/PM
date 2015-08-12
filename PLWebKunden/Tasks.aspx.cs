using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class Tasks : System.Web.UI.Page
    {
        BO_PM.Tasks workPackageTasks;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["editTask"] = null;
            Session["selectedTask"] = null;

            WorkPackage sw = (WorkPackage)Session["selectedWorkPackage"];

		    if (Session["User"] == null) Response.Redirect("Login.aspx");
            else{                
                workPackageTasks = sw.loadWorkPackageTasks();                
                TasksView.DataSource = workPackageTasks;
                TasksView.DataBind();
            }

            
            lblTasksWorkPackagename.Text = sw.Name;
        }

        protected void TasksView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedTask"] = workPackageTasks[TasksView.SelectedIndex];
            Response.Redirect("TaskDetail.aspx");
        }

        protected void TasksView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["editTask"] = workPackageTasks[TasksView.EditIndex + 1];
            Response.Redirect("AddTask.aspx");

        }

        protected void btnTasksMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnTasksMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnTasksUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnTasksLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void btnTasksAddTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTask.aspx");
        }

        protected void TasksView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Task t = workPackageTasks[TasksView.EditIndex + 1];
            if (t.Delete()) Response.Redirect("Tasks.aspx");

        }
    }
}