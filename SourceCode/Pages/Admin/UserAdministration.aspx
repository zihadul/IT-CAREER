<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" ValidateRequest="false"
    MasterPageFile="~/Master_Pages/Admin.master" CodeFile="UserAdministration.aspx.cs"
    Inherits="UserAdministration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table cellspacing="1" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                <asp:Panel runat="server" ID="pnlFilter" BackColor="#ACCEBE">
                    <table cellspacing="0" cellpadding="2">
                        <tr>
                            <td>
                                <asp:Label ID="lblSearchBy" runat="server">Search By:</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSearchBy" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchBy" SkinID="Mediumtbx" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajaxToolkit:RoundedCornersExtender Radius="4" runat="server" ID="rc1" TargetControlID="pnlFilter"
                    Corners="All" />
            </td>
            <td>
                
                <asp:HyperLink ID="hlShowAll" runat="server" NavigateUrl="UserAdministration.aspx"
                    Visible="false">All Users</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" class="HeaderPadding">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" PostBackUrl="AddEditUser.aspx" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblTotalUsers" runat="server">Total User:</asp:Label>&nbsp;
                <asp:Label ID="lblNumberOfTotalUsers" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:GridView ID="gv" runat="server" DataKeyNames="UserName" AutoGenerateColumns="false"
                    Width="100%" SkinID="skinGridList"  PageSize="20" AllowPaging="True" OnPageIndexChanging="gv_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="User Name" DataField="UserName">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Role Name" DataField="RoleName">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Email" DataField="Email">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="Created On" DataField="CreateDate">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
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
</asp:Content>
