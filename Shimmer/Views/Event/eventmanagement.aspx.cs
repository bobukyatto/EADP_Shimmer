﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shimmer.BLL;

namespace Shimmer
{
    public partial class eventmanagement : System.Web.UI.Page
    {
        Event eventobj;
        protected void Page_Load(object sender, EventArgs e)
        {
            eventobj = new Event();
            if (Session["userId"] is null)
            {
                Response.Redirect("/Views/User/Login.aspx");
            }
        }
        

        protected void btnCloseEvent_Click(Object sender, CommandEventArgs e)
        {
            int eventId = int.Parse(e.CommandArgument.ToString());
            eventobj.closeEvent(eventId);


        }
    }
}