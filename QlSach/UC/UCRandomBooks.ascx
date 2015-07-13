<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRandomBooks.ascx.cs" Inherits="QlSach.UC.UCRandomBooks" %>
<script src="tooltipster-master/js/jquery.tooltipster.js"></script>
    <script src="tooltipster-master/js/jquery.tooltipster.min.js"></script>
    <link href="tooltipster-master/css/tooltipster.css" rel="stylesheet" />

<script>
    $(document).ready(function () {
        $('.tooltip').tooltipster({
            animation: 'fall',
            delay: 500,
            theme: '.tooltipster-punk',
            //touchDevices: true,
            onlyOne: true,
            trigger: 'hover',
        });


    });
    </script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" Interval="60000" OnTick="Timer1_Tick">
        </asp:Timer>
        <div class="box-title">Sách ngẫu nhiên <div style="display:inline-block" class="refreshimage"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/refresh.png" Height="15px" OnClick="ImageButton1_Click" /></div></div>
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="0">
            <ItemTemplate>
                
                <div onclick="location.href='ThongTinSach.aspx?ms=<%# Eval("masach") %>'" 
                style="width: 280px; text-align: center; padding-top: 5px; padding-bottom: 15px;" class="bookHover tooltip" 
                title="<div>Tiêu đề: <span class=&quot;tieude&quot;> <%# Eval("tensach") %></span><br />Tác giả: <span class=&quot;tacgia&quot;><%# Eval("tacgia") %></span><br />Loại sách: <%# GetLoaiSach(Eval("maloai").ToString()) %><br />Tóm tắt: <%# ShortenedString( Eval("tomtat").ToString(),1500,"<i>... [Click để xem thêm]</i>") %><br />Tình trạng: <%# GetTinhTrang(Eval("masach").ToString()) %></div>">
                    <table style="width: 100%;">
                        <tr>
                            <td rowspan="4" style="width: 100px;">
                                <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# "~/"+Eval("anh") %>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="LTenSach" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="13px" Font-Strikeout="False" ForeColor="Green" Text='<%# ShortenedString(Eval("tensach").ToString(),30) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="LTacGia" runat="server" Text='<%# Eval("tacgia") %>' Font-Size="13px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;"><span style="color:orangered;font-size:13px">Giá:
                            <asp:Label ID="LGia" runat="server" Text='<%# Eval("gia") %>'></asp:Label> VNĐ</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;"><a href='LuuGioHang.aspx?ms=<%# Eval("MaSach") %>' class="hyperlinkButton" style="font-size: 13px">Thêm vào giỏ hàng</a></td>
                        </tr>
                    </table>

                </div>
            </ItemTemplate>
            
        </asp:DataList>
       
    </ContentTemplate>

</asp:UpdatePanel>





