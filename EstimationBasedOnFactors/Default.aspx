<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="Default.aspx.cs" Inherits="EstimationBasedOnFactors._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .style1
        {
            text-align: center;
            font-size: large;
            font-weight: bold;
            font-family:Tahoma;
        }
    p.ByLine
	{margin-top:12.0pt;
	margin-right:0cm;
	margin-bottom:36.0pt;
	margin-left:0cm;
	text-align:right;
	font-size:14.0pt;
	font-family:"Arial","sans-serif";
	font-weight:bold;
	}
    </style>
    <title>Hybrid (Fuzzy Logic & Machine Learning) Based Expert System for Medical Appointment Time Estimation - Home Page</title>
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="style1">
        <p align="left" class="ByLine" style="margin:0cm;margin-bottom:.0001pt;text-align:
left">
            <span style="font-size:12.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;
mso-bidi-font-family:&quot;Times New Roman&quot;;font-weight:normal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            By : Ismail Al-Jubbah - Muhammad Altabba<o:p></o:p></span></p>
                                <br />
        بسم الله الرحمن الرحيم&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
        <div>
        <br />
            <span class="Title"><span id="ctl00_ContentPlaceHolder_TitleLable">Setup</span>:
            </span><span class="TitleDescription">
            <span id="ctl00_ContentPlaceHolder_DescriptionLabel">Here you can send perform 
            setup and administration operations.</span></span>
            <br />
            <table id="ctl00_ContentPlaceHolder_ListView1_itemPlaceholderContainer" 
                style="PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; BORDER-SPACING: 0px; WIDTH: 100%; PADDING-RIGHT: 10px; PADDING-TOP: 10px">
                <tr style="PADDING-BOTTOM: 0px; BACKGROUND-COLOR: #f0e9fe; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; HEIGHT: 30px; COLOR: #000000; PADDING-TOP: 10px">
                    <td style="TEXT-ALIGN: center; WIDTH: 30px">
                        <img id="ctl00_ContentPlaceHolder_ListView1_ctrl0_Image1" 
                            src="http://localhost:36156/Images/Circle.gif" 
                            style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" />
                    </td>
                    <td style="TEXT-ALIGN: left; WIDTH: 120px">
                        <a href="http://localhost:36156/Setup/Factors.aspx">Edit Factors</a>:
                    </td>
                    <td>
                        <span id="ctl00_ContentPlaceHolder_ListView1_ctrl0_DescriptionLabel">Edit 
                        factors related to every case.</span>
                    </td>
                </tr>
                <tr style="PADDING-BOTTOM: 10px; BACKGROUND-COLOR: #fffaee; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; HEIGHT: 30px; LIST-STYLE-IMAGE: none; PADDING-TOP: 10px">
                    <td style="TEXT-ALIGN: center; WIDTH: 30px">
                        <img id="ctl00_ContentPlaceHolder_ListView1_ctrl2_Image1" 
                            src="http://localhost:36156/Images/Circle.gif" 
                            style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" />
                    </td>
                    <td style="TEXT-ALIGN: left; WIDTH: 120px">
                        <a id="ctl00_ContentPlaceHolder_ListView1_ctrl2_HyperLink1" 
                            href="http://localhost:36156/Setup/Configuration.aspx">Configuration</a>:
                    </td>
                    <td style="WIDTH: auto">
                        <span id="ctl00_ContentPlaceHolder_ListView1_ctrl2_DescriptionLabel">Change 
                        system configuration.</span>
                    </td>
                </tr>
                <tr style="PADDING-BOTTOM: 0px; BACKGROUND-COLOR: #f0e9fe; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; HEIGHT: 30px; COLOR: #000000; PADDING-TOP: 10px">
                    <td style="TEXT-ALIGN: center; WIDTH: 30px">
                        <img id="ctl00_ContentPlaceHolder_ListView1_ctrl4_Image1" 
                            src="http://localhost:36156/Images/Circle.gif" 
                            style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" />
                    </td>
                    <td style="TEXT-ALIGN: left; WIDTH: 120px">
                        <a href="http://localhost:36156/Setup/FuzzyClips_Output.aspx">Fuzzy Clisp Output</a>:
                    </td>
                    <td>
                        <span id="ctl00_ContentPlaceHolder_ListView1_ctrl4_DescriptionLabel">See 
                        pipleining output of Fuzzy Clisps for debuging.</span>
                    </td>
                </tr>
            </table>
    </div>
    <br />
    <span class="Title"><span id="ctl00_ContentPlaceHolder_TitleLable0">User</span>:
    </span><span class="TitleDescription">
    <span id="ctl00_ContentPlaceHolder_DescriptionLabel0">In this section you can 
    apply your administrative roles.</span></span>
    
        <table id="ctl00_ContentPlaceHolder_ListView1_itemPlaceholderContainer0" 
            style="PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; BORDER-SPACING: 0px; WIDTH: 100%; PADDING-RIGHT: 10px; PADDING-TOP: 10px">
            <tr style="PADDING-BOTTOM: 0px; BACKGROUND-COLOR: #f0e9fe; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; HEIGHT: 30px; COLOR: #000000; PADDING-TOP: 10px">
                <td style="TEXT-ALIGN: center; WIDTH: 30px">
                    <img id="ctl00_ContentPlaceHolder_ListView1_ctrl0_Image2" 
                        src="http://localhost:36156/Images/Circle.gif" 
                        style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" />
                </td>
                <td style="TEXT-ALIGN: left; WIDTH: 120px">
                    <a href="http://localhost:36156/User/Cases.aspx">Edit Cases</a>:
                </td>
                <td>
                    <span id="ctl00_ContentPlaceHolder_ListView1_ctrl0_DescriptionLabel0">Here you 
                    can add and edit new and existing cases&#39; instances.</span>
                </td>
            </tr>
            <tr style="PADDING-BOTTOM: 10px; BACKGROUND-COLOR: #fffaee; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; HEIGHT: 30px; LIST-STYLE-IMAGE: none; PADDING-TOP: 10px">
                <td style="TEXT-ALIGN: center; WIDTH: 30px">
                    <img id="ctl00_ContentPlaceHolder_ListView1_ctrl2_Image2" 
                        src="http://localhost:36156/Images/Circle.gif" 
                        style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" />
                </td>
                <td style="TEXT-ALIGN: left; WIDTH: 120px">
                    <a id="ctl00_ContentPlaceHolder_ListView1_ctrl2_HyperLink2" 
                        href="http://localhost:36156/User/ActualOutputs.aspx">Actual Outputs</a>:
                </td>
                <td style="WIDTH: auto">
                    <span id="ctl00_ContentPlaceHolder_ListView1_ctrl2_DescriptionLabel0">Here you 
                    can enter actual outputs.</span>
                </td>
            </tr>
            <tr style="PADDING-BOTTOM: 0px; BACKGROUND-COLOR: #f0e9fe; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; HEIGHT: 30px; COLOR: #000000; PADDING-TOP: 10px">
                <td style="TEXT-ALIGN: center; WIDTH: 30px">
                    <img id="ctl00_ContentPlaceHolder_ListView1_ctrl4_Image2" 
                        src="http://localhost:36156/Images/Circle.gif" 
                        style="BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" />
                </td>
                <td style="TEXT-ALIGN: left; WIDTH: 120px">
                    <a href="http://localhost:36156/User/Perform_Learning.aspx">Perform Learning</a>:
                </td>
                <td>
                    <span id="ctl00_ContentPlaceHolder_ListView1_ctrl4_DescriptionLabel0">You can 
                    here anter the actual amount of an instance. and chose to generate the rules</span>
                </td>
            </tr>
        </table>
</asp:Content>


