<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentProgressRep.aspx.cs" Inherits="WebApplication13.StudentProgressRep" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<head runat="server">
    
    <!-- Required meta tags -->
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta name="keywords" content="HTML,CSS,XML,JavaScript">
    <meta name="author" content="Ecology Theme">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PMStratinc - Shaping Lives</title>
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
    <script type="text/css">
 
    </script>
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
               <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                                        <li><i class="flaticon-mail-black-envelope-symbol"></i>admin1_user@pmstratinc.com</li>
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

    <div class="edu_nav">
        <div class="container">
            <nav class="navbar navbar-expand-md navbar-light bg-faded">
<img src="images/PMStrat_inLogo.png"  alt="" class="f_logo" style="image-resolution:unset;height:50px;width:60px">

                        <h1><a href="HomePage.aspx" class="nav-link" style="color: red">PMStrat inc</a></h1>                 <!--<a class="navbar-brand" href="index-2.html"><img src="images/logo.png" alt="logo"></a>-->
                <div class="collapse navbar-collapse main-menu" id="navbarSupportedContent">
                    <ul class="navbar-nav nav lavalamp ml-auto menu">
                                                                                 <li id="UsrStuInfo" runat="server" class="nav-item"><a href="StuReg.aspx" class="nav-link" >Student Info</a></li>

                       <li id="AdmProgress" runat="server"><a href="AdminProgress.aspx" class="nav-link">progress</a>
                                     <ul>

                                      <li class="dropdown-item" style="display:contents"><a href="AdminStage1.aspx">Stage 1</a></li>
                                        <li class="dropdown-item" style="display:contents"><a>&nbsp&nbsp</a></li>
                                        <li class="dropdown-item" style="display:contents"><a href="AdminStage2.aspx">Stage 2</a></li>
                                        <li class="dropdown-item" style="display:contents"><a>&nbsp&nbsp</a></li>
                                        <li class="dropdown-item" style="display:contents"><a href="AdminStage3.aspx">Stage 3</a></li>
                                    </ul>
                                </li>

                                <li id="AdmReports"  runat="server" class="nav-item"><a href="StudentProgressRep.aspx" class="nav-link">Reports</a>
                           
                               </li>
                                <li id="AdmQueries"  runat="server" class="nav-item"><a href="AdminQueries.aspx" class="nav-link">Queries</a></li>

                                <li id="AdminUsrMng"  runat="server" class="nav-item"><a href="AdminUsrMangemnt.aspx" class="nav-link">UserManagement</a></li>

                    </ul>
                </div>
                
            </nav><!-- END NAVBAR -->
        </div> 
    </div>

    <div class="intro_wrapper">
        <div class="container">  
            <div class="row">        
                 <div class="col-sm-12 col-md-8 col-lg-8">
                    <div class="intro_text">
                        <div class="pages_links">
                            <%--<a href="#" title="">Home</a>
                            <a href="#" title="" class="active">Student Details</a>--%>
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
                                    <span style="font-weight:bold;font-family:'Times New Roman'" class="title">STUDENT APPLICATION STATUS REPORT</span>
                                    <div class="col-12 col-sm-12 col-md-12 form-group"></div>

                                          <div class="col-6 col-sm-6 col-md-3 form-group">
                                        <asp:Label Font-Size="Large" Font-Bold="true" Text="Our Action" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-6 col-sm-6 col-md-3 form-group">
                                       <asp:DropDownList runat="server" class="form-control" id="OurAction" Width="250px" Height="45px" ForeColor="Black">
                                           <asp:ListItem>All</asp:ListItem>
                                           <asp:ListItem>InProcess</asp:ListItem>
                                           <asp:ListItem>Accepted</asp:ListItem>
                                           <asp:ListItem>Rejected</asp:ListItem>

                                           </asp:DropDownList>
                                    </div>   

                                                                        <div class="col-12 col-sm-12 col-md-12 form-group"></div>


                                                              <div class="col-6 col-sm-6 col-md-3 form-group">
 <asp:Label Font-Size="Large" Font-Bold="true" Text="From Date" runat="server"></asp:Label>   

                                                              </div>
                                            <div class="col-6 col-sm-6 col-md-3 form-group">
                                                                                                                             <div class="input-group my-colorpicker2 colorpicker-element">

<asp:TextBox CssClass="form-control" ID="FromDate" OnTextChanged="Set_ToDate" AutoPostBack="true" Font-Size="Large"  Style="width:150px" runat="server" MaxLength="11" onfocus="checkDateEntryMode(this)" onblur="checkDate(this);" onpaste="return false" onKeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                                                                                <div class="input-group-addon">   

                                                <!--------------------------------------------------------->

                                                
                                                 <!--   -->



                                            <asp:Image ID="FromImgDate" Width="25px" runat="server" ImageUrl="images/Calendar_scheduleHS.png" />
                                                                                                                                 </div>
                                                </div>
                                    <ajaxToolkit:CalendarExtender PopupPosition="BottomRight" ID="CESubmission" runat="server" TargetControlID="FromDate" PopupButtonID="FromImgDate" Format="dd-MMM-yyyy"></ajaxToolkit:CalendarExtender>
                                                                                  </div>   
                                    
                                     <div class="col-12 col-sm-12 col-md-12 form-group"></div>

                                      <div class="col-6 col-sm-6 col-md-3 form-group">
 <asp:Label Font-Size="Large" Font-Bold="true" Text="To Date" runat="server"></asp:Label>   

                                                              </div>

                                     <div class="col-6 col-sm-6 col-md-3 form-group">
                                                                             <div class="input-group my-colorpicker2 colorpicker-element">

<asp:TextBox CssClass="form-control" ID="ToDates" OnTextChanged="Set_ToDate" AutoPostBack="true" Font-Size="Large"  Style="width:150px" runat="server" MaxLength="11" onfocus="checkDateEntryMode(this)" onblur="checkDate(this);" onpaste="return false" onKeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                                        
                                         <div class="input-group-addon">   
                                             
                                         <asp:Image ID="ToImgDate" Width="25px" runat="server" ImageUrl="images/Calendar_scheduleHS.png" />
                                             </div>                                    
                                             </div>
                                    <ajaxToolkit:CalendarExtender PopupPosition="BottomRight" ID="CalendarExtender1" runat="server" TargetControlID="ToDates" PopupButtonID="ToImgDate" Format="dd-MMM-yyyy"></ajaxToolkit:CalendarExtender>
                                                                                 

                                                                         <div class="col-12 col-sm-12 col-md-12 form-group"></div>




<%--                                        <div class="col-6 col-sm-6 col-md-3 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Submission Datessss" runat="server"></asp:Label>
                                        </div>

                                    <div class="col-6 col-sm-6 col-md-3 form-group">
                                    <div class="input-group my-colorpicker2 colorpicker-element">
                                        <asp:TextBox CssClass="form-control" ID="SubmissionDates" Width="10px" runat="server" MaxLength="11" onfocus="checkDateEntryMode(this)" onblur="checkDate(this);" onpaste="return false" onKeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                                        <div class="input-group-addon">
                                            &nbsp;<asp:Image ID="ImgDateofRegistration" Width="25px" runat="server" ImageUrl="images/Calendar_scheduleHS.png" />
                                        </div>
                                    </div>
                                    <ajaxToolkit:CalendarExtender PopupPosition="BottomRight" ID="CESubmission1" runat="server" TargetControlID="SubmissionDates" PopupButtonID="ImgDateofRegistration" Format="dd-MMM-yyyy"></ajaxToolkit:CalendarExtender>


                                    <%--<div class="col-12 col-sm-12 col-md-4 form-group">
                                        <asp:Label Font-Size="Large" Font-Bold="true" Text="From Date" runat="server"></asp:Label>                                    
                                        <asp:TextBox CssClass="form-control" ID="FromDate" OnTextChanged="Set_ToDate" AutoPostBack="true" Font-Size="Large"  Style="width:200px" runat="server" MaxLength="11" onfocus="checkDateEntryMode(this)" onblur="checkDate(this);" onpaste="return false" onKeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                                        
                                            &nbsp;<asp:Image ID="FromImgDate" Width="25px" runat="server" ImageUrl="images/Calendar_scheduleHS.png" />
                                    <ajaxToolkit:CalendarExtender PopupPosition="BottomRight" ID="CESubmission" runat="server" TargetControlID="FromDate" PopupButtonID="FromImgDate" Format="dd-MMM-yyyy"></ajaxToolkit:CalendarExtender>
                                        </div>--%>     
 
                                   <%--<div class="col-12 col-sm-12 col-md-4 form-group">
                                        <asp:Label Font-Size="Large" Font-Bold="true" Text="To Date" runat="server"></asp:Label>
                                       
                                        <asp:TextBox CssClass="form-control" ID="ToDates" Font-Size="Large" Style="width:200px" runat="server" MaxLength="11" onfocus="checkDateEntryMode(this)" onblur="checkDate(this);" onpaste="return false" onKeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                                       
                                            &nbsp;<asp:Image ID="ToImgDate" Width="25px" runat="server" ImageUrl="images/Calendar_scheduleHS.png" />
                                        
                                    
                                    <ajaxToolkit:CalendarExtender PopupPosition="BottomRight" ID="CalendarExtender1" runat="server" TargetControlID="ToDates" PopupButtonID="ToImgDate" Format="dd-MMM-yyyy"></ajaxToolkit:CalendarExtender>
 </div>--%>
                               
                                    </div> 

                                        

                                   <%--   <td class="col-12 col-sm-12 col-md-6 form-group">
                                    <div class="input-group my-colorpicker2 colorpicker-element">
                                        <asp:TextBox class="form-control" ID="DateofRegistration" Width="75px" Style="z-index: auto;" runat="server" MaxLength="11" onfocus="checkDateEntryMode(this)" onblur="checkDate(this);" onpaste="return false" onKeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                                        <div class="input-group-addon">
                                            &nbsp;<asp:Image ID="ImgDateofRegistration" runat="server" ImageUrl="images/Calendar_scheduleHS.png" />
                                        </div>
                                    </div>
                                    <ajaxToolkit:CalendarExtender ID="CEDateofRegistration" runat="server" TargetControlID="DateofRegistration" PopupButtonID="ImgDateofRegistration" Format="dd-MMM-yyyy"></ajaxToolkit:CalendarExtender>

                                </td>--%>

                                 <%--    <div class="input-group my-colorpicker2 colorpicker-element" style="width: 75px">
                                                            <asp:TextBox class="form-control" CssClass="disable_future_dates" TextMode="DateTime" ID="SubmissionDates" Width="205px" Style="z-index: auto;" runat="server" MaxLength="11" onfocus="checkDateEntryMode(this)" onblur="checkDate(this);" onpaste="return false" onKeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                                                            <div class="input-group-addon">
                                                                &nbsp;<asp:Image ID="ImgBirthDate" runat="server" ImageUrl="images/Calendar_scheduleHS.png" />
                                                            </div>
                                                        </div>
                                                        
                                                        <ajaxToolkit:CalendarExtender  ID="CEBirthDate" runat="server" TargetControlID="SubmissionDates" PopupButtonID="ImgBirthDate" Format="dd-MMM-yyyy"></ajaxToolkit:CalendarExtender>--%>



                                     <div class="col-12 col-sm-12 col-md-12 submit-btn">
                                              <asp:Button runat="server" CssClass="col-md-3 btnLeftMargin btn btn-block btn-success" Font-Size="Large" Text="Submit" onclick="SubmitForm"></asp:Button>
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



 <!-- Ends: Google Map Area -->  



<!-- Footer -->  
<!-- End Footer -->

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
                                    <li><a href="AdminReports.aspx">Reports</a></li>
                                    <li><a href="AdminQueries.aspx">Queries</a></li>
                                    <li><a href="UserManagement.aspx">User Management</a></li>
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
                        <p>Our experts are waiting to hear from you . For providing end to end admission workflow through a crystal clear procedure, our consultants will guide you deep down to get
                            a good position at our Canada's top academic institutions having a reputation that will be great for your upcoming future. <span class="email" style="color:blue">admin1_user@pmstratinc.com</span>
                        </p>
                        <div class="contact_info">
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
    <div class="demo-style-switch" id="switch-style">
        <a id="toggle-switcher" class="switch-button" title="Change Styles"><span class="fa fa-cog fa-spin"></span></a>
        <div class="switched-options">
            <div class="config-title">
                <a class="navbar-brand" href="index-2.html"><img src="images/logo.png" alt="logo"></a>
                <p>Education Template</p>
                
            </div>
            <div class="demos">
                <div><a href="index-2.html" data-toggle="tooltip" data-placement="top" title="Home Style One"><img class="main-image img-fluid" src="demo/index_1.png" alt=""/></a></div>
                <div><a href="index-3.html" data-toggle="tooltip" data-placement="top" title="Home Style Two"><img class="main-image img-fluid" src="demo/index_2.png" alt=""/></a></div>
                <div><a href="index-4.html" data-toggle="tooltip" data-placement="top" title="Home Style Three"><img class="main-image img-fluid" src="demo/index_3.png" alt=""/></a></div>
                <ul class="list-unstyled clearfix">
                    <li><a href="about.html" data-toggle="tooltip" data-placement="top" title="About Page"><img src="demo/about.png" alt="" class="img-fluid"></a></li>
                    <li><a href="blog.html" data-toggle="tooltip" data-placement="top" title="Blog Page"><img src="demo/blog.png" alt="" class="img-fluid"></a></li>
                    <li><a href="blog-details.html" data-toggle="tooltip" data-placement="top" title="Blog Details Page"><img src="demo/blog_details.png" alt="" class="img-fluid"></a></li>
                    <li><a href="event.html" data-toggle="tooltip" data-placement="top" title="Event Page"><img src="demo/event.png" alt="" class="img-fluid"></a></li>
                    <li><a href="event-details.html" data-toggle="tooltip" data-placement="top" title="Event Deiails"><img src="demo/event_details.png" alt="" class="img-fluid"></a></li>
                    <li><a href="teacher-profile.html" data-toggle="tooltip" data-placement="top" title="Teacher Profile"><img src="demo/teacher_pro.png" alt="" class="img-fluid"></a></li>
                    <li><a href="course.html" data-toggle="tooltip" data-placement="top" title="Courses Page"><img src="demo/course.png" alt="" class="img-fluid"></a></li>
                    <li><a href="course-details.html" data-toggle="tooltip" data-placement="top" title="Courses Details"><img src="demo/course_details.png" alt="" class="img-fluid"></a></li>
                    <li><a href="team.html" data-toggle="tooltip" data-placement="top" title="Team Page"><img src="demo/team.png" alt="" class="img-fluid"></a></li>
                    <li><a href="contact.html" data-toggle="tooltip" data-placement="top" title="Contact Page"><img src="demo/contact.png" alt="" class="img-fluid"></a></li>
                </ul>
            </div>
        </div>
    </div>    
    </form>
</body>
