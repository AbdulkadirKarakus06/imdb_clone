using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_UserControls1
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            //string query = Request.QueryString["query"];
            //if (!string.IsNullOrEmpty(query))
            //{
            //    // Kullanıcı arama yapmışsa arama sonuçlarını göster
            //    await SearchMoviesAsync(query);
            //}
            //else
            //{
            //    // Kullanıcı arama yapmamışsa popüler filmleri göster
            //    await LoadPopularMoviesAsync();
            //}
        }
        //private async System.Threading.Tasks.Task LoadPopularMoviesAsync()
        //{
        //    var apiKey = ConfigurationManager.AppSettings["TmdbApiKey"];
        //    string url = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=en-US&page=1";

        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            string response = await client.GetStringAsync(url);
        //            JObject data = JObject.Parse(response);
        //            var results = data["results"];

        //            string htmlContent = "<h2>Popular Movies</h2>";
        //            foreach (var result in results)
        //            {
        //                string title = result["title"]?.ToString();
        //                string overview = result["overview"]?.ToString();
        //                string posterPath = result["poster_path"]?.ToString();
        //                string posterUrl = posterPath != null
        //                    ? $"https://image.tmdb.org/t/p/w500{posterPath}"
        //                    : "https://via.placeholder.com/150";

        //                htmlContent += $"<div class='movie-item'>" +
        //                               $"<img src='{posterUrl}' alt='{title}' />" +
        //                               $"<h3>{title}</h3>" +
        //                               $"<p>{overview}</p>" +
        //                               $"</div>";
        //            }

        //            resultsDiv.InnerHtml = htmlContent; // HTML'i sonuç div'ine yazdır
        //        }
        //        catch (Exception ex)
        //        {
        //            resultsDiv.InnerHtml = $"<p>Error: {ex.Message}</p>";
        //        }
        //    }
        //}

        //private async System.Threading.Tasks.Task SearchMoviesAsync(string query)
        //{
        //    var apiKey = ConfigurationManager.AppSettings["TmdbApiKey"];
        //    string url = $"https://api.themoviedb.org/3/search/multi?api_key={apiKey}&language=tr-TR&query={Uri.EscapeDataString(query)} &include_adult=false";

        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            string response = await client.GetStringAsync(url);
        //            JObject data = JObject.Parse(response);
        //            var results = data["results"];

        //            string htmlContent = $"<h2>Search Results for '{query}'</h2>";
        //            foreach (var result in results)
        //            {
        //                string title = result["title"]?.ToString() ?? result["name"]?.ToString();
        //                string overview = result["overview"]?.ToString();
        //                string posterPath = result["poster_path"]?.ToString();
        //                string posterUrl = posterPath != null
        //                    ? $"https://image.tmdb.org/t/p/w500{posterPath}"
        //                    : "https://via.placeholder.com/150";

        //                htmlContent += $"<div class='movie-item'>" +
        //                               $"<img src='{posterUrl}' alt='{title}' />" +
        //                               $"<h3>{title}</h3>" +
        //                               $"<p>{overview}</p>" +
        //                               $"</div>";
        //            }

        //            resultsDiv.InnerHtml = htmlContent; // HTML'i sonuç div'ine yazdır
        //        }
        //        catch (Exception ex)
        //        {
        //            resultsDiv.InnerHtml = $"<p>Error: {ex.Message}</p>";
        //        }
        //    }
        //}
    }
}