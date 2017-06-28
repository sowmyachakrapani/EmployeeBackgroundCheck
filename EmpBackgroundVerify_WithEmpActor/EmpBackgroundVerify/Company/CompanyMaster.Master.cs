using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpBackgroundVerify.Company
{
    public partial class CompanyMaster : System.Web.UI.MasterPage
    {
        DB2 b = new DB2();
        static string comId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                comId = Session["LoginId"].ToString();

                lblName.Text = "Welcome " + comId;
            }
        }
    }
}