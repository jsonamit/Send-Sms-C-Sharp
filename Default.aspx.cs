using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUserName.Text;
        string password = txtPassword.Text;
        LoginData ld = new LoginData(username,password);
        if (ld.HasValue)
        {
            Response.Redirect("Main.aspx");
        }
        else
        {
            lblError.Text = "Check Username and Password";
        }
    }
}