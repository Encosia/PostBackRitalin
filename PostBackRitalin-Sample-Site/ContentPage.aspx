<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContentPage.aspx.cs" Inherits="Default2" Title="Untitled Page" %>
<%@ Register Assembly="PostBackRitalin" Namespace="Encosia" TagPrefix="encosia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <fieldset>
        <legend>UpdatePanel1</legend>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
          <ContentTemplate>
            <asp:Button runat="server" ID="Button1" Text="Press Me" OnClick="Button1_Click" />
            <asp:Literal runat="server" ID="Literal1" />
          </ContentTemplate>
        </asp:UpdatePanel>
      </fieldset>
      
      <fieldset>
        <legend>UpdatePanel2</legend>
        <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
          <ContentTemplate>
            <asp:Button runat="server" ID="Button2" Text="Press Me" OnClick="Button2_Click" />
            <asp:Literal runat="server" ID="Literal2" />
          </ContentTemplate>
        </asp:UpdatePanel>
      </fieldset>
      
      <fieldset>
        <legend>UpdatePanel3</legend>
        <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
          <ContentTemplate>
            <asp:Button runat="server" ID="Button4" Text="I'm useless" OnClick="Button4_Click" />
            <asp:ImageButton runat="server" ID="Button3" ImageUrl="~/Images/search-btn.gif" OnClick="Button3_Click" />
            <asp:Literal runat="server" ID="Literal3" />
          </ContentTemplate>
        </asp:UpdatePanel>
      </fieldset>
      
      <encosia:PostBackRitalin ID="PostBackRitalin1" runat="server">
        <MonitoredUpdatePanels>
          <encosia:MonitoredUpdatePanel UpdatePanelID="UpdatePanel2" />
          <encosia:MonitoredUpdatePanel UpdatePanelID="UpdatePanel3" WaitImage="~/Images/search-btn-disabled.gif" DisableAllElements="true" />
        </MonitoredUpdatePanels>
      </encosia:PostBackRitalin>
</asp:Content>