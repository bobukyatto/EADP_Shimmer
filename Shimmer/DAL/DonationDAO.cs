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
    public class DonationDAO
    {
        public List<Donation> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Donations";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Donation> DNList = new List<Donation>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  
                int Fdrid = Convert.ToInt32(row["Id"]);
                string donBy = row["donationBy"].ToString();
                string donTo = row["donationTo"].ToString();
                string credType = row["creditType"].ToString();
                double donAmt = Convert.ToDouble(row["donAmt"].ToString());
                string fdrId = row["fundraiserId"].ToString();
                Donation obj = new Donation(donBy, donTo, credType, donAmt, fdrId);
                obj.donationid = Fdrid;
                DNList.Add(obj);
            }

            return DNList;
        }
        public int Insert(Donation DN)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            int result = 0;
            string sqlstmt = "Insert into Donations(donationBy, donationTo, amount, creditType, fundraiserId) Values(@paraDNBy, @paraDNTo, @paraAmt, @paraCredType, @paraFRId)";
            SqlCommand sqlCmd = new SqlCommand(sqlstmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraDNBy", DN.donationBy);
            sqlCmd.Parameters.AddWithValue("@paraDNTo", DN.donationTo);
            sqlCmd.Parameters.AddWithValue("@paraAmt", DN.donationAmount);
            sqlCmd.Parameters.AddWithValue("@paraCredType", DN.creditType);
            sqlCmd.Parameters.AddWithValue("@paraFRId", DN.fundraiserId);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}