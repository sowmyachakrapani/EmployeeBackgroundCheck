using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpBackgroundVerify.Visitor
{
    public partial class LoginPage : System.Web.UI.Page
    {
        DB2 b2 = new DB2();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (b2.IsValidLogin_Admin(txtLoginId.Text, txtPassword.Text))
            {
                Session["LoginId"] = txtLoginId.Text;
                Session["Password"] = txtPassword.Text;
                Session["Type"] = "Admin";
                Response.Redirect("../Admin/AdminAccount.aspx");
            }
            else
                if (b2.IsValidLogin_Company(txtLoginId.Text, txtPassword.Text))
                {
                    Session["LoginId"] = txtLoginId.Text;
                    Session["Password"] = txtPassword.Text;
                    Session["Type"] = "Company";
                    Response.Redirect("../Company/CompanyHome.aspx");
                }
                else
                    if (b2.IsValidLogin_Employee(txtLoginId.Text, txtPassword.Text))
                    {
                        Session["LoginId"] = txtLoginId.Text;
                        Session["Password"] = txtPassword.Text;
                        Session["Type"] = "Employee";
                        Response.Redirect("../Employee/EmployeeHome.aspx");
                    }
                    else
                        lblMsg.Text = "Invalid LoginID/Password.";
        }
    }
}