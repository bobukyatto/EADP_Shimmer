using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class RegisterPublic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool ValidateInput()
        {
            bool result;
            lblMsg.Text = String.Empty;


            if (String.IsNullOrEmpty(TbfullName.Text))
            {
                lblMsg.Text += "Full name is required" + "<br/>";
            }
            if (TbEmail.Text == "")
            {
                lblMsg.Text += "Email is required!" + "<br/>";
            }
            if (!TbEmail.Text.Contains("@"))
            {
                lblMsg.Text += "Not a valid email" + "<br/>";
            }
            if (TbPassword.Text == "")
            {
                lblMsg.Text += "Password is required!" + "<br/>";
            }
            if (TbPassword.Text != TbRePass.Text)
            {
                lblMsg.Text += "Password does not match!" + "<br/>";
            }

            if (String.IsNullOrEmpty(lblMsg.Text))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Account acc = new Account(TbfullName.Text, TbEmail.Text, TbPassword.Text, null, "Public");
                int result = acc.AddAccount();
                if (result == 1)
                {
                    lblMsg.Text = "User added successfully!";
                    lblMsg.ForeColor = Color.Green;
                }
                else
                {
                    lblMsg.Text = "Error in adding new user!";
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }
    }
}