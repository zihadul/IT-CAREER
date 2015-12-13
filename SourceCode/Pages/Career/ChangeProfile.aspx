﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="ChangeProfile.aspx.cs" Inherits="Pages_Admin_ChangeProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellspacing="2" cellpadding="2" border="0">
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="PersonalDetail" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                Name: <font color="Red">*</font>
            </td>
            <td>
                <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                    ValidationGroup="PersonalDetail" ControlToValidate="tbxName" ErrorMessage="Name is required.">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Army no: <font color="Red">*</font>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlPrefix" DataValueField="ArmyPrefixID" DataTextField="PrefixName">
            </asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator5" runat="server" Display="Dynamic" ValidationGroup="PersonalDetail"
                ControlToValidate="ddlPrefix" Operator="NotEqual" ValueToCompare="0" ErrorMessage="Rank is required.">*</asp:CompareValidator>
       
            <asp:TextBox ID="tbxArmyNo" runat="server" SkinID="SmallBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                ValidationGroup="PersonalDetail" ControlToValidate="tbxArmyNo" ErrorMessage="Army no. is required.">*</asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr>
            <td>
                Rank:<font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlRank" DataValueField="RankID" DataTextField="RankName">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Rank."
                    ValidationGroup="PersonalDetail" ControlToValidate="ddlRank">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Arms:<font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlArms" DataValueField="ArmsID" DataTextField="ArmsName">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Select Rank."
                    ValidationGroup="PersonalDetail" ControlToValidate="ddlArms">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Formation:<font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlFormation" DataValueField="FormationID" DataTextField="FormationName"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlFormation_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select formation."
                    ValidationGroup="PersonalDetail" ControlToValidate="ddlFormation">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Unit:<font color="red">*</font>
            </td>
            <td align="left" valign="middle">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddlUnit" DataValueField="UnitID" DataTextField="UnitName"
                            AutoPostBack="true">
                            <asp:ListItem Text="All" Value="0" Selected="True" />
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlFormation" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Mobile:<font color="Red">*</font>
            </td>
            <td>
                <asp:TextBox ID="tbxMobile" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                    ValidationGroup="PersonalDetail" ControlToValidate="tbxMobile" ErrorMessage="Mobile no. is required.">*</asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td class="style3">
                Email: <font color="Red">*</font>
            </td>
            <td>
                <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                    ValidationGroup="PersonalDetail" ControlToValidate="tbxEmail" ErrorMessage="Email is required.">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailRequired" runat="server" ControlToValidate="tbxEmail"
                    ValidationGroup="PersonalDetail" ErrorMessage="Enter valid Email." ToolTip="Enter valid Email."
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Save" OnClick="btnPortfolio_Click"
                    ValidationGroup="PersonalDetail" />
            </td>
        </tr>
    </table>
</asp:Content>
