using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp_UserControls1
{
    public partial class Top250TvMovies : System.Web.UI.Page
    {
        private const string ApiKey = "0b5aed42022ae040f17aee0a3509779b";
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTop250TvMovies();
            }
        }
    

        private async void LoadTop250TvMovies()
        {
            try
            {
                string url = $"https://api.themoviedb.org/3/tv/top_rated?api_key={ApiKey}&language=tr-TR&page=1";
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