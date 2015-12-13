<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MessagePanel.ascx.cs"
    Inherits="UserControls_MessagePanel" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pnlMessage" Visible="false">
            <fieldset>
                <legend>
                    <asp:Label ID="lblMessageTitle" runat="server" /></legend>
                <asp:Label ID="lblMessageDetails" runat="server"></asp:Label>
            </fieldset>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>