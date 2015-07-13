<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage2.Master" AutoEventWireup="true" CodeBehind="KhachhangAdmin.aspx.cs" Inherits="QlSach.KhachhangAdmin" %>

<%@ Register Src="UC/UCDauAdmin.ascx" TagName="UCDauAdmin" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="center" class="box">
        <div class="box-title">
            <asp:Label ID="lbCenterTitle" runat="server" Text="Quản lý thanh toán"></asp:Label>
        </div>
        <table align="center" width="1200">

            <tr>
                <td class="shadowedBox" width="250" valign="top" align="left" height="20">
                    <ul>
                        <li>
                            <asp:LinkButton ID="hlChuaThanhToan" runat="server" OnClick="hlChuaThanhToan_Click">Sách chưa thanh toán</asp:LinkButton>

                        </li>
                        <br />
                        <li>
                            <asp:LinkButton ID="hlDaThanhToan" runat="server" OnClick="hlDaThanhToan_Click">Sách đã thanh toán</asp:LinkButton>
                        </li>
                    </ul>
                </td>
                <td align="center" width="950" rowspan="2" class="shadowedBox">
                    <asp:Label ID="lbNull" runat="server" Text="Không có dữ liệu này!" Font-Italic="True" Visible="False"></asp:Label>
                    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="masach" DataNavigateUrlFormatString="~/thongtinsach.aspx?ms={0}" DataTextField="tensach" HeaderText="Tên sách" />
                            <asp:BoundField DataField="mahoadon" HeaderText="Mã hóa đơn" />
                            <asp:BoundField DataField="makh" HeaderText="Mã khách hàng" />
                            <asp:HyperLinkField DataNavigateUrlFields="makh" DataNavigateUrlFormatString="xacthuc.aspx?makh={0}" DataTextField="hoten" HeaderText="Họ tên KH" />
                            <asp:BoundField DataField="diachi" HeaderText="Địa chỉ" />
                            <asp:BoundField DataField="sdt" HeaderText="Số điện thoại" />
                            <asp:BoundField DataField="SoLuongMua" HeaderText="Số lượng mua" />
                            <asp:BoundField DataField="gia" HeaderText="Giá" />
                            <asp:BoundField DataField="ngaymua" HeaderText="Ngày mua" />
                            <asp:BoundField DataField="Socthd" HeaderText="Mã mua" />
                            <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td width="250" valign="top" align="center" class="shadowedBox">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#0066CC" Text="Tìm kiếm theo tên khách hàng:"></asp:Label>
                    <asp:TextBox ID="tbHoten" runat="server" CssClass="textbox" BorderColor="#009900" BorderStyle="Solid" EnableTheming="True" BorderWidth="1px"></asp:TextBox>
                    <asp:Button ID="btTK" runat="server" OnClick="btTK_Click" Text="Tìm" BorderStyle="Solid"  BackColor="#CCFF99" BorderColor="#CCFF99" CssClass="button"/>
                </td>
            </tr>

        </table>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
