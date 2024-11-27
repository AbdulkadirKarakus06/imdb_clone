using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Threading.Tasks;

namespace WebApp_UserControls1
{
    public partial class PopularMovies : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            await GetMoviesAsync();  // Asenkron metod çağrısı
        }
        private async Task GetMoviesAsync()
        {
            var apiKey = ConfigurationManager.AppSettings["TmdbApiKey"];
            var url = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=tr-TR&page=1&include_adult=false";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // API'den veri al
                    var response = await client.GetStringAsync(url);
                    var movies = JObject.Parse(response)["results"];

                    // Filmleri HTML olarak ekleyelim
                    string moviesHtml = "";
                    foreach (var movie in movies)
                    {
                        // Film bilgilerini alalım
                        var title = movie["title"];
                        var overview = movie["overview"];
                        var releaseDate = movie["release_date"];
                        var posterPath = movie["poster_path"];
                        var movieId = movie["id"]; // Film ID'sini alıyoruz

                        // Poster URL'yi tamamla
                        var posterUrl = posterPath != null ? $"https://image.tmdb.org/t/p/w500{posterPath}" : "";

                        // HTML içine film kartlarını ekleyelim ve her filme tıklanabilir bir link ekleyelim
                        moviesHtml += $"<div class='movie-card'>";
                        moviesHtml += $"<a href='Detail.aspx?movieId={movieId}'>";
                        moviesHtml += $"<img src='{posterUrl}' alt='{title}' />";
                        moviesHtml += $"</a>";
                        moviesHtml += $"<div class='movie-card-content'>";
                        moviesHtml += $"<h2>{title}</h2>";
                        moviesHtml += $"<div class='overview'>{overview}</div>";
                        moviesHtml += $"<p class='release-date'>Release Date: {releaseDate}</p>";
                        moviesHtml += $"</div>";
                        moviesHtml += $"</div>";
                    }

                    // moviesList kontrolüne filmleri ekleyelim
                    moviesList.InnerHtml = moviesHtml;
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesajı ekleyelim
                    moviesList.InnerHtml = $"Error: {ex.Message}";
                }
            }
        }
    }
}