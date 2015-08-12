using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class WorkPackages : System.Web.UI.Page
    {
        
        BO_PM.WorkPackages wp; 
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["editWorkPackage"] = null;
            Session["selectedWorkPackage"] = null;
            if (Session["User"] == null) { Response.Redirect("Login.aspx"); }
            else{
                Project sp = (Project)Session["selectedProject"];
                lblWorkPackagesProjectname.Text = sp.Name;
                wp = sp.loadWorkPackages();
                WorkPackagesView.DataSource = wp;
                WorkPackagesView.DataBind();
            }          
        }

        protected void btnWorkPackagesAddProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddWorkPackage.aspx");
        }

        protected void btnWorkPackagesMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnWorkPackagesMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnWorkPackagesUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnWorkPackagesLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void WorkPackagesView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            WorkPackage w = wp[WorkPackagesView.EditIndex + 1];
            if (w.Delete()) Response.Redirect("WorkPackages.aspx");
        }

        protected void WorkPackagesView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["editWorkPackage"] = wp[WorkPackagesView.EditIndex + 1];
            Response.Redirect("AddWorkPackage.aspx");
        }

        protected void WorkPackagesView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedWorkPackage"] = wp[WorkPackagesView.SelectedIndex];
            Response.Redirect("Tasks.aspx");
        }
    }
}