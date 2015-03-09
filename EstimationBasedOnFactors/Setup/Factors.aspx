<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factors.aspx.cs"
    Inherits="EstimationBasedOnFactors.Setup.Factors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Define Factors</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="Title">
        Define Factors:
        <div align="right">
            <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" />
        </div>
    </div>
    <asp:GridView ID="GridViewFactors" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="Name"
        Width="100%" OnRowEditing="GridViewFactors_RowEditing" OnRowDeleting="GridViewFactors_RowDeleting">
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" Width="100%" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            ...
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <div style="text-align: right">
        <asp:Button ID="ButtonAddNew" runat="server" Text="Add New" OnClick="ButtonAddNew_Click" />
    </div>
</asp:Content>
