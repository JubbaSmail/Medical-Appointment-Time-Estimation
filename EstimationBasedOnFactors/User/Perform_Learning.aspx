<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Perform_Learning.aspx.cs"
    Inherits="EstimationBasedOnFactors.User.Perform_Learning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Machine Learning Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="Title">
        Machine Learning</div>
    <div align="center">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Auto Rule Generation (ID3 Algorithm)"
            Width="290px" />
            
    <br />
    <br />
        <img alt="machine_learning" src="../images/Machine-Learning.jpg" style="width: 296px;
            height: 207px" /></div>
</asp:Content>
