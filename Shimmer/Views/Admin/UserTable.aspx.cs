using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer.Views.Admin
{
    public partial class UserTabe : System.Web.UI.Page
    {
        //List<Account> aList;
        protected void Page_Load(object sender, EventArgs e)
        {
            //RefreshGridView();
            Account acc = new Account();
            GvAccount.DataSource = acc.GetAllAccount();
            GvAccount.DataBind();
        }

        //private void RefreshGridView()
        //{
        //    Account acc = new Account();
        //    aList = acc.GetAllAccount();

        //    // using gridview to bind to the list of employee objects
        //    GvAccount.Visible = true;
        //    GvAccount.DataSource = aList;
        //    GvAccount.DataBind();
        //}

        protected void GvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row = GvAccount.SelectedRow;
            //try
            //{
            //    Account acc = new Account();
            //    int result = acc.DeleteAccount(Session["Id"].ToString());
            //}
            //catch
            //{
            //    LblMsg.Text = "Error";
            //}
        }
    }
}