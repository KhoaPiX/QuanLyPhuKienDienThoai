using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace QuanLyPhuKienDienThoai
{
    internal class DBConnect
    {

        SqlConnection connect;
        public SqlConnection Connect
        {
            get { return connect; }
            set { connect = value; }
        }
        public DBConnect()
        {
            //string conStr = "Data Source=LAPTOP-LGKCINL7;Initial Catalog=QL_PhuKienDT;Integrated Security=True";
            string conStr = "Data Source=LAPTOP-LGKCINL7;Initial Catalog=QL_PhuKienDT; User ID = sa; Password = khoa23092003";
            Connect = new SqlConnection(conStr);
        }
        public void open()
        {
            if (Connect.State == ConnectionState.Closed)
                Connect.Open();
        }
        public void close()
        {
            if (Connect.State == ConnectionState.Open)
                Connect.Close();
        }
        public DataTable getDataTable(string conStr)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(conStr, Connect);
            da.Fill(dt);
            return dt;
        }
        public int updateDatabase(string selStr, DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter(selStr, Connect);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kq = da.Update(dt);
            return kq;
        }
        public object GetData(string conStr)
        {
            SqlCommand cmd;
            open();
            cmd = new SqlCommand(conStr, Connect);
            object data = cmd.ExecuteScalar();
            close();
            return data;
        }
        public void ExecCommand(string sql)
        {
            //open();
            //SqlCommand cmd = new SqlCommand(sql, Connect);
            //cmd.ExecuteNonQuery();
            //close();
        }
    }
}
