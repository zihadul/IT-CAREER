<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClearErrorLog.ascx.cs"
    Inherits="UserControls_ClearErrorLog" %>
<table border="0" cellspacing="0" cellpadding="0" width="45%" align="left">
    <tr>
        <td valign="top">
            Clear Error Log Before:
        </td>
        <td valign="top">
            <asp:TextBox ID="tbxDate" runat="server" Width="100px" SkinID="s" />
            <ajaxToolkit:CalendarExtender runat="server" TargetControlID="tbxDate" Format="dd-MMM-yyyy"
                ID="ce1" />
        </td>
        <td align="left">
            <td align="left">
                <asp:Button runat="Server" ID="btnSave" Text="Clear" OnClick="OnBtnSave_Click" />
            </td>
        </td>
    </tr>
</table>
