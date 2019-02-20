<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormJQuery.aspx.cs" Inherits="UserQueries.WebFormJQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>pagejquery</title>
    <script type="text/javascript" lang="javascript" src="scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" lang="javascript" src="scripts/jquery-ui-1.12.1.min.js"></script>
    <script type="text/javascript" lang="javascript" src="scripts/custom/fillListboxEtc.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div title="testing">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" ></asp:DropDownList>
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Height="60px"></asp:ListBox>

        <hr />
      <%--  path <% Response.Write("aaa=" + HttpContext.Current.Request.Url.AbsolutePath); %>--%>
    </div>
        
    </form>
</body>
</html>
