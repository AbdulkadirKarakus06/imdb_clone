<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="WebApp_UserControls1.SearchResult" Async="true" %>

<%@ Register Src="~/NavBarUc.ascx" TagPrefix="uc1" TagName="NavBarUc" %>

<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Search Results</title>
    <link rel="stylesheet" href="Styles.css">
    <style>
        #resultsDiv .movie-item {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 300px;
    border: 2px solid #ddd;
    border-radius: 10px;
    padding: 15px;
    background-color: #f9f9f9;
    box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
}

#resultsDiv .movie-item img {
    width: 100%;
    height: auto;
    border-radius: 5px;
    margin-bottom: 10px;
}

#resultsDiv .movie-item h3 {
    font-size: 18px;
    margin: 10px 0;
    color: #333;
    text-align: center;
}

#resultsDiv .movie-item p {
    font-size: 14px;
    color: #555;
    margin: 0;
    text-align: justify;
    line-height: 1.5;
    word-wrap: break-word;
}

#resultsDiv {
    display: grid;
    grid-template-columns: repeat(5, 1fr);
    gap: 20px;
    justify-content: center;
    margin-top: 20px;
}

</style>
    

</head>
<body>

    <uc1:NavBarUc runat="server" ID="NavBarUc" />
    <div class="main-content" runat="server" id="resultsDiv" ></div>
</body>
</html>
