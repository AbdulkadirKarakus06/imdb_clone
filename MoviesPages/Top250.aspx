<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top250.aspx.cs" Inherits="WebApp_UserControls1.Top250" Async="true" %>

<%@ Register Src="~/NavBarUc.ascx" TagPrefix="uc1" TagName="NavBarUc" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Top 250 Movies</title>
    <style>
    .movie-list {
    display: flex;
    flex-wrap: wrap;
    gap: 20px;
    justify-content: center;
}

.movie-item {
    width: 250px;
    text-align: center;
    border: 1px solid #ccc;
    border-radius: 10px;
    padding: 15px;
    background-color: #f9f9f9;
}

.movie-item img {
    width: 100%;
    height: auto;
    border-radius: 5px;
}

.pagination {
    text-align: center;
    margin-top: 20px;
}

.pagination a, .pagination span {
    display: inline-block;
    margin: 0 5px;
    padding: 10px 15px;
    border: 1px solid #ccc;
    border-radius: 5px;
    text-decoration: none;
    color: #333;
}

.pagination span {
    background-color: #007bff;
    color: white;
    font-weight: bold;
}

</style>
    <link rel="stylesheet" href="Styles.css">
</head>
<body>
    <uc1:NavBarUc runat="server" ID="NavBarUc" />
    <div class="pagination" runat="server" id="paginationDiv" ></div>
    <div class="movie-list" runat="server" id="movieListDiv"></div>
    
</body>
</html>
