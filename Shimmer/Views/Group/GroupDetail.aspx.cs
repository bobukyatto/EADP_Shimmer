using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Shimmer
{
    public partial class GroupDetail : System.Web.UI.Page
    {
        Group group = new Group();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] is null)
            {
                Response.Redirect("/Views/User/Login.aspx");
            }
            Group group = new Group();
            if (Request.QueryString["id"] != null)
            {
                DataSet ds = null;
                ds = group.GetGroupById(group, Convert.ToInt32(Request.QueryString["id"]));
                name.InnerText = ds.Tables[0].Rows[0]["Name"].ToString();
                memberNo.Text = ds.Tables[0].Rows[0]["MemberNum"].ToString();
                description.InnerText = ds.Tables[0].Rows[0]["Description"].ToString();
                leader.InnerText = group.getLeaderName(Convert.ToInt32(ds.Tables[0].Rows[0]["Leader"]));
                leaderIcon.Src = group.getLeaderImage(Convert.ToInt32(ds.Tables[0].Rows[0]["Leader"]));
                DataSet dsMember = null;
                dsMember = group.getMemberOfGroup(Convert.ToInt32(Request.QueryString["id"]));

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["State"]) == 0)//if group is instant join
                {
                    reasonSection.Visible = false;
                }

                if(Convert.ToInt32(ds.Tables[0].Rows[0]["Available"]) == 0)//if not available
                {
                    apply.Enabled = false;
                    available.InnerText = "Close";
                }
                else
                {
                    available.InnerText = "Available";
                }

                if(Session["joinSuccess"] !=null)
                {
                    Response.Write("<script language='javascript'>alert('You have successfully join the group!');</script>");
                    Session["joinSuccess"] = null;
                }

                if(Session["applySuccess"] != null)
                {
                    Response.Write("<script language='javascript'>alert('You have successfully submit your application, please wait for the group leader to check your application.');</script>");
                    Session["applySuccess"] = null;
                }

                int memberInGroup = 0;
                foreach (DataTable table in dsMember.Tables)//if member is inside the group, return 1
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        if (Session["userId"].ToString() == dr["Username"].ToString())
                        {
                            memberInGroup = 1;
                        }
                    }
                }
                if (memberInGroup == 1)//if member is already in group
                {
                    applySection.Visible = false;
                    recordSection.Visible = true;
                }

            }
            else
            {
                Response.Redirect("GroupList.aspx");
            }

        }

        protected string getLeaderName(int Id)
        {
            return group.getLeaderName(Id);
        }

        protected string getLeaderImg(int Id)
        {
            return group.getLeaderImage(Id);
        }

        protected string getGroupImg(string img)
        {
            return group.checkGroupImageUrl(img);
        }

        protected void apply_Click(object sender, EventArgs e)
        {
            if (reasonSection.Visible == false)//if this group is instant join
            {
                group.InsertMember(group, Convert.ToInt32(Session["userId"]), Convert.ToInt32(Request.QueryString["Id"]));
                group.updateMemberNum(group, Convert.ToInt32(Request.QueryString["Id"]));
                group.memberJoinGroupRecord(group, Convert.ToInt32(Request.QueryString["Id"]), group.getNameById(Convert.ToInt32(Session["userId"])));
                Session["joinSuccess"] = true;
                Response.Redirect("GroupDetail.aspx?id=" + Request.QueryString["Id"].ToString());
            }
            else if(group.checkApplication(group, Convert.ToInt32(Session["userId"]), Convert.ToInt32(Request.QueryString["Id"]))==0)//if need to apply and user have not apply yet
            {
                group.InsertApplication(group, Convert.ToInt32(Session["userId"]), Convert.ToInt32(Request.QueryString["Id"]),reason.Text);
                Session["applySuccess"] = true;
                Response.Redirect("GroupDetail.aspx?id=" + Request.QueryString["Id"].ToString());
            }
            else//if already apply
            {
                Response.Write("<script language='javascript'>alert('You have already applied, please wait for the group leader to check your application.');</script>");
            }
        }
    }
}