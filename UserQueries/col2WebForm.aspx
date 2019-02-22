<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="col2WebForm.aspx.cs" Inherits="UserQueries.col2WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>2column</title>

    <link href="~/Content/styles/custom2column.css" rel="stylesheet" type="text/css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="mainId" >
                <div class="row">
                    <div class="column left">
                        <h2>Column 1</h2>
                        <p>text left</p>
                        <asp:Label ID="Label1" runat="server" Text="Edition Date" Font-Size="Large"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Font-Size="Small" Width="80px" MaxLength="10"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Region:" Font-Size="Large"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Small"></asp:DropDownList>

                    </div>
                    <div class="column right">
                        <h2>Column 2   4</h2>
                        <p>text right</p>
                        <asp:Label ID="Label3" runat="server" Text="Tracks:" Font-Size="Large"></asp:Label><br />
                        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Height="160px" Font-Size="Small"></asp:ListBox>
                    </div>


                </div>
                <div style="clear:both;"/>
                <div id="idsubmit" style="text-align: center;"><br />

                    <asp:Button ID="BtnProcess" runat="server" Text="Process" Font-Size="Large"  />
                </div>
            </div>

        </div>

    </form>
</body>
</html>
