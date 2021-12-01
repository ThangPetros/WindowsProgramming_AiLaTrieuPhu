using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_AiLaTrieuPhu_Thang
{
    class DAL
    {
        SqlConnection GetConnection()
        {
            String connString = @"Data Source=DESKTOP-9CNLHJ6\SQLEXPRESS;Initial Catalog=DBAILATRIEUPHU;Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                return conn;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable GetTable(String sql)
        {
            SqlConnection conn = GetConnection();
            SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
            DataTable tl = new DataTable();
            dt.Fill(tl);
            return tl;
        }
        public void ExecNonQuery(String sql)
        {
            SqlConnection conn = GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
