<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" ValidateRequest="false"
    MasterPageFile="~/Master_Pages/Admin.master" CodeFile="UserAdministration.aspx.cs"
    Title="Administrator" Inherits="UserAdministration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="5" cellpadding="2" border="0" width="100%">
                <tr>
                    <td colspan="2" valign="top">
                        <asp:Panel ID="pnlContent" runat="server" BackColor="#1570b9">
                            <table>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblSearchBy" runat="server">Search By:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSearchBy" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearchBy" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server"
                                            Text="Search"></asp:Button>
                                    </td>
                                    <td valign="top">
                                        <asp:HyperLink ID="hlShowAll" runat="server" NavigateUrl="UserAdministration.aspx"
                                            Visible="false">All Users</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <ajaxToolkit:RoundedCornersExtender ID="rcepnlContent" runat="server" BorderColor="#8a9e99"
                            Corners="Top" Radius="3" TargetControlID="pnlContent" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnAddNew" runat="server" Text="Add New" PostBackUrl="AddEditUser.aspx" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gv" runat="server" DataKeyNames="UserName" SkinID="SampleGridView"
                            AutoGenerateColumns="false" Width="100%" PageSize="20" AllowPaging="True" OnPageIndexChanging="gv_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="User Name" DataField="UserName">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Email" DataField="Email">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
<%--                                <asp:BoundField HeaderText="Created On" DataField="CreateDate">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                <asp:BoundField HeaderText="Last Login" DataField="LastLoginDate">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton SkinID="ButtonResetPassword" ID="btnViewDetails" runat="server" Text="Reset Password" PostBackUrl='<%# String.Concat("ResetPassword.aspx?UN=", Eval("UserName").ToString()) %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" SkinID="ButtonEdit" PostBackUrl='<%# String.Concat("AddEditUser.aspx?UN=", Eval("UserName").ToString()) %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:ImageButton SkinID="ButtonDelete" ID="btnDelete" runat="server"  CommandArgument='<%# Eval("UserName") %>'
                                    OnClientClick="return confirm('Pressing OK will delete this record. Do you want to continue?')"
                                    OnCommand="btnDelete_Command"></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
