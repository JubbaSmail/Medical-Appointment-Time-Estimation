<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditCase.aspx.cs"
    Inherits="EstimationBasedOnFactors.User.EditCase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit Case Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
    <div class="Title">
    Edit Case:
    </div>
        <table style="width: 100%;">
            <tr>
                <td>
                    ID
                </td>
                <td>
                    <asp:Label ID="LabelID" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="2">
                    <asp:Button ID="ButtonOk" runat="server" Text="Ok" OnClick="ButtonOk_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Attributes
                </td>
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewCaseAttirbutes" runat="server" AutoGenerateColumns="False"
                                BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                CellPadding="3" CellSpacing="2" OnRowEditing="GridViewCaseAttirbutes_RowEditing"
                                OnRowCancelingEdit="GridViewCaseAttirbutes_RowCancelingEdit" OnRowUpdating="GridViewCaseAttirbutes_RowUpdating">
                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                <Columns>
                                    <asp:BoundField HeaderText="Name" ReadOnly="True" DataField="Key" />
                                    <asp:TemplateField HeaderText="Value">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxAttributesValue" runat="server" Text='<%# Bind("Value") %>' Width="200"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Value") %>' Width="210"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" HeaderStyle-Width="100"/>
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    ...
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
