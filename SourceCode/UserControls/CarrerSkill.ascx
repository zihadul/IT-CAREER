<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarrerSkill.ascx.cs" Inherits="UserControls_CarrerSkill" %>
<table width="100%" cellspacing="5" cellpadding="0">
    <tr>
        <td class="replyHeader" >
            Field of Interest
        </td>
    </tr>
    <tr>
        <td class="Course" >
            <fieldset>
                <legend><b>
                    <asp:CheckBox ID="chkSoftware" runat="server" OnCheckedChanged="chkSoftware_CheckedChanged"
                        Text="Software" AutoPostBack="true" /></b></legend>
                <table width="100%">
                    <tr>
                        <td class="style1" colspan="2" valign="top">
                            <asp:Panel ID="pnlInterest" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DataList ID="dlInterest" runat="server" DataKeyField="InterestID" RepeatColumns="8"
                                            Width="100%" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkInterest" runat="server" /><%# Eval("InterestName")%>
                                                <asp:Label runat="server" ID="lblInterestID" Text=' <%# Eval("InterestID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="chkSoftware" EventName="CheckedChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <%--<asp:CheckBox ID="chkSoftware" runat="server" OnCheckedChanged="chkSoftware_CheckedChanged" Text="Software" AutoPostBack="true"/> --%>
        </td>
    </tr>
    <tr>
        <td style="padding-top: 10px" >
        </td>
    </tr>
    <tr>
        <td class="Course">
            <fieldset>
                <legend><b>
                    <asp:CheckBox ID="chkHardware" runat="server" OnCheckedChanged="chkHardware_CheckedChanged"
                        Text="Hardware" AutoPostBack="true" /></b></legend>
                <table width="100%">
                    <tr>
                        <td class="style1" colspan="2" valign="top">
                            <asp:Panel ID="pnlHardware" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DataList ID="dlHardware" runat="server" DataKeyField="InterestID" RepeatColumns="8"
                                            Width="100%" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkInterest" runat="server" /><%# Eval("InterestName")%>
                                                <asp:Label runat="server" ID="lblInterestID" Text=' <%# Eval("InterestID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="chkHardware" EventName="CheckedChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td style="padding-top: 10px" >
        </td>
    </tr>
    <tr>
        <td class="Course">
            <fieldset>
                <legend><b>
                    <asp:CheckBox ID="chkNetwork" runat="server" OnCheckedChanged="chkNetwork_CheckedChanged"
                        Text="Network" AutoPostBack="true" /></b></legend>
                <table width="100%">
                    <tr>
                        <td class="style1" colspan="2" valign="top">
                            <asp:Panel ID="pnlnetwork" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DataList ID="dlNetwork" runat="server" DataKeyField="InterestID" RepeatColumns="8"
                                            Width="100%" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkInterest" runat="server" /><%# Eval("InterestName")%>
                                                <asp:Label runat="server" ID="lblInterestID" Text=' <%# Eval("InterestID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="chkNetwork" EventName="CheckedChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
</table>
<%--<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="EducationTraining" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <table width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td class="replyHeader" colspan="2">
                        Field of Interest
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        Select your interest by category
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView runat="server" GridLines="None" ShowHeader="False" ShowFooter="False"
                            ID="gvEducation" Width="100%" AllowPaging="False" AutoGenerateColumns="False"
                            OnRowDataBound="gvEducation_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="2" cellspacing="2" style="background-color: #F0F3F4;">
                                            <tr>
                                                <td colspan="2" align="center">
                                                    Academic Qualification No
                                                    <%# (Container.DataItemIndex + 1).ToString() %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Course">
                                                    Category:<font color="red">*</font>
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Text="Select" />
                                                        <asp:ListItem Text="Software" />
                                                        <asp:ListItem Text="Hardware" />
                                                        <asp:ListItem Text="Network" />
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator5" runat="server" Display="Dynamic" ControlToValidate="ddlCategory"
                                                        ValidationGroup="EmploymentHistory11" Operator="NotEqual" ValueToCompare="Select"
                                                        ErrorMessage="Category is required.">Select Category</asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1" colspan="2" valign="top">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:DataList ID="dlInterest" runat="server" DataKeyField="InterestID" RepeatColumns="8"
                                                                Width="100%" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkInterest" runat="server" /><%# Eval("InterestName")%>
                                                                    <asp:Label runat="server" ID="lblInterestID" Text=' <%# Eval("InterestID") %>' Visible="false" />
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right">
                                                    <asp:LinkButton runat="server" Text="Remove This Block" ID="btnRemoveAcademicQual"
                                                        Visible='<%# (Container.DataItemIndex + 1).ToString() == "1" ? false : true  %>'
                                                        CausesValidation="False" OnClientClick="return confirm('Sure to remove this block?')"
                                                        CommandArgument='<%# Container.DataItemIndex %>' OnCommand="btnRemoveAcademicQual_Command" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:LinkButton runat="server" Text="Add Academic Qualification Block (If Required)"
                            ID="btnAddAcademicQualification" OnClick="btnAddAcademicQualification_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="HBlanktd">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>--%>
