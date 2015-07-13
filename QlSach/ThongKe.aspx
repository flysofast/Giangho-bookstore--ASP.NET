<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage2.Master" AutoEventWireup="true" CodeBehind="ThongKe.aspx.cs" Inherits="QlSach.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box">
                <div class="box-title">
                    <asp:Label ID="lbCenterTitle" runat="server" Text="Thống kê"></asp:Label>
                </div>
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: center">
                            Loại sách&nbsp;
                            <%--<asp:DropDownList ID="drdLoaiSach" runat="server" AutoPostBack="True" DataTextField="tenloai" DataValueField="maloai">
                            </asp:DropDownList>--%>
                        </td>
                        <td>
                            Ngày&nbsp;
                            <asp:DropDownList ID="drdNgay" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdNgay_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Tháng&nbsp;
                            <asp:DropDownList ID="drdThang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdThang_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Năm&nbsp;
                            <asp:DropDownList ID="drdNam" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdNam_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:ListBox ID="lsbLoaiSach" runat="server" DataTextField="tenloai" DataValueField="maloai" Rows="1" AutoPostBack="True" ViewStateMode="Enabled" Width="90%"></asp:ListBox>
                        </td>
                        <td colspan="3" style="text-align: center; vertical-align: top;">
                            <strong style="font-size: large; color: #008000">Các sách đã được mua:</strong><br />
                            <asp:GridView ID="grvSach" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="90%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="masach" HeaderText="Mã sách" />
                                    <asp:HyperLinkField DataNavigateUrlFields="masach" DataNavigateUrlFormatString="~/thongtinsach.aspx?ms={0}" DataTextField="tensach" HeaderText="Tên sách" />
                                    <asp:BoundField DataField="soluongmua" HeaderText="Số lượng mua" />
                                    <asp:BoundField DataField="gia" DataFormatString="{0} VNĐ" HeaderText="Giá tiền" />
                                    <asp:BoundField DataField="thanhtien" DataFormatString="{0} VNĐ" HeaderText="Thành tiền" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                            <asp:Label ID="lbNone" runat="server" Font-Italic="True" Text="Không có dữ liệu nào" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%">&nbsp;</td>
                        <td colspan="3" style="text-align: center">
                            <br style="width: 85%" />
                            Tổng số sách:
                            <asp:Label ID="lbTotalCount" runat="server" Font-Bold="True" ForeColor="Red">0 cuốn</asp:Label>
                            <br />
                            Tổng tiền:
                            <asp:Label ID="lbTotal" runat="server" Font-Bold="True" ForeColor="Red">0 VNĐ</asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
