using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shimmer
{
    public partial class GroupList : System.Web.UI.Page
    {
        Group group = new Group();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["command"] == null)
            {
                itemCount.InnerText = group.GetTotalNumber(group).ToString();
            }
            else
            {
                SqlDataSource1.SelectCommand = Session["command"].ToString();
                SqlDataSource1.DataBind();
                ListView1.DataBind();
                itemCount.InnerText = group.GetNumber(group, Session["command"].ToString()).ToString();
                Session["command"] = null;
            }

            if (Session["DDL"] != null)
            {
                DropDownList1.SelectedValue = Session["DDL"].ToString();
                Session["DDL"] = null;
            }
        }

        protected string CheckAvailability(int available)
        {
            return group.checkAvailability(available);
        }

        protected string GetImage(string img)
        {
            return group.checkGroupImageUrl(img);
        }

        protected string GetLeaderImage(int username)
        {
            return group.getLeaderImage(username);
        }
        protected string GetLeaderName(int username)
        {
            return group.getLeaderName(username);
        }

        protected void filter_Click(object sender, EventArgs e)
        {
            string command = "Select * From [Group]";
            if (name.Text != "")//If name textbox is filled with text
            {
                command += " WHERE [Name] LIKE '%" + name.Text + "%'";
                if (available.Checked == true)//if availble box is checked
                {
                    command += " AND Available = 1";
                    if (instantJoin.Checked == true)
                    {
                        command += " AND State = 0";
                        Session["command"] = command;
                        Response.Redirect("GroupList.aspx");
                    }
                    else
                    {
                        Session["command"] = command;
                        Response.Redirect("GroupList.aspx");
                    }
                }
                else if (instantJoin.Checked == true)//if instantJoin box is checked
                {
                    command += " AND State = 0";
                    Session["command"] = command;
                    Response.Redirect("GroupList.aspx");
                }
                else//If ONLY name textbox is filled with text
                {
                    Session["command"] = command;
                    Response.Redirect("GroupList.aspx");
                }
            }
            else if (available.Checked == true)
            {
                command += " WHERE Available = 1";
                if (instantJoin.Checked == true)
                {
                    command += " AND State = 0";
                    Session["command"] = command;
                    Response.Redirect("GroupList.aspx");
                }
                else
                {
                    Session["command"] = command;
                    Response.Redirect("GroupList.aspx");
                }
            }
            else if (instantJoin.Checked == true)
            {
                command += " WHERE State = 0";
                Session["command"] = command;
                Response.Redirect("GroupList.aspx");
            }
            else
            {
                Session["command"] = command;
                Response.Redirect("GroupList.aspx");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string command = SqlDataSource1.SelectCommand;
            if (DropDownList1.SelectedValue == "0")
            {
                command.Replace(" ORDER BY Id DESC", "").Replace(" ORDER BY MemberNum DESC", "");
            }
            else if (DropDownList1.SelectedValue == "1")//if most recent
            {
                command.Replace(" ORDER BY MemberNum DESC", "");
                command += " ORDER BY Id DESC";
            }
            else//if most member
            {
                command.Replace(" ORDER BY Id DESC", "");
                command += " ORDER BY MemberNum DESC";
            }
            Session["command"] = command;
            Session["DDL"] = DropDownList1.SelectedValue;
            Response.Redirect("GroupList.aspx");
        }
    }
}