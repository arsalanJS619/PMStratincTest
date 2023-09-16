<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="WebApplication13.RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    
<head runat="server">

    <!-- Required meta tags -->
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta name="keywords" content="HTML,CSS,XML,JavaScript">
    <meta name="author" content="Ecology Theme">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PMStratinc - Shaping Lives</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon">
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--        <script src="Extension.min.js" type="text/javascript"></script>--%>



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
                                <%--  <li class="nav-item">
                                    <a href="#" class="nav-link active">Home</a>
                                    <ul class="navbar-nav nav mx-auto">
                                        <li class="nav-item"><a href="index-2.html" class="nav-link">Home Version 01</a></li>
                                        <li class="nav-item"><a href="index-3.html" class="nav-link">Home Version 02</a></li>
                                        <li class="nav-item"><a href="index-4.html" class="nav-link">Home Version 03</a></li>
                                        <li class="nav-item"><a href="index-5.html" class="nav-link">Home Version 04</a></li>
                                    </ul>
                                </li>--%>
                                <li class="nav-item"><a href="about.html" class="nav-link">About</a></li>
                                <%-- <li class="nav-item">
                                    <a href="course.html" class="nav-link">Courses</a>
                                    <ul class="navbar-nav nav mx-auto">
                                        <li class="nav-item"><a href="course.html" class="nav-link">Courses</a></li>
                                        <li class="nav-item"><a href="course-details.html" class="nav-link">Courses Details</a></li>
                                    </ul>
                                </li>--%>
                                <%-- <li class="nav-item">
                                    <a href="blog.html" class="nav-link">Blog</a>
                                    <ul class="navbar-nav nav mx-auto">
                                        <li class="nav-item"><a href="blog.html" class="nav-link">Blog List</a></li>
                                        <li class="nav-item"><a href="blog-2.html" class="nav-link">Blog Grid One</a></li>
                                        <li class="nav-item"><a href="blog-3.html" class="nav-link">Blog Grid Two</a></li>
                                        <li class="nav-item"><a href="blog-details.html" class="nav-link">Blog Details</a></li>
                                    </ul>
                                </li>--%>
                                <%--<li class="nav-item">
                                    <a href="#" class="nav-link">Pages</a>
                                    <ul class="navbar-nav nav mx-auto">
                                        <li class="nav-item">
                                            <a href="#" class="nav-link dropdown_icon">Courses</a>
                                            <ul class="navbar-nav nav mx-auto">
                                                <li class="nav-item"><a href="course.html" class="nav-link">Courses</a></li>
                                                <li class="nav-item"><a href="course-details.html" class="nav-link">Courses Details</a></li>
                                            </ul>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link dropdown_icon">Events</a>
                                            <ul class="navbar-nav nav mx-auto">
                                                <li class="nav-item"><a href="event.html" class="nav-link">Event</a></li>
                                                <li class="nav-item"><a href="event-details.html" class="nav-link">Event Details</a></li>
                                            </ul>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link dropdown_icon">Blog</a>
                                            <ul class="navbar-nav nav mx-auto">
                                                <li class="nav-item"><a href="blog.html" class="nav-link">Blog List</a></li>
                                                <li class="nav-item"><a href="blog-2.html" class="nav-link">Blog Grid One</a></li>
                                                <li class="nav-item"><a href="blog-3.html" class="nav-link">Blog Grid Two</a></li>
                                                <li class="nav-item"><a href="blog-details.html" class="nav-link">Blog Details</a></li>
                                            </ul>
                                        </li>
                                        <li class="nav-item"><a href="become-a-teacher.html" class="nav-link">Become A Teacher</a></li>
                                        <li class="nav-item"><a href="teacher-profile.html" class="nav-link">Teachers Profile</a></li>
                                        <li class="nav-item"><a href="team.html" class="nav-link">Teachers Page</a></li>
                                        <li class="nav-item"><a href="forgot-password.html" class="nav-link">Forgot Password</a></li>
                                    </ul>
                                </li>--%>

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

            <div class="intro_wrapper">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 col-md-8 col-lg-8">
                            <div id="dv1" runat="server" class="intro_text">
                                <h1>Settlement Services</h1>

                                <%--     ArrivalDate:	Cannot be less than today's date.
Airline:	
Flight #:	
Airport:	
Total Number of Persons Arriving	Range 1 - 10
Number of children under 4-years:	Range 1-10--%>

                                <%--<div class="pages_links">
                            <a href="#" title="">Home</a>
                            <a href="#" title="" class="active">Settl Details</a>
                        </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <!-- End Header -->



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
                                    <span style="font-weight:bold" class="title">Travel Info </span>
                                   <div class="col-12"></div>

                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Arrival Date" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                         <div class="col-12 col-sm-12 col-md-6 form-group">
                                                                <div class="input-group my-colorpicker2 colorpicker-element" style="width: 75px;padding-right:unset">
                                                                    <asp:TextBox class="form-control" ID="BirthDate11"  Width="275px" Style="z-index: auto" runat="server" MaxLength="11"></asp:TextBox>
                                                                    <%-- <div class="input-group-addon">
                                                                &nbsp;<asp:Image ID="ImgBirthDate" runat="server" ImageUrl="images/Calendar_scheduleHS.png" />
                                                            </div>--%>
                                                                </div>
                                            
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="BirthDate11" Format="dd-MMM-yyyy"></ajaxToolkit:CalendarExtender>

                                                            </div>            

                                    </div>  


                                                                       <div class="col-12"></div>

                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Airline" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:TextBox runat="server" ID="TxtAirlineID"></asp:TextBox>
                                    </div>  
                                    
                                    
                                    <div class="col-12"></div>

                                      <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Flight" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
<%--                                           runat="server" class="form-control" id="TotalPersID" />--%>
                                    </div>  

                                      <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Airport" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
<%--                                           runat="server" class="form-control" id="TotalPersID" />--%>
                                    </div>  

                                      <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Total Person" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
<%--                                           runat="server" class="form-control" id="TotalPersID" />--%>
                                    </div>  

                                      <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Number Person" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
<%--                                           runat="server" class="form-control" id="TotalPersID" />--%>
                                    </div>  


                                     <div class="col-12"></div>


                                    <h3 class="title">Services Required</h3>

                                                                       <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="ChkBox1" style="font-size: x-large; font-weight: bold">Hotel PickUp</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="ChkBox1" />
                </div>

                                     <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="ChkBox2" style="font-size: x-large; font-weight: bold">Visit To Office</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="ChkBox2" />
                </div>

                                                         <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="ChkBox3" style="font-size: x-large; font-weight: bold">Hotel Stay</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="ChkBox3" />
                </div>

                                     <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="ChkBox4" style="font-size: x-large; font-weight: bold">Visit To Bank</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="ChkBox4" />
                </div>

                                                         <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="ChkBox5" style="font-size: x-large; font-weight: bold">House Leasing</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="ChkBox5" />
                </div>

                                     <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="ChkBox6" style="font-size: x-large; font-weight: bold">Visit To School</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="ChkBox6" />
                </div>

                                                         <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="ChkBox7" style="font-size: x-large; font-weight: bold">Shopping</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="ChkBox7" />
                </div>

                                     <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="ChkBox8" style="font-size: x-large; font-weight: bold">Any Additional</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="ChkBox8" />
                </div>









                                     <div class="col-12"></div>

                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <label for="VisitOffice" style="font-size: x-large; font-weight: bold">Visit To Office</label>
                </div>
                <div class="col-12 col-sm-12 col-md-6 form-group">
                    <input type="checkbox" style="width: 35px; height: 35px" id="VisitOffice" name="NVisitOffice" />
                </div>



                                     <div class="col-12"></div>



                                     <div class="col-12"></div>

                                       <div class="col-12 col-sm-12 col-md-6 form-group">
                                           <br />
                                        <asp:Label Font-Size="X-Large" Font-Bold="true" Text="Notes" runat="server"></asp:Label>
                                        </div>
                                    <div class="col-12 col-sm-12 col-md-6 form-group">
                                        <input type="text" runat="server" class="form-control" id="Notes" style="width:500px;height:200px" />
                                    </div>  


                                      <div class="col-12 col-sm-12 col-md-12 submit-btn">
                                        <button runat="server" type="submit" class="text-center" onclick="CallMe" >Submit</button>
                                    </div>

                                </div>
                            </form>   
                        </div>                     
                      

                        <div class="row">
                        </div>
                    </div> 
                </div>
           </div>
        </div>
    </div>
</section>




        <!-- Footer -->
        <footer class="footer_2">
            <div class="container">
                <div class="footer_top">
                    <div class="row">
                        <div class="col-12 col-md-6 col-lg-4">
                            <div class="footer_single_col footer_intro">
                                <img src="images/logo2.png" alt="" class="f_logo">
                                <p>Ante amet vitae vulputate odio nulla vel pretium pulvinar aenean. Rhoncus eget adipiscing etiam arcu. Ultricies justo ipsum nec amet.</p>
                            </div>
                        </div>
                        <div class="col-12 col-md-6 col-lg-2">
                            <div class="footer_single_col">
                                <h3>Useful Links</h3>
                                <ul class="location_info quick_inf0">
                                    <li><a href="#">Leadereship</a></li>
                                    <li><a href="#">Company</a></li>
                                    <li><a href="#">Diversity</a></li>
                                    <li><a href="#">Jobs</a></li>
                                    <li><a href="#">Press</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-12 col-md-6 col-lg-2">
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
                        </div>
                        <div class="col-12 col-md-6 col-lg-4">
                            <div class="footer_single_col contact">
                                <h3>Contact Us</h3>
                                <p>Ante amet vitae vulputate odio nulla vel pretium aenean.</p>
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
                        <div class="col-12 col-md-12 col-lg-12">
                            <div class="copyright">
                                <a target="_blank" href="https://www.templateshub.net">Templates Hub</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="shapes_bg">
<%--                <img src="images/shapes/testimonial_2_shpe_1.png" alt="" class="shape_3">--%>
                <img src="images/shapes/footer_2.png" alt="" class="shape_1">
            </div>
        </footer>
        <!-- End Footer -->

        <section id="scroll-top" class="scroll-top">
            <h2 class="disabled">Scroll to top</h2>
            <div class="to-top pos-rtive">
                <a href="#"><i class="flaticon-right-arrow"></i></a>
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
                    <a class="navbar-brand" href="index-2.html">
                        <img src="images/logo.png" alt="logo"></a>
                    <p>Education Template</p>

                </div>
                <div class="demos">
                    <div><a href="index-2.html" data-toggle="tooltip" data-placement="top" title="Home Style One">
                        <img class="main-image img-fluid" src="demo/index_1.png" alt="" /></a></div>
                    <div><a href="index-3.html" data-toggle="tooltip" data-placement="top" title="Home Style Two">
                        <img class="main-image img-fluid" src="demo/index_2.png" alt="" /></a></div>
                    <div><a href="index-4.html" data-toggle="tooltip" data-placement="top" title="Home Style Three">
                        <img class="main-image img-fluid" src="demo/index_3.png" alt="" /></a></div>
                    <ul class="list-unstyled clearfix">
                        <li><a href="about.html" data-toggle="tooltip" data-placement="top" title="About Page">
                            <img src="demo/about.png" alt="" class="img-fluid"></a></li>
                        <li><a href="blog.html" data-toggle="tooltip" data-placement="top" title="Blog Page">
                            <img src="demo/blog.png" alt="" class="img-fluid"></a></li>
                        <li><a href="blog-details.html" data-toggle="tooltip" data-placement="top" title="Blog Details Page">
                            <img src="demo/blog_details.png" alt="" class="img-fluid"></a></li>
                        <li><a href="event.html" data-toggle="tooltip" data-placement="top" title="Event Page">
                            <img src="demo/event.png" alt="" class="img-fluid"></a></li>
                        <li><a href="event-details.html" data-toggle="tooltip" data-placement="top" title="Event Deiails">
                            <img src="demo/event_details.png" alt="" class="img-fluid"></a></li>
                        <li><a href="teacher-profile.html" data-toggle="tooltip" data-placement="top" title="Teacher Profile">
                            <img src="demo/teacher_pro.png" alt="" class="img-fluid"></a></li>
                        <li><a href="course.html" data-toggle="tooltip" data-placement="top" title="Courses Page">
                            <img src="demo/course.png" alt="" class="img-fluid"></a></li>
                        <li><a href="course-details.html" data-toggle="tooltip" data-placement="top" title="Courses Details">
                            <img src="demo/course_details.png" alt="" class="img-fluid"></a></li>
                        <li><a href="team.html" data-toggle="tooltip" data-placement="top" title="Team Page">
                            <img src="demo/team.png" alt="" class="img-fluid"></a></li>
                        <li><a href="contact.html" data-toggle="tooltip" data-placement="top" title="Contact Page">
                            <img src="demo/contact.png" alt="" class="img-fluid"></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
