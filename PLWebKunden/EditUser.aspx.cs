using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class EditUser : System.Web.UI.Page
    {
        private User u;
        protected void Page_Load(object sender, EventArgs e)
        {

            u = (User)Session["User"];
            if (u == null) Response.Redirect("Login.apsx");
            if (!IsPostBack && u != null)
            {               
               txtEditUserFirstname.Text = u.Firstname;
               txtEditUserLastname.Text = u.Lastname;
               txtEditUserEmail.Text = u.Email;               
            }
        }

        protected void btnEditUserSave_Click(object sender, EventArgs e)
        {
            string fn = txtEditUserFirstname.Text;
            string ln = txtEditUserLastname.Text;
            string email = txtEditUserEmail.Text;
            string pw = txtEditUserPassword.Text;
            string pw2 = txtEditUserConfirmPassword.Text;

            //change user
            if (u != null)
            {
                u.Firstname = fn;
                u.Lastname = ln;
                u.Email = email;
                if (u.Save())
                {
                    //change password if both entered
                    if (txtEditUserPassword.Text != "" && txtEditUserConfirmPassword.Text != "" &&
                       txtEditUserPassword.Text == txtEditUserConfirmPassword.Text)
                    {
                        u.changePassword(txtEditUserPassword.Text);
                    }
                }
                Response.Redirect("MyProjects.aspx");
            }
        }

        protected void btnEditUserCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProjects.aspx");
        }
     }
}