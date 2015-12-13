<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Sliders.ascx.cs" Inherits="UserControls_Sliders" %>
<div class="sliders-container">
    <div id="carousel-sliders-generic" class="carousel slide" data-ride="carousel">
        <!--wraper for @slide-->
        <div class="carousel-inner" role="listbox">
            <div class="item active sliders-item ">
                <asp:Image runat="server" ID="sldrimg1" ImageUrl="~/Resources/Images/career-image1.jpg"
                    CssClass=" " />
                <div class="col-xs-8 col-sm-8 col-md-8 carousel-content text-center hidden-xs">
                    <p class="slider-bg-txt">
                        Meeting specific employment needs</p>
                    <p class="slider-sml-txt hidden-xs">
                        Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor
                        incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.
                    </p>
                    <button type="submit" class="sndrbtn1">
                        <span class="glyphicon glyphicon-search"></span>
                        <label class="btns-txt">
                            Search Job</label>
                    </button>
                    <button type="submit" class="sndrbtn2">
                        <span class="glyphicon glyphicon-user "></span>
                        <label class="btns-txt">
                            Post Resume</label>
                    </button>
                </div>
            </div>
            <div class="item " role="listbox">
                <asp:Image runat="server" ID="sldrimgs2" ImageUrl="~/Resources/Images/career-image2.jpg"
                    CssClass=" sldrs-img" />
                <div class="col-xs-8 col-sm-8 col-md-8 carousel-content text-center hidden-xs">
                    <p class="slider-bg-txt">
                        Meeting specific employment needs</p>
                    <p class="slider-sml-txt hidden-xs">
                        Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor
                        incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.
                    </p>
                    <button type="submit" class="sndrbtn1">
                        <span class="glyphicon glyphicon-search"></span>
                        <label class="btns-txt">
                            Search Job</label>
                    </button>
                    <button type="submit" class="sndrbtn2">
                        <span class="glyphicon glyphicon-user "></span>
                        <label class="btns-txt">
                            Post Resume</label>
                    </button>
                </div>
            </div>
            <div class="item " role="listbox">
                <asp:Image runat="server" ID="sldrimg3" ImageUrl="~/Resources/Images/career-image3.jpg"
                    CssClass="" />
                <div class="col-xs-8 col-sm-8 col-md-8 carousel-content text-center hidden-xs">
                    <p class="slider-bg-txt">
                        Staffing solutions for yours Problems</p>
                    <p class="slider-sml-txt hidden-xs">
                        Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor
                        incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.
                    </p>
                    <button type="submit" class="sndrbtn1">
                        <span class="glyphicon glyphicon-search"></span>
                        <label class="btns-txt">
                            Search Job</label>
                    </button>
                    <button type="submit" class="sndrbtn2">
                        <span class="glyphicon glyphicon-user "></span>
                        <label class="btns-txt">
                            Post Resume</label>
                    </button>
                </div>
            </div>
        </div>
        <!--@controls-->
        <a class="left carousel-control" href="#carousel-sliders-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left glyphcn-crvn-lft"></span><span class="sr-only">
                Previous</span> </a><a class="right carousel-control" href="#carousel-sliders-generic"
                    role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right  glyphcn-crvn-rgt">
                    </span><span class="sr-only">Next</span> </a>
    </div>
</div>
