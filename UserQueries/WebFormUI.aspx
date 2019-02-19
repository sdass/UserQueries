<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormUI.aspx.cs" Inherits="UserQueries.WebFormUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Enter email:"></asp:Label> &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtBxSearchInput" runat="server" onfocus="clearPreviousOutput()"></asp:TextBox>
            <br /><br />
            <div id="divMessage" style="color: red; text-align:center" runat="server" />
        
        <br /><br /><br />
        <asp:Button ID="BtnSubmit" runat="server" Text="Search" OnClick="BtnSubmit_Click" />
        <asp:Button ID="BtnViewPdf" runat="server" Text="ViewPdf" OnClick="BtnViewPdf_Click" />
        <asp:Button ID="Button1" runat="server" Text="ViewMSWord" OnClick="BtnViewMSWord_Click" />

        </asp:Panel>

         <br /><br /><br />
        <hr />
        <asp:Panel ID="Panel2" runat="server">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        </asp:Panel>
        

    </div>
    </form>

    <script type="text/javascript">
    
        function clearPreviousOutput() {
            console.log("on textFocus()...");  
            var grid = document.getElementById("GridView1");
            if(grid != null){
                grid.style.display = "none";
            }
            document.getElementById("divMessage").innerText = "";
            
        }
        function changeUrlAddressAndHistory() {
            if (window.history.pushState) {
                window.history.pushState("", "Pdf Preview", "~/WebFormPdfView.aspx?PDF=HAW0920_0710P.pdf" );
            }else{
                document.location.href = "~/WebFormPdfView.aspx?PDF=HAW0920_0710P.pdf";
            }
        }
    </script>
</body>
</html>
