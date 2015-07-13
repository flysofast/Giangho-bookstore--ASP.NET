<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emails.aspx.cs" Inherits="QlSach.LacVietEmails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng kí email tải app beta</title>
    <style type="text/css">
        
       .logo {
    display:inline-block;
    animation: shaking 1s infinite ease-in-out alternate;
    -webkit-animation: shaking 1s infinite ease-in-out alternate;
}


@keyframes shaking {
    0% {
        transform: rotate(0deg);
        -ms-transform: rotate(0deg); /* IE 9 */
        -webkit-transform: rotate(0deg); /* Safari and Chrome */
    }

    50% {
        transform: rotate(0deg);
        -ms-transform: rotate(0deg); /* IE 9 */
        -webkit-transform: rotate(0deg); /* Safari and Chrome */
    }

    65% {
        transform: rotate(1deg);
        -ms-transform: rotate(1deg); /* IE 9 */
        -webkit-transform: rotate(1deg); /* Safari and Chrome */
    }

    75% {
        transform: rotate(-1deg);
        -ms-transform: rotate(-1deg); /* IE 9 */
        -webkit-transform: rotate(-1deg); /* Safari and Chrome */
    }

    100% {
        transform: rotate(0.5deg);
        -ms-transform: rotate(0.5deg); /* IE 9 */
        -webkit-transform: rotate(0.5deg); /* Safari and Chrome */
    }
}

@-webkit-keyframes shaking /* Safari and Chrome */
{
    0% {
        transform: rotate(0deg);
        -ms-transform: rotate(0deg); /* IE 9 */
        -webkit-transform: rotate(0deg); /* Safari and Chrome */
    }

    50% {
        transform: rotate(0deg);
        -ms-transform: rotate(0deg); /* IE 9 */
        -webkit-transform: rotate(0deg); /* Safari and Chrome */
    }

    65% {
        transform: rotate(1deg);
        -ms-transform: rotate(1deg); /* IE 9 */
        -webkit-transform: rotate(1deg); /* Safari and Chrome */
    }

    75% {
        transform: rotate(-1deg);
        -ms-transform: rotate(-1deg); /* IE 9 */
        -webkit-transform: rotate(-1deg); /* Safari and Chrome */
    }

    100% {
        transform: rotate(0.5deg);
        -ms-transform: rotate(0.5deg); /* IE 9 */
        -webkit-transform: rotate(0.5deg); /* Safari and Chrome */
    }
}


        .auto-style1 {
            width: 632px;
        }
       
    </style>
</head>
<body style="background:url(css/dimension.png) repeat fixed center top;" >
    <form id="form1" runat="server">
        <div style="margin: 0 auto; width: 1334px" >

            <table style="width: 90%">
                <tr>
                    <td class="auto-style1" style="width: 700px;">

                        <asp:Label ID="Label1" runat="server" Text="Email tài khoản WP:"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Style="margin-left: 19px" Width="181px" TextMode="Email"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="margin-left: 18px" Text="OK" />
                        <br />
                        <br />
                        Đăng kí app:
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="156px" DataTextField="app" DataValueField="app" style="margin-left: 14px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Selected="False" Value="lacviet">Lạc Việt 2.1</asp:ListItem>
                            <asp:ListItem Selected="True" Value="fantasticfarm">Fantastic Farm</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <%-- <img src="http://vietfriendship.net/images.php" />--%>
                        <asp:Label ID="lbHostName" runat="server">Bạn đến từ </asp:Label>
                        <br />
                        <asp:Label ID="lbHostIP" runat="server">IP của bạn: </asp:Label>
                        <br />
                        <asp:Label ID="lbBrowser" runat="server">Trình duyệt: </asp:Label>
                    </td>
                    <td style="vertical-align: top; width: 500px; text-align: center;">
                       
                        
                            <b><span style="font-size: medium;">Có cái app mong bà con ủng hộ:<br />
                            </span></b>
                        <a href="http://www.winphoneviet.com/forum/index.php?threads/49510/" style="text-decoration:none;">

                            &nbsp;<span style="font-size: medium; font-family:Tahoma"><span style="color: rgb(255, 0, 0);"><b><span style="color: rgb(255, 0, 0);">Just Run</span></b></span><span class="Apple-converted-space">&nbsp;</span>-<span class="Apple-converted-space">&nbsp;</span><span style="color: rgb(51, 102, 255);">Ứng dụng miễn phí giúp bạn hứng thú chạy bộ
                            <br />
                            (click để xem thông tin thêm, bấm vào logo để tải)</span></span>
                            <br /></a>
                       
                        <br />
                        <a style="text-decoration: none" href="http://www.windowsphone.com/en-us/store/app/just-run/32718529-30bd-482c-b6e3-e876aba10a15">
                           <div class="logo"> <img src="images/JustRunLogo.png" height="150px" width="150px" /></div><img src="images/QRJustRun.png" height="150px" width="150px" /></a>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" style="width: 700px;">
                        <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                    &nbsp;</td>
                    <td style="vertical-align: top; width: 500px; text-align: center;">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1" style="width: 700px;">Danh sách email:
        <asp:Label ID="lbcount" runat="server"></asp:Label>
                    </td>
                    <td style="vertical-align: top; width: 500px; text-align: center;">Email chưa add:
                    <asp:Label ID="lbnew" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" style="width: 700px;">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="158px" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" Width="547px" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="email" HeaderText="Email" />
                                <asp:CheckBoxField DataField="added" HeaderText="Đã add" ReadOnly="True" />
                                <asp:BoundField DataField="date" HeaderText="ĐK lúc" />
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </td>
                    <td style="vertical-align: top; width: 500px; text-align: center;">
                        <asp:TextBox ID="TextBox2" runat="server" Height="100%" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
