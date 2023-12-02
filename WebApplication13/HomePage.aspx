<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication13.HomePage" %>


<!DOCTYPE html>

<html>

<head runat="server">
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta name="keywords" content="HTML,CSS,XML,JavaScript">
    <meta name="author" content="Ecology Theme">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PMStrat inc - Shaping Lives</title>
    <link rel="shortcut icon" href="images/PMStrat_inLogo.ico" type="image/x-icon" />
    <!-- Goole Font -->
    <link href="https://fonts.googleapis.com/css?family=Rubik:400,500,700" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,500,700,900" rel="stylesheet">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/assets/bootstrap.min.css">
    <!-- Font awsome CSS -->
    <link rel="stylesheet" href="css/assets/font-awesome.min.css">
    <link rel="stylesheet" href="css/assets/flaticon.css">
    <link rel="stylesheet" href="css/assets/magnific-popup.css">
    <!-- owl carousel -->
    <link rel="stylesheet" href="css/assets/owl.carousel.css">
    <link rel="stylesheet" href="css/assets/owl.theme.css">
    <link rel="stylesheet" href="css/assets/animate.css">
    <!-- Slick Carousel -->
    <link rel="stylesheet" href="css/assets/slick.css">
    <link rel="stylesheet" href="css/assets/preloader.css" />

    <!-- Revolution Slider -->
    <link rel="stylesheet" href="css/assets/revolution/layers.css">
    <link rel="stylesheet" href="css/assets/revolution/navigation.css">
    <link rel="stylesheet" href="css/assets/revolution/settings.css">
    <!-- Mean Menu-->
    <link rel="stylesheet" href="css/assets/meanmenu.css">
    <!-- main style-->
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/responsive.css">
    <link rel="stylesheet" href="css/demo.css">
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>
    
<body>
    <script type="text/javascript">

        function validateEmail(email) {
            var re = /\S+@\S+\.\S+/;
            return re.test(email);
        }

        function validateLogin() {
            var txtName; var message = ""; var controlVal;

            var LoginEmail = document.getElementById("<%=LoginEmail.ClientID%>");
            if (LoginEmail.value == "") {
                alert("Email Field cannot be Empty");
                return false;
            }
            else if (validateEmail(LoginEmail.value) == false) {
                alert("Email not in correct format");
                return false;
            }

            LoginPaswd = document.getElementById("<%=LoginPassword.ClientID%>");
            if (LoginPaswd.value == "") {
                alert("Password Field cannot be Empty");
                return false;
            }
        }

        function validateRegister() {

            var email = document.getElementById("<%=RegEmail.ClientID%>");
            if (email.value. == "") {
                alert("Email Field cannot be Empty");
                return false;
            }
            else if (validateEmail(email.value) == false) {
                alert("Email not in correct format");
                return false;
            }


            var user = document.getElementById("<%=RegUserName.ClientID%>");
            if (user.value == "") {
                alert("UserName Field cannot be Empty");
                return false;
            }

            var paswd = document.getElementById("<%=RegPassword.ClientID%>");
            if (paswd.value == "") {
                alert("Password Field cannot be Empty");
                return false;
            }
        }

            
        
    </script>
    <style>
        #nav {
            list-style: none inside;
            margin: 0;
            padding: 0;
            text-align: center;
        }

            #nav li {
                display: block;
                position: relative;
                float: left;
                background: #24af15; /* menu background color */
            }

                #nav li a {
                    display: block;
                    padding: 0;
                    text-decoration: none;
                    width: 200px; /* this is the width of the menu items */
                    line-height: 35px; /* this is the hieght of the menu items */
                    color: #ffffff; /* list item font color */
                }

                #nav li li a {
                    font-size: 80%;
                }
                /* smaller font size for sub menu items */
                #nav li:hover {
                    background: #003f20;
                }
            /* highlights current hovered list item and the parent list items when hovering over sub menues */
            #nav ul {
                position: absolute;
                padding: 0;
                left: 0;
                display: none; /* hides sublists */
            }

            #nav li:hover ul ul {
                display: none;
            }
            /* hides sub-sublists */
            #nav li:hover ul {
                display: block;
            }
            /* shows sublist on hover */
            #nav li li:hover ul {
                display: block; /* shows sub-sublist on hover */
                margin-left: 200px; /* this should be the same width as the parent list item */
                margin-top: -35px; /* aligns top of sub menu with top of list item */
            }
    </style>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>



        <header class="header_four">
            <!-- Preloader -->
            <div id="preloader">
                <div id="status">&nbsp;</div>
            </div>
            <div class="header_top">
                <div class="container">

                    <div class="row">
                        <div class="col-12 col-sm-12 col-lg-12" style="background-color: red">
                            <div class="info_wrapper">
                                <div class="contact_info">
                                    <ul class="list-unstyled">
                                        <li><i >+1 (647) 232-8196</i></li>
                                        <li><i class="flaticon-mail-black-envelope-symbol"></i><a style="color:white" href="mailto:admin1_user@pmstratinc.com">admin1_user@pmstratinc.com</a></li>
                                        
                                    </ul>
                                </div>
                                <div class="login_info">
                                    <ul id="LoginHeader" runat="server" class="d-flex">
                                        <li class="nav-item"><a href="#" class="nav-link sign-in js-modal-show"><i class="flaticon-user-male-black-shape-with-plus-sign"></i>Sign Up</a></li>
                                        <li class="nav-item"><a href="#" class="nav-link join_now js-modal-show"><i class="flaticon-padlock"></i>Log In</a></li>
                                    </ul>
                                    <ul id="UserLogged" runat="server" class="d-flex" style="color: black">
                                        <li class="nav-item"><a href="#" class="nav-link sign-in js-modal-show"><i class="flaticon-user-male-black-shape-with-plus-sign"></i></a></li>
                                        <%--                                        <li class="nav-item"><a href="#" class="nav-link join_now js-modal-show"><i class="flaticon-padlock"></i>Log In</a></li>--%>
                                    </ul>

                                    <a href="HomePage.aspx" id="LogoutHeader" onserverclick="LogoutUser" runat="server" title="">Logout</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


<%--
              <li class="nav-item"><a href="course.html" class="nav-link">Courses</a>
                            <ul class="navbar-nav nav mx-auto">
                                <li class="nav-item"><a href="course.html" class="nav-link">Courses</a></li>
                                <li class="nav-item"><a href="course-details.html" class="nav-link">Courses Details</a></li>
                            </ul> 
                        </li>--%>
            <div class="edu_nav" style="background-color:ButtonHighlight">
                <div class="container">
                    <nav class="navbar navbar-expand-md navbar-light bg-faded" style="padding:unset">
                         <img src="images/PMStrat_inLogo.png"  alt="" class="f_logo" style="image-resolution:unset;height:50px;width:60px">

                        <h1><a href="HomePage.aspx" class="nav-link" style="color: red">PMStrat Inc</a></h1>
                        <!--<a class="navbar-brand" href="index-2.html"><img src="images/logo.png" alt="logo"></a>-->
                        <div class="collapse navbar-collapse main-menu" id="navbarSupportedContent" style="padding:unset">
                            <ul class="navbar-nav nav lavalamp ml-auto menu">

                                <li id="UsrAbout" runat="server" class="nav-item"><a href="About.aspx" class="nav-link" >About</a></li>

                                 <li id="UsrStuInfo" runat="server" class="nav-item"><a href="StuReg.aspx" class="nav-link" >Student Info</a></li>

<%--                                 <li id="UsrStuProgress" runat="server" class="nav-item"><a href="About.aspx" class="nav-link" >Student Progress</a></li>--%>

                                                        <li id="UsrProgress" visible="false" runat="server"><a class="nav-link">Progress</a>
                                     <ul style="background-color:white">

                                        <li class="dropdown-item" style="display:contents"><a href="Stage1.aspx" > Stage 1</a></li>
                                        <li class="dropdown-item" style="display:contents"><a>&nbsp&nbsp</a></li>
                                        <li class="dropdown-item" style="display:contents"><a href="Stage2.aspx" > Stage 2</a></li>
                                        <li class="dropdown-item" style="display:contents"><a>&nbsp&nbsp</a></li>
                                        <li class="dropdown-item" style="display:contents"><a href="Stage3.aspx" > Stage 3</a></li>
                                    </ul>
                                </li>        
                            
                                <li id="AdmProgress" visible="false" runat="server"><a class="nav-link">Progress</a>
                                     <ul>

                                        <li class="dropdown-item" style="display:contents"><a href="AdminStage1.aspx">Stage 1</a></li>
                                        <li class="dropdown-item" style="display:contents"><a>&nbsp&nbsp</a></li>
                                        <li class="dropdown-item" style="display:contents"><a href="AdminStage2.aspx">Stage 2</a></li>
                                        <li class="dropdown-item" style="display:contents"><a>&nbsp&nbsp</a></li>
                                        <li class="dropdown-item" style="display:contents"><a href="AdminStage3.aspx">Stage 3</a></li>
                                    </ul>
                                </li>

                             <li id="UsrContact" runat="server" class="nav-item"><a href="Contact.aspx" class="nav-link">Contact</a></li>
                           
                                <li id="AdmReports" visible="false" runat="server" class="nav-item"><a href="StudentProgressRep.aspx" class="nav-link">Reports</a>
                           
                               </li>
                                <li id="AdmQueries" visible="false" runat="server" class="nav-item"><a href="AdminQueries.aspx" class="nav-link">Queries</a></li>

                                <li id="AdminUsrMng" visible="false" runat="server" class="nav-item"><a href="AdminUsrMangemnt.aspx" class="nav-link">UserManagement</a></li>

                                <li id="AdminStuPage" visible="false" runat="server" class="nav-item"><a href="StuReg.aspx" class="nav-link">UserManagement</a></li>


                                <%--<li id="UsrImmigration" visible="false" runat="server" class="nav-item"><a href="immigration.html" class="nav-link">Immigration</a></li>

                                <li id="UsrSettlement" visible="false" runat="server" class="nav-item"><a href="Settlement.aspx" class="nav-link">Settlement</a></li>--%>

                          
                            </ul>
                        </div>

                      
                        <%--<div class="mr-auto search_area ">
                            <ul class="navbar-nav mx-auto">
                                <li class="nav-item"><i class="search_btn flaticon-magnifier"></i>
                                    <div id="search">
                                        <button type="button" class="close">×</button>
                                        <form>
                                            <input type="search" value="" placeholder="Search here...." required />
                                        </form>
                                    </div>
                                </li>
                            </ul>
                        </div>--%>
                    </nav>
                    <!-- END NAVBAR -->
                </div>
            </div>


            <div class="rev_slider_wrapper">
                <div id="rev_slider_1" class="rev_slider">
                    <ul>
                        <li data-index="rs-1706" data-transition="fade" data-slotamount="7" data-hideafterloop="0" data-hideslideonmobile="off" data-easein="default" data-easeout="default" data-masterspeed="1000" data-rotate="0" data-saveperformance="off" data-title="Slide" data-param1="" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">

                            <div class="slider-overlay"></div>
                            <!-- SLIDE'S MAIN BACKGROUND IMAGE -->
                            <img src="images/banner/banner_1.jpg" alt="Sky" class="rev-slidebg" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="10" class="rev-slidebg" data-no-retina>
                            <!-- LAYER NR. 1 -->
                            <%--<div class="tp-caption font-lora sfb tp-resizeme letter-space-5 h-p"
                                data-x="['left','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['middle','middle','middle','middle']" data-voffset="['-200','-280','-250','-200']"
                                data-fontsize="['20','40','40','28']"
                                data-lineheight="['70','80','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"z:0;rX:0;rY:0;rZ:0;sX:0.9;sY:0.9;skX:0;skY:0;opacity:0;","speed":400,"to":"o:1;","delay":100,"split":"chars","splitdelay":0.05,"ease":"Power3.easeInOut"},{"delay":"wait","speed":100,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                style="z-index: 7; color: #fff; font-family: 'Rubik', sans-serif; max-width: auto; max-height: auto; white-space: nowrap; font-weight: 500;">
                                The Goal Of Education Is The Advancement Of Knowledge
                   
                            </div>--%>
                            <!-- LAYER NR. 2 -->
                            <div class="tp-caption NotGeneric-Title   tp-resizeme"
                                id="slide-3045-layer-1"
                                data-x="['left','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['middle','middle','middle','middle']" data-voffset="['-120','-140','-140','-120']"
                                data-fontsize="['65','120','100','70']"
                                data-lineheight="['70','120','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"x:[105%];z:0;rX:45deg;rY:0deg;rZ:90deg;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","speed":2000,"to":"o:1;","delay":1000,"split":"chars","splitdelay":0.05,"ease":"Power4.easeInOut"},{"delay":"wait","speed":1000,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                data-textalign="['left','left','left','left']"
                                data-paddingtop="[10,10,10,10]"
                                data-paddingright="[0,0,0,0]"
                                data-paddingbottom="[10,10,10,10]"
                                data-paddingleft="[0,0,0,0]"
                                style="z-index: 5; font-family: 'Roboto', sans-serif; font-weight: 900; white-space: nowrap; text-transform: left;">
                                Providing Interested Students With               
                   
                            </div>

                            <!-- LAYER NR.3 -->
                            <div class="tp-caption NotGeneric-Title   tp-resizeme"
                                id="slide-3045-layer-5"
                                data-x="['left','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['middle','middle','middle','middle']" data-voffset="['-40','0','-10','-40']"
                                data-fontsize="['65','120','100','70']"
                                data-lineheight="['70','120','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"x:[105%];z:0;rX:45deg;rY:0deg;rZ:90deg;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","speed":2000,"to":"o:1;","delay":1000,"split":"chars","splitdelay":0.05,"ease":"Power4.easeInOut"},{"delay":"wait","speed":1000,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                data-textalign="['left','left','left','left']"
                                data-paddingtop="[10,10,10,10]"
                                data-paddingright="[0,0,0,0]"
                                data-paddingbottom="[10,10,10,10]"
                                data-paddingleft="[0,0,0,0]"
                                style="z-index: 5; font-family: 'Roboto', sans-serif; font-weight: 900; white-space: nowrap; text-transform: left;">
                                Detailed Information and Guidance on
                            </div>

                             <div class="tp-caption NotGeneric-Title   tp-resizeme"
                                id="slide-3045-layer-29"
                                data-x="['center','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['middle','middle','middle','middle']" data-voffset="['140','-90','-100','80']"
                                data-fontsize="['65','120','100','70']"
                                data-lineheight="['70','120','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"x:[105%];z:0;rX:45deg;rY:0deg;rZ:90deg;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","speed":2000,"to":"o:1;","delay":1000,"split":"chars","splitdelay":0.05,"ease":"Power4.easeInOut"},{"delay":"wait","speed":1000,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                data-textalign="['left','left','left','left']"
                                data-paddingtop="[10,10,10,10]"
                                data-paddingright="[0,0,0,0]"
                                data-paddingbottom="[10,10,10,10]"
                                data-paddingleft="[0,0,0,0]"
                                style="z-index: 5; font-family: 'Roboto', sans-serif; font-weight: 700; white-space: nowrap; text-transform: left;">
                                <a style="color:red">Admission Pre Requisites</a>
                            </div>

                            <!-- LAYER NR. 4 -->
                            <%--<div class="tp-caption rev-btn rev-btn left_btn"
                                id="slide-2939-layer-8"
                                data-x="['left','left','left','left']" data-hoffset="['0','500','420','280']"
                                data-y="['middle','middle','middle','middle']" data-voffset="['75','220','190','100']"
                                data-fontsize="['14','14','10','8']"
                                data-lineheight="['34','34','30','20']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="button"
                                data-actions='[{"event":"click","action":"jumptoslide","slide":"rs-2939","delay":""}]'
                                data-responsive_offset="on"
                                data-responsive="off"
                                data-frames='[{"from":"x:-50px;opacity:0;","speed":1000,"to":"o:1;","delay":1750,"ease":"Power2.easeOut"},{"delay":"wait","speed":1500,"to":"opacity:0;","ease":"Power4.easeIn"},{"frame":"hover","speed":"300","ease":"Linear.easeNone","to":"o:1;rX:0;rY:0;rZ:0;z:0;","style":"c:#ffffff;bg:#ff5a2c;bw:2px 2px 2px 2px;"}]'
                                data-textalign="['left','left','left','left']"
                                data-paddingtop="[12,12,8,8]"
                                data-paddingright="[40,40,30,25]"
                                data-paddingbottom="[12,12,8,8]"
                                data-paddingleft="[40,40,30,25]"
                                style="z-index: 14; white-space: nowrap; font-weight: 500; color: #ffffff; font-family: Rubik; text-transform: uppercase; background-color: #ff5a2c; border-color: rgba(0, 0, 0, 1.00); border-width: 2px; border-radius: 3px;">
                                Get Started Now
                   
                            </div>--%>
                            <!-- LAYER NR. 5 -->
                            <%--<div class="tp-caption NotGeneric-Title   tp-resizeme"
                                id="slide-3045-layer-39"
                                data-x="['center','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['center','middle','middle','middle']" data-voffset="['80','200','180','140']"
                                data-fontsize="['65','120','100','70']"
                                data-lineheight="['70','120','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"x:[105%];z:0;rX:45deg;rY:0deg;rZ:90deg;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","speed":2000,"to":"o:1;","delay":1000,"split":"chars","splitdelay":0.05,"ease":"Power4.easeInOut"},{"delay":"wait","speed":1000,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                data-textalign="['left','left','left','left']"
                                data-paddingtop="[10,10,10,10]"
                                data-paddingright="[0,0,0,0]"
                                data-paddingbottom="[10,10,10,10]"
                                data-paddingleft="[0,0,0,0]"
                                style="z-index: 5; font-family: 'Roboto', sans-serif; font-weight: 700; white-space: nowrap; text-transform: left;">
                                Check Our Services            
                            </div>--%>
                            
                        </li>

                        <li data-index="rs-1708" data-transition="fade" data-slotamount="7" data-hideafterloop="0" data-hideslideonmobile="off" data-easein="default" data-easeout="default" data-masterspeed="1000" data-rotate="0" data-saveperformance="off" data-title="Slide" data-param1="" data-param2="" data-param3="" data-param4="" data-param5="" data-param6="" data-param7="" data-param8="" data-param9="" data-param10="" data-description="">
                            <div class="slider-overlay"></div>
                            <img src="images/banner/banner_2.jpg" alt="Sky" class="rev-slidebg" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="10" class="rev-slidebg" data-no-retina>
                            <!-- LAYER NR. 1 -->
                            <%--<div class="tp-caption font-lora sfb tp-resizeme letter-space-5 h-p"
                                data-x="['left','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['middle','middle','middle','middle']" data-voffset="['-200','-280','-250','-200']"
                                data-fontsize="['20','40','40','28']"
                                data-lineheight="['70','80','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"z:0;rX:0;rY:0;rZ:0;sX:0.9;sY:0.9;skX:0;skY:0;opacity:0;","speed":400,"to":"o:1;","delay":100,"split":"chars","splitdelay":0.05,"ease":"Power3.easeInOut"},{"delay":"wait","speed":100,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                style="z-index: 7; color: #fff; font-family: 'Rubik', sans-serif; max-width: auto; max-height: auto; white-space: nowrap; font-weight: 500;">
                                The Goal Of Education Is The Advancement Of Knowledge
                   
                            </div>--%>
                            <!-- LAYER NR. 2 -->
                            <div class="tp-caption NotGeneric-Title   tp-resizeme"
                                id="slide-3045-layer-11"
                                data-x="['left','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['middle','middle','middle','middle']" data-voffset="['-120','-140','-140','-120']"
                                data-fontsize="['65','120','100','70']"
                                data-lineheight="['70','120','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"x:[105%];z:0;rX:45deg;rY:0deg;rZ:90deg;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","speed":2000,"to":"o:1;","delay":1000,"split":"chars","splitdelay":0.05,"ease":"Power4.easeInOut"},{"delay":"wait","speed":1000,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                data-textalign="['left','left','left','left']"
                                data-paddingtop="[10,10,10,10]"
                                data-paddingright="[0,0,0,0]"
                                data-paddingbottom="[10,10,10,10]"
                                data-paddingleft="[0,0,0,0]"
                                style="z-index: 5; font-family: 'Roboto', sans-serif; font-weight: 700; white-space: nowrap; text-transform: left;">
                                Providing Interested Students With               
                            </div>

                            <!-- LAYER NR.3 -->
                            <div class="tp-caption NotGeneric-Title   tp-resizeme"
                                id="slide-3045-layer-12"
                                data-x="['left','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['middle','middle','middle','middle']" data-voffset="['-40','0','-10','-40']"
                                data-fontsize="['65','120','100','70']"
                                data-lineheight="['70','120','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"x:[105%];z:0;rX:45deg;rY:0deg;rZ:90deg;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","speed":2000,"to":"o:1;","delay":1000,"split":"chars","splitdelay":0.05,"ease":"Power4.easeInOut"},{"delay":"wait","speed":1000,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                data-textalign="['left','left','left','left']"
                                data-paddingtop="[10,10,10,10]"
                                data-paddingright="[0,0,0,0]"
                                data-paddingbottom="[10,10,10,10]"
                                data-paddingleft="[0,0,0,0]"
                                style="z-index: 5; font-family: 'Roboto', sans-serif; font-weight: 700; white-space: nowrap; text-transform: left;">
                                Detailed Information and Guidance on
                            </div>



                            <div class="tp-caption NotGeneric-Title   tp-resizeme"
                                id="slide-3045-layer-19"
                                data-x="['center','center','center','center']" data-hoffset="['0','0','0','0']"
                                data-y="['center','middle','middle','middle']" data-voffset="['80','200','180','140']"
                                data-fontsize="['65','120','100','70']"
                                data-lineheight="['70','120','70','70']"
                                data-width="none"
                                data-height="none"
                                data-whitespace="nowrap"
                                data-type="text"
                                data-responsive_offset="on"
                                data-frames='[{"from":"x:[105%];z:0;rX:45deg;rY:0deg;rZ:90deg;sX:1;sY:1;skX:0;skY:0;","mask":"x:0px;y:0px;s:inherit;e:inherit;","speed":2000,"to":"o:1;","delay":1000,"split":"chars","splitdelay":0.05,"ease":"Power4.easeInOut"},{"delay":"wait","speed":1000,"to":"y:[100%];","mask":"x:inherit;y:inherit;s:inherit;e:inherit;","ease":"Power2.easeInOut"}]'
                                data-textalign="['left','left','left','left']"
                                data-paddingtop="[10,10,10,10]"
                                data-paddingright="[0,0,0,0]"
                                data-paddingbottom="[10,10,10,10]"
                                data-paddingleft="[0,0,0,0]"
                                style="z-index: 5; font-family: 'Roboto', sans-serif; font-weight: 700; white-space: nowrap; text-transform: left;">
                                <a style="color:red">Admission Pre Requisites</a>          
                            </div>
                        </li>

                    </ul>
                    <!-- END SLIDES LIST -->
                </div>
                <!-- END SLIDER CONTAINER -->
            </div>

            <!--==================
        Slider
    ===================-->

            <!-- END SLIDER CONTAINER WRAPPER -->
        </header>

        <%--<section class="cources_highlight">
            <div class="container">
                Check Our 
       
            <div class="row">
                <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                    <div class="latest_blog_carousel">
                        <div class="single_item single_item_first">
                            <div class="blog-img">
                                <a href="student.html">
                                    <img src="images/features/studyCanada1.png" alt="" class="img-fluid"></a>
                            </div>
                            <div class="blog_title">
                                <span>Study best courses in</span>
                                <h3>Canada</h3>
                                <p>
                                    Get Admission in Canada's top universities from anywhere around the world...
                               
                            </div>
                        </div>

                        <%--<div class="single_item single_item_center">
                            <div class="blog-img">
                                <a href="Settlement.aspx" title="">
                                    <img src="images/features/newcomers1.png" alt="" class="img-fluid"></a>
                            </div>
                            <div class="blog_title">
                                <span>Get Settled in</span>
                                <h3><a href="#" title="">Canada</a></h3>
                                <p>
                                    Get Assisted With Our Best Settlement Services For All Your Concerns...
                               
                            </div>
                        </div>

                        <div class="single_item single_item_last">
                            <div class="blog-img">
                                <a href="immigration.html" title="">
                                    <img src="images/features/canada-immigration.jpg" alt="" class="img-fluid"></a>
                            </div>
                            <div class="blog_title">
                                <span>Live In </span>
                                <h3><a href="#" title="">Canada</a></h3>
                                <p>
                                    Come and Live your Dream Life in Canada with Our Immigration Services...
                                
                            </div>
                        </div>--%>

                   
        <!-- End Popular Courses Highlight -->

          <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            </div>
        </div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>


        <section class="popular_courses">
              <div class="container"> 
                  <div class="row">
                      <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                          <div class="sub_title">
                              <h2 style="font-family:Calibri;color:darkblue;background-color:honeydew">Want to study in Canada - but don't know where to start? 
Or even where to apply? 
Or who to contact? 

<%--Many students find the admissions process confusing and daunting. 


 
<a class="glow" href="StuReg.aspx">Contact us today for a no-obligation consultation...</a>--%>
                          </div><!-- ends: .section-header -->
                      </div>
                   </div>
            </div>
            </section>




        <section class="about_us">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-7 col-lg-7">
                <div class="about_title">
                   <h3 style="color:black;font-weight:bold"> 



Many students find the admissions process confusing and daunting. 


 
<a class="glow" href="Contact.aspx"  style="font-size:larger">Contact us today for a no-obligation consultation...</a></h3>
                 </div>
            </div>
            <div class="col-12 col-sm-12 col-md-5 col-lg-5 p-0">
                <div class="banner_about">
                    <img src="images/banner/about_thinking.jpg" alt="">
                 </div>
            </div>
        </div>     
        </div>
            </section>


          






<%--        <section class="popular_courses">
              <div class="container"> 
                  <div class="row">
                      <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                          <div class="sub_title">
<%--                              <h2>Our Popular Services</h2>--%>
                           <%--   <h2 style="font-family:Calibri;color:red;background-color:honeydew">Want to study in Canada - but don't know where to start? 
Or even where to apply? 
Or who to contact? 

Many students find the admissions process confusing and daunting. 


 
<a class="glow" href="StuReg.aspx">Contact us today for a no-obligation consultation...</a>
                          </div><!-- ends: .section-header -->
                      </div>
                   </div>
            </div>
            </section>--%>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:black;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
              </section>

           <div class="row"></div>
                 <div class="row"></div>
                 <div class="row"></div>

        <div class="story_about">
        <div class="container">            
            <div class="row">
                <div class="col-12 col-sm-6 col-md-7 col-lg-7">
                    <div class="story_banner">
                        <img src="images/banner/about_us.png" alt="">
                     </div>
                </div>
                        
                <div class="col-12 col-sm-6 col-md-5 col-lg-5">
                    <div class="about_story_title">
                        <div class="row"></div>
                 <div class="row"></div>
                 <div class="row"></div>
                        <h3 style="color:black;font-weight:bold">
                            
                             <div class="row"></div>
                            <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                <div class="title">
                    <h3 style="color:white;font-weight:bold"> 



 
<%--                    <p>At vero eos et accusamus et iusto odio dignissio ducimus qui blanditiis praesentium volu ptat umtjk deleniti atque corrupti quos esentium voluptatum delen itamus et iusto odio dignissimos ducimus qui blanditii. </p>--%>
                 </div>
            </div>
        </div>
    </div>
    <div>            
<div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0"></div>
    
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                 </div>
            </div>
    </div>
    <div ></div>
                                
              </section>
                 <div class="col-12 col-sm-12 col-md-7 col-lg-7">
                     </div>
                    

                            With access throughout on a personal basis to our expert advisors, you'll be given a tailor-made plan which takes the stress out of the entire admissions process, leaving you to  explore and enjoy a world of possibilities at your chosen university. 
</h3>
<%--                        <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum del Education atque corrupti.</p>--%>
                     </div>
                </div>
            </div>
        </div>
    </div>
        

           

        <section class="login_signup_option">
            <div class="l-modal is-hidden--off-flow js-modal-shopify">
                <div class="l-modal__shadow js-modal-hide"></div>
                <div class="login_popup login_modal_body">
                    <div class="Popup_title d-flex justify-content-between">
                        <h2 class="hidden">&nbsp;</h2>
                        <!-- Nav tabs -->
                        <div class="row">
                            <div class="col-12 col-lg-12 col-md-12 col-lg-12 login_option_btn">
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#login" role="tab">Login</a></li>
                                    <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#panel2" role="tab">Register</a></li>
                                </ul>
                            </div>
                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                <!-- Tab panels -->
                                <div class="tab-content card">
                                    <!--Login-->
                                    <div class="tab-pane fade in show active" id="login" role="tabpanel">
                                        <%--                                    <form action="#">--%>
                                        <div class="row">
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-9">
                                                <div class="form-group">
                                                    <%--                                                    <label class="control-label">Email</label>--%>
                                                    <input id="LoginEmail" runat="server" type="email" class="form-control" placeholder="Email">
                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-9">
                                                <div class="form-group">
                                                    <%--                                                    <label class="control-label">Password</label>--%>
                                                    <input id="LoginPassword" runat="server" type="password" class="form-control" placeholder="Password">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                            <div class="row">
                                                <a href="ForgetPassword.aspx" style="font-size:large" title="" class="forget_pass">Forget Password ?</a>
<%--                                                <asp:Button ID="btnLogi1n" CssClass="col-md-3 btnRightMargin btn btn-block btn-success" Width="300px" Text="Login" OnClick="LoginUser" runat="server" />--%>
                                                &nbsp&nbsp &nbsp&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp
                                               <asp:Button ID="btnLogin" Width="300px" Text="Login" OnClick="LoginUser" CssClass="col-md-3 btnRightMargin btn btn-block btn-success"  OnClientClick="return validateLogin()" runat="server" />
<%--                                                <asp:Button ID="btnForgetPasswd" CssClass="col-md-3 btnRightMargin btn btn-block btn-success" Width="300px" Text="Forget Password" OnClick="RedirectToForgetPaswd" runat="server" />--%>

<%--                                                <asp:Button onClick="RedirectToForgetPaswd" Width="400px" Text="Forget Password" CssClass="col-md-3 btnRightMargin btn btn-block btn-success" ID="btnForgetPasswd" runat="server"/>--%>

                                                </div>
                                            <%--<div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="social_login">
                                                    <div class="social_items">
                                                        <button class="google_login google">Login Google</button>
                                                        <button class="google_login facebook">Login Facebook</button>
                                                        <button class="google_login twitter">Login Twitter</button>
                                                        <button class="google_login linkdin">Login Linkdin</button>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                        <label runat="server" id="labelmsg"></label>
                                        <%--                                    </form>--%>
                                    </div>
                                    <!--/.Panel 1-->
                                    <!--Panel 2-->
                                    <div class="tab-pane fade" id="panel2" role="tabpanel">
                                        <%--                                    <form action="#" class="register">--%>
                                        <div class="row">
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="form-group">
                                                    
                                                    <%--                                                    <label class="control-label">Name</label>--%>
<%--                                                    <asp:TextBox ID="RegUser"  runat="server" CssClass="form-control" placeholder="Username" AutoPostBack="true" OnTextChanged="CheckEmptyValue" />--%>
                                                    <input type="text" id="RegUserName" runat="server" class="form-control" placeholder="Username"  />

                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="form-group">
                                                    <%--                                                    <label class="control-label">Email</label>--%>
                                                    <input type="email" id="RegEmail" runat="server" class="form-control" placeholder="Email"/>
                                                    <%--                                                    <asp:RegularExpressionValidator ID="RegExpEmail" runat="server" ControlToValidate="RegEmail" ValidationExpression="^\S+@\S+$" Text="incorrect format" />--%>
                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="form-group">
                                                    <%--                                                    <label class="control-label">Password</label>--%>
                                                    <input type="password" id="RegPassword" runat="server" class="form-control" placeholder="Password"/>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-12">

                                                    <div>

                                                        <label><span style="font-weight: bold; font-size: medium; color: black">Student Admission &nbsp</span></label>
                                                    </div>

                                                </div>

                                            </div>


                                            <input type="checkbox" class="defaultCheckbox" runat="server"
                                                id="ChkEdu" checked="checked" name="ChkEdu" style="width: 25px; height: 25px; float: right">

                                       <%--     <div class="row">
                                                <div class="col-lg-12">

                                                    <div>

                                                        <label><span style="font-weight: bold; font-size: medium; color: black">Want Immigration Services in Canada ? &nbsp</span></label>
                                                    </div>

                                                </div>

                                            </div>


                                            <input type="checkbox" class="defaultCheckbox" runat="server"
                                                id="ChkImg" name="ChkImg" style="width: 25px; height: 25px">
--%>



                                           <%-- <div class="row">
                                                <div class="col-lg-12">

                                                    <div>
                                                        <label><span style="font-weight: bold; font-size: medium; color: black">Want Settlement Services in Canada ? &nbsp</span></label>
                                                    </div>

                                                </div>

                                            </div>


                                            <input type="checkbox" class="defaultCheckbox" runat="server"
                                                id="ChkSett" name="ChkSett" onchange="ChkValue" style="width: 25px; height: 25px; scroll-padding-right: auto">--%>


                                            <%--                                             <input type="checkbox" class="defaultCheckbox"
            name="checkBox1" style="width: 25px; height: 25px" checked>--%>
                                        </div>

                                        <div class="row" runat="server">

                                            <asp:Button ID="btnRegister" runat="server" OnClick="RegisterUser" Text="Register" OnClientClick="return validateRegister();" CssClass="col-md-3 btnRightMargin btn btn-block btn-success"  />
                                            <asp:Label ID="RgstMessage" Font-Size="Large" runat="server" />
                                        </div>

                                        <%--                                        <div class="col-12 col-lg-12 col-md-12 col-lg-12 d-flex justify-content-between login_option">--%>
                                        <div>
                                            <asp:Button ID="btnRegister1" Visible="false" Text="Register" OnClick="RegisterUser" runat="server" />

                                        </div>

                                        <div>
                                            <asp:Button ID="Button1" Visible="false" Text="RegisterMe" OnClick="RegisterUser" runat="server"/>

                                        </div>

                                        <asp:Label ID="RegLabel" Visible="false" runat="server"></asp:Label>
                                        <%--                                        </div>--%>
                                        <%--                                    </form>--%>
                                    </div>

                                    <!--/.Panel 2-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="about_top_wrapper">
    <div class="container">            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                 <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                     </div>
                 <div class="col-12 col-sm-12 col-md-12 col-lg-5">
                     </div>
                <div class="title">
                    <h2 style="color:red;font-weight:bold"> 


PM Strat answers all your Questions...
                      
                    </h2>
                   
                <h3 style="color:black;font-weight:bold">At Pm Strat, we aim to guide you through your first steps of choosing the college that's right for you,  to applications, acceptance, enrolment and through to immigration and settling in. And we do it fast. </h3>
 </div>
            </div>
        </div>
    </div>

     
    
    <div ></div>
<div>            
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-7 ml-auto p-0">
                <div class="banner_learn">
                    <img src="images/banner/learnstep.jpg" alt="">
                 </div>
            </div>
        </div>
    </div>


    
</section>

        <footer style="background-color: #ff0000">
            <div class="container" style="background-color: #ff0000">
                <div class="row">
                    <div class="col-12 col-sm-3 col-md-3 col-lg-3 p-0 ">
                        <div class="shape_wrapper">
                            <%--                            <img src="images/shapes/bubble_shpe_1.png" alt="" class="shape_t_1">--%>
                            <%--                            <img src="images/shapes/round_shpae_1.png" alt="" class="shape_t_2">--%>
                        </div>
                    </div>
                    <div class="col-12 col-sm-9 col-md-9 col-lg-9 p-0 become_techer_wrapper">
                        <div class="become_a_teacher">
                            <div class="title">
                                <%--<h2>Become A Instructor</h2>
                                <p>Lorem ipsum dolor sit amet mollis felis dapibus arcu donec viverra. Pede phasellus eget. Etiam maecenas vel vici quis dictum rutrum nec nisi et.</p>--%>
                            </div>
                            <!-- ends: .section-header -->
                            <%-- <div class="get_s_btn">
                                <a href="#" title="">Get Started Now</a>
                            </div>--%>
                            <%--                            <img src="images/shapes/bubble_shpe_2.png" alt="" class="shape_t_1">--%>
                        </div>
                    </div>
                </div>
                <footer class="footer_2">
            <div class="container">
                <div class="footer_top">
                    <div class="row">
                        <div class="col-12 col-md-6 col-lg-4">
                            <div class="footer_single_col footer_intro">
                                <div class="row">
                              <img src="images/PMStrat_inLogo.png"  alt="" class="f_logo" style="image-resolution:unset;height:50px;width:60px">

                        <h2><a href="HomePage.aspx" class="nav-link" style="color: white">PMStrat inc</a></h2>  
                                    </div>
                        <p>PM Strat Inc is changing lives of individuals. Be the first one to register.</p>
                            </div>
                        </div>
                        <div class="col-12 col-md-6 col-lg-2">
                            <div class="footer_single_col">
                                <h3>Useful Links</h3>
                                <ul class="location_info quick_inf0">
                                    <li><a href="HomePage.aspx">Home</a></li>
                                    <li><a href="About.aspx">About</a></li>
                                    <li><a href="Contact.aspx">Contact</a></li>
                                    <li><a href="StuReg.aspx">Student</a></li>
                                </ul>
                            </div>
                        </div>
                        <%--<div class="col-12 col-md-6 col-lg-2">
                            <div class="footer_single_col information">
                                <h3>information</h3>
                                <ul class="quick_inf0">
                                    <li><a href="#">Leadereship</a></li>
                                    <li><a href="#">Company</a></li>
                                    <li><a href="#">Diversity</a></li>
                                    <li><a href="#">Jobs</a></li>
                                    <li><a href="#">Press</a></li>
                                </ul>
                            </div>
                        </div>--%>
                        <div class="col-12 col-md-12 col-lg-6">
                            <div class="footer_single_col contact">
                        <h3>Contact Us</h3>
                        <p>Our experts are waiting to hear from you. <span class="email" style="color:blue">admin1_user@pmstratinc.com</span>
                        </p>
                        <div class="contact_info">
<%--                            <span>+000 124 325</span> --%>
                              <span>+1 (647) 232-8196</span> 
                        </div>
                        <%--<ul class="social_items d-flex list-unstyled">
                            <li><a href="#"><i class="fab fa-facebook-f fb-icon"></i></a></li>
                            <li><a href="#"><i class="fab fa-twitter twitt-icon"></i></a></li>
                            <li><a href="#"><i class="fab fa-linkedin-in link-icon"></i></a></li>
                            <li><a href="#"><i class="fab fa-instagram ins-icon"></i></a></li>
                        </ul>--%>
                    </div>
                        </div>
                        <%--<div class="col-12 col-md-12 col-lg-12">
                    <div class="copyright">
                        <a target="_blank" href="https://www.templateshub.net">Templates Hub</a>
                    </div>
                 </div>--%>
                    </div>
                </div>
            </div>
            <div class="shapes_bg">
                <%--        <img src="images/shapes/testimonial_2_shpe_1.png" alt="" class="shape_3">        --%>
                <img src="images/shapes/footer_2.png" alt="" class="shape_1">
            </div>
        </footer>
            </div>
            
            <%--            <img src="images/shapes/footer_bg_shpe_1.png" alt="" class="shapes1_footer">--%>
        </footer>
    </form>

    <section id="scroll-top" class="scroll-top">
        <h2 class="disabled">Scroll to top</h2>
        <div class="to-top pos-rtive">
            <a href="#"><i class="flaticon-right-arrow"></i></a>
        </div>
    </section>

    <!-- JavaScript -->
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- Revolution Slider -->
    <script src="js/assets/revolution/jquery.themepunch.revolution.min.js"></script>
    <script src="js/assets/revolution/jquery.themepunch.tools.min.js"></script>
    <script src="js/jquery.magnific-popup.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/slick.min.js"></script>
    <script src="js/jquery.meanmenu.min.js"></script>
    <!-- Counter Script -->
    <script src="js/waypoints.min.js"></script>
    <script src="js/jquery.counterup.min.js"></script>
    <script src="js/wow.min.js"></script>
    <!-- Revolution Extensions -->
    <script src="js/assets/revolution/extensions/revolution.extension.actions.min.js"></script>
    <script src="js/assets/revolution/extensions/revolution.extension.carousel.min.js"></script>
    <script src="js/assets/revolution/extensions/revolution.extension.kenburn.min.js"></script>
    <script src="js/assets/revolution/extensions/revolution.extension.layeranimation.min.js"></script>
    <script src="js/assets/revolution/extensions/revolution.extension.migration.min.js"></script>
    <script src="js/assets/revolution/extensions/revolution.extension.navigation.min.js"></script>
    <script src="js/assets/revolution/extensions/revolution.extension.parallax.min.js"></script>
    <script src="js/assets/revolution/extensions/revolution.extension.slideanims.min.js"></script>
    <script src="js/assets/revolution/extensions/revolution.extension.video.min.js"></script>
    <script src="js/assets/revolution/revolution.js"></script>
    <script src="js/custom.js"></script>
</body>
</html>
