using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Shimmer
{
    public partial class MyApplication : System.Web.UI.Page
    {
        Group group = new Group();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataBind();
            Repeater2.DataBind();
            if (Repeater1.Items.Count == 0)
            {
                noPending.Visible = true;
            }
            if (Repeater2.Items.Count == 0)
            {
                noPast.Visible = true;
            }
        }

        protected string getApplicationName(int GroupId)
        {
            DataSet ds = null;
            ds = group.GetGroupById(group, GroupId);
            return ds.Tables[0].Rows[0]["Name"].ToString();
        }

        protected string getApplicationImage(int GroupId)
        {
            DataSet ds = null;
            ds = group.GetGroupById(group, GroupId);
            return group.checkGroupImageUrl(ds.Tables[0].Rows[0]["Image"].ToString());
        }
    }
}