using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp_UserControls1
{
    public partial class PopularTvMovies : System.Web.UI.Page
    {
        private const string ApiKey = "0b5aed42022ae040f17aee0a3509779b";
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPopularTvMovies();
            }
        }
    

        private async void LoadPopularTvMovies()
        {
            try
            {
                string url = $"https://api.themoviedb.org/3/tv/popular?api_key={ApiKey}&language=tr-TR&page=1";
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);
                    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                    DisplayMovies(data.results);
                }
            }
            catch (Exception ex)
            {
                resultsDiv.InnerHtml = $"<p>Error loading movies: {ex.Message}</p>";
            }
        }

        private void DisplayMovies(dynamic movies)
        {
            foreach (var movie in movies)
            {
                string title = movie.name;
                string posterPath = $"https://image.tmdb.org/t/p/w500{movie.poster_path}";
                string id = movie.id;
                var overview = movie["overview"];
                var releaseDate = movie["release_date"];
                var series_id = movie["id"]; // Film ID'sini alıyoruz

                var posterUrl = posterPath != null ? $"https://image.tmdb.org/t/p/w500{posterPath}" : "";

                string moviesHtml = "";
                moviesHtml += $"<div class='movie-card'>";
                moviesHtml += $"<a href='Detail.aspx?series_id={series_id}'>";
                moviesHtml += $"<img src='{posterUrl}' alt='{title}' />";
                moviesHtml += $"</a>";
                moviesHtml += $"<div class='movie-card-content'>";
                moviesHtml += $"<h2>{title}</h2>";
                moviesHtml += $"<div class='overview'>{overview}</div>";
                moviesHtml += $"<p class='release-date'>Release Date: {releaseDate}</p>";
                moviesHtml += $"</div>";
                moviesHtml += $"</div>";

                resultsDiv.InnerHtml += $@"
                <div style='width: 200px; text-align: center;'>
                    <a href='detail.aspx?id={id}'>
                        <img src='{posterPath}' alt='{title}' style='width: 100%; height: auto; border-radius: 8px;' />
                        <h3>{title}</h3>
                    </a>
                </div>";
            }
        }
    }

}