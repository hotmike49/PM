﻿using System;
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

        private Users allUsers;
        private Users projectUsers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                allUsers = Main.getAllUsers();
                chkAddProjectProjectUser.DataSource = allUsers;
                chkAddProjectProjectUser.DataBind();
                foreach (ListItem i in chkAddProjectProjectUser.Items)
                {
                    i.Value = allUsers[chkAddProjectProjectUser.Items.IndexOf(i)].Username;
                    i.Text = i.Value;
                }

                if (Session["editProject"] != null)
                {
                    Project ep = (Project)Session["editProject"];
                    txtProjectname.Text = ep.Name;
                    txtProjectDescription.Text = ep.Description;
                    calProjectStartDate.SelectedDate = ep.CreatedDate;
                    calProjectEndDate.SelectedDate = ep.EndDate;

                    foreach (ListItem i in chkAddProjectProjectUser.Items)
                    {

                        projectUsers = Main.getProjectUsers(ep);

                        foreach (User u in projectUsers)
                        {
                            if (i.Value == u.Username)
                            {
                                i.Selected = true;
                            }
                        }

                    }
                }
            }
        }

        protected void btnAddProjectAddUser_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnAddProjectSave_Click(object sender, EventArgs e)
        {
            string name = txtProjectname.Text;
            string desc = txtProjectDescription.Text;
            DateTime startdate = calProjectStartDate.SelectedDate;
            DateTime enddate = calProjectEndDate.SelectedDate;

            if (Session["editProject"] == null)
            {
                User u = (User)Session["User"];
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
                Response.Redirect("MyProjects.aspx");
            }
            else
            {
                Project p = (Project)Session["editProject"];
                p.Name = name;
                p.CreatedDate = startdate;
                p.EndDate = enddate;
                p.Description = desc;

                if (p.Save())
                {
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
                    Response.Redirect("MyProjects.aspx");
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