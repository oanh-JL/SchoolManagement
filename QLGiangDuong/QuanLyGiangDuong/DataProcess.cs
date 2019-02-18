using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiangDuong
{
    class DataProcess
    {
       // string connStr = "Data Source=DESKTOP-4K7P4SD\\SQLEXPRESS;Initial Catalog=QLGiangDuong;Integrated Security=True";
         string connStr = "Data Source=HAKHANH;Initial Catalog=QLGiangDuong;Integrated Security=True";
        SqlConnection sqlConn = null;
       public  void OpenConnect()
        {
            sqlConn = new SqlConnection(connStr);
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
        }
       public  void CloseConnect()
        {
            if (sqlConn.State != ConnectionState.Closed)
                sqlConn.Close();
            sqlConn.Dispose();
        }
        public DataTable SelectTable(string sqlSelect)
        {
            DataTable dtResult = new DataTable();
            OpenConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect, sqlConn);
            sqlData.Fill(dtResult);
            CloseConnect();
            sqlData.Dispose();
            return dtResult;
        }
        public void UpdateData(string sqlUpdates)
        {
            OpenConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = sqlUpdates;
            sqlComm.ExecuteNonQuery();
            CloseConnect();
            sqlComm.Dispose();
        }
        

    }
}
