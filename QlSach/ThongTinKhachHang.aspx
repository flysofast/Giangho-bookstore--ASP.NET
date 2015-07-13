<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="ThongTinKhachHang.aspx.cs" Inherits="QlSach.ThongTinKhachHang1" %>

<%@ Register Src="~/UC/UCKhachHang.ascx" TagPrefix="uc1" TagName="UCKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <uc1:UCKhachHang runat="server" ID="UCKhachHang" /></div>
</asp:Content>
