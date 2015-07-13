<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLoaiSach.ascx.cs" Inherits="QlSach.UC.UCLoaiSach" %>
<%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" Height="149px" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="maloai" DataNavigateUrlFormatString="?ml={0}" DataTextField="tenloai" ShowHeader="False" HeaderStyle-Wrap="False">
<HeaderStyle Wrap="False"></HeaderStyle>

            <ItemStyle Font-Size="14px" />
            </asp:HyperLinkField>
        </Columns>
        
    </asp:GridView>--%>
<link href="../css/sidemenu.css" rel="stylesheet" />

<%--<script>
    $(function () {
        $("#nav li").hover(function () {
            //$(this).effect("highlight",100);
            $(this).find("ul:first").show();
        });

        $("#nav li").mouseleave(function () {
            //$(this).effect("highlight");
           
            $(this).find("ul:first").hide();
        });
    });
</script>--%>
<div id="wrapper">
    <ul id="nav">
        <%BuildMenu(); %>
    </ul>

</div>

