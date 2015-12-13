<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Portfolio.ascx.cs" Inherits="UserControls_Portfolio" %>

<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="EducationTraining" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <table width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td class="replyHeader" colspan="2">
                        Portfolio
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        Add your portfolio
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView runat="server" GridLines="None" ShowHeader="False" ShowFooter="False"
                            ID="gvPortfolio" Width="100%" AllowPaging="False" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="2" cellspacing="2" style="background-color: #F0F3F4;">
                                            <tr>
                                                <td colspan="2" align="center">
                                                    Portfolio No
                                                    <%# (Container.DataItemIndex + 1).ToString() %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Name: <font color="Red">*</font>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxProjectName" runat="server" Text='<%# Eval("ProjectName") %>'
                                                        SkinID="BigBox" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                        ValidationGroup="EducationTraining" ControlToValidate="tbxProjectName" ErrorMessage="Project Title is required.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Duration: <font color="Red">*</font>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxDuration" runat="server" Text='<%# Eval("Duration") %>' SkinID="BigBox" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ValidationGroup="EducationTraining" ControlToValidate="tbxDuration" ErrorMessage="Duration is required.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Description:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxRemarks" runat="server" TextMode="MultiLine" Rows="3" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                     Photo:
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:FileUpload ID="filePhoto" runat="server" /><asp:Label ID="lblImage" runat="server"></asp:Label><br />
<%--                                                                <asp:HiddenField ID="hfup1" runat="server"  Value='<%# filePhoto.  %>'/>--%>
                                                                <asp:FileUpload ID="filePhoto1" runat="server" /><asp:Label ID="Label1" runat="server"></asp:Label><br />
                                                                <asp:FileUpload ID="filePhoto2" runat="server" /><asp:Label ID="Label2" runat="server"></asp:Label><br />
                                                                <asp:FileUpload ID="filePhoto3" runat="server" /><asp:Label ID="Label3" runat="server"></asp:Label>
                                                                <br />
                                                                (Allowed formats are: jpg, jpeg, bmp, png and gif. Maximum file size <b>
                                                                    <%= maxFileUploadSize.ToString() %>
                                                                    KB</b>.)
                                                            </td>
                                                            <td align="right" valign="top">
                                                                <asp:Image runat="server" ID="image" Width="50px" Height="50" Visible="False" />
                                                                <asp:Image runat="server" ID="Image1" Width="50px" Height="50" Visible="False" /><br />
                                                                <asp:Image runat="server" ID="Image2" Width="50px" Height="50" Visible="False" />
                                                                <asp:Image runat="server" ID="Image3" Width="50px" Height="50" Visible="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right">
                                                    <asp:LinkButton runat="server" Text="Remove This Block" ID="btnRemoveAcademicQual"
                                                        Visible='<%# (Container.DataItemIndex + 1).ToString() == "1" ? false : true  %>'
                                                        CausesValidation="False" OnClientClick="return confirm('Sure to remove this block?')"
                                                        CommandArgument='<%# Container.DataItemIndex %>' OnCommand="btnRemovePortfolio_Command" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:LinkButton runat="server" Text="Add Portfolio Block (If Required)" ID="btnAddAcademicQualification" CausesValidation="false"
                            OnClick="btnAddPortfolio_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="HBlanktd">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
