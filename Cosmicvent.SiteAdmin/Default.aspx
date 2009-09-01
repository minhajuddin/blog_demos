<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cosmicvent.SiteAdmin._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Site Admin</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <p>
      <label for="UserName">
        UserName:</label>
      <asp:TextBox ID="UserName" runat="server" />
    </p>
    <p>
      <label for="Password">
        Password:</label>
      <asp:TextBox ID="Password" runat="server" TextMode="Password" />
    </p>
    <p>
      <asp:RadioButton ID="TakeOfflineRadioButton" GroupName="SiteStatus" Text="Take Site Offline"
        runat="server" />
      <asp:RadioButton ID="BringUpOnlineRadioButton" GroupName="SiteStatus" Text="Bring Up Site Online"
        runat="server" />
    </p>
    <span id="output" runat="server"></span>
    <br />
    <asp:Button ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click" runat="server" />
  </div>
  </form>
</body>
</html>
