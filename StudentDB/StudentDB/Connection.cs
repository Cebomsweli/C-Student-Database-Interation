using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StudentDB
{
    class Connection
    {
        private SqlConnection conn;
        private SqlCommand comm;
        private SqlDataAdapter da;
        private DataTable dt;
        SqlCommandBuilder cmBuilder;

        //Initializing connection
       public Connection()
        {
            string connectionString = @"Data Source=146.230.177.46\ISTN3;Initial Catalog=ist3df;User ID=ist3df;Password=yn6yw4";
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT * FROM tblStudent", conn);
        }

        //Data table(It opens connection)(It instantiate the table adapter object that queries the DB)
        public DataTable QueryDdata()
        {
            conn.Open();
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        //updating the table
        public void Update(DataTable dt)
        {
            conn.Open();
            cmBuilder = new SqlCommandBuilder(da);
            da.Update(dt);
            conn.Close();
        }

        public void InsertStudent(string stuName,int age,double aveMarks,string password)
        {
            DataTable dt = QueryDdata();
            DataRow dr = dt.NewRow();
            dr["Stu_name"]= stuName;
            dr["Stu_age"] = age;
            dr["Stu_average"] = aveMarks;
            dr["Stu_password"] = password;
            dt.Rows.Add(dr);
            Update(dt);
        }
    }
}
