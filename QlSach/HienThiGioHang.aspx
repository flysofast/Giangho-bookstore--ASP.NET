<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="HienThiGioHang.aspx.cs" Inherits="QlSach.HienThiGioHang1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/controls.css" rel="stylesheet" />
    <div align="center">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" CellPadding="3" Width="95%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="masach" HeaderText="Mã sách" />
                            <asp:HyperLinkField DataNavigateUrlFields="masach" DataNavigateUrlFormatString="~/thongtinsach.aspx?ms={0}" DataTextField="tensach" HeaderText="Tên sách" />
                            <asp:BoundField DataField="soluong" HeaderText="Số lượng" />
                            <asp:BoundField DataField="gia" HeaderText="Giá" />
                            <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" />
                            <asp:BoundField HeaderText="Số lượng cần mua thêm" />
                            <asp:HyperLinkField />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <div>
                        <br />
&nbsp; 
                        <asp:Label ID="lbTT" runat="server" Text="Thành tiền:"></asp:Label>
&nbsp;<asp:Label ID="LTongtien" runat="server" ForeColor="Red"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btCapNhat" runat="server" Text="Cập nhật" OnClick="btCapNhat_Click" Height="30px" CssClass="normalbutton" />

                        &nbsp;&nbsp;

                        <asp:Button ID="btXoaGio" runat="server" Text="Xóa giỏ hàng" OnClick="btXoaGio_Click"  Height="30px" CssClass="normalbutton" />
&nbsp;&nbsp;
                        <asp:Button ID="btThanhToan" runat="server" Text="Đặt mua" OnClick="btThanhToan_Click"  Height="30px" CssClass="normalbutton" />
                    </div>
                </div>
</asp:Content>
