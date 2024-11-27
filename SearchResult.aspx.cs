using System;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebApp_UserControls1
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            string query = Request.QueryString["query"];
            if (!string.IsNullOrEmpty(query))
            {
                await SearchMoviesAsync(query);
            }
            else
            {
                resultsDiv.InnerHtml = "<p>Please enter a search term.</p>";
            }
        }

            private async System.Threading.Tasks.Task SearchMoviesAsync(string query)
            {
            var apiKey = ConfigurationManager.AppSettings["TmdbApiKey"];
            string url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&language=tr-TR&query={Uri.EscapeDataString(query)}&include_adult=false";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string response = await client.GetStringAsync(url);
                        JObject data = JObject.Parse(response);
                        var results = data["results"];

                        string htmlContent = "";
                        foreach (var result in results)
                        {
                        string movieId = result["id"]?.ToString(); // Film ID'sini al
                        string title = result["title"]?.ToString() ?? result["name"]?.ToString();
                            string overview = result["overview"]?.ToString();
                            string posterPath = result["poster_path"]?.ToString();
                            string posterUrl = posterPath != null
                                ? $"https://image.tmdb.org/t/p/w500{posterPath}"
                                : "https://via.placeholder.com/150";

                            htmlContent += $"<div class='movie-item'>" +
                             $"<a href='Detail.aspx?movieId={movieId}' style='text-decoration:none; color: inherit;'>" + // Link ekle
                                           $"<img src='{posterUrl}' alt='{title}' />" +
                                           $"<h3>{title}</h3>" +
                                           $"<p>{overview}</p>" +
                                           $"</div>";
                        }

                        resultsDiv.InnerHtml = htmlContent;
                    }
                    catch (Exception ex)
                    {
                        resultsDiv.InnerHtml = $"<p>Error: {ex.Message}</p>";
                    }
                }
            }
    }

}