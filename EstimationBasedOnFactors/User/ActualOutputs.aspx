<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualOutputs.aspx.cs" Inherits="EstimationBasedOnFactors.User.ActualOutputs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<div class="Title">
Actual Outputs
</div>
    <table>
        <tr>
            <td style="border: thin solid #000000;" class="style1">
                Patient:
            </td>
            <td style="border: thin solid #000000;">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="283px" Height="16px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="border: thin solid #000000; direction: ltr;" class="style2">
                Actual Time Required:
            </td>
            <td style="border: thin solid #000000; text-align: left">
                <asp:TextBox ID="TextBoxActualTime" runat="server" Width="284px" ValidationGroup="1"></asp:TextBox>
            </td>
            <td>
                Minutes
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxActualTime"
                    ErrorMessage="You should enter the time" SetFocusOnError="True" Display="Dynamic"
                    ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td style="text-align: right; margin-left: 40px;">
                <asp:Button ID="Button_Learn" runat="server" OnClick="Button1_Click" Text="Save"
                    ValidationGroup="1" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td style="text-align: left">
                <asp:Label ID="LabelMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
