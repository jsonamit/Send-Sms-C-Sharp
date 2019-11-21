using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ActivitiesData
/// </summary>
public class ActivitiesData
{
    private int _Id;
    private string _Tittle;
    private string _Name;
    private string _Image;
    private string _Description;

    public ActivitiesData()
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM activities WHERE id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Tittle = ds.Tables[0].Rows[0]["title"].ToString();
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _Description = ds.Tables[0].Rows[0]["description"].ToString();


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
        param.Add(new MySqlParameter("@Id", _Id));
        param.Add(new MySqlParameter("@Tittle", _Tittle));
        param.Add(new MySqlParameter("@Name", _Name));
        param.Add(new MySqlParameter("@Image", _Image));
        param.Add(new MySqlParameter("@Description", _Description));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO  activities(title,name,image,description) VALUES (@Tittle,@Name,@Image,@Description)", param);
        connect.Dispose();
        connect = null;
    }
    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@Tittle", _Tittle));
        param.Add(new MySqlParameter("@Name", _Name));
        param.Add(new MySqlParameter("@Image", _Image));
        param.Add(new MySqlParameter("@Description", _Description));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE activities SET title=@Tittle,name=@Name,image=@Image,description=@Description WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }


    public void Search(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@Tittle", _Tittle));
        param.Add(new MySqlParameter("@Description", _Description));
        param.Add(new MySqlParameter("@Image", _Image));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE activities SET title=@Tittle,name=@Name,image=@Image,description=@Description WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }

    public void Delete(string query)
    {
        Connection connect = new Connection();
        connect.ExecStatement("DELETE from activities");
        connect.Dispose();
        connect = null;
    }
    //method for selection
    public DataSet getActivitiesData(String query)
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

    public string Tittle
    {
        get { return _Tittle; }
        set { _Tittle = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }


    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public bool HasValue { get; set; }
}