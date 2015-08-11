using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class AddProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Login.aspx");
            if (Session["editProject"] != null)
            {
                Project ep = (Project) Session["editProject"];
                txtProjectname.Text = ep.Name;
                txtProjectDescription.Text = ep.Description;
                calProjectStartDate.SelectedDate = ep.CreatedDate;
                calProjectEndDate.SelectedDate = ep.EndDate;
            }
        }

        protected void btnAddProjectAddUser_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnAddProjectSave_Click(object sender, EventArgs e)
        {
            if (Session["editProject"] == null)
            {

                User u = (User)Session["User"];
                string name = txtProjectname.Text;
                string desc = txtProjectDescription.Text;
                DateTime startdate = calProjectStartDate.SelectedDate;
                DateTime enddate = calProjectEndDate.SelectedDate;
                if (name != "" && enddate != null && desc != "")
                {
                    Project p = u.addProject(name, startdate, enddate, desc);
                    foreach (ListItem i in chkAddProjectProjectUser.Items)
                    {
                        string username = i.Value;
                        if (i.Selected)
                        {
                            p.addProjectUser(username);
                        }
                        else
                        {
                            p.deleteProjectUser(username);
                        }
                    }
                }
            }
        }

        protected void btnAddProjectMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnAddProjectUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnAddProjectLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void btnAddProjectMyProjects_Click1(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnAddProjectCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

    }
}