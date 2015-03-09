<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFactor.aspx.cs" Inherits="EstimationBasedOnFactors.EditFactor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Edit Factor Page</title>
    <style type="text/css">
        body
        {
            font-family: "Calibri";
            font-size: 11pt;
        }
        .Title
        {
            font-size: large;
            font-weight: bold;
        }
        .Subtitle
        {
            font-size: larger;
        }
        .CreateTemplateTable
        {
            width: 640px;
        }
        .MembershipFunctionsTable
        {
            width: 640px;
            text-align: center;
        }
        .MembershipFunctionsTableCell
        {
            border-bottom: none;
            border-top: none;
            border: solid 1px black;
            width: 50%;
        }
        .MembershipFunctionsTableTitle
        {
            border: solid 1px black;
            background-color: #CCCCCC;
            color: Red;
            font-weight: bold;
        }
        .MembershipFunctionsParametersTable
        {
            width: 100%;
            text-align: left;
        }
        .style1
        {
            direction: ltr;
        }
    </style></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="Title">
        Edit Factor:</div>
    <table class="CreateTemplateTable">
        <tr>
            <td>
                Name:
            </td>
            <td>
                <asp:TextBox ID="TextBoxName" runat="server" Width="215px"></asp:TextBox>
            </td>
            <td rowspan="3">
                <asp:Button ID="ButtonOk" runat="server" Text="Ok" 
                    OnClick="ButtonOk_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Range:
            </td>
            <td>
                from:
                <asp:TextBox ID="TextBoxRangeFrom" runat="server" Width="75px"></asp:TextBox>
                &nbsp;to
                <asp:TextBox ID="TextBoxRangeTo" runat="server" Width="75px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Unit
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="TextBoxUnit" runat="server" Width="110px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="MembershipFunctionsTable">
                <tr>
                    <td class="MembershipFunctionsTableTitle">
                        Membership Functions:
                    </td>
                </tr>
                <tr>
                    <td class="MembershipFunctionsTableCell" align="center">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Style="margin-right: 0px;
                            text-align: left;" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None"
                            BorderWidth="1px" CellPadding="3" DataKeyNames="Name" 
                            OnRowDeleting="GridView1_RowDeleting" CellSpacing="2" Width="100%">
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" Width="100%" />
                            <Columns>
                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                <asp:BoundField HeaderText="Value" DataField="Value">
                                    <ItemStyle Width="400px" />
                                </asp:BoundField>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                ...
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <div class="Subtitle">
                Add Membership Function(s):</div>
            <table class="MembershipFunctionsTable">
                <tr>
                    <td class="MembershipFunctionsTableTitle">
                        Triangular function
                    </td>
                    <td class="MembershipFunctionsTableTitle">
                        Trapezoidal function
                    </td>
                </tr>
                <tr>
                    <td class="MembershipFunctionsTableCell">
                        <asp:Image ID="ImageTriangular" runat="server" AlternateText="Triangular" ImageUrl="~/images/Triangular.png"
                            Width="300px" />
                    </td>
                    <td class="MembershipFunctionsTableCell">
                        <asp:Image ID="ImageTrapezoidal" runat="server" AlternateText="Triangular" ImageUrl="~/images/Trapezoidal.png"
                            Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td class="MembershipFunctionsTableCell">
                        <table class="MembershipFunctionsParametersTable">
                            <tr>
                                <td>
                                    Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
                                </td>
                                <td rowspan="4">
                                    <asp:Button ID="ButtonAddTri" runat="server" Text="Add" OnClick="ButtonAddTri_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Start:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Middle:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    End:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="MembershipFunctionsTableCell">
                        <table class="MembershipFunctionsParametersTable">
                            <tr>
                                <td>
                                    Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
                                </td>
                                <td rowspan="5">
                                    <asp:Button ID="ButtonAddTrap" runat="server" Text="Add" OnClick="ButtonAddTrap_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Start:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Upper Left:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Upper Right:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    End:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <table class="MembershipFunctionsTable">
                <tr class="MembershipFunctionsTableCell" style="border: thin solid #000000">
                    <td class="MembershipFunctionsTableTitle">
                        S function
                    </td>
                    <td class="MembershipFunctionsTableTitle">
                        Z function
                    </td>
                </tr>
                <tr>
                    <td class="MembershipFunctionsTableCell">
                        <asp:Image ID="ImageS" runat="server" AlternateText="Triangular" ImageUrl="~/images/S.png"
                            Width="300px" />
                    </td>
                    <td class="MembershipFunctionsTableCell">
                        <asp:Image ID="ImageZ" runat="server" AlternateText="Triangular" ImageUrl="~/images/Z.png"
                            Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td class="MembershipFunctionsTableCell">
                        <table class="MembershipFunctionsParametersTable">
                            <tr>
                                <td>
                                    Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
                                </td>
                                <td rowspan="3">
                                    <asp:Button ID="ButtonAddS" runat="server" OnClick="ButtonAddS_Click" Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Start:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    End:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="MembershipFunctionsTableCell">
                        <table class="MembershipFunctionsParametersTable">
                            <tr>
                                <td>
                                    Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox29" runat="server"></asp:TextBox>
                                </td>
                                <td rowspan="3">
                                    <asp:Button ID="ButtonAddZ" runat="server" OnClick="ButtonAddZ_Click" Style="height: 26px"
                                        Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Start:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    End:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <table class="MembershipFunctionsTable">
                <tr class="MembershipFunctionsTableRow" style="border: thin solid #000000">
                    <td class="MembershipFunctionsTableTitle">
                        π function
                    </td>
                    <td class="MembershipFunctionsTableTitle">
                        Linguistic Expression
                    </td>
                </tr>
                <tr>
                    <td class="MembershipFunctionsTableCell">
                        <asp:Image ID="ImagePi" runat="server" AlternateText="Triangular" ImageUrl="~/images/Pi.png"
                            Width="300px" />
                    </td>
                    <td class="MembershipFunctionsTableCell">
                        <asp:Image ID="Image3" runat="server" AlternateText="Triangular" ImageUrl="~/images/Expression.png"
                            Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td class="MembershipFunctionsTableCell">
                        <table class="MembershipFunctionsParametersTable">
                            <tr>
                                <td>
                                    Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                                </td>
                                <td rowspan="4">
                                    <asp:Button ID="ButtonAddPi" runat="server" OnClick="ButtonAddPi_Click" Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Distance from Middle:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox13" runat="server" Height="22px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Midle Point:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="MembershipFunctionsTableCell">
                        <table class="MembershipFunctionsParametersTable">
                            <tr>
                                <td>
                                    Name:
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                                </td>
                                <td rowspan="2">
                                    <asp:Button ID="ButtonAddLinguisticExpression" runat="server" OnClick="ButtonAddLinguisticExpression_Click"
                                        Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Expression:
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="TextBox25" runat="server" Height="100%" TextMode="MultiLine" Width="97%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
