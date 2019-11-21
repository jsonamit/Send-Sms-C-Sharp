using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Enquiry : System.Web.UI.Page
{
    static int EnquiryId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelViewEnquiry.Visible = false;
            PanelEntry.Visible = true;
        }
    }

    protected void btnEnquirySubmit_Click(object sender, EventArgs e)
    {
        EnquiryData edata = new EnquiryData();
        edata.Name = txtName.Text;
        edata.Mobile = txtmobile.Text;
        edata.Email = txtEmail.Text;
        edata.Courses = ddlCourses.SelectedValue;
        edata.Save();
        Reset();
    }
    public void Reset()
    {
        txtName.Text = "";
        txtmobile.Text = "";
        txtEmail.Text = "";
        ddlCourses.SelectedIndex = 0;
    }

    protected void btnViewEnquiry_Click(object sender, EventArgs e)
    {
        PanelViewEnquiry.Visible = true;
        PanelEntry.Visible = false;
        BindRepeater();
    }
    private void BindRepeater()
    {
        try
        {
            EnquiryData edata = new EnquiryData();
            DataSet ds = edata.getEnquiryData("select * from enquiry ");
            RpViewEnquiry.DataSource = ds;
            RpViewEnquiry.DataBind();
        }
        catch (Exception ex) { }
    }

    protected void RpViewEnquiry_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        EnquiryId = int.Parse(e.CommandArgument.ToString());
        string cmdname = e.CommandName.ToString();
        if (cmdname == "addmission")
        {
            Response.Redirect("EnquiryAdmission.aspx?id=" + EnquiryId);
        }
    }
}