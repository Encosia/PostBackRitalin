<%@ Page Language="C#" MasterPageFile="~/Test.master" AutoEventWireup="true" CodeFile="Test2.aspx.cs"
    Inherits="Test2" Title="Untitled Page" %>

<%@ Reference VirtualPath="~/Test.master" %>
<%@ Register Assembly="PostbackRitalin" Namespace="Encosia" TagPrefix="cc1" %>
<asp:Content ID="Header1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnl_Main" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="lbl_Text" runat="server">
            </asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_Delete" EventName="Command" />
            <asp:AsyncPostBackTrigger ControlID="btn_Save" EventName="Command" />
            <asp:AsyncPostBackTrigger ControlID="btn_Post" EventName="Command" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnl_buttons" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center" runat="server" id="Account_Update_Buttons">
                <tr>
                    <td align="right">
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete Account" OnClick="btn_Delete_Click"
                            Width="150px" />
                    </td>
                    <td width="10">
                    </td>
                    <td align="center">
                        <asp:Button ID="btn_Save" runat="server" Text="Save Account" OnClick="btn_Save_Click"
                            Width="150px" />
                    </td>
                    <td width="10">
                    </td>
                    <td align="right">
                        <asp:Button ID="btn_Post" runat="server" Text="Post Account" OnClick="btn_Post_Click"
                            Width="150px" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc1:PostBackRitalin ID="PostBackRitalin1" runat="server">
        <MonitoredUpdatePanels>
            <cc1:MonitoredUpdatePanel UpdatePanelID="upnl_buttons" WaitText="Loading..." DisableAllElements="true" />
        </MonitoredUpdatePanels>
    </cc1:PostBackRitalin>
</asp:Content>
