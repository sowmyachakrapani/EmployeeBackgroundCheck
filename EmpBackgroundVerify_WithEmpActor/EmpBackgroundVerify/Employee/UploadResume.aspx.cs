using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace EmpBackgroundVerify.Employee
{
    public partial class UploadResume : System.Web.UI.Page
    {
        static int empid;
        DB2 b = new DB2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                empid = int.Parse(Session["LoginId"].ToString());
                DataTable tab_emp = b.Emp_Get_EmpId(empid);
                if (tab_emp.Rows.Count > 0)
                {
                    DataTable tab_com=new DataTable();
                    DataTable tab_Emp_Comp = b.Emp_CompanyId(empid);
                    if (tab_Emp_Comp.Rows.Count > 0)
                    {
                        string compid = tab_Emp_Comp.Rows[0]["CompanyId"].ToString();
                        tab_com = b.Emp_GetCompanies(compid);
                    }
                    else
                    {
                        tab_com = b.Company_GetAll_Approved2();
                    }

                    DDLcompany.DataSource = tab_com;
                    DDLcompany.DataTextField = "CompanyName";
                    DDLcompany.DataValueField = "CompanyId";
                    DDLcompany.DataBind();
                    DDLcompany.Items.Insert(0, "Select");
                }
               
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (FUresume.HasFile)
            {
                string filename = FUresume.PostedFile.FileName;
                string extn = Path.GetExtension(filename);
                string r_path = "~/Resumes/" + empid + "_" + DDLcompany.SelectedItem.Value + extn;
                FUresume.PostedFile.SaveAs(Server.MapPath("/Resumes/" + empid + "_" + DDLcompany.SelectedItem.Value + extn));
                DataTable tab_resume=b.Emp_GetResume_Cid_Eid(DDLcompany.SelectedItem.Value, empid);
                if (tab_resume.Rows.Count == 0)
                {
                    if (b.Emp_UploadResume(DDLcompany.SelectedItem.Value, empid, r_path) == 1)
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Resume uploaded successfully.')</script>");
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Error in upoading resume.')</script>");

                    DDLcompany.SelectedIndex = 0;
                }
                else// employee already uploaded his/her resume
                {
                    int r_id=int.Parse(tab_resume.Rows[0]["ResumeId"].ToString());
                    if(b.Emp_GetResume_Cid_Eid(r_id,r_path)==1)
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Resume uploaded successfully.')</script>");
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Error in upoading resume.')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),"alert","<script>alert('Select Photo.....!')</script>");
            }
        }
    }
}