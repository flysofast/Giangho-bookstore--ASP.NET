<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuaAdmin.aspx.cs" Inherits="QlSach.SuaAdmin" %>

<%@ Register src="UC/UCDauAdmin.ascx" tagname="UCDauAdmin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" width="1200" class="shadowedBox">
            <tr>
                <td>
                    <uc1:UCDauAdmin ID="UCDauAdmin1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center">
        <table style="width:100%;" align="center">
            <tr>
                <td width="500" align="right">Mã sách:
        </td>
                <td colspan="2" align="left">
        <asp:TextBox ID="txtms" runat="server" ForeColor="Black" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  width="500" align="right">Tên sách:</td>
                <td  colspan="2" align="left">
        <asp:TextBox ID="txtts" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="500" align="right">Tác giả:</td>
                <td colspan="2" align="left">
        <asp:TextBox ID="txttg" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="500" align="right">Số lượng:</td>
                <td colspan="2" align="left">
        <asp:TextBox ID="txtsl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="500" align="right">Giá</td>
                <td colspan="2" align="left">
        <asp:TextBox ID="txtgia" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="500" align="right">Ngày nhập</td>
                <td colspan="2" align="left"><asp:Calendar ID="CNgayNhap" runat="server"></asp:Calendar>
    
                </td>
            </tr>
            <tr>
                <td width="500" align="right">Mã loại:</td>
                <td colspan="2" align="left">
                    <asp:DropDownList ID="DMaloai" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="500" align="right">Ảnh bìa: </td>
                <td colspan="2" align="left">
                    <asp:Image ID="Image1" runat="server" />
                    <br />
                    Chọn ảnh bìa khác:
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="500" align="right">&nbsp;</td>
                <td align="left">
                    <asp:Button ID="btLuu" runat="server" OnClick="btLuu_Click" Text="Lưu" />
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
