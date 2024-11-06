using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCounterFinalProject.Classes
{
    public class DataBaseProcess
    {
        // public static string strConnect = "Data Source=DESKTOP-IDTOGAB\\SQLEXPRESS03;" +
        //"DataBase=BTL_LTTQ;User ID=sa;" +
        //"Password=toantung3107;Integrated Security=false";

        public static string strConnect = "Data Source=DESKTOP-JSDGA71\\SQLEXPRESS;Initial Catalog=BTL_LTTQ;Integrated Security=True";

        SqlConnection sqlConnect = null;

        // open connect
        void OpenConnect()
        {
            sqlConnect = new SqlConnection(strConnect);
            if(sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        // close connect
        void CloseConnect()
        {
            if(sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }

        // execute select
        public DataTable DataReader(string sqlSelct)
        {
            DataTable tblData = new DataTable();
            OpenConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelct, sqlConnect);
            sqlData.Fill(tblData);
            CloseConnect();
            return tblData;
        }

        // execute insert, update, delete
        public void DataChange(string sql)
        {
            OpenConnect();
            SqlCommand sqlComma = new SqlCommand();
            sqlComma.Connection = sqlConnect;
            sqlComma.CommandText = sql;
            sqlComma.ExecuteNonQuery();
            CloseConnect();
        }


    }
}
