<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Cases.aspx.cs"
    Inherits="EstimationBasedOnFactors.User.Cases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cases Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
        <div class="Title">
            Cases:
        </div>
        <div style="text-align: right">
            <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click"
                Style="text-align: right" />
        </div>
        <div>
            <asp:GridView ID="GridViewCases" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="100%"
                OnRowDeleting="GridViewCases_RowDeleting" OnRowEditing="GridViewCases_RowEditing">
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True">
                        <HeaderStyle Width="80px" />
                    </asp:CommandField>
                    <asp:CommandField ShowEditButton="True">
                        <HeaderStyle Width="80px" />
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    ...
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
    </div>
    <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add" />
</asp:Content>
