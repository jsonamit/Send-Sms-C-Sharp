using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendSms : System.Web.UI.Page
{
    static int VisitUserId;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDownCheckBoxes();

    }
    public void FillDropDownCheckBoxes()
    {

        string VisitUser = ddlCategory.SelectedValue.ToString();
        DropDownCheckBoxes.Items.Clear();
        if (VisitUser == "Visitor")
        {

            EnquiryData rdata = new EnquiryData();
            DataSet ds = rdata.getEnquiryData("Select * from enquiry");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = ds.Tables[0].Rows[i]["name"].ToString();
                item.Value = ds.Tables[0].Rows[i]["id"].ToString();
                item.Selected = false;
                DropDownCheckBoxes.Items.Add(item);
            }
            DropDownCheckBoxes.Items.Insert(0, new ListItem("All", "0"));

        }
        else
        {
            DropDownCheckBoxes.Items.Clear();
            if (VisitUser == "Users")
            {
                UsersData rrdata = new UsersData();
                DataSet ds = rrdata.getUsersData("Select * from users");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = ds.Tables[0].Rows[i]["name"].ToString();
                    item.Value = ds.Tables[0].Rows[i]["id"].ToString();
                    item.Selected = false;
                    DropDownCheckBoxes.Items.Add(item);
                }
                DropDownCheckBoxes.Items.Insert(0, new ListItem("All", "0"));
            }
            else
            {

            }
        }

    }

    //public void BindVisitorUsers()
    //{
    //    int VisitUser = int.Parse(ddlCategory.SelectedValue.ToString());
    //    switch (VisitUser)
    //    {
    //        case 1:
    //            EnquiryData rdata = new EnquiryData();
    //            DataSet ds = rdata.getEnquiryData("Select * from enquiry");

    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                ListItem item = new ListItem();
    //                item.Text = ds.Tables[0].Rows[i]["name"].ToString();
    //                item.Value = ds.Tables[0].Rows[i]["id"].ToString();
    //                item.Selected = false;
    //                DropDownCheckBoxes.Items.Add(item);
    //            }
    //            DropDownCheckBoxes.Items.Insert(0, new ListItem("All", "0"));
    //            break;
    //        case 2:
    //            UsersData rrdata = new UsersData();
    //            DataSet dds = rrdata.getUsersData("Select * from users");
    //            if (dds.Tables[0].Rows.Count == 0)
    //            {
    //                DropDownCheckBoxes.SelectedIndex = 0;

    //            }
    //            else
    //            {
    //                for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
    //                {
    //                    ListItem item = new ListItem();
    //                    item.Text = dds.Tables[0].Rows[i]["name"].ToString();
    //                    item.Value = dds.Tables[0].Rows[i]["id"].ToString();
    //                    item.Selected = false;
    //                    DropDownCheckBoxes.Items.Add(item);
    //                }
    //                DropDownCheckBoxes.Items.Insert(0, new ListItem("All", "0"));
    //            }

    //            break;
    //    }

    //}
    protected void DropDownCheckBoxes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownCheckBoxes.SelectedIndex == 0)
        {
            for (int j = 1; j < DropDownCheckBoxes.Items.Count; j++)
            {
                DropDownCheckBoxes.Items[j].Enabled = false;
                
            }
           
        }
        else
        {
            for (int j = 1; j < DropDownCheckBoxes.Items.Count; j++)
            {
                DropDownCheckBoxes.Items[j].Enabled = true;
            }
        }
    }
    protected void btnSendSms_Click(object sender, EventArgs e)
    {

        foreach (ListItem item in DropDownCheckBoxes.Items)
        {

            if (item.Selected)
            {
                VisitUserId = int.Parse(item.Value.ToString());
                string VisitUser = ddlCategory.SelectedValue.ToString();
                if (VisitUser == "Visitor")
                {
                    string index = DropDownCheckBoxes.SelectedIndex.ToString();
                    DataSet dsu;
                    if (DropDownCheckBoxes.SelectedIndex == 0)
                    {
                        for (int j = 1; j < DropDownCheckBoxes.Items.Count; j++)
                        {
                            DropDownCheckBoxes.Items[j].Enabled = false;
                        }
                        EnquiryData edata = new EnquiryData();
                        dsu = edata.getEnquiryData("select * from enquiry");
                    }
                    else
                    {
                        EnquiryData edata = new EnquiryData();
                        dsu = edata.getEnquiryData("select * from enquiry where id=" + VisitUserId);
                    }


                    string msg = txtMessege.Text;
                    for (int i = 0; i < dsu.Tables[0].Rows.Count; i++)
                    {
                        string name = dsu.Tables[0].Rows[i][1].ToString();
                        string mobile = dsu.Tables[0].Rows[i][2].ToString();

                        string cont = "Dear" + " name = " + name + "\n" + msg;
                      // sendMessage(cont, mobile);
                    }
                    Reset();
                }
                else
                {
                    DataSet dsu;
                    if (DropDownCheckBoxes.SelectedIndex == 0)
                    {
                        UsersData udata = new UsersData();
                        dsu = udata.getUsersData("select * from users");
                    }
                    else
                    {
                        UsersData udata = new UsersData();
                        dsu = udata.getUsersData("select * from users where id = " + VisitUserId);
                    }


                    string msg = txtMessege.Text;
                    for (int i = 0; i < dsu.Tables[0].Rows.Count; i++)
                    {
                        string name = dsu.Tables[0].Rows[i][1].ToString();
                        string mobile = dsu.Tables[0].Rows[i][2].ToString();

                        string cont = "Dear" + " name = " + name + "\n" + msg;
                        //sendMessage(cont, mobile);
                    }
                    Reset();

                }

            }
            else
            {

            }
        }

    }
    public static void sendMessage(string msg, string mobile)
    {
        string api = "";
        string token = "";
        string senderid = "";
        string rmobile = mobile;
        string route = "2";
        string msgtype = "1";
        string sms = msg;
        string cont = "token=" + token + "&sender=" + senderid + "&number=" + rmobile + "&route=" + route + "&type=" + msgtype + "&sms=" + sms;
        string apiurl = api + "" + cont;

        try
        {
            //Create the request and send data to Ozeki NG SMS Gateway Server by        HTTP connection
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(apiurl);

            //Get response from Ozeki NG SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
        catch (Exception ex) { }
    }
    public void Reset()
    {
        ddlCategory.SelectedIndex = 0;
        DropDownCheckBoxes.SelectedIndex = 0;
        txtMessege.Text = "";
    }



    
}
