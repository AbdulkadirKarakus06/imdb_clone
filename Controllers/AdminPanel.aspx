<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="WebApp_UserControls1.AdminPanel" %>

<%@ Register Src="~/OrtakUc.ascx" TagPrefix="uc1" TagName="OrtakUc" %>
<%@ Register Src="~/NavBarUc.ascx" TagPrefix="uc1" TagName="NavBarUc" %>
<%@ Register Src="~/SideBarAdmin.ascx" TagPrefix="uc1" TagName="SideBarAdmin" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:OrtakUc runat="server" ID="OrtakUc" />
    <link href="SideBar.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <uc1:NavBarUc runat="server" ID="NavBarUc" />
    <form id="form1" runat="server">
     <uc1:SideBarAdmin runat="server" ID="SideBarAdmin" />   
      
       <div align="center">
ADMIN PANEL
          
</div>
        
    </form>
</body>
</html>
