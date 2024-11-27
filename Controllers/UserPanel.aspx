<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPanel.aspx.cs" Inherits="WebApp_UserControls1.UserPanel" %>

<%@ Register Src="~/OrtakUc.ascx" TagPrefix="uc1" TagName="OrtakUc" %>
<%@ Register Src="~/SideBarUser.ascx" TagPrefix="uc1" TagName="SideBarUser" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="SideBar.css" rel="stylesheet" />
    <uc1:OrtakUc runat="server" ID="OrtakUc" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:SideBarUser runat="server" id="SideBarUser" />
        <div align="center">
            USER PANEL
        </div>
    </form>
</body>
</html>
