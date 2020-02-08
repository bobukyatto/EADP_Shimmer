using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shimmer.BLL;

namespace Shimmer
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        Group group = new Group();
        int currentUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] is null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            else
            {
                currentUserId = int.Parse(Session["userId"].ToString());
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true || RadioButton2.Checked == true)
            {
                if (imgUpload.HasFile)
                {
                    imgUpload.SaveAs(Server.MapPath("~//Public//Image//Uploads//" + imgUpload.FileName));
                    if (group.InsertGroup(group, groupName.Text, Convert.ToInt32(maxNo.Text), currentUserId, description.Text, imgUpload.FileName, RadioButton2.Checked ? 1 : 0) == 1)
                    {
                        group.InsertMember(group, Convert.ToInt32(currentUserId));
                        group.leaderCreateGroupRecord(group, group.getLeaderName(currentUserId));
                        success.Text = "Creation success!";
                        success.Visible = true;
                    }
                    else
                    {
                        alert.Text = "Error Occur";
                        alert.Visible = true;
                    }
                }
                else
                {
                    if (group.InsertGroup(group, groupName.Text, Convert.ToInt32(maxNo.Text), currentUserId, description.Text, "blog5.jpg", RadioButton2.Checked ? 1 : 0) == 1)
                    {
                        group.InsertMember(group, Convert.ToInt32(currentUserId));
                        group.leaderCreateGroupRecord(group, group.getLeaderName(currentUserId));
                        success.Text = "Creation success!";
                        success.Visible = true;
                    }
                    else
                    {
                        alert.Text = "Error Occur";
                        alert.Visible = true;
                    }
                }

            }
            else
            {
                alert.Text = "Please choose your options on auto-approve.";
                alert.Visible = true;
            }
        }
    }
}