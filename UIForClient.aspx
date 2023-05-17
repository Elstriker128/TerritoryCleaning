<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UIForClient.aspx.cs" Inherits="TerritoryCleaning.UIForClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/StyleForUI.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:CustomValidator ID="CustomValidator1" runat="server"></asp:CustomValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator2" runat="server"></asp:CustomValidator>
            <br />
            Input path to families&#39; data directory<asp:TextBox ID="TextBox1" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Families' data is essential" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            Input path to costs&#39; data directory<asp:TextBox ID="TextBox2" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Costs' data is essential" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            Input the tax info<asp:TextBox ID="TextBox3" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="The required tax info is essential" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Read primary data" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Make calculations" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
