<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarrerEmploymentHistory.ascx.cs"
    Inherits="UserControls_CarrerEmploymentHistory" %>
<table width="100%" cellspacing="0" cellpadding="0">
   
    <tr>
        <td>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="EmploymentHistory" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <table width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td class="replyHeader" colspan="2">
                        Employment History
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        Complete this section with your recent employment information.<br />Use each block to represent one single employment in cronological manner.
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView runat="server" GridLines="None" ShowHeader="False" ShowFooter="False"
                            ID="gvEmploymentHistory" Width="100%" AllowPaging="False" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="2" cellspacing="2" style="background-color: #F0F3F4;">
                                            <tr>
                                                <td colspan="2" align="center">
                                                    
                                                    Experience <%# (Container.DataItemIndex + 1).ToString() %>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    Company Name: <font color="Red">*</font>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxCompanyName" runat="server" SkinID="SkinFreeText" Text='<%# Eval("CompanyName") %>' />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                        ValidationGroup="EmploymentHistory" ControlToValidate="tbxCompanyName" ErrorMessage="Company Name is required.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                           <tr>
                                                <td>
                                                    Company Business: 
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxCompanyBusiness" runat="server" SkinID="SkinFreeText" Text='<%# Eval("CompanyBusiness") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Company Location: 
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxCompanyLocation" runat="server" SkinID="SkinFreeText" Text='<%# Eval("CompanyLocation") %>' />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    Position Held: <font color="Red">*</font>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxPositionHeld" runat="server" SkinID="SkinFreeText" Text='<%# Eval("PositionHeld") %>' />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ValidationGroup="EmploymentHistory" ControlToValidate="tbxPositionHeld" ErrorMessage="Position Held is required.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Department:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxDepartment" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Department") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Responsibilities:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxResponsibilities" runat="server" TextMode="MultiLine" Rows="3" Text='<%# Eval("Responsibities") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    Area of Experiences:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxAreaofExperiences" runat="server" TextMode="MultiLine" Rows="3" Text='<%# Eval("AreaOfExperience") %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    From:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxFrom" runat="server" SkinID="SkinFreeText"
                                                    Text='<%# Eval("FromDate").ToString()== "" ? "" :  Convert.ToDateTime(Eval("FromDate").ToString()).ToString("dd-MMM-yyyy") %>' />
                                                    <ajaxToolkit:CalendarExtender runat="server" ID="ce1" 
                                                     TargetControlID="tbxFrom" Format="dd-MMM-yyyy"/>
                                                     To
                                                     <asp:TextBox ID="tbxTo" runat="server" SkinID="SkinFreeText"
                                                     Text='<%# Eval("ToDate").ToString()== "" ? "" :  Convert.ToDateTime(Eval("FromDate").ToString()).ToString("dd-MMM-yyyy") %>' />
                                                    <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" 
                                                     TargetControlID="tbxTo" Format="dd-MMM-yyyy"/>
                                                     <asp:CheckBox runat="server" ID="chkIsContinue" Text="Continue"
                                                      Checked='<%# Eval("IsContinue").ToString() == "" ? false : Convert.ToBoolean(Eval("IsContinue")) %>' />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td colspan="2" align="right">
                                                    <asp:LinkButton runat="server" Text="Remove This Block" ID="btnEmploymentHistory" 
                                                       CausesValidation="False" OnClientClick="return confirm('Sure to remove this block?')"  CommandArgument='<%# Container.DataItemIndex %>' 
                                                        OnCommand="btnEmploymentHistory_Command" />
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
                        <asp:LinkButton runat="server" Text="Add Employment History Block (If Required)"
                            ID="btnAddEmploymentHistory" OnClick="btnAddEmploymentHistory_Click"
                             />
                    </td>
                </tr>

            </table>
        </td>
    </tr>
</table>
