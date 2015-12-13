<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="EmailTemplateEdit.aspx.cs" Inherits="Pages_Common_EmailTemplateEdit"
    ValidateRequest="false" Title="Email Template Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:Panel ID="pnlContent" runat="server">
        <table border="0" cellpadding="1" cellspacing="1" class="defaultTable">
            <tr>
                <td>
                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                        <tr>
                            <td colspan="2" class="labelMessage" align="left">
                                <asp:HiddenField ID="hdnID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="GeneraltdLabel" style="width: 80px">
                                Template Title:
                            </td>
                            <td class="GeneraltdText">
                                <asp:TextBox runat="server" ID="tbxTemplateTitle" />
                            </td>
                        </tr>
                        <tr>
                            <td class="GeneraltdLabel">
                                Variables:
                            </td>
                            <td class="GeneraltdText">
                                <asp:Label runat="server" ID="lblVariables" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <cc1:Editor ID="txtContent" runat="server" Width="100%" Height="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;
                                <asp:Button ID="hlkBack" CausesValidation="False" runat="server" PostBackUrl="~/Pages/Admin/EmailTemplate.aspx"
                                    Text="Back" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:RoundedCornersExtender ID="rceLogin" runat="server" BorderColor="#c1a669"
        Corners="Top" Radius="3" TargetControlID="pnlContent" />
</asp:Content>
