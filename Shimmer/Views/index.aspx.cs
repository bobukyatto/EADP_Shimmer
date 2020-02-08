using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class index : System.Web.UI.Page
    {

        Group group = new Group();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataBind();
            if (Repeater1.Items.Count == 0)
            {
                groupSection.Visible = false;
            }
        }

        protected string getGroupName(int Id)
        {
            return group.GetGroupById(group, Id).Tables[0].Rows[0]["Name"].ToString();
        }

        protected string getGroupImg(int Id)
        {
            return group.checkGroupImageUrl(group.GetGroupById(group, Id).Tables[0].Rows[0]["Image"].ToString());
        }
    }
}