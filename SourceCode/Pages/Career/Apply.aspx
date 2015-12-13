<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Default.master" AutoEventWireup="true"
    CodeFile="Apply.aspx.cs" Inherits="Pages_Career_Apply" Title="Apply" ValidateRequest="false" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellpadding="0" style="border-spacing: 0px 4px;">
        <tr>
            <td>
                <b>Job Positon:</b>&nbsp;<asp:Label ID="tbxTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Job Description:</b>&nbsp;<asp:Label ID="tbxDescription" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table cellspacing="1" style="margin: 0px auto; border-spacing: 0px 4px;">
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="PageTitle3">
                Upload your CV Here:
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="2" style="margin: 0px auto">
                    <tr>
                        <td>
                            Name:
                        </td>
                        <td>
                            <asp:TextBox ID="tbxName" runat="server" Width="400px" SkinID="SkinFreeText"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxName"
                                ErrorMessage="Input name.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            CV:
                        </td>
                        <td>
                            <asp:FileUpload ID="fileCV" runat="server" Width="223px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fileCV"
                                ErrorMessage="Select cv.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <div style="width: 210px;">
                                <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="none" CaptchaLength="5"
                                    BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" BackColor="#d4e0ee"
                                    CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                    CaptchaMaxTimeout="240" Width="223px" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Enter Code:
                        </td>
                        <td class="CaptchaTextEntry">
                            <asp:TextBox ID="tbxCaptcha" runat="server" Width="400px" SkinID="SkinFreeText" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxCaptcha"
                                ErrorMessage="Enter the code shown in image.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CausesValidation="false" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
