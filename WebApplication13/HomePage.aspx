<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication13.HomePage" %>


<!DOCTYPE html>

<html>
    <script>
        __doPostBack("btnBack_Click", "");
    </script>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta name="keywords" content="HTML,CSS,XML,JavaScript">
    <meta name="author" content="Ecology Theme">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PMStratinc - Shaping Lives</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
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
                                        <li><i class="flaticon-phone-receiver"></i>+000-2356-222</li>
                                        <li><i class="flaticon-mail-black-envelope-symbol"></i>contact@yourdomain.com</li>
                                    </ul>
                                </div>
                                <div class="login_info">
                                    <ul class="d-flex">
                                        <li class="nav-item"><a href="#" class="nav-link sign-in js-modal-show"><i class="flaticon-user-male-black-shape-with-plus-sign"></i>Sign Up</a></li>
                                        <li class="nav-item"><a href="#" class="nav-link join_now js-modal-show"><i class="flaticon-padlock"></i>Log In</a></li>
                                    </ul>
<%--                                    <a href="#" title="" class="apply_btn">Apply Now</a>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="edu_nav">
                <div class="container">
                    <nav class="navbar navbar-expand-md navbar-light bg-faded">
                    <h1><a href="HomePage.aspx" class="nav-link" style="color:red">PMStratinc</a></h1>
                        <!--<a class="navbar-brand" href="index-2.html"><img src="images/logo.png" alt="logo"></a>-->
                        <div class="collapse navbar-collapse main-menu" id="navbarSupportedContent">
                            <ul class="navbar-nav nav lavalamp ml-auto menu">
                              
                                <li class="nav-item"><a href="about.html" class="nav-link">About</a></li>
                               
                             

                                <li class="nav-item"><a href="student.html" class="nav-link">Student</a></li>

                                <li class="nav-item"><a href="immigration.html" class="nav-link">Immigration</a></li>

                                <li class="nav-item"><a href="Settlement.aspx" class="nav-link">Settlement</a></li>

                                <li id="UserMang" class="nav-item" runat="server" ><a href="UserManagement.aspx" class="nav-link">User Management</a></li>


                                <li class="nav-item"><a href="contact.html" class="nav-link">Contact</a></li>
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
                        PMStratinc...Providing Quality                  
                   
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
                        Services in Canada for Everyone                   
                    </div>

                    <%-- <div class="tp-caption NotGeneric-Title   tp-resizeme"
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
Check Our Serives               
                            </div>--%>

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
                    <div class="tp-caption NotGeneric-Title   tp-resizeme"
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
                    </div>
                    s
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
                        PMStratinc...Providing Quality                  
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
                        Services in Canada for Everyone                   
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
                        Check Our Services            
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

          <section class="cources_highlight">
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

                        <div class="single_item single_item_center">
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
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- End Popular Courses Highlight -->
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
                                    <form action="#">
                                        <div class="row">
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="form-group">
                                                    <label class="control-label">Email</label>
                                                    <input id="txtEmail" runat="server" type="email" class="form-control" placeholder="Username">
                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="form-group">
                                                    <label class="control-label">Password</label>
                                                    <input id="txtPassword" runat="server" type="password" class="form-control" placeholder="Password">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12 d-flex justify-content-between login_option">
                                                <a href="forgot-password.html" title="" class="forget_pass">Forget Password ?</a>
                                                <button type="submit" id="btnLogin" onclick="UserLogin_Submit" class="btn btn-default login_btn">Login</button>
                                            </div>
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="social_login">
                                                    <div class="social_items">
                                                        <button class="google_login google">Login Google</button>
                                                        <button class="google_login facebook">Login Facebook</button>
                                                        <button class="google_login twitter">Login Twitter</button>
                                                        <button class="google_login linkdin">Login Linkdin</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                                <!--/.Panel 1-->
                                <!--Panel 2-->
                                <div class="tab-pane fade" id="panel2" role="tabpanel">
                                    <form action="#" class="register">
                                        <div class="row">
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="form-group">
                                                    <label class="control-label">Name</label>
                                                    <input type="text" class="form-control" placeholder="Username" />
                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="form-group">
                                                    <label class="control-label">Email</label>
                                                    <input type="email" class="form-control" placeholder="Email" />
                                                </div>
                                            </div>
                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12">
                                                <div class="form-group">
                                                    <label class="control-label">Password</label>
                                                    <input type="password" id="RegPassword" runat="server" class="form-control" placeholder="Password" />
                                                </div>
                                            </div>

                                               <div class="row">
                                                <div class="col-lg-12">

                                                    <div>

                                                        <label><span style="font-weight: bold; font-size: medium; color: black">Want Academic Services in Canada ? &nbsp</span></label>
                                                    </div>

                                                </div>

                                            </div>


                                            <input type="checkbox" class="defaultCheckbox"
                                                id="ChkEdu" name="ChkEdu" style="width: 25px; height: 25px;float:right">

                                               <div class="row">
                                                <div class="col-lg-12">

                                                    <div>

                                                        <label><span style="font-weight: bold; font-size: medium; color: black">Want Immigration Services in Canada ? &nbsp</span></label>
                                                    </div>

                                                </div>

                                            </div>


                                            <input type="checkbox" class="defaultCheckbox"  
                                                id="ChkImg" name="ChkImg" style="width: 25px; height: 25px">




                                            <div class="row">
                                                <div class="col-lg-12">

                                                    <div>
                                                        <label><span style="font-weight: bold; font-size: medium; color: black">Want Settlement Services in Canada ? &nbsp</span></label>
                                                    </div>

                                                </div>

                                            </div>


                                            <input type="checkbox" class="defaultCheckbox" 
                                                id="ChkSettl" name="ChkSettl"" style="width: 25px; height: 25px;scroll-padding-right:auto">


<%--                                             <input type="checkbox" class="defaultCheckbox"
            name="checkBox1" style="width: 25px; height: 25px" checked>--%>

                                        </div>
                                        <div class="row" runat="server">
                                         <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" class="col-md-6 btnLeftMargin btn btn-block btn-success" />

                                            <div class="col-12 col-lg-12 col-md-12 col-lg-12 d-flex justify-content-between login_option">
                                                <button  type="submit" causesvalidation="false" name="register" onserverclick="TestMe" runat="server">Register</button>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                                
                                <!--/.Panel 2-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

        <footer style="background-color:#ff0000" >
            <div class="container" style="background-color:#ff0000">
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
                <div class="footer_top">
                    <div class="row">
                       <%-- <%--<div class="col-12 col-md-6 col-lg-4" style="background-color:#ff0000">
                            <%--<div class="footer_single_col footer_intro">
<%--                                <img src="images/logo2.png" alt="" class="f_logo">--%>
<%--                                <p>Ante amet vitae vulputate odio nulla vel pretium pulvinar aenean. Rhoncus eget adipiscing etiam arcu. Ultricies justo ipsum nec amet.</p>--%>
                           <%-- </div>
                        </div>--%>
                        <div class="col-12 col-md-6 col-lg-2" style="background-color:#ff0000">
                            <div class="footer_single_col">
                                <h3>Useful Links</h3>
                                <ul class="location_info quick_inf0">
                                    <li><a href="#">About Us</a></li>
                                    <li><a href="#">Blog</a></li>
                                    <li><a href="#">Developers</a></li>
                                    <li><a href="#">Services</a></li>
                                    <li><a href="#">Contact</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-12 col-md-6 col-lg-2" style="background-color:#ff0000">
                            <div class="footer_single_col information">
                                <h3>information</h3>
                                <ul class="quick_inf0">
                                    <li><a href="#">Campus Tour</a></li>
                                    <li><a href="#">Student Life</a></li>
                                    <li><a href="#">Scholarship</a></li>
                                    <li><a href="#">Admission</a></li>
                                    <li><a href="#">Leadership</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-12 col-md-6 col-lg-4" style="background-color:#ff0000">
                            <div class="footer_single_col contact">
                                <h3>Contact Us</h3>
                                <p>Fell free to get in touch us via Phone or send us a message.</p>
                                <div class="contact_info">
                                    <span>+000 124 325</span>
                                    <span class="email">info@yourdomain.com</span>
                                </div>
                                <ul class="social_items d-flex list-unstyled">
                                    <li><a href="#"><i class="fab fa-facebook-f fb-icon"></i></a></li>
                                    <li><a href="#"><i class="fab fa-twitter twitt-icon"></i></a></li>
                                    <li><a href="#"><i class="fab fa-linkedin-in link-icon"></i></a></li>
                                    <li><a href="#"><i class="fab fa-instagram ins-icon"></i></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="round_shape">
                <span class="shape_1"></span>
                <span class="shape_2"></span>
                <span class="shape_3"></span>
                <span class="shape_4"></span>
                <span class="shape_5"></span>
                <span class="shape_6"></span>
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
