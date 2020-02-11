using Shimmer.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer.Views.User
{
    public partial class UpdateDeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateName.Text = (string)Session["fullname"];
                UpdateEmail.Text = (string)Session["email"];
                UpdatePhone.Text = (string)Session["phoneno"];
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Account acc = new Account(UpdateName.Text, UpdateEmail.Text, UpdatePhone.Text, UpdatePass.Text);
                int result = acc.UpdateAccount(Session["userId"].ToString(), UpdateName.Text, UpdateEmail.Text, UpdatePhone.Text, UpdatePass.Text);
                if (result == 1)
                {
                    Response.Redirect("UserProfile.aspx");
                }
                else
                {
                    LblMsg.Text = "Error in updating";
                    LblMsg.ForeColor = Color.Red;
                }

                // Too check if the current password 
                //Account acc = new Account(UpdateName.Text, UpdateEmail.Text, UpdatePhone.Text);
                //var checkacctobj = acc.CheckPassword(UpdateEmail.Text);
                //if (checkacctobj is null)
                //{
                //    LblMsg.Text = "please ensure your email and current password are correct" + "<br/>";
                //}
                //else if (UpdatePass.Text == checkacctobj.Password)
                //{
                //    //account acc = new account(updatename.text, updateemail.text, updatephone.text, updatepass.text);
                //    int result = acc.UpdateAccount(Session["userId"].ToString(), UpdateName.Text, UpdateEmail.Text, UpdatePhone.Text);
                //    if (result == 1)
                //    {
                //        Response.Redirect("userprofile.aspx");
                //    }
                //    else
                //    {
                //        LblMsg.Text = "error in updating";
                //        LblMsg.ForeColor = Color.Red;
                //    }
                //}
            }
        }

        private bool ValidateInput()
        {
            bool result;
            LblMsg.Text = String.Empty;


            if (String.IsNullOrEmpty(UpdateName.Text))
            {
                LblMsg.Text += "Full name is required" + "<br/>";
            }
            if (UpdateEmail.Text == "")
            {
                LblMsg.Text += "Email is required!" + "<br/>";
            }
            if (!UpdateEmail.Text.Contains("@"))
            {
                LblMsg.Text += "Not a valid email" + "<br/>";
            }
            if (UpdatePhone.Text == "")
            {
                LblMsg.Text += "Phone is required!" + "<br/>";
            }
            
            if (UpdatePass.Text != rePass.Text)
            {
                LblMsg.Text += "Password does not match!" + "<br/>";
            }

            if (String.IsNullOrEmpty(LblMsg.Text))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Account acc = new Account();
        //        int result = acc.DeleteAccount(int.Parse(Session["userId"].ToString()));

        //        Response.Redirect("Login.aspx");
        //    }
        //    catch
        //    {
        //        LblMsg.Text = "Error";
        //    }
        //}
    }
}