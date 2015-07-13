<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCDauAdmin.ascx.cs" Inherits="QlSach.UC.UCDauAdmin1" %>

<%@ Register Src="~/UC/UCLogin.ascx" TagPrefix="uc1" TagName="UCLogin" %>

<link href="../css/style.css" rel="stylesheet" />
<link rel="Shortcut icon" href="../images/imgSmallAvatar.jpg" />
<script src="Scripts/jquery-1.10.2.js"></script>
<script type="text/javascript">
    $(function () {

        rightalign();//gọi hàm khi load web 
        $(window).resize(function () {//gọi lại hàm khi thay đổi kích thước trình duyệt 
            rightalign()
        })
        function rightalign() {//xây dựng hàm căn giữa 
            $('#login').css({ 'top': 25, 'left': ($(window).width() / 2 - $("#login").width()) + $("#MainPage").width() / 2 + 3 })
        }

        $("#login").hide(0);

        $("#loginlabel").click(function () {

            $("#login").slideDown(400);


        });

        $("#login").mouseleave(function () {
            $("#login").slideUp(400);
        });
    });
</script>
<div style="background-color: white; width: 1200px; height: 155px; margin-bottom: 10px; align-self: center;">
    <a href="default.aspx">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Logo.jpg" ImageAlign="Left" /></a>
    <%--<uc1:UCLoginAdmin runat="server" ID="UCLoginAdmin" />--%>
    <div id="login" style="padding-left: 0px; position: fixed; z-index: 100; background-color: darkgreen; /*border-radius: 0px 0px 8px 8px;*/ opacity: 0.9; border: groove 4px greenyellow">
        <uc1:UCLogin runat="server" ID="UCLogin" />
    </div>
    <ul class="menu" style="width: 1210px; position: fixed; top: 0px; z-index: 99;">
        <li><a href="Admin.aspx"><span>QUẢN LÝ SÁCH</span></a></li>
        <li><a href="QLLoai.aspx"><span>QUẢN LÝ LOẠI</span></a></li>
        <li><a href="Khachhangadmin.aspx"><span>KHÁCH HÀNG</span></a></li>
        <li><a href="Taikhoan.aspx"><span>TÀI KHOẢN</span></a></li>
        <li><a href="Default.aspx" class="active"><span>VỀ TRANG CHỦ</span></a></li>
        <li style="float: right" id="loginlabel"><a><span>
            <asp:Label ID="lbLogin" runat="server" Text="ĐĂNG NHẬP"></asp:Label></span></a></li>
    </ul>
</div>
