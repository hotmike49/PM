using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;

namespace PLWebKunden
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) { Response.Redirect("MyProjects.apsx"); }
        }

        protected void btnRegisterRegister_Click(object sender, EventArgs e)
        {
            string fn = txtRegisterFirstname.Text;
            string ln = txtRegisterLastname.Text;
            string un = txtRegisterUsername.Text;
            string email = txtRegisterEmail.Text;
            string pw = txtRegisterPassword.Text;
            string pw2 = txtRegisterConfirmPassword.Text;

                if (pw == pw2)
                {
                    if (Main.register(fn, ln, un, email, pw))
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                else txtRegisterConfirmPassword.Text = "not identical passwords";
            
        }

        protected void btnRegisterCancel_Click(object sender, EventArgs e)
        {
           Response.Redirect("MyProjects.aspx");
        }
    }
}