<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     Code&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="Code" runat="server"></asp:TextBox>
 <br />
 <br />
 Name&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="Name" runat="server"></asp:TextBox>
 <br />
 <br />
 Amount&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
 <br />
 <br />
 Category&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:DropDownList ID="Category" runat="server"></asp:DropDownList>
 <br />
 <br />
 Price&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="Price" runat="server"></asp:TextBox>
 <br />
 <br />
 Creation Date&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="CreationDate" runat="server"></asp:TextBox>
 <br />
 <br />
 <br />
 <asp:Button ID="ButtonCreate" runat="server" Text="Create" CssClass="ButtonEstilo" OnClick="ButtonCreate_Action"/>
    <asp:Label ID="LblCreate" runat="server"></asp:Label>
 <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="ButtonEstilo" OnClick="ButtonUpdate_Action"/>
 <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="ButtonEstilo" OnClick="ButtonDelete_Action"/>
 <asp:Button ID="ButtonRead" runat="server" Text="Read" CssClass="ButtonEstilo" OnClick="ButtonRead_Action"/>
 <asp:Button ID="ButtonReadFirst" runat="server" Text="Read First" CssClass="ButtonEstilo" OnClick="ButtonRF_Action"/>
 <asp:Button ID="ButtonReadPrev" runat="server" Text="Read Prev" CssClass="ButtonEstilo" OnClick="ButtonPrev_Action"/>
 <asp:Button ID="ButtonNext" runat="server" Text="Read Next" CssClass="ButtonEstilo" OnClick="ButtonNext_Action" />
</asp:Content>
