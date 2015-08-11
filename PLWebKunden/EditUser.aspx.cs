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
        protected void Page_Load(object sender, EventArgs e)
        {
		    if (Session["User"] == null) Response.Redirect("Login.aspx");
        }
    }
}