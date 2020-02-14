using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class GroupApplicationManagement : System.Web.UI.Page
    {
        Group group = new Group();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataBind();
            appNo.InnerText = Repeater1.Items.Count.ToString();
            if (Session["approve"] != null)
            {
                Response.Write("<script language='javascript'>alert('You have approved this user to join the group!');</script>");
                Session["approve"] = null;
            }

            if (Session["reject"] != null)
            {
                Response.Write("<script language='javascript'>alert('You have rejected this user to join the group!');</script>");
                Session["reject"] = null;
            }
        }

        protected string getApplicantName(int Id)
        {
            return group.getNameById(Id);
        }

        protected string getApplicantIcon(int Id)
        {
            return group.getLeaderImage(Id);
        }

        protected string getGroupName(int Id)
        {
            return group.GetGroupById(group, Id).Tables[0].Rows[0]["Name"].ToString();
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            HiddenField id = (HiddenField)item.FindControl("applicationId");
            group.updateApplicationToApprove(group, Convert.ToInt32(id.Value));
            HiddenField applicant = (HiddenField)item.FindControl("applicantId");
            HiddenField groupId = (HiddenField)item.FindControl("groupId");
            group.InsertMember(group, Convert.ToInt32(applicant.Value), Convert.ToInt32(groupId.Value));
            group.updateMemberNum(group, Convert.ToInt32(groupId.Value));
            group.memberJoinGroupRecord(group, Convert.ToInt32(groupId.Value), group.getNameById(Convert.ToInt32(applicant.Value)));
            Session["approve"] = true;
            Response.Redirect("GroupApplicationManagement.aspx");
        }

        protected void Reject_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            HiddenField id = (HiddenField)item.FindControl("applicationId");
            group.updateApplicationToReject(group, Convert.ToInt32(id.Value));
            Session["reject"] = true;
            Response.Redirect("GroupApplicationManagement.aspx");
        }
    }
}