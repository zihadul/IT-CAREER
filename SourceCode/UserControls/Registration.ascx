<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Registration.ascx.cs"
    Inherits="UserControls_Registration" %>
<table border="0" cellspacing="0" cellpadding="3" align="center"  border="1">
    <tr>
        <td colspan="2" class="labelMessage" align="left">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="PersonalDetail" runat="server" />
        </td>
    </tr>
    </tr>
    <tr>
        <td class="style1">
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
            <asp:TextBox ID="tbxArmyNo" runat="server" SkinID="SmallBox" placeholder="Army No"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                ValidationGroup="PersonalDetail" ControlToValidate="tbxArmyNo" ErrorMessage="Army no. is required.">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator6" runat="server" Display="Dynamic" ValidationGroup="PersonalDetail"
                ControlToValidate="tbxArmyNo" Operator="DataTypeCheck"  
                ErrorMessage="Required number." Type="Integer">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
            Rank:<font color="red">*</font>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlRank" DataValueField="RankID" DataTextField="RankName">
            </asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ValidationGroup="PersonalDetail"
                ControlToValidate="ddlRank" Operator="NotEqual" ValueToCompare="0" ErrorMessage="Rank is required.">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
            Arms:<font color="red">*</font>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlArms" DataValueField="ArmsID" DataTextField="ArmsName">
            </asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator3" runat="server" Display="Dynamic" ValidationGroup="PersonalDetail"
                ControlToValidate="ddlArms" Operator="NotEqual" ValueToCompare="0" ErrorMessage="Arms is required.">*</asp:CompareValidator>
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
            <asp:CompareValidator ID="CompareValidator4" runat="server" Display="Dynamic" ValidationGroup="PersonalDetail"
                ControlToValidate="ddlFormation" Operator="NotEqual" ValueToCompare="0" ErrorMessage="Formation is required.">*</asp:CompareValidator>
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
                        ValidationGroup="PersonalDetail" AutoPostBack="true">
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
        <td class="style1">
            Mobile:<font color="Red">*</font>
        </td>
        <td>
            <asp:TextBox ID="tbxMobile" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic"
                ValidationGroup="PersonalDetail" ControlToValidate="tbxMobile" ErrorMessage="Mobile No. is required.">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
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
        <td class="style1">
            User Name: <font color="Red">*</font>
        </td>
        <td>
            <asp:TextBox ID="tbxUserName" runat="server" SkinID="SkinPrice" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                ValidationGroup="PersonalDetail" ControlToValidate="tbxUserName" ErrorMessage="User Name is required.">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="GeneraltdLabel">
            Password:&nbsp;<font color="red">*</font>
        </td>
        <td class="GeneraltdText">
            <asp:TextBox ID="tbxPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password."
                ValidationGroup="PersonalDetail" ControlToValidate="tbxPassword">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="GeneraltdLabel">
            Confirm Password:&nbsp;<font color="red">*</font>
        </td>
        <td class="GeneraltdText">
            <asp:TextBox ID="tbxConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Confirm Password."
                ValidationGroup="PersonalDetail" ControlToValidate="tbxConfirmPassword">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbxConfirmPassword"
                ValidationGroup="PersonalDetail" Operator="Equal" ControlToCompare="tbxPassword"
                ErrorMessage="Password and Confirm Password are not same.">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td align="left">
            <asp:Button ID="btnSave" runat="server" Text="Submit" ValidationGroup="PersonalDetail"
                OnClick="btnSave_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
        </td>
    </tr>
</table>
