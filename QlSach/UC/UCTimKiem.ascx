<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTimKiem.ascx.cs" Inherits="QlSach.UC.UCTimKiemChung" %>
<link href="../css/controls.css" rel="stylesheet" />
<%--<script src="../Scripts/jquery-1.10.2.js"></script>--%>
<%--<script type="text/javascript">
    $(function () {
        

        $("#txtTk").focus(function () {
            $("#txtTk").css("color", "#f33fff");
        });
    });



</script>--%>
<asp:Panel ID="Panel1" runat="server" DefaultButton="btTim">
<asp:TextBox ID="txtTk" Height="25px" runat="server" class="tb" Font-Italic="True" ForeColor="Gray" Width="171px" CssClass="textbox" BorderColor="gray" BorderStyle="Solid"></asp:TextBox>
<br />
<br />

<asp:Button ID="btTim" runat="server" Height="30px" OnClick="btTim_Click" Text="Tìm kiếm" CssClass="normalbutton" />
<br />
    </asp:Panel>


