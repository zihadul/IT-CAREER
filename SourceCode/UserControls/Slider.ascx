<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Slider.ascx.cs" Inherits="UserControls_Slider" %>
<div class="flexslider">
    <ul class="slides">
        <asp:Repeater ID="rptSlider" runat="server">
            <ItemTemplate>
                <li>
                  <%# Eval("Description")%>
                    <asp:Image ID="img1" runat="server" ImageUrl='<%#"~/Resources/Userfile/Slider/Thumbs/" + Eval("ImageName") %>'
                               AlternateText="" title='' />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
<script type="text/javascript">
    $(window).load(function () {
        $('.flexslider').flexslider({
            animation: "fade",
            slideshowSpeed: 3500,
            animationDuration: 600,
            start: function (slider) {
                $('body').removeClass('loading');
            }
        });
    });
</script>