<%@ Page Language="C#" MasterPageFile="~/Master_Pages/PrintMaster.master" AutoEventWireup="true"
    CodeFile="ViewResume.aspx.cs" Inherits="Pages_Career_ViewResume" Title="View Resume" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td align="left">
                <asp:Panel runat="server" ID="pnlAction" Visible="False">
                    <div style="text-align: center">
                        <asp:Panel runat="server" ID="pnlActionCommand" CssClass="modalPopup">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <b>Set Action and Comments</b>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Action:
                                    </td>
                                    <td>
                                        <asp:RadioButton runat="server" ID="rdoShortList" Text="Short List" GroupName="Action" />
                                        <asp:RadioButton runat="server" ID="rdoReject" Text="Reject" GroupName="Action" />
                                        <asp:RadioButton runat="server" ID="rdoNoAction" Text="No Action" GroupName="Action" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Comment:
                                    </td>
                                    <td style="width: 350px">
                                        <asp:TextBox runat="server" ID="tbxComment" Text="" TextMode="MultiLine" Rows="3" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="HBlanktd">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Button ID="btnAction" runat="server" Text="Save" OnClick="btnAction_Click" />
                                        <asp:Button ID="buttonOK" runat="server" Text="Close" />
                                        <asp:LinkButton ID="btnCancel" runat="server" Text="" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="Popup1" runat="server" TargetControlID="btnSetAction"
                            PopupControlID="pnlActionCommand" BackgroundCssClass="modalBackground" DropShadow="true"
                            RepositionMode="RepositionOnWindowResizeAndScroll" OkControlID="buttonOK" CancelControlID="btnCancel">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel runat="server" ID="pnlEmail" CssClass="modalPopup" Width="600px">
                            <table width="100%">
                                <tr>
                                    <td colspan="2">
                                        <b>Send Email</b>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80px;">
                                        Subject
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="tbxSubject" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="HBlanktd">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Message:
                                    </td>
                                    <td style="width: 350px">
                                        <cc1:Editor ID="tbxMessage" runat="server" Width="100%" Height="350px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="HBlanktd">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                                        <asp:Button ID="btnOKEmail" runat="server" Text="Close" />
                                        <asp:LinkButton ID="btnCancelEmail" runat="server" Text="" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnSendEmail"
                            PopupControlID="pnlEmail" BackgroundCssClass="modalBackground" DropShadow="true"
                            RepositionMode="RepositionOnWindowResizeAndScroll" OkControlID="btnOKEmail" CancelControlID="btnCancelEmail">
                        </ajaxToolkit:ModalPopupExtender>
                        <div class="HBlanktd">
                        </div>
                        <center>
                            <asp:Button runat="server" ID="btnSetAction" Text="Set Action" />
                            <asp:Button runat="server" ID="btnSendEmail" Text="Send Email" />
                        </center>
                        <div class="HBlanktd">
                        </div>
                </asp:Panel>
                <ajaxToolkit:RoundedCornersExtender runat="server" Corners="All" Radius="4" ID="rce1"
                    BorderColor="Silver" TargetControlID="pnlAction" />
                <table width="100%" cellpadding="2" cellspacing="2" style="background-color: white;">
                    <%--<tr>
                        <td colspan="2" align="right">
                            <asp:ImageButton ID="btnPrint" SkinID="btnPrint" runat="server" AlternateText="Print"
                                CausesValidation="false" OnClick="btnPrint_Click" ImageAlign="Middle" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="left" valign="middle" class="style4" colspan="2">
                            <table width="100%">
                                <tr>
                                    <td align="left" valign="top">
                                        <table>
                                            <tr>
                                                <td style="font-size: 20px; color: Blue; font-weight: bold" colspan="2">
                                                    <asp:Label ID="tbxName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Address:<asp:Label ID="tbxPresentAddress" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Mobile:
                                                    <asp:Label ID="tbxMobile" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Email:
                                                    <asp:Label ID="tbxEmail" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right" valign="top">
                                        <asp:Image runat="server" ID="imgPhoto" Width="110px" Height="110px" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="replyHeader" colspan="3">
                            Personal Detail
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Father's Name:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblFatherName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Mother's Name:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblMotherName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Rank:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblRank" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Arms:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblArms" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Formation:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblFormation" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Unit:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblUnit" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Army No:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblArmyNo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Date of Birth:
                        </td>
                        <td class="style8">
                            <asp:Label ID="tbxDateofBirth" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Gender:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblGender" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Marital Status:
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblMaritalStatus" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Religion:
                        </td>
                        <td class="style8">
                            <asp:Label ID="tbxReligion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Permanent Address:
                        </td>
                        <td class="style8">
                            <asp:Label ID="tbxPermanentAddress" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="replyHeader" colspan="3">
                            Other Relevant Information
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Career Summery:
                        </td>
                        <td colspan="2" class="style8">
                            <asp:Label ID="tbxCareerSummery" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Special Qualification:
                        </td>
                        <td colspan="2" class="style8">
                            <asp:Label ID="tbxSpecialQualification" runat="server" />
                        </td>
                    </tr>
                    <%-- <tr>
                        <td class="style7">
                            Keywords:
                        </td>
                        <td colspan="2" class="style8">
                            <asp:Label ID="tbxKeywords" runat="server" />
                        </td>
                    </tr>--%>
                </table>
                <table width="100%" cellpadding="2" cellspacing="2">
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="pnlInterest">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="replyHeader" colspan="3">
                                            Field of Interest
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style7">
                                            Interest:
                                        </td>
                                        <td colspan="2" class="style8">
                                            <asp:Label ID="lblInterest" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="2" cellspacing="2">
                    <tr>
                        <td colspan="3">
                            <asp:Panel runat="server" ID="pnlAcademicQualification">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="replyHeader">
                                            Academic Qualification
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView runat="server" GridLines="None" ShowFooter="False" ID="gvEducation"
                                                Width="100%" AllowPaging="False" AutoGenerateColumns="False" CellSpacing="2"
                                                CellPadding="1">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Exam Title" DataField="DegreeTitle">
                                                        <ItemStyle HorizontalAlign="Left" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Institute" DataField="Institute">
                                                        <ItemStyle HorizontalAlign="Left" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Result">
                                                        <ItemTemplate>
                                                            <%# Eval("Result") %><br />
                                                            <%# Eval("Achievement")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Passing Year">
                                                        <ItemTemplate>
                                                            <%# Eval("YearOfPassing")%><br />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Duration">
                                                        <ItemTemplate>
                                                            <%# Eval("Duration")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel runat="server" ID="pnlTrainingSummery">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="replyHeader">
                                            Course Summery
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView runat="server" GridLines="None" ID="gvTraining" Width="100%" AllowPaging="False"
                                                AutoGenerateColumns="False" CellSpacing="2" CellPadding="1">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Course Title" DataField="CourseName">
                                                        <ItemStyle HorizontalAlign="Left" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Institute" DataField="InstitutionName">
                                                        <ItemStyle HorizontalAlign="Left" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Result">
                                                        <ItemTemplate>
                                                            <%# Eval("Result")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Year">
                                                        <ItemTemplate>
                                                            <%# Eval("Year")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Duration" DataField="DurationName">
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td colspan="3">
                            <asp:Panel runat="server" ID="pnlProfessionalQualification">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="replyHeader">
                                            Professional Qualification
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView runat="server" GridLines="None" CellSpacing="2" CellPadding="1" ID="gvProfessionalQualification"
                                                Width="100%" AllowPaging="False" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Certification" DataField="Certification">
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Institute" DataField="Institute">
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Location" DataField="Location">
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="From" DataField="FromDate" DataFormatString="{0: dd-MMM-yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="To" DataField="ToDate" DataFormatString="{0: dd-MMM-yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>--%>
                    <%-- <tr>
                        <td align="left" colspan="3">
                            <asp:Panel runat="server" ID="pnlEmploymentHistory">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="replyHeader">
                                            Employment History
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView runat="server" GridLines="None" CellSpacing="2" CellPadding="1" ID="gvEmploymentHistory"
                                                Width="100%" AllowPaging="False" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Company">
                                                        <ItemTemplate>
                                                            <%# Eval("CompanyName")%><br />
                                                            <%# Eval("CompanyBusiness").ToString() == "" ? "" : "Business: " + Eval("CompanyBusiness")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Location" DataField="CompanyLocation">
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Position Held">
                                                        <ItemTemplate>
                                                            <%# Eval("PositionHeld")%><br />
                                                            <%# Eval("Department")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Responsibities">
                                                        <ItemTemplate>
                                                            <%# Eval("Responsibities").ToString().Replace(Convert.ToChar(10).ToString(), "<br />") %><br />
                                                            <%# Eval("Department")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Area of Experiences">
                                                        <ItemTemplate>
                                                            <%# Eval("AreaOfExperience").ToString().Replace(Convert.ToChar(10).ToString(), "<br />")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Duration">
                                                        <ItemTemplate>
                                                            From
                                                            <%# Eval("FromDate").ToString()== "" ? "" :  Convert.ToDateTime(Eval("FromDate").ToString()).ToString("dd-MMM-yyyy") %>
                                                            <%# Convert.ToBoolean(Eval("IsContinue")) ? " To Still Now" : (Eval("ToDate").ToString() == "" ? "" : " To " + Convert.ToDateTime(Eval("FromDate").ToString()).ToString("dd-MMM-yyyy"))%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>--%>
                    <%-- <tr>
                        <td align="left" colspan="3">
                            <asp:Panel runat="server" ID="pnlReference">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="replyHeader">
                                            Reference
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataList runat="server" RepeatColumns="2" ID="dlReference" Width="100%" CellSpacing="2">
                                                <ItemTemplate>
                                                    <table cellpadding="2" cellspacing="2">
                                                        <tr>
                                                            <td>
                                                                Name:
                                                            </td>
                                                            <td>
                                                                <%# Eval("RefName") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Organization:
                                                            </td>
                                                            <td>
                                                                <%# Eval("Organization") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Designation:
                                                            </td>
                                                            <td>
                                                                <%# Eval("Designation") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Address:
                                                            </td>
                                                            <td>
                                                                <%# Eval("Address") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Phone:
                                                            </td>
                                                            <td>
                                                                <%# Eval("PhoneNo") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Mobile:
                                                            </td>
                                                            <td>
                                                                <%# Eval("MobileNo") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Email:
                                                            </td>
                                                            <td>
                                                                <%# Eval("Email") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Relation:
                                                            </td>
                                                            <td>
                                                                <%# Eval("Relation") %>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="50%" BackColor="#F0F3F4" />
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Panel runat="server" ID="pnlPortfolio">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="replyHeader">
                                            Portfolio
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView runat="server" GridLines="None" CellSpacing="2" CellPadding="1" ID="gvPortfolio"
                                                Width="100%" AllowPaging="False" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <%# Eval("ProjectName")%><br />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Description" DataField="Remarks">
                                                        <ItemStyle HorizontalAlign="left" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Duration">
                                                        <ItemTemplate>
                                                            <%# Eval("Duration")%><br />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Image">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" Text="Image1" ID="btnImg" OnCommand="btnImg_Command"
                                                                CommandArgument='<%# Eval("Image")%>' />
                                                            <asp:LinkButton runat="server" Text="Image2" ID="LinkButton1" OnCommand="btnImg1_Command"
                                                                CommandArgument='<%# Eval("Image1")%>' /><br />
                                                            <asp:LinkButton runat="server" Text="Image3" ID="LinkButton2" OnCommand="btnImg2_Command"
                                                                CommandArgument='<%# Eval("Image2")%>' />
                                                            <asp:LinkButton runat="server" Text="Image4" ID="LinkButton3" OnCommand="btnImg3_Command"
                                                                CommandArgument='<%# Eval("Image3")%>' />
                                                            <%--<%# Eval("Image")%>
                                                            <%# Eval("Image1")%><br />
                                                            <%# Eval("Image2")%>
                                                            <%# Eval("Image3")%>--%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                        <HeaderStyle HorizontalAlign="Center" BackColor="#F0F3F4" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <ajaxToolkit:ModalPopupExtender ID="ImgPopup" runat="server" TargetControlID="lnkDummy"
        X="250" PopupControlID="pnl1" BackgroundCssClass="modalBackground" DropShadow="True"
        OkControlID="buttonClose" DynamicServicePath="" Enabled="True">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnl1" runat="server" CssClass="modalPopup">
        <table cellpadding="0" cellspacing="0" width="100%" style="margin-top: 5px; border: solid 1px;">
            <tr>
                <td align="center">
                    <asp:Image runat="server" ID="Image1" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 4px; text-align: center;">
                    <asp:Button ID="buttonClose" runat="server" Text="Close" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:LinkButton runat="server" ID="lnkDummy"></asp:LinkButton>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style4
        {
            width: 426px;
        }
        .style7
        {
            width: 125px;
        }
        .style8
        {
            width: 81%;
        }
    </style>
</asp:Content>
