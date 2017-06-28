using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Net.Mail;

namespace EmpBackgroundVerify.Visitor
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        DB2 b = new DB2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable tab_City = b.Cities_GetAll();
                if (tab_City.Rows.Count > 0)
                {
                    DDLcity.DataSource = tab_City;
                    DDLcity.DataTextField = "CityName";
                    DDLcity.DataValueField = "CityId";
                    DDLcity.DataBind();
                }
                DDLcity.Items.Insert(0, "Select");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (b.Company_Exists(txtComName.Text.ToUpper(), int.Parse(DDLcity.SelectedItem.Value)) == 0)
            {
                string comId=null;
                if (b.CompanyCount() == 0)
                    comId = "comp-1";
                else
                {
                    string maxId = b.Company_GetMaxId();
                    if (maxId.Length > 0)
                        comId="comp-"+ (int.Parse(maxId.Split('-')[1]) + 1);
                }

                //Login id and password both are same.

                txtAddress.Text=txtAddress.Text.Replace("'","''");
                txtAddress.Text=txtAddress.Text.Replace("\n","<br>");

                string certphotoName=FUphoto.PostedFile.FileName;
                string extn=Path.GetExtension(certphotoName);
                FUphoto.PostedFile.SaveAs(Server.MapPath("../CompanyCertificates/"+comId+extn));
                string filepath="../CompanyCertificates/"+comId+extn;

                if (b.Company_Register(comId, comId, txtComName.Text.ToUpper(), txtAddress.Text, txtMobileNo.Text, int.Parse(DDLcity.SelectedItem.Value), txtEmailId.Text, txtWebsite.Text, txtDate.Text, filepath) == 1)
                {
                    //sending mail
                    try
                    {
                        string msgBody = string.Format("Welcome " + txtComName.Text + " to EmployeeBGverify Site,Your loginID:" + comId + " and Password:" + comId + ".");
                        Emails.MailSender.SendEmail("demo.project.demo@gmail.com", "demo.project", txtEmailId.Text, "Company login ID and password", msgBody, " ");
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Registered successfully. LoginID and Password sent to your mail address.')</script>");
                        Response.Write("<script>window.alert('Registered successfully. LoginID and Password sent to your mail address.')</script>");
                    }
                    catch
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Registered successfully. Error in sending mail.')</script>");
                        Response.Write("<script>window.alert('Registered successfully. Error in sending mail.')</script>");
                    }
                    //MailMessage mail = new MailMessage();
                    //mail.To.Add(txtEmailId.Text);

                    //mail.From = new MailAddress("demo.project.demo@gmail.com");
                    //mail.Subject = "Reply to feedback";
                    //string Body = string.Format("Welcome " + txtComName.Text + " to EmployeeBGverify Site,Your loginID:" + comId + " and Password:" + comId+".");
                    //mail.Body = Body;
                    //SmtpClient smtp = new SmtpClient();
                    //smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                    //smtp.Port = 587;
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new System.Net.NetworkCredential("demo.project.demo@gmail.com", "demo.project");

                    ////Or your Smtp Email ID and Password
                    //smtp.EnableSsl = true;
                    //smtp.Send(mail);


                    //--------------------------------------------------------------------------
                    Clear();
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Registered successfully. LoginID and Password sent to your mail address.')</script>");
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Error in registration.')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('This company already registered.')</script>");
            }
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtAddress.Text = "";
            txtComName.Text = "";
            txtDate.Text = "";
            txtEmailId.Text = "";
            txtMobileNo.Text = "";
            txtWebsite.Text = "";
            DDLcity.SelectedIndex = 0;
        }
    }
}