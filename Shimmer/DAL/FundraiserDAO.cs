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
    public class FundraiserDAO
    {
        public List<Fundraiser> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Fundraisers";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Fundraiser> FdrList = new List<Fundraiser>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int Fdrid = Convert.ToInt32(row["Id"]);
                string orgBy = row["organisedBy"].ToString();
                string name = row["name"].ToString();
                string desc = row["description"].ToString();
                double donationGoal = Convert.ToDouble(row["donationGoal"].ToString());
                string cat = row["category"].ToString();
                Fundraiser obj = new Fundraiser(orgBy, name, desc, donationGoal, cat);
                obj.id = Fdrid;
                FdrList.Add(obj);
            }

            return FdrList;
        }

        public DataSet DSFundraisers()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Fundraisers", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public Fundraiser SelectAllbyID(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Fundraisers Where id=(@paraId)";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            Fundraiser obj = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                int Fdrid = Convert.ToInt32(row["Id"]);
                string orgBy = row["organisedBy"].ToString();
                string name = row["name"].ToString();
                string desc = row["description"].ToString();
                double donationGoal = Convert.ToDouble(row["donationGoal"].ToString());
                string cat = row["category"].ToString();
                obj = new Fundraiser(orgBy, name, desc, donationGoal, cat);
                obj.id = Fdrid;
            }

            return obj;
        }
        public int Insert(Fundraiser FR)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            int result = 0;
            string sqlstmt = "Insert into Fundraisers(name, description, donationGoal, category) Values(@paraName, @paraDesc, @paraGoal, @paraCategory)";
            SqlCommand sqlCmd = new SqlCommand(sqlstmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", FR.name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", FR.description);
            sqlCmd.Parameters.AddWithValue("@paraGoal", FR.donationGoal);
            sqlCmd.Parameters.AddWithValue("@paraCategory", FR.category);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int Update(Fundraiser fdR)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Fundraisers SET name = @paraTitle, description = @paraDesc, " +
                "donationGoal = @paraDonGoal WHERE Id =  @paraId";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraTitle", fdR.name);
            sqlCmd.Parameters.AddWithValue("@paraDesc", fdR.description);
            sqlCmd.Parameters.AddWithValue("@paraDonGoal", fdR.donationGoal);
            sqlCmd.Parameters.AddWithValue("@paraId", fdR.id.ToString());

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int DeleteFundraiser(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Delete from Fundraisers WHERE Id =  @paraId";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraId", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}