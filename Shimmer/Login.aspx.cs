using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            bool result;
            lblMsgLogin.Text = String.Empty;


            if (String.IsNullOrEmpty(TbEmailLogin.Text))
            {
                lblMsgLogin.Text += "Please input email" + "<br/>";
            }
            if (TbPassLogin.Text == "")
            {
                lblMsgLogin.Text += "Please input password!" + "<br/>";
            }
            //if (TbPassLogin.Text == Account.checkPassword(TbEmailLogin.Text))
            //{

            //}
            if (String.IsNullOrEmpty(lblMsgLogin.Text))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Account acc = new Account();
                if (TbPassLogin.Text == acc.CheckPassword(TbEmailLogin.Text))
                {
                    Session["email"] = TbEmailLogin.Text;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    lblMsgLogin.Text = "Please enter valid email and password!";
                }

            }
        }
    }
}