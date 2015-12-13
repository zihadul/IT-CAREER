<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="EmailTemplate.aspx.cs" Inherits="Pages_Common_EmailTemplate" Title="Email Template Setup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table border="0" cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td class="HBlanktd">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                    Width="100%" AllowPaging="false" SkinID="skinGridList" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="TemplateTitle" HeaderText="Template Title">
                            <ItemStyle CssClass="GridCellStyle" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" PostBackUrl='<%# String.Concat("~/Pages/Admin/EmailTemplateEdit.aspx?ID=", Eval("ID").ToString()) %>'
                                    SkinID="ButtonEdit" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="50px" HorizontalAlign="Center" CssClass="GridCellStyle" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
