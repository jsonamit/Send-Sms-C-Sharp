using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRepeater();
        }
    }
    private void BindRepeater()
    {
        try
        {
            UsersData udata = new UsersData();
            DataSet ds = udata.getUsersData("select * from users");
            rpUsers.DataSource = ds;
            rpUsers.DataBind();
        }
        catch (Exception ex) { }
    }
}