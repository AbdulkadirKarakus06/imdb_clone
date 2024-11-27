<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top250TvMovies.aspx.cs" Inherits="WebApp_UserControls1.Top250TvMovies" Async="true"%>

<%@ Register Src="~/NavBarUc.ascx" TagPrefix="uc1" TagName="NavBarUc" %>

<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Top 250 TV Movies</title>
        <style>
    .tvmovie-list {
        margin-top:20px;
    display: flex;
    flex-wrap: wrap;
    gap: 20px;
    justify-content: center;
}

.tvmovie-item {
    width: 250px;
    text-align: center;
    border: 1px solid #ccc;
    border-radius: 10px;
    padding: 15px;
    background-color: #f9f9f9;
}

.tvmovie-item img {
    width: 100%;
    height: auto;
    border-radius: 5px;
}
</style>
    <link rel="stylesheet" href="Styles.css">
</head>
<body>
    <uc1:NavBarUc runat="server" ID="NavBarUc" />
     <div class="pagination" runat="server" id="paginationDiv" ></div>
    <div id="resultsDiv" class="tvmovie-list" runat="server" style="display: flex; flex-wrap: wrap; gap: 10px;"></div>
</body>
</html>
