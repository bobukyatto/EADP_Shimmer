using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void publicRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPublic.aspx");
        }

        protected void orgRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterOrg.aspx");
        }
    }
}