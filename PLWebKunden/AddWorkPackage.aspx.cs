using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class AddWorkPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		    if (Session["User"] == null) Response.Redirect("Login.aspx");

            if (!IsPostBack){            
                if (Session["editWorkPackage"] != null)
                {
                    WorkPackage ew = (WorkPackage)Session["editWorkPackage"];                    
                    txtWorkPackagename.Text = ew.Name;
                    txtWorkPackageDesc.Text = ew.Description;
                    calWorkPackageStartDate.SelectedDate = ew.CreatedDate;
                    calWorkPackageEndDate.SelectedDate = ew.EndDate;
                }
            }
        }

        protected void btnAddWorkPackageMyProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }

        protected void btnAddWorkPackageMyTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyTasks.aspx");
        }

        protected void btnAddWorkPackageUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btnAddWorkPackageLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void btnAddWorkPackageSave_Click(object sender, EventArgs e)
        {
            string name = txtWorkPackagename.Text;
            string desc = txtWorkPackageDesc.Text;
            DateTime startdate = calWorkPackageStartDate.SelectedDate;
            DateTime enddate = calWorkPackageEndDate.SelectedDate;

           //Add Workpackage
           if (Session["editWorkPackage"] == null){
                if (name != "" && startdate != null && enddate != null && desc != ""){
                    Project sp = (Project)Session["selectedProject"];
                    if(sp.addWorkPackage(name, startdate, enddate, desc)){
                        //Addworkpackage erfolgreich
                    }               
                }
                Response.Redirect("WorkPackages.aspx");
            }
            //Edit Workpackage
            else{
                    WorkPackage w = (WorkPackage)Session["editWorkPackage"];
                    w.Name = name;
                    w.CreatedDate = startdate;
                    w.EndDate = enddate;
                    w.Description = desc;

                    if (w.Save())
                    {
                      //Save erfolgreich
                    }
                    Response.Redirect("WorkPackages.aspx");
                }
          }

        protected void btnAddWorkPackageCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkPackages.aspx");
        }

        protected void btnAddWorkPackageSave_Click1(object sender, EventArgs e)
        {
            string name = txtWorkPackagename.Text;
            string desc = txtWorkPackageDesc.Text;
            DateTime startdate = calWorkPackageStartDate.SelectedDate;
            DateTime enddate = calWorkPackageEndDate.SelectedDate;

            //Add Workpackage
            if (Session["editWorkPackage"] == null)
            {
                if (name != "" && startdate != null && enddate != null && desc != "")
                {
                    Project sp = (Project)Session["selectedProject"];
                    if (sp.addWorkPackage(name, startdate, enddate, desc))
                    {
                        //Addworkpackage erfolgreich
                    }
                }
                Response.Redirect("WorkPackages.aspx");
            }
            //Edit Workpackage
            else
            {
                WorkPackage w = (WorkPackage)Session["editWorkPackage"];
                w.Name = name;
                w.CreatedDate = startdate;
                w.EndDate = enddate;
                w.Description = desc;

                if (w.Save())
                {
                    //Save erfolgreich
                }
                Response.Redirect("WorkPackages.aspx");
            }
        }
        }
}

