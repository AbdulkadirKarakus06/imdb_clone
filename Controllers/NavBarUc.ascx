<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarUc.ascx.cs" Inherits="WebApp_UserControls1.NavBarUc" %>


 <nav class="navbar">
        <div class="nav-left">
            <a href="PopularMovies.aspx">Popular Movies</a>
            <a href="Top250.aspx">Top 250 Movies</a>
            <a href="PopularTvMovies.aspx">Popular TV Movies</a>
            <a href="Top250TvMovies.aspx">Top 250 TV Movies</a>
        </div>
        <div class="nav-center">
            <form method="get" action="SearchResult.aspx">
                <input type="text" name="query" placeholder="Search for movies, TV shows..." class="search-bar">
                <button type="submit">Search</button>
            </form>
        </div>
        <div class="nav-right">
            <a href="LogIn.aspx" style="color: white;">Giriş Yap</a>
            <a href="Register.aspx" style="color: white;">Kayıt Ol</a>
        </div>
    </nav>
