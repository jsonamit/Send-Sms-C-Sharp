using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginData
/// </summary>
public class LoginData
{
    private int _Id;
    private string _Username;
    private string _Password;
    public LoginData()
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM login WHERE id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Username = ds.Tables[0].Rows[0]["username"].ToString();
                _Password = ds.Tables[0].Rows[0]["password"].ToString();
                
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public LoginData(string username,string password)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", username));
        param.Add(new MySqlParameter("@password", password));
        using (DataSet ds = connect.GetDataset("SELECT * FROM login WHERE username=@username and password=@password", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Username = ds.Tables[0].Rows[0]["username"].ToString();
                _Password = ds.Tables[0].Rows[0]["password"].ToString();

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
        param.Add(new MySqlParameter("@username", _Username));
        param.Add(new MySqlParameter("@password", _Password));    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO  login(username,password) VALUES (@username,@password)", param);
        connect.Dispose();
        connect = null;
    }
    public void Delete(string query)
    {
        Connection connect = new Connection();
        connect.ExecStatement("DELETE from login");
        connect.Dispose();
        connect = null;
    }
    //method for selection
    public DataSet getLoginData(String query)
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
    public string Username
    {
        get { return _Username; }
        set { _Password = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}