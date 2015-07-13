<%@ Page MasterPageFile="~/AdminMasterPage2.Master" Language="C#" AutoEventWireup="true" CodeBehind="ThemAdmin.aspx.cs" Inherits="QlSach.ThemAdmin" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <link href="css/controls.css" rel="stylesheet" />
            <div id="center" class="box">
                <div class="box-title">
                    <asp:Label ID="lbCenterTitle" runat="server" Text="Cập nhật thông tin sách"></asp:Label>
                </div>
                <table style="width: 100%">
                    <tr>
                        <td width="10%" style="text-align: right">Mã sách:
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtms" runat="server" ForeColor="Black" Width="212px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lbMaSachTrung" runat="server" ForeColor="Red" Text="&quot;Mã sách này đã tồn tại!&quot;" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">Tên sách:</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtts" runat="server" Width="212px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">Tác giả:</td>
                        <td colspan="2">
                            <asp:TextBox ID="txttg" runat="server" Width="212px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">Số lượng:</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtsl" runat="server" Width="212px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">Giá</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtgia" runat="server" Width="212px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">Số tập</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtSotap" runat="server" Width="212px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">Ngày nhập</td>
                        <td colspan="2">
                            <asp:Calendar ID="CNgayNhap" runat="server" Width="212px"></asp:Calendar>

                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">Loại sách:</td>
                        <td colspan="2">
                            <asp:DropDownList ID="DMaloai" runat="server" DataTextField="tenloai" DataValueField="maloai">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">Ảnh bìa </td>
                        <td colspan="2">
                            <asp:Image ID="Image1" runat="server" />
                            <br />
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" width="10%">Chọn ảnh bìa khác:</td>
                        <td colspan="2">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" width="10%">Tóm tắt:</td>
                        <td colspan="2">
                            <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Width="90%"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" style="text-align: right">
                        </td>
                        <td  style="text-align: center">
                            <asp:Button ID="btLuu" runat="server" OnClick="btLuu_Click" Text="Lưu" Width="76px"  CssClass="normalbutton" Height="29px"/>
                            <br />
                            <asp:Label ID="LHienthiloi" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

</asp:Content>
