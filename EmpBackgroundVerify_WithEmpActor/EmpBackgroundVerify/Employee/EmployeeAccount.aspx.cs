using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpBackgroundVerify.Employee
{
    public partial class EmployeeAccount : System.Web.UI.Page
    {
        static int empid;
        DB2 b = new DB2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                empid = int.Parse(Session["LoginId"].ToString());

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Password"].ToString() == txtOld.Text)
            {
                if (b.Emp_ChangePassword(txtConfirm.Text, empid) == 1)
                {
                    Session["Password"] = txtConfirm.Text;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Password changed successfully.')</script>");
                    txtConfirm.Text = "";
                    txtNew.Text = "";
                    txtOld.Text = "";
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invalid Old Password.')</script>");
                }
            }
        }



    }
}