using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EmpBackgroundVerify.Company
{
    public partial class EmployeeBGverify : System.Web.UI.Page
    {
        DB2 b = new DB2();
        static string compId;
        static string ViwedCompId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                compId = Session["LoginId"].ToString();
                Panel3.Visible = false;
                Panel_fresher.Visible = true;
                Panel_experience.Visible = false;
            }
        }

        protected void RBfresher_CheckedChanged(object sender, EventArgs e)
        {
            Panel_fresher.Visible = true;
            Panel_experience.Visible = false;
            LB_SendRequest.Visible = false;
            Clear();
        }

        private void Clear()
        {
            Panel3.Visible = false;
            txtCardNo.Text = "";
            txtEmpId.Text = "";
            lblMsg.Text = "";

            DVemp.DataSource = null;
            DVemp.DataBind();
        }

        protected void RBexperienced_CheckedChanged(object sender, EventArgs e)
        {
            Panel_experience.Visible = true;
            Panel_fresher.Visible = false;
            LB_SendRequest.Visible = true;
            Clear();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (RBexperienced.Checked)
            {
                if (txtEmpId.Text.Length > 0)
                {
                    DataTable tab_empDetails2 = b.BG_GetEmpWorkDetails_EmpId(int.Parse(txtEmpId.Text));
                    if (tab_empDetails2.Rows.Count > 0)
                    {
                        Panel3.Visible = true;
                        EmpWorkDetails();
                        lblMsg.Text = "Record Found.";
                    }
                    else
                    {
                        lblMsg.Text = "Record not found.";
                        Panel3.Visible = false;
                    }
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('Enter Employee ID.')<script>");
            }
            else
            {
                if (txtCardNo.Text.Length > 0)
                {
                    #region fresher details
                    DataTable tab_empDetails = b.BG_GetEmpDetails_CardNo(txtCardNo.Text);
                    if (tab_empDetails.Rows.Count > 0)
                    {
                        Panel3.Visible = true;
                        txtEmpId.Text = tab_empDetails.Rows[0]["EmpId"].ToString();
                        EmpWorkDetails();
                        lblMsg.Text = "Record Found.";
                    }
                    else
                    {
                        lblMsg.Text = "Record not found.";
                        Panel3.Visible = false;
                    }
                    #endregion
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('Enter Aadhar Card Number.')<script>");
            }
        }

        private void EmpWorkDetails()
        {
            #region experience details
            //work details
            DataTable tab_empDetails = b.BG_GetEmpWorkDetails_EmpId(int.Parse(txtEmpId.Text));
            if (tab_empDetails.Rows.Count > 0)
            {
                foreach (TableRow row in tblWork.Rows)
                {
                    tblWork.Rows.Remove(row);
                }

                lblMsg.Text = "";
                //basic details
                DataTable tab_basicDetails = b.BG_GetEmpBasicDetails_EmpId(int.Parse(txtEmpId.Text));
                ImgEmp.ImageUrl = tab_basicDetails.Rows[0]["Photo"].ToString();
                lblEmpId.Text = tab_basicDetails.Rows[0]["EmpId"].ToString();
                lblName.Text = tab_basicDetails.Rows[0]["EmpName"].ToString();
                DVemp.DataSource = tab_basicDetails;
                DVemp.DataBind();

                CreateTable();
                if (compId != ViwedCompId)
                {
                    if (b.BG_AddCompanyVisitDetails(compId, ViwedCompId, int.Parse(txtEmpId.Text)) == 1)
                        ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('Visitor details stored successfully.')</script>");
                    else
                        ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('Error in adding Visitor details.')</script>");
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('Employee belongs to same company')</script>");

            }
            else
                lblMsg.Text = "Record not found.";
            #endregion
        }

        private void CreateTable()
        {
            DataTable tab_compIds = b.BG_GetEmp_CompIds(int.Parse(txtEmpId.Text));
            if (tab_compIds.Rows.Count > 0)
            {
                #region displaying employee details
                tblWork.BorderWidth = 2;
                tblWork.GridLines = GridLines.Both;
                tblWork.BorderStyle = BorderStyle.Solid;

                for (int i = 0; i < tab_compIds.Rows.Count; i++)
                {
                    DataTable tab_emp = b.BG_GetEmpDetails_EmpId_CompId(int.Parse(txtEmpId.Text), tab_compIds.Rows[i]["CompanyId"].ToString());
                    DataTable tab_compName = b.Company_Get_ComId(tab_compIds.Rows[i]["CompanyId"].ToString());
                    TableRow row = new TableRow();
                    TableRow row2 = new TableRow();
                    TableCell c_1 = new TableCell();
                    c_1.Width = 100;
                    c_1.Text = "<b>COMPANY NAME :</b>";
                    TableCell c_2 = new TableCell();
                    c_2.Text = tab_compName.Rows[0]["CompanyName"].ToString();
                    TableCell c2_1 = new TableCell();
                    c2_1.Width = 100;
                    c2_1.Text = "";
                    TableCell c2_2 = new TableCell();
                    GridView gv = new GridView();
                    gv.ID = gv + "_" + i;
                    gv.DataSource = tab_emp;
                    gv.DataBind();


                    c2_2.Controls.Add(gv);

                    row2.Controls.Add(c_1);
                    row2.Controls.Add(c_2);
                    row.Controls.Add(c2_1);
                    row.Controls.Add(c2_2);
                    tblWork.Controls.Add(row2);
                    tblWork.Controls.Add(row);
                }
                #endregion
            }

            //Visitor company details
            ViwedCompId = tab_compIds.Rows[tab_compIds.Rows.Count - 1][0].ToString();
        }

        protected void LB_SendRequest_Click(object sender, EventArgs e)
        {
            if (compId != ViwedCompId)
            {
                if (b.BG_SendRequest(compId, ViwedCompId, int.Parse(txtEmpId.Text)) == 1)
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('Request successfully.')</script>");
                else
                    ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('Error in sending request.')</script>");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "alert", "<script>alert('Employee belongs to same company')</script>");

            //EmpWorkDetails();
            CreateTable();

        }
    }
}