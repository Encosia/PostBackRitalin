<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageButton.aspx.cs" Inherits="ImageButton" %>
<%@ Register Assembly="PostBackRitalin" Namespace="Encosia" TagPrefix="encosia" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PostBack Ritalin - ImageButton Test</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager runat="server" />
      
      <fieldset>
        <legend>UpdatePanel1</legend>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
          <ContentTemplate>
            <asp:ImageButton runat="server" ID="ImageButton1"  OnClick="ImageButton1_Click" ImageUrl="~/search-btn.gif" />
            <asp:Literal runat="server" ID="Literal1" />
          </ContentTemplate>
        </asp:UpdatePanel>
      </fieldset>
      
      <encosia:PostBackRitalin runat="server" WaitImage="search-btn-disabled.gif" />
    </form>
</body>
</html>
