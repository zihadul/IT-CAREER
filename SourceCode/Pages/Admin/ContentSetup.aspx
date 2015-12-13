<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="ContentSetup.aspx.cs" Inherits="Pages_Admin_ContentSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:Panel ID="pnlContent" runat="server">
        <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="labelMessage" align="left">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="GeneraltdLabel">
                    Page:
                    <asp:DropDownList ID="ddlPage" runat="server" AppendDataBoundItems="true" DataTextField="pagename"
                        DataValueField="virtualpath" AutoPostBack="true"
                        onselectedindexchanged="ddlPage_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-top:10px">
                    <cc1:Editor ID="txtContent" runat="server" Width="100%" Height="500px" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:RoundedCornersExtender ID="rcepnlContent" runat="server" BorderColor="#8a9e99"
        Corners="Top" Radius="3" TargetControlID="pnlContent" />
</asp:Content>
