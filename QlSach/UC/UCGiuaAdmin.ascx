<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGiuaAdmin.ascx.cs" Inherits="QlSach.UC.UCGiuaAdmin" %>
 
<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
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
 
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script>
      $(function () {
         
          $(".hlXoa").click(function (e) {
             
              var link = this.href;
              $("#dialog-confirm").dialog({
                  resizable: false,
                  width: 500,
                  height: 200,
                  modal: true,
                  buttons: {
                      "Quân tử nhất ngôn": function () {
                          $(this).dialog("close");
                          location.href = link;
                      },
                      "Tại hạ click nhầm": function () {
                          $(this).dialog("close");
                      }
                  }
              });
              e.preventDefault();
          });
      });
  </script>
<div id="dialog-confirm" title="Thủ hạ lưu tình" style="display:none;">
  <p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>Cuốn kinh thư này quả thực là thiên hạ vô song. Các hạ thật sự muốn đốt nó thành tro bụi hay sao?</p>
</div>
<asp:DataList ID="DataList1" runat="server" Width="100%" RepeatColumns="3" RepeatDirection="Horizontal">
    <ItemTemplate>
        <div <%--onclick="location.href='ThongTinSach.aspx?ms=<%# Eval("masach") %>'--%>" 
                style="width: 280px; text-align: center; padding-top: 5px; padding-bottom: 15px;" class="bookHover tooltip" 
                title="<div>Tiêu đề: <span class=&quot;tieude&quot;> <%# Eval("tensach") %></span><br />Tác giả: <span class=&quot;tacgia&quot;><%# Eval("tacgia") %></span><br />Loại sách: <%# GetLoaiSach(Eval("maloai").ToString()) %><br />Tóm tắt: <%# ShortenedString( Eval("tomtat").ToString(),1500,"<i>... [Click để xem thêm]</i>") %><br />Tình trạng: <%# GetTinhTrang(Eval("masach").ToString()) %></div>">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/"+Eval("anh") %>' Height="130" />
                <br />

                
        <asp:Label ID="LTenSach" runat="server" Text='<%# ShortenedString(Eval("tensach").ToString(),30) %>' Font-Bold="True" Font-Overline="False" Font-Size="14px" Font-Strikeout="False"></asp:Label>
                <br />
                
        <asp:Label ID="LTacGia" runat="server" Text='<%# Eval("tacgia") %>' Font-Size="13px"></asp:Label>
                <br />
                <span style="color:orangered;font-weight:bold; font-size:14px">Giá: <asp:Label ID="LGia" runat="server" Text='<%# Eval("gia") %>'></asp:Label> VNĐ</span>
                <br />
            
        <p align="center">
           <%-- <a href="ThemAdmin.aspx">Thêm</a>&nbsp;&nbsp;--%>
            
            <a href="ThemAdmin.aspx?ms=<%#Eval("masach") %>">Sửa</a>&nbsp;&nbsp;
            <a class="hlXoa" href="XoaAdmin.aspx?ms=<%#Eval("masach") %>">Xóa</a>
            
        </p></div>
    </ItemTemplate>
</asp:DataList>
<div style="text-align:center">
    <asp:Label ID="LpTrang" runat="server" ></asp:Label>
</div>
