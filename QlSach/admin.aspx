<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="QlSach.admin" %>
<%@ Register src="UC/UCGiuaAdmin.ascx" tagname="UCGiuaAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:UCGiuaAdmin ID="UCGiuaAdmin1" runat="server" style="text-align:center"/>

</asp:Content>
