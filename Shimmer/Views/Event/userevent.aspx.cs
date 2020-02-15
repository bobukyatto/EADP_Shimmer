using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class userevent : System.Web.UI.Page
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

        }

        protected void btnGroupEvents_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Views/Event/groupevent.aspx");
        }
    }
}