using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_PM;
namespace PLWebKunden
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {       
             if (Session["User"] != null) Response.Redirect("MyProjects.aspx");  
        }

        protected void btnLoginLogin_Click(object sender, EventArgs e)
        {
              string username = txtUsername.Text;
              string pw = txtPassword.Text;
              if (Main.checkLogin(username, pw) != null)
              {
                  Session["User"] = Main.checkLogin(username, pw);
                  Response.Redirect("MyProjects.aspx");
              }
        }

        protected void btnLoginCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        }
    }