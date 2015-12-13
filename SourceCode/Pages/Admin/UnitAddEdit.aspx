<%@ Page Title="Add/Edit Unit" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="UnitAddEdit.aspx.cs" Inherits="Pages_Admin_UnitAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="defaultEntry" runat="server" DefaultButton="btnSave">
                <table cellpadding="2" cellspacing="0" border="0">
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Submit" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Formation:<font color="red">*</font>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlFormation" DataValueField="FormationID" DataTextField="FormationName">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select formation."
                                ValidationGroup="Submit" ControlToValidate="ddlFormation">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Unit:<font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxUnit" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter unit."
                                ValidationGroup="Submit" ControlToValidate="tbxUnit">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Submit" OnClick="btnSave_Click" />
                            <asp:Button ID="Button1" runat="server" Text="Back" CausesValidation="false" Width="60"
                                Height="25" PostBackUrl="~/Pages/Admin/Unit.aspx" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
