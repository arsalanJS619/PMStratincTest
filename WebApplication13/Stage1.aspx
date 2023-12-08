<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stage1.aspx.cs" Inherits="WebApplication13.Stage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    
    <!-- Required meta tags -->
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
       
<header class="header_inner contact_page">
<!-- Preloader -->
<div id="preloader">
    <div id="status">&nbsp;</div>
</div>    
    <div class="header_top">
        <div class="container">
            <div class="row">
                <div class="col-12 col-sm-12 col-lg-12">
                    <div class="info_wrapper">
                        <div class="contact_info">                   
                            <ul class="list-unstyled">
<li><i >+1 (647) 232-8196</i></li>
<%--                                <li><i class="flaticon-mail-black-envelope-symbol"></i>admin1_user@pmstratinc.com</li>--%>
                            </ul>                    
                        </div>
                         <div class="login_info">
                                    <ul id="LoginHeader" runat="server" class="d-flex">
<%--                                        <li class="nav-item"><a href="#" class="nav-link sign-in js-modal-show"><i class="flaticon-user-male-black-shape-with-plus-sign"></i>Sign Up</a></li>--%>
<%--                                        <li class="nav-item"><a href="#" class="nav-link join_now js-modal-show"><i class="flaticon-padlock"></i>Log In</a></li>--%>
                                    </ul>
                           <ul id="UserLogged" runat="server" class="d-flex" style="color: black">
                                        <li class="nav-item"><a href="#" class="nav-link sign-in js-modal-show"><i class="flaticon-user-male-black-shape-with-plus-sign"></i></a></li>
                                        <%--                                        <li class="nav-item"><a href="#" class="nav-link join_now js-modal-show"><i class="flaticon-padlock"></i>Log In</a></li>--%>
                                    </ul>

                                    <a href="HomePage.aspx" id="LogoutHeader" onserverclick="LogoutUser" runat="server" title="">Logout</a>
                       
                        </div>
                        <%--<div class="login_info">
                             <ul class="d-flex">
                                <li class="nav-item"><a href="#" class="nav-link sign-in js-modal-show"><i class="flaticon-user-male-black-shape-with-plus-sign"></i>Sign Up</a></li>
                                <li class="nav-item"><a href="#" class="nav-link join_now js-modal-show"><i class="flaticon-padlock"></i>Lon In</a></li>
                            </ul>
<%--                            <a href="#" title="" class="apply_btn">Apply Now</a>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="edu_nav">
        <div class="container">
            <nav class="navbar navbar-expand-md navbar-light bg-faded">
 <img src="images/PMStrat_inLogo.png"  alt="" class="f_logo" style="image-resolution:unset;height:50px;width:60px">

                        <h1><a href="HomePage.aspx" class="nav-link" style="color: red">PMStrat Inc</a></h1>                <!--<a class="navbar-brand" href="index-2.html"><img src="images/logo.png" alt="logo"></a>-->
                <div class="collapse navbar-collapse main-menu" id="navbarSupportedContent">
                    <ul class="navbar-nav nav lavalamp ml-auto menu">
                        
                               <li class="nav-item"><a href="About.aspx" class="nav-link">About</a></li>                      
                        
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


                            
                                <li id="AdmProgress" visible="false" runat="server"><a href="AdminProgress.aspx" class="nav-link">Progress</a>
                                     <ul>

                                        <li class="dropdown-item"><a href="AdminStage1.aspx" style="padding:unset">Stage 1</a></li>
                                        <li class="dropdown-item"><a href="AdminStage2.aspx">Stage 2</a></li>
                                        <li class="dropdown-item"><a href="AdminStage3.aspx">Stage 3</a></li>
                                    </ul>
                                </li>
                              <%-- <li class="nav-item"><a href="StudentReg.aspx" class="nav-link">Student</a></li>

                                <li class="nav-item"><a href="immigration.html" class="nav-link">Immigration</a></li>

                                <li class="nav-item"><a href="Settlement.aspx" class="nav-link">Settlement</a></li>--%>

<%--                                <li id="UserMang" class="nav-item" runat="server" ><a href="UserManagement.aspx" class="nav-link">User Management</a></li>--%>

                                <li class="nav-item"><a href="Contact.aspx" class="nav-link">Contact</a></li>
                    </ul>
                </div>
                
            </nav><!-- END NAVBAR -->
        </div> 
    </div>

            <div class="intro_wrapper" style="background: url('../images/banner/stage1.jpg') no-repeat center center !important;">
        <div class="container">  
            <div class="row">        
                 <div class="col-sm-12 col-md-8 col-lg-8">
                    <div class="intro_text">
                        <div class="pages_links">
                           <h1 style="color:white">Stage 1</h1>
                            <h1 style="color:white">Application Progress</h1>
                            <h1 style="color:transparent">.</h1>
                              <h1 style="color:transparent">.</h1>
                                                                                    <h1 style="color:transparent">.</h1>
                        </div>
                    </div>
                </div>              
            </div>
        </div> 
    </div> 
</header> <!-- End Header -->



  <!-- End Login Signup Option -->




<section class="contact_info_wrapper">
     <div class="container">  
        <div class="row">  
           
            <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                <div class="contact_form_wrapper">
<%--                    <h2 class="title">Fill Details</h2>--%>
                    <div class="leave_comment">
                        <div class="contact_form">
                            <form action="#">
                                <div class="row">
                                    <span style="font-weight:bold" class="title">APPLICATION SUBMISSION</span>
                                   <div class="col-12"></div>

                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Applicant ID" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <input type="text" runat="server" class="form-control" id="ApplicantID" disabled="disabled" style="width:500px;color:darkgrey" readonly="true" />
                                    </div>  

                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Submission Date" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <input type="text" runat="server" id="SubmissionDates" disabled="disabled"  maxlength="11" style="width:500px;color:darkgrey"/>
                                    </div>  

                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                      
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="OnLine Form" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                         <input type="checkbox" class="defaultCheckbox" readonly="true" disabled="disabled" runat="server" id="onlinForm" style="width: 25px; height: 25px;float:left"/>
                                    </div>  

                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Supporting Doc" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                         <input type="checkbox" class="defaultCheckbox" disabled="disabled" runat="server" readonly="true" id="SupportingDoc" style="width: 25px; height: 25px;float:left"/>
                                    </div>  


                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="IELTS Score" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                         <input type="checkbox" class="defaultCheckbox" runat="server" id="IELTSScore" disabled="disabled" readonly="true" style="width: 25px; height: 25px;float:left"/>
                                    </div>  
                                    
                                                                     
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Processing Fee" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                         <input type="checkbox" class="defaultCheckbox" runat="server" id="ProcessingFee" disabled="disabled" readonly="true" style="width: 25px; height: 25px;float:left"/>
                                    </div>  


                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Our Action" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                       <asp:DropDownList runat="server" class="form-control" Enabled="false" id="OurAction" Width="500px" Height="40px" readonly="true">
                                           <asp:ListItem>Under Review</asp:ListItem>
                                           <asp:ListItem>Details Requested</asp:ListItem>
                                           <asp:ListItem>All Good</asp:ListItem>

                                           </asp:DropDownList>
                                    </div>   

                                   
                                      <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Remarks" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <input type="text" runat="server" class="form-control" id="Stage1Remarks" disabled="disabled"  style="width:500px;color:darkgrey" readonly="true"/>
                                    </div>  

                                     <div class="col-12 col-sm-12 col-md-12 submit-btn">
                                              <asp:Button runat="server" Visible="false" CssClass="col-md-3 btnLeftMargin btn btn-block btn-success" Text="Submit" onclick="SubmitForm"></asp:Button>
                                            </div>
                                                                    </div>
                            </form>   
                        </div>
                    </div> 
                </div>
           </div>
        </div>
    </div>
</section> <!-- Contact Info Wrappper-->



<%--<section class="contact_map">
    <div class="container-fluid">  
        <div class="row">                  
            <div class="col-12 col-sm-12 col-md-12 col-lg-12 mr-auto p-0">
                <h2 class="disabled">Google Map</h2>
                <div class="google_map">
                    <div class="gmap">
                        <div id="map"></div>
                    </div><!-- Ends: .gmap -->                    
                </div>
           </div>
        </div>
    </div>
</section>--%> <!-- Ends: Google Map Area -->  



<!-- Footer -->  
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
                        <p>Our experts are waiting to hear from you . <span class="email" style="color:blue">admin1_user@pmstratinc.com</span>
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
<!-- End Footer -->

<section id="scroll-top" class="scroll-top">
    <h2 class="disabled">Scroll to top</h2>
    <div class="to-top pos-rtive">
        <a href="#"><i class = "flaticon-right-arrow"></i></a>
    </div>
</section>

    <!--  JavaScript -->
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.magnific-popup.min.js"></script>     
    <script src="js/owl.carousel.min.js"></script>  
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAhrdEzlfpnsnfq4MgU1e1CCsrvVx2d59s"></script>
    <script src="js/map-helper.js"></script>     
    <script src="js/slick.min.js"></script>   
    <script src="js/jquery.meanmenu.min.js"></script>  
    <script src="js/wow.min.js"></script> 
    <!-- Counter Script -->
    <script src="js/waypoints.min.js"></script>
    <script src="js/jquery.counterup.min.js"></script>
    <script src="js/custom.js"></script> 
    
    <!-- =========================================================
         STYLE SWITCHER | ONLY FOR DEMO NOT INCLUDED IN MAIN FILES
    ============================================================== -->
    <script type="text/javascript" src="js/demo.js"></script>
        
    </form>
</body>
</html>
