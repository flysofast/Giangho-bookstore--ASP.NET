<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGiua.ascx.cs" Inherits="QlSach.UC.UCGiua" %>
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
            onlyOne:true,
            trigger: 'hover',
        });

        
    });
    </script>
<asp:DataList ID="DataList1" runat="server" Width="100%" RepeatColumns="3" RepeatDirection="Horizontal">
    <ItemTemplate>
        <%--onmouseover="Tip('<div class=&quot;tooltip&quot;><img src=\'<%# Eval("anh") %>\'><br /><b>Tiêu đề: <%# Eval("tensach") %></b><br />Tác giả: <%# Eval("tacgia") %><br />Tom</div>')"--%>
            <div onclick="location.href='ThongTinSach.aspx?ms=<%# Eval("masach") %>'" 
                style="width: 280px; text-align: center; padding-top: 5px; padding-bottom: 15px;" class="bookHover tooltip" 
                title="<div>Tiêu đề: <span class=&quot;tieude&quot;> <%# Eval("tensach") %></span><br />Tác giả: <span class=&quot;tacgia&quot;><%# Eval("tacgia") %></span><br />Loại sách: <%# GetLoaiSach(Eval("maloai").ToString()) %><br />Tóm tắt: <%# ShortenedString( Eval("tomtat").ToString(),1500,"<i>... [Click để xem thêm]</i>") %><br />Tình trạng: <%# GetTinhTrang(Eval("masach").ToString()) %></div>">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/"+Eval("anh") %>' Height="130" />
                <br />


                <asp:Label ID="LTenSach" runat="server" Text='<%# ShortenedString(Eval("tensach").ToString(),30) %>' Font-Bold="True" Font-Overline="False" Font-Size="14px" Font-Strikeout="False" ForeColor="Green"></asp:Label>
                <br />

                <asp:Label ID="LTacGia" runat="server" Text='<%# Eval("tacgia") %>' Font-Size="13px"></asp:Label>
                <br />
                <span style="color: orangered; font-weight: bold; font-size: 14px">Giá:
                    <asp:Label ID="LGia" runat="server" Text='<%# Eval("gia") %>'></asp:Label>
                    VNĐ</span>
                <br />
                <a href='LuuGioHang.aspx?ms=<%# Eval("MaSach") %>' class="hyperlinkButton" style="font-size: 13px">Thêm vào giỏ hàng</a>
            </div>
    </ItemTemplate>
</asp:DataList>
<div style="text-align: center; margin-top: 50px;">
    <asp:Label ID="LpTrang" runat="server"></asp:Label>
</div>

