<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="PostBackRitalin" Namespace="Encosia" TagPrefix="encosia" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PostBack Ritalin - Default Test</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager runat="server" ID="ScriptManager1" />
      <fieldset>
        <legend>UpdatePanel1</legend>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
          <ContentTemplate>
            <asp:Button runat="server" ID="Button1" Text="Press Me" OnClick="Button1_Click" />
            <asp:Literal runat="server" ID="Literal1" />
          </ContentTemplate>
        </asp:UpdatePanel>
      </fieldset>
      
      <fieldset>
        <legend>UpdatePanel2</legend>
        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
          <ContentTemplate>
            <asp:Button runat="server" ID="Button2" Text="Press Me" OnClick="Button2_Click" />
            <asp:Literal runat="server" ID="Literal2" />
          </ContentTemplate>
        </asp:UpdatePanel>
      </fieldset>
      
      <encosia:PostBackRitalin ID="PostBackRitalin1" runat="server" />
    </form>
</body>
</html>