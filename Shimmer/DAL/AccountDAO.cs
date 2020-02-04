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
    }
}