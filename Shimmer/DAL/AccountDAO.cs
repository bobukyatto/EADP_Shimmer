using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Shimmer.DAL
{
    public class AccountDAO
    {
        public List<Account> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select id, fullname, email, phoneno, usertype from dbo.[Account]";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);


            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Account> accList = new List<Account>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int id = int.Parse(row["id"].ToString());
                string fullname = row["fullname"].ToString();
                string email = row["email"].ToString();
                string phone = row["phoneno"].ToString();
                string usertype = row["usertype"].ToString();
                Account obj = new Account(id, fullname, email, null, phone, usertype);
                accList.Add(obj);
            }

            return accList;
        }

        public int Insert(Account acc)
        {
            // Execute NonQuery return an integer value
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "INSERT INTO Account (fullname, email, password, phoneno, usertype) " +
                "VALUES (@paraFullName, @paraEmail, @paraPassword, @paraPhone, @paraUserType)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraFullName", acc.FullName);
            sqlCmd.Parameters.AddWithValue("@paraEmail", acc.Email);
            sqlCmd.Parameters.AddWithValue("@paraPassword", acc.Password);
            sqlCmd.Parameters.AddWithValue("@paraPhone", (object)acc.Phone ?? DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@paraUserType", acc.UserType);



            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        

        public Account CheckPassword(string email)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from dbo.[Account] where email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Account verifyAccount = null;

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                int id = int.Parse(row["id"].ToString());
                string fullname = row["fullname"].ToString();
                string eemail = row["email"].ToString();
                string password = row["password"].ToString();
                string phone = row["phoneno"].ToString();
                string usertype = row["usertype"].ToString();

                verifyAccount = new Account(id, fullname, eemail, password, phone, usertype);
            }
            else
            {
                verifyAccount = null;
            }

            return verifyAccount;
        }

        public Account SelectById(int id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from dbo.[Account] where id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Account acc = null;

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string fullname = row["fullname"].ToString();
                string eemail = row["email"].ToString();
                string password = row["password"].ToString();
                string phone = row["phoneno"].ToString();
                string usertype = row["usertype"].ToString();

                acc = new Account(id, fullname, eemail, password, phone, usertype);
            }
           

            return acc;
        }

        public int UpdateAccount(string id, string fullname, string email, string phone, string password)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "UPDATE Account SET fullname = @paraFullName, email = @paraEmail, phoneno = @paraPhone, password = @paraPassword where id = @paraId ";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraFullName", fullname);
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraPhone", (object)phone ?? DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@paraPassword", password);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

       

    }
}