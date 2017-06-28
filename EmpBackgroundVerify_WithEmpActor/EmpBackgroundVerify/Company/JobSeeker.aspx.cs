using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

namespace EmpBackgroundVerify.Company
{
    public partial class JobSeeker : System.Web.UI.Page
    {
        DB2 b = new DB2();
        static string compId;
        static DataTable tab_js = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                compId = Session["LoginId"].ToString();
                tab_js = b.EmpResume_GetAll_CompId(compId);
                if (tab_js.Rows.Count > 0)
                {
                    DL_Resumes.DataSource = tab_js;
                    DL_Resumes.DataBind();
                }
                else
                {
                    DL_Resumes.Controls.Clear();
                    DL_Resumes.DataSource = null;
                    DL_Resumes.DataBind();
                }
            }
        }

        static int empid;

        protected void LB_Accuracy_Click(object sender, EventArgs e)
        {
            empid = int.Parse(((LinkButton)sender).CommandArgument);

            DataTable tab_emp_resu = b.EmpResume_GetAll_CompId_EmpId(compId, empid);
            if (tab_emp_resu.Rows.Count > 0)
            {
                //fetching employee basic details
                string name = null;
                string mobile = null;
                string dob = null;
                string quali = null;
                string aadharno = null;
                string emailid=null;
                DataTable tab_basicDetails = b.BG_GetEmpBasicDetails_EmpId(empid);
                if (tab_basicDetails.Rows.Count > 0)
                {
                     name = tab_basicDetails.Rows[0]["EmpName"].ToString();
                     mobile = tab_basicDetails.Rows[0]["MobileNo"].ToString();
                     dob = tab_basicDetails.Rows[0]["DOB"].ToString();
                     quali = tab_basicDetails.Rows[0]["Qualification"].ToString();
                     aadharno = tab_basicDetails.Rows[0]["AadharCardNo"].ToString();
                     emailid=tab_basicDetails.Rows[0]["EmailId"].ToString();
                }

                //fetching employee work details
                string des = null;
                string dept = null;
                string deptid = null, desid = null, compid = null, compname = null, status = null;
                DataTable tab_workDetails = b.EmpResume_GetEmpDetails_EmpId(empid);
                if (tab_workDetails.Rows.Count > 0)
                {
                    des = tab_workDetails.Rows[0]["Designation"].ToString();
                    desid = tab_workDetails.Rows[0]["DesId"].ToString();
                    dept = tab_workDetails.Rows[0]["DeptName"].ToString();
                    deptid = tab_workDetails.Rows[0]["DeptId"].ToString();
                    compid = tab_workDetails.Rows[0]["CompanyId"].ToString();
                    compname = tab_workDetails.Rows[0]["CompanyName"].ToString();
                    status = tab_workDetails.Rows[0]["WorkStatus"].ToString();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("EmpId",typeof(string));
                dt.Columns.Add("EmpName", typeof(string));
                dt.Columns.Add("MobileNo", typeof(string));
                dt.Columns.Add("EmailId", typeof(string));
                dt.Columns.Add("DOB", typeof(string));
                dt.Columns.Add("Qualification", typeof(string));
                dt.Columns.Add("AadharCardNo", typeof(string));
                dt.Columns.Add("CompanyId", typeof(string));
                dt.Columns.Add("CompanyName", typeof(string));
                dt.Columns.Add("DeptId", typeof(string));
                dt.Columns.Add("DeptName", typeof(string));
                dt.Columns.Add("DesId", typeof(string));
                dt.Columns.Add("Designation", typeof(string));
                dt.Columns.Add("Status", typeof(string));

                dt.Rows.Add(empid, name, mobile, emailid, dob, quali, aadharno, compid, compname, deptid, dept, desid, des, status);

                string res_path = tab_emp_resu.Rows[0]["Resume"].ToString();
                double flg = 0;
                string res_data = ExtractTextFromPdf(Server.MapPath(res_path));
                string[] lines = res_data.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] v = lines[i].Split(':');
                    if (v[1] == dt.Rows[0][i].ToString())
                        flg++;
                }

                int l=lines.Length;
                double accuracy = 0.0;
                accuracy = (( flg / l) * (100.0));
                string acc = string.Format("Accuracy of employee details : {0:f2}%", accuracy);
                Response.Write("<script>alert('"+acc+"')</script>");
            }

        }

        protected void LB_BG_Click(object sender, EventArgs e)
        {
            empid = int.Parse(((LinkButton)sender).CommandArgument);
            Session["EmpId"] = empid;
            Session["flg"] = "4";
            Response.Redirect("EmployeeDetails.aspx");
        }


        public static string ExtractTextFromPdf(string Filepath)
        {
            PdfReader reader = new PdfReader(Filepath);


            StringBuilder text = new StringBuilder();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            }

            return text.ToString();

        }
    
    }
}