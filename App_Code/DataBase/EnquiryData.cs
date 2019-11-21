using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EnquiryData
/// </summary>
public class EnquiryData
{
    private int _Id;
    private string _Name;
    private string _Mobile;
    private string _Courses;
    private string _Email;
    
    public EnquiryData()
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM enquiry WHERE id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());               
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Courses = ds.Tables[0].Rows[0]["courses"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", _Id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@courses", _Courses));
        param.Add(new MySqlParameter("@email", _Email));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO  enquiry(name,mobile,courses,email) VALUES (@name,@mobile,@courses,@email)", param);
        connect.Dispose();
        connect = null;
    }
    public void Delete(string query)
    {
        Connection connect = new Connection();
        connect.ExecStatement("DELETE from enquiry");
        connect.Dispose();
        connect = null;
    }
    //method for selection
    public DataSet getEnquiryData(String query) 
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string Mobile
    {
        get { return _Mobile; }
        set { _Mobile = value; }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string Courses
    {
        get { return _Courses; }
        set { _Courses = value; }
    }
   
    public bool HasValue { get; set; }
}