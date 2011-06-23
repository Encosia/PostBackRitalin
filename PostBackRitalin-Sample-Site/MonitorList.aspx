<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonitorList.aspx.cs" Inherits="MonitorList" %>
<%@ Register Assembly="PostBackRitalin" Namespace="Encosia" TagPrefix="encosia" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PostBack Ritalin - Monitored Panel Test</title>
    <style type="text/css">
      a.disabled { color: Gray; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager runat="server" ID="ScriptManager1" />
      
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
            
            <br />
            
            <asp:LinkButton runat="server" ID="LinkButton1" Text="Click me" OnClick="LinkButton1_Click" />
          </ContentTemplate>
        </asp:UpdatePanel>
      </fieldset>
      
      <fieldset>
        <legend>UpdatePanel3</legend>
        <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
          <ContentTemplate>
            <asp:ImageButton runat="server" ID="Button3" ImageUrl="~/search-btn.gif" OnClick="Button3_Click" />
            <asp:Literal runat="server" ID="Literal3" />
          </ContentTemplate>
        </asp:UpdatePanel>
      </fieldset>
      
      <encosia:PostBackRitalin ID="PostBackRitalin1" runat="server" PreloadWaitImages="true" WaitClass="disabled">
        <MonitoredUpdatePanels>
          <encosia:MonitoredUpdatePanel UpdatePanelID="UpdatePanel2" DisableAllElements="true" />
          <encosia:MonitoredUpdatePanel UpdatePanelID="UpdatePanel3" WaitImage="search-btn-disabled.gif" />
        </MonitoredUpdatePanels>
      </encosia:PostBackRitalin>
    </form>
</body>
</html>