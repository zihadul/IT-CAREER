<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Default.master" Description="A customized software development company in bangladesh."
    AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" Title="Contact Us" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:Panel ID="pnlContent" runat="server">
        <table cellspacing="0" cellpadding="0" border="1" width="100%">
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="3" align="center"  border="1">
                        <tr>
                            <td align="left" class="DemoRequestHeader">
                                Your Email:
                            </td>
                            <td>
                                <asp:TextBox ID="tbxEmail"  runat="server" SkinID="BigBox" />
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                    TargetControlID="tbxEmail" WatermarkText="Your Email Address" WatermarkCssClass="watermarked" />
                                <asp:RequiredFieldValidator runat="server" ID="NReq" ControlToValidate="tbxEmail"
                                    Display="None" ErrorMessage="<b>Required Field Missing</b><br />Your email is required.<br />&nbsp;" />
                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="NReqE" TargetControlID="NReq"
                                    HighlightCssClass="validatorCalloutHighlight" Width="250px" />
                                <asp:RegularExpressionValidator ID="regVEmail" runat="server" Display="None" ErrorMessage="<b>Email Address</b><br />Invalid email format.<br />&nbsp;"
                                    ControlToValidate="tbxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                    TargetControlID="regVEmail" HighlightCssClass="validatorCalloutHighlight" Width="250px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Subject:
                            </td>
                            <td>
                                <asp:TextBox ID="tbxSubject"  runat="server" SkinID="BigBox" />
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                    TargetControlID="tbxSubject" WatermarkText="Subject" WatermarkCssClass="watermarked" />
                                <asp:RequiredFieldValidator runat="server" ID="reqSubject" ControlToValidate="tbxSubject"
                                    Display="None" ErrorMessage="<b>Required Field Missing</b><br />Subject is required.<br />&nbsp;" />
                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                    TargetControlID="reqSubject" HighlightCssClass="validatorCalloutHighlight" Width="250px" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                Message:
                            </td>
                            <td>
                                <asp:TextBox ID="tbxMessage" CssClass="Width400" TextMode="MultiLine" Rows="10" runat="server"
                                    SkinID="customTextBox" />
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                    TargetControlID="tbxMessage" WatermarkText="Message" WatermarkCssClass="watermarked" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="none" CaptchaLength="4"
                                    BorderStyle="Solid" BorderWidth="1px" BorderColor="Silver" BackColor="#d4e0ee"
                                    CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="10"
                                    CaptchaMaxTimeout="240" Width="223px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Enter Code:
                            </td>
                            <td>
                                <asp:TextBox ID="tbxCaptcha" runat="server" />
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server"
                                    TargetControlID="tbxCaptcha" WatermarkText="Captcha" WatermarkCssClass="watermarked" />
                                <asp:RequiredFieldValidator ID="reqCaptcha" runat="server" ControlToValidate="tbxCaptcha"
                                    Display="None" ErrorMessage="<b>Required Field Missing</b><br />Enter the code shown in image.<br />&nbsp;" />
                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                                    TargetControlID="reqCaptcha" HighlightCssClass="validatorCalloutHighlight" Width="250px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CausesValidation="false" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
