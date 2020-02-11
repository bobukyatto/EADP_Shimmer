using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class confirmevent : System.Web.UI.Page
    {
        string eventid;
        Event eventobj;
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

            string eventid = Request.QueryString["eventid"];
            if (eventid != null)
            {
                Event eventobj = new Event().GetEventById(int.Parse(eventid));
                if (eventobj is null) // todo check if owner or admin
                {
                    Response.Redirect("/Views/Event/events.aspx");
                }
                else if (eventobj.OrganizedBy != currentUserId && Session["userType"].ToString() != "Admin")
                {
                    Response.Redirect("/Views/Event/events.aspx");
                }

            }
        }
    }
}