using System;
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
        }

        protected void btnCloseEvent_Click(Object sender, CommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            eventobj.closeEvent(ID);

        }
    }
}