<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="HienThiKhachHang.aspx.cs" Inherits="QlSach.HienThiKhachHang1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
                        <asp:Label ID="Label1" runat="server" Style="text-align: center" Text="Lịch sử giao dịch:" Font-Bold="True" Font-Size="Larger" ForeColor="#3366FF"></asp:Label>
                        <br />
                        <br />

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="98%">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="masach" DataNavigateUrlFormatString="~/thongtinsach.aspx?ms={0}" DataTextField="tensach" HeaderText="Tên sách" />
                                <asp:BoundField DataField="tacgia" HeaderText="Tác giả" />
                                <asp:BoundField DataField="SoLuongMua" HeaderText="Số lượng mua" />
                                <asp:BoundField DataField="MaHoaDon" HeaderText="Mã hóa đơn" />
                                <asp:BoundField DataField="NgayMua" HeaderText="Ngày mua" />
                                <asp:BoundField HeaderText="Tình trạng " DataField="tt">
                                    <ItemStyle ForeColor="Red" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" BorderStyle="Dotted" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlDoiThongTin" runat="server" NavigateUrl="~/ThongTinKhachHang.aspx?act=tdtt">Thay đổi thông tin tài khoản</asp:HyperLink>
        </div>
</asp:Content>
