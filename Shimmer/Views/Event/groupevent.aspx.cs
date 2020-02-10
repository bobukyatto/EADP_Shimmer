using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class groupevent : System.Web.UI.Page
    {
        int currentUserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] is null)
            {
                Response.Redirect("/Views/User/Login.aspx");
            }
            else
            {
                currentUserId = int.Parse(Session["userId"].ToString());
            }

            if (!IsPostBack)
            {
                // need to force select command and databind again. else dropdownlist.count will be 0
                groupListSqlDataSource.SelectCommand = "SELECT * FROM [Group] WHERE (Id IN (SELECT Group_1.Id FROM [Group] AS Group_1 INNER JOIN GroupMember ON Group_1.Id = GroupMember.GroupID WHERE (GroupMember.Username = @paramUserId)))";
                ddlGroupList.DataBind();
            }

            if (ddlGroupList.Items.Count == 0)
            {
                
                lbGroupHeading.Text = "You are not in a group.";
                ddlGroupList.Visible = false;
            }

        }
    }
}