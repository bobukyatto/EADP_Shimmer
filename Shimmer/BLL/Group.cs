using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Shimmer
{
    public partial class Group
    {
        public Group()
        {

        }

        public int InsertGroup(Group group, string name, int maxno, int leader, string description, string Image, int State)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Group](Name, MaxMember, Leader, MemberNum, Description, Image, Available, State) VALUES (@Name, @MaxMember, @Leader, 1, @Description, @Image, 1, @State)", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@MaxMember", maxno);
                cmd.Parameters.AddWithValue("@Leader", leader);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Image", Image);
                cmd.Parameters.AddWithValue("@State", State);
                con.Open();
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    con.Close();
                    return 1;//success
                }
                else
                {
                    con.Close();
                    return 0;//fail
                }
            }
            catch (Exception)
            {
                return 0;//fail
            }


        }

        public int GetTotalNumber(Group group)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            string command = "Select * From [Group]";
            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            return ds.Tables[0].Rows.Count;
        }

        public int GetNumber(Group group, string command)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            return ds.Tables[0].Rows.Count;
        }

        public DataSet GetGroupById(Group group, int id)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            string command = "Select * From [Group] WHERE Id = " + id;
            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            return ds;

        }

        public string checkGroupImageUrl(string img)
        {
            if (img == "")
            {
                return "img/photo/photo-1494526585095-c41746248156.jpg";
            }
            else
            {
                return "img/group/" + img;
            }
        }

        public string getLeaderImage(int Id)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            string command = "Select * From [User] WHERE Id = " + Id.ToString();
            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            return "img/avatar/" + ds.Tables[0].Rows[0]["Icon"];
        }

        public string checkAvailability(int i)
        {
            if (i == 1)
            {
                return "Available";
            }
            else
            {
                return "Closed";
            }
        }
        public string getLeaderName(int Id)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            string command = "Select * From [User] WHERE Id = " + Id.ToString();
            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            return ds.Tables[0].Rows[0]["Name"].ToString();
        }

        public DataSet getMemberOfGroup(int Id)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            string command = "Select * From [Member] WHERE [GroupID] = " + Id.ToString();
            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            return ds;
        }

        public int GetLastGroupId(Group group)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            string command = "Select * From [Group] ORDER BY Id DESC";
            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);

        }
        public void InsertMember(Group group, int username)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("INSERT INTO [Member](Username,GroupID) VALUES (@Username,@GroupID)", con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@GroupID", GetLastGroupId(group));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void InsertMember(Group group, int username, int GroupId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("INSERT INTO [Member](Username,GroupID) VALUES (@Username,@GroupID)", con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@GroupID", GroupId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void leaderCreateGroupRecord(Group group, string username)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("INSERT INTO [GroupRecord](GroupID,OccurTime,Detail,Remark) VALUES (@GroupID,@OccurTime,@Detail,@Remark)", con);
            cmd.Parameters.AddWithValue("@GroupID", GetLastGroupId(group));
            cmd.Parameters.AddWithValue("@OccurTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Detail", username + " has created the group");
            cmd.Parameters.AddWithValue("@Remark", "Create");
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void memberJoinGroupRecord(Group group, int GroupId, string username)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("INSERT INTO [GroupRecord](GroupID,OccurTime,Detail,Remark) VALUES (@GroupID,@OccurTime,@Detail,@Remark)", con);
            cmd.Parameters.AddWithValue("@GroupID", GroupId);
            cmd.Parameters.AddWithValue("@OccurTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Detail", username + " has joined the group");
            cmd.Parameters.AddWithValue("@Remark", "Join");
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string getNameById(int Id)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            string command = "Select * From [User] WHERE Id = " + Id.ToString();
            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            return ds.Tables[0].Rows[0]["Name"].ToString();
        }

        public void updateMemberNum(Group group, int Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("UPDATE [Group] SET MemberNum = MemberNum + 1 Where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void InsertApplication(Group group, int username, int GroupId, string reason)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("INSERT INTO [Application](Username,GroupID,Status,GroupLeader,Reason) VALUES (@Username,@GroupID,@Status,@GroupLeader,@Reason)", con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@GroupID", GroupId);
            cmd.Parameters.AddWithValue("@Status", "Pending");
            cmd.Parameters.AddWithValue("@Reason", reason);
            cmd.Parameters.AddWithValue("@GroupLeader", Convert.ToInt32(GetGroupById(group, GroupId).Tables[0].Rows[0]["Leader"]));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public int checkApplication(Group group, int username, int GroupId)
        {
            DataSet ds = new DataSet();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(DBConnect);

            string command = "Select * From [Application] WHERE GroupId = " + GroupId.ToString() + " AND Username = " + username.ToString();
            Conn.Open();
            new SqlDataAdapter(command, Conn).Fill(ds);

            Conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                return 0;//no application yet
            }
            else
            {
                return 1;
            }
        }

        public void updateApplicationToApprove(Group group, int Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("UPDATE [Application] SET Status = 'Approve' Where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateApplicationToReject(Group group, int Id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("UPDATE [Application] SET Status = 'Reject' Where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}