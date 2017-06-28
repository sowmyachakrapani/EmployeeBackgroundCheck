<%@ Page Title="" Language="C#" MasterPageFile="~/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="JobSeeker.aspx.cs" Inherits="EmpBackgroundVerify.Company.JobSeeker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article">
          <h2><span>JOB SEEKERS</span></h2>
          <%--<p class="infopost">Posted on <span class="date">11 sep 2018</span> by <a href="#">Admin</a> &nbsp;&nbsp;|&nbsp;&nbsp; Filed under <a href="#">templates</a>, <a href="#">internet</a> <a href="#" class="com"><span>11</span></a></p>--%>
          <div class="clr"></div>
          
          <div class="post_content">
            <p >
                <table align="center" style="width:100%">
                    <tr>
                        <td style="color: #000000; font-size: large">
                        
                            
                        
                            <asp:DataList ID="DL_Resumes" runat="server" BackColor="White" 
                                BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                                GridLines="Horizontal" RepeatColumns="2">
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                <ItemStyle BackColor="White" ForeColor="#333333" />
                                <ItemTemplate>
                                    <asp:Panel ID="Panel3" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="color: #FF0000">
                                                                EMPLOYEE ID</td>
                                                            <td>
                                                                <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmpId") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="LB_Accuracy" runat="server" 
                                                                    CommandArgument='<%# Eval("EmpId") %>'  ForeColor="Blue" 
                                                                    onclick="LB_Accuracy_Click">Accuracy</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="LB_BG" runat="server" 
                                                                    CommandArgument='<%# Eval("EmpId") %>' ForeColor="#1E21FE" 
                                                                    onclick="LB_BG_Click">Background</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
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
                                        </table>
                                    </asp:Panel>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            </asp:DataList>
                        
                            
                        
                            <br />
                            <br />
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        
                            
                        
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
