<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavMenu.ascx.cs" Inherits="UserControls_NavMenu" %>
    <nav class="navbar navbar-fixed-top cbp-af-header" role="navigation">
       <div class="container">
                   <div class="hder-btns text-right visible-xs">
                       <i class="fa fa-hand-o-down hdr-icon wow zoomIn" data-wow-delay="2000ms" data-wow-duration="2000ms" ></i>
                       <i class="fa fa-search hdr-icon wow zoomIn" data-wow-delay="1500ms" data-wow-duration="1500ms"></i>
                       <i class="fa fa-registered hdr-icon wow zoomIn"  data-wow-delay="1000ms" data-wow-duration="1000ms"></i>
                       <i class="fa fa-lock hdr-icon wow zoomIn"data-wow-delay="500ms" data-wow-duration="500ms" ></i>
                  </div>
               <div class="hder-btns text-right hidden-xs">
                   <asp:Button runat="server" ID="Button1" Text="Post Resume" CssClass="nav-btns hidden-xs wow zoomIn" data-wow-delay="2000ms" data-wow-duration="2000ms" />
                   <asp:Button runat="server" ID="Button2" Text="Find Resume" CssClass="nav-btns hidden-xs wow zoomIn" data-wow-delay="1500ms" data-wow-duration="1500ms"/>
                    <asp:Button runat="server" ID="Button3" Text="Register" CssClass="nav-btns hidden-xs wow zoomIn" data-wow-delay="1000ms" data-wow-duration="1000ms"/>
                   <asp:HyperLink runat="server" ID="btns1"  Text="Login" NavigateUrl="~/Login.aspx" CssClass="nav-btns hidden-xs wow zoomIn" data-wow-delay="500ms" data-wow-duration="500ms"/>
              </div>
         <div class="navbar-header">
           <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
             <span class="icon-bar"></span>
             <span class="icon-bar"></span>
             <span class="icon-bar"></span>
           </button>
              <a class="navbar-brand" href="#">
                  <asp:Image runat="server" ID="brndimgs1" ImageUrl="~/Resources/Images/hedear-logo.png" CssClass="hdrs-logo wow zoomIn"  data-wow-duration="2500ms"/> 
              </a>
          </div>
          <div class="navbar-collapse collapse">
           <ul class="nav navbar-nav navbar-right">
                <li class="active"><asp:HyperLink runat="server" ID="HyperLink5" NavigateUrl="~/Default.aspx">Home</asp:HyperLink></li>
                 <li><asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="~/Pages/About.aspx">About</asp:HyperLink></li>
                <li><asp:HyperLink runat="server" ID="menuss1" NavigateUrl="~/Pages/Job.aspx">Job</asp:HyperLink></li>
                 <li><asp:HyperLink runat="server" ID="HyperLink3" NavigateUrl="~/Pages/Candidates.aspx">Candidate</asp:HyperLink></li>
                <li><asp:HyperLink runat="server" ID="HyperLink4" NavigateUrl="~/Pages/Contact.aspx">Contact</asp:HyperLink></li>
           </ul>
        </div>
    </div>
</nav>
