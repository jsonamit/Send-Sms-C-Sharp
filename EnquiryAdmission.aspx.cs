using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EnquiryAdmission : System.Web.UI.Page
{
    static int Enquiryid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelViewUsers.Visible = false;
            PanelEnteryuser.Visible = true;
            Enquiryid = int.Parse(Request.QueryString["id"].ToString());
            GetValueEnquiry();
        }
    }

    public void GetValueEnquiry()
    {
        FeeData fdata = new FeeData();
        DataSet ds = fdata.getFeeData("Select * from enquiry where id="+ Enquiryid);
        txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
        txtmobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
        txtxEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
        ddlCourses.SelectedValue = ds.Tables[0].Rows[0]["courses"].ToString();
    }
    protected void btnEnquirySubmit_Click(object sender, EventArgs e)
    {
        UsersData udata = new UsersData();
        udata.Name = txtName.Text;
        udata.Email = txtxEmail.Text;
        udata.Mobile = txtmobile.Text;
        udata.Courses = ddlCourses.SelectedValue.ToString();
        udata.Save();
        DataSet ds = udata.getUsersData("select max(id) from users");
        int UserMaxid = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        FeeData fdata = new FeeData();
        fdata.Fee = txtFee.Text;
        fdata.Userid = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        fdata.Payment = txtPayment.Text;
        int fee = int.Parse(txtFee.Text);
        int payment = int.Parse(txtPayment.Text);
        int remainpayment = int.Parse(txtFee.Text) - int.Parse(txtPayment.Text);
        fdata.Remain_payment = remainpayment.ToString();
        fdata.Save();
        Reset();
    }
    public void Reset()
    {
        txtName.Text = "";
        txtxEmail.Text = "";
        txtmobile.Text = "";
        ddlCourses.SelectedIndex = 0;
        txtFee.Text = "";
        txtPayment.Text = "";
    }

    protected void btnViewUsers_Click(object sender, EventArgs e)
    {
        PanelViewUsers.Visible = true;
        PanelEnteryuser.Visible = false;
        BindRepeater();
    }

    private void BindRepeater()
    {
        try
        {
            UsersData udata = new UsersData();
            DataSet ds = udata.getUsersData("select users.id,users.name,users.mobile,users.courses,users.email,fee.user_id,fee.payment,fee.remain_payment from users join fee on users.id=fee.user_id ");
            RpViewUsers.DataSource = ds;
            RpViewUsers.DataBind();
        }
        catch (Exception ex) { }
    }

}