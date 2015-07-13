<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="QlSach.ErrorPage" %>


<%@ Register Src="~/UC/UCLogin.ascx" TagPrefix="uc1" TagName="UCLogin" %>
<%@ Register Src="~/UC/Dau.ascx" TagPrefix="uc1" TagName="Dau" %>
<%@ Register Src="~/UC/UCRandomBooks.ascx" TagPrefix="uc1" TagName="UCRandomBooks" %>
<%@ Register Src="~/UC/UCLoaiSach.ascx" TagPrefix="uc1" TagName="UCLoaiSach" %>
<%@ Register Src="~/UC/UCTimKiem.ascx" TagPrefix="uc1" TagName="UCTimKiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Giang Hồ Bookstore - Lỗi</title>
    <link rel="Shortcut icon" href="../images/yinyang.png" />
    <link href="css/Style2.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery-ui.js.js"></script>
    <script type="text/javascript">
        $(function () {

            rightalign();//gọi hàm khi load web 


            $(window).resize(function () {//gọi lại hàm khi thay đổi kích thước trình duyệt 
                rightalign();
            });
            function rightalign() {//xây dựng hàm căn giữa 
                $('#login').css({ 'top': 25, 'left': ($(window).width() / 2 - $("#login").width()) + $("#topmenu").width() / 2 - 6 })
            }
            //$("#login").hide(0);



            $("#loginlabel").click(function () {
                //$("#login").effect("easeOutBounce", "slow");
                //$("#login").slideDown(400);
                $("#login").toggle("drop", 300);
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="MainPage" style="position: relative;">
            
            <div id="login" style="display:none;padding-bottom: 5px; position: fixed; z-index: 100; background-color: #2f2f2f; /*border-radius: 0px 0px 8px 8px; */ opacity: 0.9; padding-left: 6px">
                <uc1:UCLogin runat="server" ID="UCLogin" />
            </div>
            <div id="page" class="box">
                <div id="header">
                    <uc1:Dau runat="server" ID="Dau" />

                </div>
                <div id="maincenter" style="text-align:center">
        <div class="box-title">
            <asp:Label ID="lbCenterTitle" runat="server" Text="Có lỗi xảy ra! "></asp:Label>
             Liên kết hiện tại không khả dụng. <a href="javascript:history.go(-1)">Bấm vào đây để quay về trang trước!</a>
        </div>

                </div>
            </div>
            <div id="footer">
                <div id="footer-content">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 400px">&nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="18pt" ForeColor="White" Text="Bài thực hành lập trình web"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 400px">&nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" Text="Giáo viên hướng dẫn: Nguyễn Hoàng Hà"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 400px">&nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" Text="Sinh viên: Lê Hải Nam"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
