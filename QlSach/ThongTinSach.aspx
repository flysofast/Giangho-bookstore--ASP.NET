<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="ThongTinSach.aspx.cs" Inherits="QlSach.ThongTinSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .info {
            text-align: left;
            vertical-align: top;
            /*background-color: #FF6222;*/
            background: url(css/pool_table2.png) repeat;
            color: white;
            padding: 2px 3px;
        }
    </style>
    <div style="height: 100%">
        <table style="width: 100%;">
            <tr>
                <td rowspan="7" style="width: 40%;vertical-align:top">
                    <asp:Image ID="Image1" runat="server" Width="100%" />
                </td>
                <td class="info" style="width: 12%">Mã sách</td>
                <td class="info">
                    <asp:Label ID="lbMaSach" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="info" style="width: 12%">Tiêu đề</td>
                <td class="info">
                    <asp:Label ID="lbTieuDe" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF6222"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="info" style="width: 12%">Tác giả</td>
                <td class="info">
                    <asp:Label ID="lbTacgia" runat="server" Text="Label" ForeColor="Green"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="info" style="width: 12%">Số tập</td>
                <td class="info">
                    <asp:Label ID="lbSotap" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="info" style="width: 12%">Loại sách</td>
                <td class="info">
                    <asp:Label ID="lbLoaiSach" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="info" style="width: 12%">Tóm tắt nội dung</td>
                <td class="info">
                    <asp:Label ID="lbTomTat" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="info" style="width: 12%">Tình trạng</td>
                <td class="info">
                    <asp:Label ID="lbTinhTrang" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
