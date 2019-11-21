using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelViewUsers.Visible = false;
            PanelEnteryuser.Visible = true;
        }
    }

    protected void btnEnquirySubmit_Click(object sender, EventArgs e)
    {
        UsersData udata = new UsersData();
        udata.Name = txtName.Text;
        udata.Email = txtxEmail.Text;       
        udata.Mobile = txtmobile.Text;
        udata.Courses = ddlCourses.SelectedValue;
        udata.Save();
        DataSet ds = udata.getUsersData("select max(id) from users");
        int UserMaxid = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        FeeData fdata = new FeeData();
        fdata.Fee = txtFee.Text;
        fdata.Userid= int.Parse(ds.Tables[0].Rows[0][0].ToString());
        fdata.Payment = txtPayment.Text;
        int fee= int.Parse(txtFee.Text);
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
   
    public string TestPayment()
    {
        string Payment = "";
        DataSet ds = null;
      
        try
        {
            FeeData brdata = new FeeData();
            ds = brdata.getFeeData("select remain_payment from fee");
           
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string RemPayment = ds.Tables[0].Rows[i]["remain_payment"].ToString();
                 Payment = RemPayment;
               
            }
                    
        }
        catch (Exception ex) { }
        return Payment;

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