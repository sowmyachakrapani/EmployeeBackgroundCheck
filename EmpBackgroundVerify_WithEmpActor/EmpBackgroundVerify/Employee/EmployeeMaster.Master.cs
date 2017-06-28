using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EmpBackgroundVerify.Employee
{
    public partial class EmployeeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB2 b=new DB2();
            int empid = int.Parse(Session["LoginId"].ToString());
            DataTable tab_emp = b.Emp_Get_EmpId(empid);
            if (tab_emp.Rows.Count > 0)
            {
                lblName.Text = "WELCOME "+tab_emp.Rows[0]["EmpName"].ToString();
            }
        }
    }
}