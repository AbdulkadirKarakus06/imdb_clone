<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopularMovies.aspx.cs" Inherits="WebApp_UserControls1.PopularMovies" Async="true" %>

<%@ Register Src="~/OrtakUc.ascx" TagPrefix="uc1" TagName="OrtakUc" %>
<%@ Register Src="~/NavBarUc.ascx" TagPrefix="uc1" TagName="NavBarUc" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Popular Movies</title>
    <style>
        /* Genel Sayfa Stili */
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            color: #fff;
        }

        h1 {
            text-align: center;
            color: #fff;
            padding: 30px 0;
            background-color: #1C1C1C;
            margin: 0;
        }

        /* Film Grid Düzeni */
        .movies-container {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
            gap: 20px;
            padding: 20px;
            max-width: 1200px;
            margin: 0 auto;
        }

        /* Film Kartları */
        .movie-card {
            background-color: #2C2C2C;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            transition: transform 0.3s ease;
        }

        .movie-card:hover {
            transform: translateY(-10px);
        }

        .movie-card img {
            width: 100%;
            height: auto;
            border-bottom: 5px solid #1C1C1C;
        }

        .movie-card-content {
            padding: 15px;
        }

        .movie-card-content h2 {
            font-size: 18px;
            font-weight: bold;
            color: #fff;
            margin: 0;
            margin-bottom: 10px;
        }

        .movie-card-content p {
            color: #ccc;
            font-size: 14px;
            margin-bottom: 10px;
        }

        .release-date {
            font-size: 12px;
            color: #999;
        }

        /* Başlık ve Posterler Arası Mesafe */
        .movie-card-content .overview {
            display: -webkit-box;
            -webkit-line-clamp: 3;
            -webkit-box-orient: vertical;
            overflow: hidden;
            text-overflow: ellipsis;
            color: #ccc;
            font-size: 14px;
            height: 60px;
        }

    </style>
    <link rel="stylesheet" href="Styles.css">
</head>
<body>
    <uc1:NavBarUc runat="server" ID="NavBarUc" />
    <div class="movies-container" id="moviesList" runat="server"></div>
</body>
</html>

