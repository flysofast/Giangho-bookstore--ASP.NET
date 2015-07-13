<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage2.Master" AutoEventWireup="true" CodeBehind="QLLoai.aspx.cs" Inherits="QlSach.QLLoai1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="css/controls.css" rel="stylesheet" />
    <div  class="box" >
        <div class="box-title">
            <asp:Label ID="lbCenterTitle" runat="server" Text="Quản lý loại sách"></asp:Label>
        </div>
        <table align="center" width="1210" class="shadowedBox">
            <tr>
                <td align="right">&nbsp;<asp:Label ID="Label1" runat="server" Text="Chọn loại sách:"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="201px" CssClass="textbox" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">Chọn danh mục:</td>
                <td align="left">
                    <asp:DropDownList ID="drdDanhmuc" runat="server" DataTextField="tendanhmuc" DataValueField="madanhmuc" Height="20px" Width="201px" CssClass="textbox">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="200" align="right" style="width: 1000px">Mã loại</td>
                <td style="width: 1000px">
                    <asp:TextBox ID="tbMaloai" runat="server" Width="201px" Enabled="False" CssClass="textbox" ></asp:TextBox>
                    <asp:Label ID="lbMa" runat="server" Font-Bold="True" ForeColor="Red" Text="Mã loại này đã tồn tại!" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="200" align="right" style="width: 1000px">Tên loại:</td>
                <td style="width: 1000px">
                    <asp:TextBox ID="tbTenloai" runat="server" Width="201px" CssClass="textbox" ></asp:TextBox>
                    <asp:Label ID="lbTen" runat="server" Font-Bold="True" ForeColor="Red" Text="Tên loại này đã tồn tại!" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="200">&nbsp;</td>
                <td align="left" style="padding-top: 7px;">
                    <asp:Button ID="btThem" runat="server" Text="Thêm mới..." OnClick="btThem_Click" CssClass="normalbutton"/>
                    <asp:Button ID="btSua" runat="server" Text="Sửa" OnClick="btSua_Click" CssClass="normalbutton"/>
                    <asp:Button ID="btXoa" runat="server" Text="Xóa" OnClick="btXoa_Click" CssClass="normalbutton"/>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
