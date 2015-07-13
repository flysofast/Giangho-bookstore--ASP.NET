<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLogin.ascx.cs" Inherits="QlSach.UC.UCLogin" %>
<style type="text/css">
    #hl:hover {
        color: orange;
    }

    .auto-style3 {
        width: 153px;
    }
</style>
<link href="../css/controls.css" rel="stylesheet" />
<%--<script src="Scripts/jquery-1.10.2.js"></script>
<script type="text/javascript">
    $(function () {
        //var txtBox = document.getElementById("tbUser");
        //txtBox.focus();
        $('#' + <%= tbUser.ClientID %>).focus();
        });
</script>--%>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <asp:Panel ID="Panel1" runat="server" DefaultButton="btLogin">
            <table style="width: 268px; height: 126px;">
                <tr>
                    <td>&nbsp;</td>
                    <td style="text-align: center" class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbID" runat="server" ForeColor="White" Text="Tên đăng nhập:"></asp:Label>
                    </td>
                    <td style="text-align: center" class="auto-style3">
                        <asp:TextBox ID="tbUser" runat="server" BackColor="White" Width="128px" CssClass="textbox" BorderColor="#ff8f3f" BorderStyle="Solid" EnableTheming="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btSignOut" runat="server" OnClick="btSignOut_Click" Text="Đăng xuất" Width="87px" Height="27px" CssClass="normalbutton"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:HyperLink ID="hlThongTin" runat="server" ForeColor="#ff8f3f" NavigateUrl="~/HienThiKhachHang.aspx" Width="100%"><span id="hl">Thông tin tài khoản</span></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbPass" runat="server" ForeColor="White" Text="Mật khẩu:"></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="tbPass" runat="server" BackColor="White" BorderColor="#ff8f3f" BorderStyle="Solid" CssClass="textbox" TextMode="Password" Width="128px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; margin-top: 7px;padding-top:5px">
                        <asp:Button ID="btLogin" runat="server" CssClass="normalbutton"  Height="27px" OnClick="btLogin_Click" Text="Đăng nhập" Width="92px" />
                        &nbsp; &nbsp; &nbsp;
                <asp:Button ID="btRegister" runat="server" CssClass="normalbutton" Height="27px" OnClick="btRegister_Click" Text="Đăng kí" Width="92px" />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Style="text-align: center" Width="100%"></asp:Label>
                        <br />

                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Panel ID="pnlCaptcha" runat="server">
                            
                            <img src="../Class/CaptchaVal.aspx" style="width: 95%; height: auto;" />
                            <asp:Label ID="lbSai" runat="server" ForeColor="Red" Text="Mã xác nhận chưa chính xác!" Visible="False"></asp:Label>
                            <asp:TextBox ID="tbCaptcha" runat="server" Width="95%"></asp:TextBox>
                        </asp:Panel>

                    </td>
                </tr>
            </table>

        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
