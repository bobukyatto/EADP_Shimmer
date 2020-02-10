using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer.Views.User
{
    public partial class ProfileOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayProfile();
        }

        protected void DisplayProfile()
        {
            Account accObj = new Account();
            accObj = accObj.GetAccountById(int.Parse(Session["userId"].ToString()));
            if (accObj != null)
            {
                LblName.Text = accObj.FullName;
                LblEmail.Text = accObj.Email;
                LblPhone.Text = accObj.Phone;

                Session["fullname"] = accObj.FullName;
                Session["phoneno"] = accObj.Phone;

            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUser.aspx");
        }
    }
}