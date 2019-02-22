<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormJQuery.aspx.cs" Inherits="UserQueries.WebFormJQuery" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>pagejquery</title>
    <script type="text/javascript" lang="javascript" src="scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" lang="javascript" src="scripts/jquery-ui-1.12.1.min.js"></script>
    <script type="text/javascript" lang="javascript" src="scripts/custom/fillListboxEtc.js"></script>

    <link href="~/Content/styles/custom2column.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="outer">
            <div id="mainId">
                <div class="row">
                    <div class="column left">
                        <asp:Label ID="Label1" runat="server" Text="Edition Date" Font-Size="Large"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Font-Size="Small" Width="80px" MaxLength="10"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Region:" Font-Size="Large"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Small"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;
                    </div>
                    <div class="column right">
                        <asp:Label ID="Label3" runat="server" Text="Tracks:" Font-Size="Large"></asp:Label><br />
                        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Height="160px" Font-Size="Small"></asp:ListBox>
                    </div>
                </div>

                <div style="clear: both" />

                <div id="idsubmit" style="text-align: center;">
                    <br />

                    <asp:Button ID="BtnProcess" runat="server" Text="Process" Font-Size="Large" OnClick="BtnProcess_Click" OnClientClick="return ValidateForm();" />
                </div>

                <asp:TextBox ID="txtBoxAllINputId" runat="server" Font-Size="small" Style="display: none;"></asp:TextBox>
                <hr />
                <asp:Label ID="lblStatusId" runat="server" Text="" Font-Size="Medium" ForeColor="Red"></asp:Label>

            </div>
        </div>

    </form>
</body>
</html>
