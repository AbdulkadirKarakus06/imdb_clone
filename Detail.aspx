<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="WebApp_UserControls1.Detail" Async="true" %>
<%@ Register Src="~/NavBarUc.ascx" TagPrefix="uc1" TagName="NavBarUc" %>

<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <title>Movie Detail</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: black;
            color: #fff;
            padding: 20px;
        }

        h1 {
            text-align: center;
            color: #fff;
            padding: 20px;
            background-color: #1C1C1C;
        }

        .movie-detail {
            display: flex;
            justify-content: center;
            margin-top: 20px;
        }

        .movie-detail img {
            width: 300px;
            height: auto;
            margin-right: 30px;
            border-radius: 10px;
        }

        .movie-info {
            max-width: 700px;
            text-align: left;
        }

        .movie-info h2 {
            font-size: 24px;
            color: #fff;
        }

        .movie-info p {
            font-size: 16px;
            color: #ccc;
        }

        .release-date {
            font-size: 14px;
            color: #999;
        }
        /* Photo Gallery Styling */
.photo-gallery {
    display: grid;
    grid-template-columns: repeat(4, 1fr); /* 4 fotoğraf yan yana */
    gap: 10px; /* Fotoğraflar arasındaki boşluk */
    margin-top: 30px;
}

.movie-photo {
    width: 100%;
    height: auto;
    border: 2px solid #ddd;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    transition: transform 0.3s ease-in-out;
}

.movie-photo:hover {
    transform: scale(1.05);
}
/* Yorum Alanı Stilleri */
#commentsSection {
    margin-top: 30px;
}

#commentList {
    margin-top: 20px;
}

#commentList div {
    margin-bottom: 10px;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
}

#commentList strong {
    font-size: 1.1em;
    color: #333;
}

#commentList p {
    font-size: 1em;
    color: #555;
}

#commentForm input, #commentForm textarea {
    width: 100%;
    margin-bottom: 10px;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
}

#commentForm button {
    padding: 10px 20px;
    background-color: #28a745;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
}

#commentForm button:hover {
    background-color: #218838;
}
    </style>
    <link rel="stylesheet" href="Styles.css">
</head>
<body>
    <uc1:NavBarUc runat="server" ID="NavBarUc" />
    <div class="movie-detail">
        <!-- Poster -->
        <img id="moviePoster" runat="server" src="" alt="Movie Poster" />

        <!-- Movie Info -->

        <div class="movie-info">
            <h2 id="movieTitle" runat="server"></h2>
            <p id="movieOverview" runat="server"></p>
            <p class="release-date" id="moviereleaseDate" runat="server"></p>
             
        </div>
       
    </div>
    <div class="photo-gallery" runat="server" id="photoGallery" ></div>
     <!-- Yorum Yapma Formu -->
        <h3>Leave a Comment</h3>
        <form id="commentForm" runat="server">
            <label for="txtUserName">Your Name:</label>
            <input type="text" id="txtUserName" runat="server" />
            <br />
            <label for="txtComment">Your Comment:</label>
            <textarea id="txtComment" runat="server" rows="4" cols="50"></textarea>
            <br />
            <button type="submit" runat="server" onserverclick="SubmitComment">Submit</button>
        </form>

     <div runat="server" id="commentsSection">
            <h3>Comments</h3>
            <div runat="server" id="commentList">
                <!-- Yorumlar buraya yüklenecek -->
            </div>
        </div>
</body>
</html>
