using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using Shimmer.BLL;

namespace Shimmer.DAL
{
    public class EventDAO
    {
        
       public List<Event> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection mySQLConnection = new SqlConnection(DBConnect);

            string SQLStatement= "Select * from Event";
            

            SqlDataAdapter da = new SqlDataAdapter(SQLStatement, mySQLConnection);

            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            List<Event> eventList = new List<Event>();
            int numResultRow = ds.Tables[0].Rows.Count;
            for (int i=0; i < numResultRow; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int OrganizedBy = int.Parse(row["eventOrganizedBy"].ToString());
                string Name = row["eventName"].ToString();
                string Image = row["eventImage"].ToString();
                string Description = row["eventDescription"].ToString();
                string Location = row["eventLocation"].ToString();
                string PostalCode = row["eventPostalCode"].ToString();
                int Status = int.Parse(row["eventStatus"].ToString());
                int Category = int.Parse(row["eventCategory"].ToString());
                float Charges = int.Parse(row["eventCharges"].ToString());
                string ContactName = row["eventContactName"].ToString();
                string ContactEmail = row["eventContactEmail"].ToString();
                string ContactNumber = row["eventContactNumber"].ToString();

                string StartDateTime = row["eventStartDateTime"].ToString();

                string Duration = row["eventDuration"].ToString();
                int MinimumAttendee = int.Parse(row["eventMinimumAttendee"].ToString());
                int MaximumAttendee = int.Parse(row["eventMaximumAttendee"].ToString());
                int Certification = int.Parse(row["Certification"].ToString());
                int Id = int.Parse(row["Id"].ToString());
                Event obj = new Event(OrganizedBy, Name,Image,Description,Location,PostalCode,Status,Category,Charges,ContactName,ContactEmail,ContactNumber,StartDateTime,Duration,MinimumAttendee,MaximumAttendee,Certification,Id);
                eventList.Add(obj);

            }
            return eventList;
        }

        public Event SelectById(int id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Event where id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Event emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                int OrganizedBy = int.Parse(row["eventOrganizedBy"].ToString());
                string Name = row["eventName"].ToString();
                string Image = row["eventImage"].ToString();
                string Description = row["eventDescription"].ToString();
                string Location = row["eventLocation"].ToString();
                string PostalCode = row["eventPostalCode"].ToString();
                int Status = int.Parse(row["eventStatus"].ToString());
                int Category = int.Parse(row["eventCategory"].ToString());
                float Charges = float.Parse(row["eventCharges"].ToString());
                string ContactName = row["eventContactName"].ToString();
                string ContactEmail = row["eventContactEmail"].ToString();
                string ContactNumber = row["eventContactNumber"].ToString();

                string StartDateTime = row["eventStartDateTime"].ToString();

                string Duration = row["eventDuration"].ToString();
                int MinimumAttendee = int.Parse(row["eventMinimumAttendee"].ToString());
                int MaximumAttendee = int.Parse(row["eventMaximumAttendee"].ToString());
                int Certification = int.Parse(row["Certification"].ToString());
                int Id = int.Parse(row["Id"].ToString());

                emp = new Event(OrganizedBy, Name, Image, Description, Location, PostalCode, Status, Category, Charges, ContactName, ContactEmail, ContactNumber, StartDateTime, Duration, MinimumAttendee, MaximumAttendee, Certification, Id);

            }
            else
            {
                emp = null;
            }

            return emp;
            }

        public int Insert(Event eventobj)
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
            string sqlStmt = "INSERT INTO Event (eventOrganizedBy, eventName, eventImage, eventDescription, eventLocation," +
                "eventPostalCode,eventStatus,eventCategory,eventCharges,eventContactName,eventContactEmail,eventContactNumber,eventStartDateTime," +
                "eventDuration, eventMinimumAttendee,eventMaximumAttendee,certification) " +
                "VALUES (@paraOrganizedBy,@paraName, @paraImage, @paraDescription, @paraLocation, @paraPostalCode, @paraStatus, @paraCategory, @paraCharges, @paraContactName, " +
                "@paraContactEmail, @paraContactNumber, @paraStartDateTime, @paraDuration, @paraMinimumAttendee, @paraMaximumAttendee, @paraCertification)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);
            
            sqlCmd.Parameters.AddWithValue("@paraOrganizedBy", eventobj.OrganizedBy);
            sqlCmd.Parameters.AddWithValue("@paraName", eventobj.Name);
            sqlCmd.Parameters.AddWithValue("@paraImage", eventobj.Image);
            sqlCmd.Parameters.AddWithValue("@paraDescription", eventobj.Description);
            sqlCmd.Parameters.AddWithValue("@paraLocation", eventobj.Location);
            sqlCmd.Parameters.AddWithValue("@paraPostalCode", eventobj.PostalCode);
            sqlCmd.Parameters.AddWithValue("@paraStatus", eventobj.Status);
            sqlCmd.Parameters.AddWithValue("@paraCategory", eventobj.Category);
            sqlCmd.Parameters.AddWithValue("@paraCharges", eventobj.Charges);
            sqlCmd.Parameters.AddWithValue("@paraContactName", eventobj.ContactName);
            sqlCmd.Parameters.AddWithValue("@paraContactEmail", eventobj.ContactEmail);
            sqlCmd.Parameters.AddWithValue("@paraContactNumber", eventobj.ContactNumber);
            sqlCmd.Parameters.AddWithValue("@paraStartDateTime", eventobj.StartDateTime);
            sqlCmd.Parameters.AddWithValue("@paraDuration", eventobj.Duration);
            sqlCmd.Parameters.AddWithValue("@paraMinimumAttendee", eventobj.MinimumAttendee);
            sqlCmd.Parameters.AddWithValue("@paraMaximumAttendee", eventobj.MaximumAttendee);
            sqlCmd.Parameters.AddWithValue("@paraCertification", eventobj.Certification);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public int Update(Event eventobj)
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
            string sqlStmt = "UPDATE Event SET eventOrganizedBy = @paraOrganizedBy,eventName = @paraName,eventImage = @paraImage,eventDescription = @paraDescription,eventLocation = @paraLocation,eventPostalCode = @paraPostalCode,eventStatus = @paraStatus,eventCategory = @paraCategory,eventCharges = @paraCharges,eventContactName = @paraContactName,eventContactEmail = @paraContactEmail,eventContactNumber = @paraContactNumber,eventStartDateTime = @paraStartDateTime,eventDuration = @paraDuration,eventMinimumAttendee = @paraMinimumAttendee,eventMaximumAttendee = @paraMaximumAttendee,certification = @paraCertification where Id = @paraId";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraOrganizedBy", eventobj.OrganizedBy);
            sqlCmd.Parameters.AddWithValue("@paraName", eventobj.Name);
            sqlCmd.Parameters.AddWithValue("@paraImage", eventobj.Image);
            sqlCmd.Parameters.AddWithValue("@paraDescription", eventobj.Description);
            sqlCmd.Parameters.AddWithValue("@paraLocation", eventobj.Location);
            sqlCmd.Parameters.AddWithValue("@paraPostalCode", eventobj.PostalCode);
            sqlCmd.Parameters.AddWithValue("@paraStatus", eventobj.Status);
            sqlCmd.Parameters.AddWithValue("@paraCategory", eventobj.Category);
            sqlCmd.Parameters.AddWithValue("@paraCharges", eventobj.Charges);
            sqlCmd.Parameters.AddWithValue("@paraContactName", eventobj.ContactName);
            sqlCmd.Parameters.AddWithValue("@paraContactEmail", eventobj.ContactEmail);
            sqlCmd.Parameters.AddWithValue("@paraContactNumber", eventobj.ContactNumber);
            sqlCmd.Parameters.AddWithValue("@paraStartDateTime", eventobj.StartDateTime);
            sqlCmd.Parameters.AddWithValue("@paraDuration", eventobj.Duration);
            sqlCmd.Parameters.AddWithValue("@paraMinimumAttendee", eventobj.MinimumAttendee);
            sqlCmd.Parameters.AddWithValue("@paraMaximumAttendee", eventobj.MaximumAttendee);
            sqlCmd.Parameters.AddWithValue("@paraCertification", eventobj.Certification);
            sqlCmd.Parameters.AddWithValue("@paraId", eventobj.Id);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            System.Diagnostics.Debug.WriteLine("SomeText");
            System.Diagnostics.Debug.WriteLine(sqlStmt);

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public int UserJoinEvent(int eventid, int userid)
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
            string sqlStmt = "INSERT INTO EventAssociation (eventId, userId) " + "VALUES (@paraEventId, @paraUserId)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEventId", eventid);
            sqlCmd.Parameters.AddWithValue("@paraUserId", userid);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public int UserReJoinEvent(int eventid, int userid)
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
            string sqlStmt = " UPDATE EventAssociation SET status =@paraStatus WHERE eventId = " + eventid + " AND userId = " + userid;
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraStatus", "Pending");

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public int UserLeaveEvent(int eventid, int userid)
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
            string sqlStmt = " UPDATE EventAssociation SET status = @paraStatus WHERE eventId = " + eventid+" AND userId = " + userid;
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraStatus", "Left");

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<Event.eventAssociation> SelectEventAssociationByID(int eventid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ShimmerConnectionString"].ConnectionString;
            SqlConnection mySQLConnection = new SqlConnection(DBConnect);

            string SQLStatement = "Select * from EventAssociation WHERE eventId = " + eventid;
            SqlDataAdapter da = new SqlDataAdapter(SQLStatement, mySQLConnection);

            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            List<Event.eventAssociation> eventAssociationList = new List<Event.eventAssociation>();
            int numResultRow = ds.Tables[0].Rows.Count;
            for (int i = 0; i < numResultRow; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int eventId = int.Parse(row["eventId"].ToString());
                int userId = int.Parse(row["userId"].ToString());
                int groupId = int.Parse(row["groupId"].ToString());
                string status = row["status"].ToString();
                int statusBy = int.Parse(row["statusBy"].ToString());
                string statusReason= row["statusReason"].ToString();
                int reminder = int.Parse(row["reminder"].ToString());

             
                Event.eventAssociation eventAssociationobj = new Event.eventAssociation(eventid, userId,groupId,status,statusBy,statusReason,reminder);
                eventAssociationList.Add(eventAssociationobj);

            }
            return eventAssociationList;
        }

        public int GroupJoinEvent(int eventid, int groupid)
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
            string sqlStmt = "INSERT INTO EventAssociation (eventId, userId, groupId) " + "SELECT @paraEventId, Username , @paraGroupId FROM GroupMember WHERE GroupID = @paraGroupId";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEventId", eventid);
            sqlCmd.Parameters.AddWithValue("@paraGroupId", groupid);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }


    }
}