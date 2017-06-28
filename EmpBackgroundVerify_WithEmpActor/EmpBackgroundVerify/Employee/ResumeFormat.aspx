<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="ResumeFormat.aspx.cs" Inherits="EmpBackgroundVerify.Employee.ResumeFormat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
          <h2><span>RESUME FORMAT</span></h2>
          <%--<p class="infopost">Posted on <span class="date">11 sep 2018</span> by <a href="#">Admin</a> &nbsp;&nbsp;|&nbsp;&nbsp; Filed under <a href="#">templates</a>, <a href="#">internet</a> <a href="#" class="com"><span>11</span></a></p>--%>
          <div class="clr"></div>
          
          <div class="post_content">
            <p >
                <table align="center" 
                    
                    style="width: 82%; background-image: url('../images/swat_default_background.jpg');">
                    <tr>
                        <td style="color: #000000; font-size: large">
                            Employee&nbsp; should upload their resume in the following format as a PDF file.</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="ImgFormat" runat="server" Height="600px" 
                                ImageUrl="~/Employee/ResumeFormat2.JPG" Width="500px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td bgcolor="#FFFF99" style="color: #000000">
                            <span style="color: #CC0000; font-size: medium">NOTE: </span>If resume uploaded 
                            in any other format will be treated as a fraud</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                NavigateUrl="~/Employee/UploadResume.aspx" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Yellow">Click Here to Upload your Resume</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
              </p>
          </div>
          <div class="clr"></div>
        </div>


</asp:Content>
