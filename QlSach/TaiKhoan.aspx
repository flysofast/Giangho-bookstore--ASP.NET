<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage2.Master" AutoEventWireup="true" CodeBehind="TaiKhoan.aspx.cs" Inherits="QlSach.TaiKhoan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/controls.css" rel="stylesheet" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="center" class="box">
                <div class="box-title">
                    <asp:Label ID="lbCenterTitle" runat="server" Text="Quản lý tài khoản"></asp:Label>
                </div>
                <table align="center" width="1200" class="shadowedBox">

                    <tr>
                        <td align="center" valign="top" width="180">Chọn tên đăng nhập:
                        </td>
                        <td align="left" valign="top" width="400">
                            <asp:DropDownList ID="drdID" runat="server" AutoPostBack="True" Height="19px" OnSelectedIndexChanged="drdID_SelectedIndexChanged" Width="211px">
                            </asp:DropDownList>
                        </td>
                        <td align="right" valign="top" width="200">Tên đăng nhập:</td>
                        <td align="left" valign="top" style="width: 650px">
                            <asp:TextBox ID="tbID" runat="server" Enabled="False" Width="192px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lbID" runat="server" ForeColor="Red" Text="Tên đăng nhập này đã tồn tại!" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" width="400" style="width: 400px; vertical-align: top; font-size: large; font-weight: bold;" colspan="2">Tìm kiếm:</td>
                        <td align="right" valign="top" width="200">Mật khẩu mới:</td>
                        <td align="left" valign="top" style="width: 650px">
                            <asp:TextBox ID="tbPass" runat="server" Width="192px" TabIndex="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="150" class="auto-style2">Họ tên:</td>
                        <td align="center" valign="top" width="400" style="text-align: left; vertical-align: top;" class="auto-style3">
                            <asp:TextBox ID="tbTKHoten" runat="server" Width="202px"></asp:TextBox>
                        </td>
                        <td align="right" valign="top" width="200" class="auto-style2">Loại tài khoản:</td>
                        <td align="left" valign="top" class="auto-style4">
                            <asp:RadioButton ID="rdAdmin" runat="server" GroupName="Quyen" Text="Administrator" TabIndex="4" />
                            <asp:RadioButton ID="rdNormal" runat="server" Checked="True" GroupName="Quyen" Text="Thường" TabIndex="5" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="150">Tên đăng nhập:</td>
                        <td align="center" valign="top" width="400" style="width: 200px; text-align: left; vertical-align: top;">
                            <asp:TextBox ID="tbTKID" runat="server" Width="202px"></asp:TextBox>
                        </td>
                        <td align="right" valign="top" width="200">Họ tên:</td>
                        <td align="left" valign="top" style="width: 650px">
                            <asp:TextBox ID="tbHoten" runat="server" Width="192px" TabIndex="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" width="400" colspan="2">
                            <asp:Button ID="btTim" runat="server" Text="Tìm" OnClick="btTim_Click" CssClass="normalbutton"/>
                            <br />
                            <asp:Label ID="lbNone" runat="server" ForeColor="Red" Text="Không tìm thấy!" Visible="False"></asp:Label>
                        </td>
                        <td align="right" valign="top" width="200">&nbsp;</td>
                        <td align="left" valign="top" style="width: 650px">
                            <asp:Button ID="btThem" runat="server" Text="Thêm mới..." OnClick="btThem_Click" CssClass="normalbutton"/>
                            <asp:Button ID="btSua" runat="server" OnClick="btSua_Click" Text="Sửa" CssClass="normalbutton"/>
                            <asp:Button ID="btXoa" runat="server" Text="Xóa" OnClick="btXoa_Click" CssClass="normalbutton"/>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>





