<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCKhachHang.ascx.cs" Inherits="QlSach.UC.UCKhachHang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../css/controls.css" rel="stylesheet" />
<body style="text-align: left">
<div class="shadowedBox" align="center">
        <table align="center" width="100%" >
            <tr>
                <td width="120" align="center" >Họ tên:&nbsp;</td>
                <td align="left">
    <asp:TextBox ID="tbHoten" runat="server" Width="229px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequireFieldValidator3" runat="server" ErrorMessage="Phải nhập họ tên!" ControlToValidate="tbHoten"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td  width="120" align="center">Địa chỉ:&nbsp;&nbsp;</td>
                <td align="left"> <asp:TextBox ID="tbDiachi" runat="server" Width="228px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Phải nhập địa chỉ!" ControlToValidate="tbDiachi"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td  width="120" align="center">Số điện thoại:</td>
                <td align="left">
        <asp:TextBox ID="tbSdt" Width="229px" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Phải nhập số điện thoại!" ControlToValidate="tbSdt"></asp:RequiredFieldValidator>
   
                </td>
            </tr>
            <tr>
                <td  width="120" align="center">E-mail:</td>
                <td align="left">
                    <asp:TextBox ID="tbEmail" Width="229px" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  width="120" align="center">Tên đăng nhập:</td>
                <td align="left">
                    <asp:TextBox ID="tbTenDangNhap" Width="229px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbTenDangNhap" ErrorMessage="Phải nhập tên đăng nhập!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td  width="120" align="center">Mật khẩu</td>
                <td align="left">
                    <asp:TextBox ID="tbMK" Width="229px" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbMK" ErrorMessage="Phải nhập mật khẩu!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width="120" align="center">
        
    
                </td>
                <td align="left"><asp:Button ID="Button1" runat="server" Text="Đăng kí" OnClick="Button1_Click" Width="123px" CssClass="normalbutton" /></td>
            </tr>
            <tr>
                <td width="50" align="center">
        
    
                    &nbsp;</td>
                <td align="left">
                    <asp:Label ID="lbGioHang" runat="server" Text="Thông tin giỏ hàng:"></asp:Label>
                    <br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" Width="500px">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="masach" HeaderText="Mã sách" />
        <asp:HyperLinkField DataNavigateUrlFields="masach" DataNavigateUrlFormatString="~/thongtinsach.aspx?ms={0}" DataTextField="tensach" HeaderText="Tên sách" />
        <asp:BoundField DataField="soluong" HeaderText="Số lượng" />
        <asp:BoundField DataField="gia" HeaderText="Giá" />
        <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" />
    </Columns>
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
</asp:GridView>



                </td>
            </tr>
        </table>

<%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
        <asp:Label ID="lbTT" runat="server" Text="Thành tiền:"></asp:Label>
        <asp:Label ID="LTongtien" runat="server" ForeColor="Red"></asp:Label>
         </div>               



