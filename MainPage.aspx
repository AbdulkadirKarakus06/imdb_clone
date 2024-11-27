<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApp_UserControls1.MainPage" Async="true" %>

<%@ Register Src="~/NavBarUc.ascx" TagPrefix="uc1" TagName="NavBarUc" %>
<%@ Register Src="~/OrtakUc.ascx" TagPrefix="uc1" TagName="OrtakUc" %>



<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>IMDb Clone - Home</title>
    <link rel="stylesheet" href="Styles.css">
</head>
<body>
    <uc1:NavBarUc runat="server" ID="NavBarUc" />
    <!-- Main Content -->
    <div class="main-content">
        <h1>IMDb klonuna hoşgeldiniz.</h1>
        <p>Elimizdeki imkanları tam manasıyla kullansak çözemeyeceğimiz bir şey yoktu da ben kullanarak anca kadar yapabildim. Kalanı sizin hayal gücünüze bağlı.</p>
    </div>
    <%--<div id="resultsDiv" runat="server" class="search-results"></div>--%>
</body>
</html>
