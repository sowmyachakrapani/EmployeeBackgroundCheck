<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="UploadResume.aspx.cs" Inherits="EmpBackgroundVerify.Employee.UploadResume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
          <h2><span>UPLOAD YOUR RESUME</span></h2>
          <%--<p class="infopost">Posted on <span class="date">11 sep 2018</span> by <a href="#">Admin</a> &nbsp;&nbsp;|&nbsp;&nbsp; Filed under <a href="#">templates</a>, <a href="#">internet</a> <a href="#" class="com"><span>11</span></a></p>--%>
          <div class="clr"></div>
          
          <div class="post_content">
            <p >
                <table align="center" style="width:100%">
                    <tr>
                        <td style="color: #000000; font-size: large">
                        
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 141px">
                                        Company Name</td>
                                    <td style="width: 290px">
                                        <asp:DropDownList ID="DDLcompany" runat="server" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToValidate="DDLcompany" ErrorMessage="Select Company" Font-Size="Small" 
                                            ForeColor="#CC0000" ValidationGroup="a" ValueToCompare="Select"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 141px" valign="top">
                                        Upload Resume</td>
                                    <td style="width: 290px" valign="top">
                                        <asp:FileUpload ID="FUresume" runat="server" />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="FUresume" ErrorMessage="Upload resume" Font-Size="Small" 
                                            ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator>
&nbsp;<br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.pdf)$"
    ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="Please select a valid PDF File file."
    Display="Dynamic" Font-Size="Small" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 141px">
                                        &nbsp;</td>
                                    <td style="width: 290px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 141px">
                                        &nbsp;</td>
                                    <td style="width: 290px">
                                        <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Text="SUBMIT" 
                                            onclick="btnSubmit_Click" ValidationGroup="a" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 141px">
                                        &nbsp;</td>
                                    <td style="width: 290px">
                                        &nbsp;&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        
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
