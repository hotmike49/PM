using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class AddTask : System.Web.UI.Page
    {
        private Users projectUsers;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                projectUsers = Main.getProjectUsers((Project)Session["selectedProject"]);
                chkTaskUser.DataSource = projectUsers;
                chkTaskUser.DataBind();
                foreach (ListItem i in chkTaskUser.Items)
                {
                    i.Value = projectUsers[chkTaskUser.Items.IndexOf(i)].Username;
                    i.Text = i.Value;
                }

                if (Session["editTask"] != null)
                {
                    Task et = (Task)Session["editTask"];
                    txtTaskname.Text = et.Name;
                    txtTaskDescription.Text = et.Description;
                    calTaskStartDate.SelectedDate = et.CreatedDate;
                    calTaskEndDate.SelectedDate = et.EndDate;
                    if (et.Status == "Done") ddlStatus.SelectedValue = "1";
                    else ddlStatus.SelectedValue = "0";

                    foreach (ListItem i in chkTaskUser.Items)
                    {

                        Users taskUsers = et.loadTaskUsers();

                        foreach (User u in taskUsers)
                        {
                            if (i.Value == u.Username)
                            {
                                i.Selected = true;
                            }
                        }

                    }
                }
            }

		    if (Session["User"] == null) Response.Redirect("Login.aspx");
        }

        protected void btnAddTaskSave_Click(object sender, EventArgs e)
        {
            string name = txtTaskname.Text;
            string desc = txtTaskDescription.Text;
            DateTime startdate = calTaskStartDate.SelectedDate;
            DateTime enddate = calTaskEndDate.SelectedDate;

            if (Session["editTask"] == null)
            {
                User u = (User)Session["User"];
                if (name != "" && enddate != null && desc != "")
                {
                    Task t = ((WorkPackage)Session["selectedWorkPackage"]).addTask(name, startdate, enddate, desc);
                    foreach (ListItem i in chkTaskUser.Items)
                    {
                        string username = i.Value;
                        if (i.Selected)
                        {
                            t.addTaskUser(username);
                        }
                    }
                }
                Response.Redirect("Tasks.aspx");
            }
            else
            {
                Task t = (Task)Session["editTask"];
                t.Name = name;
                t.CreatedDate = startdate;
                t.EndDate = enddate;
                t.Description = desc;
                t.Status = ddlStatus.SelectedValue;
                if (t.Save())
                {
                    foreach (ListItem i in chkTaskUser.Items)
                    {
                        string username = i.Value;
                        if (i.Selected)
                        {
                            t.addTaskUser(username);
                        }
                        else
                        {
                            t.deleteTaskUser(username);
                        }
                    }
                    Response.Redirect("Tasks.aspx");
                }
            }
        }

        protected void btnAddTaskCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tasks.aspx");
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