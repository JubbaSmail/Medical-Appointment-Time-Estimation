<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs"
    Inherits="EstimationBasedOnFactors.Setup.Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Configuration Page</title>
    <style type="text/css">
        .style1
        {
            width: 175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
        <h1>
            <img alt="config" src="../images/Configuration%20Settings.png" style="width: 256px;
                height: 256px" /></h1>
        <h1>
            Configuration:</h1>
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                    Working Directory:
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" />
    </div>
</asp:Content>
