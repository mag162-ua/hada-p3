<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 50%;
            margin: auto;
            font-family: Arial, sans-serif;
        }

        .header {
            text-align: initial;
            font-size: 14px;
            margin-bottom: 10px;
        }

        .banner {
            background-color: #39b8b8;
            color: black;
            text-align: center;
            padding: 40px;
            font-size: 34px;
            font-weight: bold;
        }
        .content h2 {
            font-size: 32px;
            font-weight: bold;
            margin-top: 20px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-top: 10px;
        }

        .input_box, .dropdown {
            width: 20%;
            padding: 5px;
            margin-top: 5px;
        }

        .button-container {
            margin-top: 20px;
            text-align: center;
        }

        .ButtonEstilo {
            padding: 3px 6px;
            margin-right: 5px;
            background-color: #ddd;
            border: 1px solid #aaa;
            cursor: pointer;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content">
            <h2>Products management</h2>    
          Code&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="Code" runat="server" MaxLength="16"></asp:TextBox>
         <asp:RequiredFieldValidator ControlToValidate="Code" ErrorMessage="Code is required" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
         &nbsp
         <asp:RegularExpressionValidator ControlToValidate="Code" ValidationExpression="^[a-zA-Z0-9]{1,16}$" ErrorMessage="Code must be 1-16 alphanumeric characters." runat="server" ForeColor="Red" ValidationGroup="CreateValidation"></asp:RegularExpressionValidator>
         <br />
         <br />
         Name&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="Name" runat="server" MaxLength="32"></asp:TextBox>
         <asp:RequiredFieldValidator ControlToValidate="Name" ErrorMessage="Name is required" runat="server" ForeColor="Red" ValidationGroup="CreateValidation"/>
         <br />
         <br />
         Amount&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ControlToValidate="Amount" ErrorMessage="Amount is required" runat="server" ForeColor="Red" />
            &nbsp
         <asp:RangeValidator ControlToValidate="Amount" ErrorMessage="Amount must be between 0 and 9999" MaximumValue="9999" Type="Integer" MinimumValue="0" runat="server" ForeColor="Red" ValidationGroup="CreateValidation"/>
         <br />
         <br />
         Category&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:DropDownList ID="Category" runat="server"></asp:DropDownList>
         <br />
         <br />
         Price&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="Price" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ControlToValidate="Price" ErrorMessage="Price is required" runat="server" ForeColor="Red" ValidationGroup="UpdateValidation" />
            &nbsp
         <asp:RegularExpressionValidator ControlToValidate="Price" ValidationExpression="^\d{1,4}(\.\d{1,2})?$" ErrorMessage="Price must be between 9999.99" runat="server" ForeColor="Red" ValidationGroup="UpdateValidation" /> 
         <br />
         <br />
         Creation Date&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="CreationDate" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ControlToValidate="CreationDate" ErrorMessage="Creation Date is required" runat="server" ForeColor="Red" ValidationGroup="CreateValidation"/>
            &nbsp
         <asp:RegularExpressionValidator ControlToValidate="CreationDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4} (0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$" ErrorMessage="Invalid date format (dd/mm/yyyy hh:mm:ss)" runat="server" ForeColor="Red" />
         <br />
         <br />
         <br />
            <asp:ValidationSummary ID="ValidationSummaryCreate" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" ValidationGroup="CreateValidation"/>
            <asp:ValidationSummary ID="ValidationSummaryUpdate" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" ValidationGroup="UpdateValidation" />
         <asp:Button ID="Button1" runat="server" Text="Create" CssClass="ButtonEstilo" OnClick="ButtonCreate_Action" CausesValidation="true" ValidationGroup="CreateValidation"/>
         <asp:Button ID="Button2" runat="server" Text="Update" CssClass="ButtonEstilo" OnClick="ButtonUpdate_Action" CausesValidation="true" ValidationGroup="UpdateValidation"/>
         <asp:Button ID="Button3" runat="server" Text="Delete" CssClass="ButtonEstilo" OnClick="ButtonDelete_Action" CausesValidation="false"/>
         <asp:Button ID="Button4" runat="server" Text="Read" CssClass="ButtonEstilo" OnClick="ButtonRead_Action" CausesValidation="false" />
         <asp:Button ID="Button5" runat="server" Text="Read First" CssClass="ButtonEstilo" OnClick="ButtonRF_Action" CausesValidation="true" />
         <asp:Button ID="Button6" runat="server" Text="Read Prev" CssClass="ButtonEstilo" OnClick="ButtonPrev_Action" CausesValidation="true" />
         <asp:Button ID="Button7" runat="server" Text="Read Next" CssClass="ButtonEstilo" OnClick="ButtonNext_Action" CausesValidation="true" />
         <br />
            <asp:Label ID="LblInfo" runat="server"></asp:Label>
        </div>
</asp:Content>


