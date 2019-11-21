using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for FeeData
/// </summary>
public class FeeData
{
    private int _Id;
    private int _User_id;
    private string _Fee;
    private string _Payment;
    private string _Remain_payment;

    public FeeData()
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM fee WHERE id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _User_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                _Fee = ds.Tables[0].Rows[0]["fee"].ToString();
                _Payment = ds.Tables[0].Rows[0]["payment"].ToString();
                _Remain_payment = ds.Tables[0].Rows[0]["remain_payment"].ToString();              
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
        param.Add(new MySqlParameter("@user_id", _User_id));
        param.Add(new MySqlParameter("@fee", _Fee));
        param.Add(new MySqlParameter("@payment", _Payment));
        param.Add(new MySqlParameter("@remain_payment", _Remain_payment));      
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO  fee(user_id,fee,payment,remain_payment) VALUES (@user_id,@fee,@payment,@remain_payment)", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateFee(int user_id)  
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", _User_id));
        param.Add(new MySqlParameter("@payment", _Payment));
        param.Add(new MySqlParameter("@remain_payment", _Remain_payment));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE fee SET payment=@payment,remain_payment=@remain_payment WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Delete(string query)
    {
        Connection connect = new Connection();
        connect.ExecStatement("DELETE from fee");
        connect.Dispose();
        connect = null;
    }
    //method for selection
    public DataSet getFeeData(String query)
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
    public int Userid
    {
        get { return _User_id; }
        set { _User_id = value; }
    }
    public string Fee
    {
        get { return _Fee; }
        set { _Fee = value; }
    }
    public string Payment
    {
        get { return _Payment; }
        set { _Payment = value; }
    }
    public string Remain_payment
    {
        get
        {
            return _Remain_payment;
        }
        set
        {
            _Remain_payment = value;
        }
    }
    public bool HasValue
    {
        get;
        set;

    }
}