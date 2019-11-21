<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" class="fixed accounts lock-screen">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>Rajasthali</title>
    <%--<link rel="apple-touch-icon" sizes="120x120" href="favicon/apple-icon-120x120.png">
    <link rel="icon" type="image/png" sizes="192x192" href="favicon/android-icon-192x192.png">
    <link rel="icon" type="image/png" sizes="32x32" href="favicon/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="favicon/favicon-16x16.png">--%>
    <link rel="stylesheet" href="vendor/bootstrap/css/bootstrap.css">
    <link rel="stylesheet" href="vendor/font-awesome/css/font-awesome.css">
    <link rel="stylesheet" href="vendor/animate.css/animate.css">
    <link rel="stylesheet" href="stylesheets/css/style.css">
    <script>
        // register jQuery extension
        jQuery.extend(jQuery.expr[':'], {
            focusable: function (el, index, selector) {
                return $(el).is('a, button, :input, [tabindex]');
            }
        });
        $(document).on('keypress', 'input,select', function (e) {
            if (e.which == 13) {
                e.preventDefault();
                // Get all focusable elements on the page
                var $canfocus = $(':focusable');
                var index = $canfocus.index(document.activeElement) + 1;
                if (index >= $canfocus.length) index = 0;
                $canfocus.eq(index).focus();
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
            <div class="page-body">
                <%--<div class="logo">
                    <div class="avatar">
                        <img alt="Jane Doe" src="images/6.png" />
                    </div>
                </div>--%>
                <div class="box animated fadeInUp">
                    <div class="panel">
                        <div class="panel-content bg-scale-0">
                                <h3 class="text-center mb-md">Rajasthali</h3>
                                <div class="form-group mt-md">
                                    <span class="input-with-icon">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUserName" placeholder="Username"></asp:TextBox>
                                        <i class="fa fa-envelope"></i>
                                    </span>
                                </div>
                                <div class="form-group">
                                    <span class="input-with-icon">
                                        <asp:TextBox TextMode="Password" runat="server" CssClass="form-control" ID="txtPassword" placeholder="Password"></asp:TextBox>
                                        <i class="fa fa-key"></i>
                                    </span>
                                </div>
                            <div class="form-group">
                                        <asp:Label  runat="server" ID="lblError" ForeColor="Red" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="form-group">
                                   <%-- <a href="Home.aspx" class="btn btn-primary btn-block ">Login</a>--%>
                                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-wide btn-loading btn-primary btn-block" Text="Login" OnClick="btnLogin_Click" />
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="vendor/jquery/jquery-1.12.3.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
        <script src="vendor/nano-scroller/nano-scroller.js"></script>
        <script src="javascripts/template-script.min.js"></script>
        <script src="javascripts/template-init.min.js"></script>
    </form>
</body>
</html>