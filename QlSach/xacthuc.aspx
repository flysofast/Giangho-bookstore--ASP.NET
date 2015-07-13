<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage2.Master" AutoEventWireup="true" CodeBehind="xacthuc.aspx.cs" Inherits="QlSach.xacthuc" %>

<%@ Register Src="UC/UCDauAdmin.ascx" TagName="UCDauAdmin" TagPrefix="uc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box">
        <div class="box-title">
            <asp:Label ID="lbCenterTitle" runat="server" Text="Xác thực hóa đơn"></asp:Label>
        </div>
        <table style="width: 100%;padding-bottom:10px">

            <tr>
                <td align="center" colspan="3" style="font-weight: bold; color: #0000FF" width="100%">CÁC THÔNG TIN VỀ KHÁCH HÀNG</td>
            </tr>
            <tr>
                
                <td  style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%" >Mã khách hàng:</td>
                <td align="left" class="auto-style1" >
                    <asp:DropDownList ID="drdMakh" runat="server" AutoPostBack="True" DataTextField="makh" DataValueField="makh" OnSelectedIndexChanged="drdMakh_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%" >Họ tên:</td>
                <td align="left" class="auto-style1" >
                    <asp:Label ID="Lhoten" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%" >Địa chỉ:</td>
                <td class="auto-style1" align="left" >
                    <asp:Label ID="Ldiachi" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
               <td  style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%" >Số điện thoại:</td>
                <td align="left" >
                    <asp:Label ID="LSDT" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%" >Email:</td>
                <td align="left" >
                    <asp:Label ID="Lemail" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%">Tên đăng nhập:</td>
                <td align="left">
                    <asp:Label ID="lbTenDN" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="font-weight: bold; color: #0000FF" width="100%">CÁC ĐƠN HÀNG ĐÃ ĐẶT MUA</td>
            </tr>
            <tr>
                <td  style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%" >Số hóa đơn:</td>
                <td align="left" >
                    <asp:DropDownList ID="drdSohd" runat="server" AutoPostBack="True" DataTextField="mahoadon" DataValueField="mahoadon" OnSelectedIndexChanged="drdSohd_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%" >Ngày đặt mua:</td>
                <td align="left" >
                    <asp:Label ID="lbNgaymua" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td  style="width: 42%">&nbsp;</td>
                <td align="left" style="width: 11%" >Tình trạng thanh toán:</td>
                <td align="left" >
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Font-Bold="True" ForeColor="#FF3300" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Chưa thanh toán" />
                </td>
            </tr>
            <tr>
                <td align="right"  colspan="2">&nbsp;</td>
                <td align="left" >&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="font-weight: bold; color: #0000FF" width="100%">CÁC SÁCH ĐÃ ĐẶT MUA</td>
            </tr>
            <tr>
                <td align="center" colspan="3" width="100%">
                    <asp:GridView Width="95%" ID="GridView1" runat="server" CellPadding="3" AutoGenerateColumns="False"  OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="cthd" HeaderText="Mã mua" />
                            <asp:BoundField DataField="tensach" HeaderText="Tên sách" />
                            <asp:BoundField DataField="tacgia" HeaderText="Tác giả" />
                            <asp:BoundField DataField="SoLuongMua" HeaderText="Số lượng mua" />
                            <asp:BoundField DataField="ngaymua" HeaderText="Ngày mua" />
                            <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" />
                            <asp:BoundField HeaderText="Thay đổi số lượng" />
                            <asp:ButtonField CommandName="btSua" Text="Sửa" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Xóa" />
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
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3"  style="width:100%;padding-top:10px">Tổng tiền:
                    <asp:Label ID="lbTotal" runat="server" Font-Bold="True" ForeColor="Red">0 VNĐ</asp:Label>
                    <br />
                </td>
            </tr>
        </table>
    </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
