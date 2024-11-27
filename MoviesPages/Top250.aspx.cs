using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Configuration;

namespace WebApp_UserControls1
{
    public partial class Top250 : System.Web.UI.Page
    {
        private const int MoviesPerPage = 12; // Sayfa başına gösterilecek film sayısı
        private int _currentPage = 1; // Başlangıç sayfası
        private const int TotalMoviesToFetch = 252; // Çekilecek toplam film sayısı
        private const int MoviesPerApiPage = 20; // TMDb API'de bir sayfada gelen film sayısı

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["page"] != null)
            {
                // URL'den sayfa numarasını al
                _currentPage = int.Parse(Request.QueryString["page"]);
            }
            await GetTopMoviesAsync();
        }
            private async Task GetTopMoviesAsync()
            {
            var apiKey = ConfigurationManager.AppSettings["TmdbApiKey"];
            var totalPagesToFetch = (int)Math.Ceiling((double)TotalMoviesToFetch / MoviesPerApiPage);

            List<JToken> allMovies = new List<JToken>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // İlk 240 filmi çekmek için birden fazla API çağrısı yap
                    for (int i = 1; i <= totalPagesToFetch; i++)
                    {
                        var url = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=tr-TR&page={i}&include_adult=false";
                        var response = await client.GetStringAsync(url);
                        var movieList = JObject.Parse(response);
                        var results = movieList["results"];
                        allMovies.AddRange(results);
                    }

                    // Sayfa başına filmleri filtrele
                    var paginatedMovies = allMovies
                        .Skip((_currentPage - 1) * MoviesPerPage)
                        .Take(MoviesPerPage);

                    // Filmleri HTML olarak oluştur
                    string htmlContent = "";
                    foreach (var movie in paginatedMovies)
                    {
                        var movieId = movie["id"];
                        var title = movie["title"];
                        var overview = movie["overview"];
                        var posterPath = movie["poster_path"];

                        // Poster URL'yi tamamla
                        var posterUrl = posterPath != null ? $"https://image.tmdb.org/t/p/w500{posterPath}" : "https://via.placeholder.com/150";

                        // Film bilgilerini ekle
                        htmlContent += $"<div class='movie-item'>" +
                                       $"<img src='{posterUrl}' alt='{title}' />" +
                                       $"<h3>{title}</h3>" +
                                       $"<p>{overview}</p>" +
                                       $"<a href='Detail.aspx?movieId={movieId}'>View Details</a>" +
                                       $"</div>";
                    }

                    // Film listesini ekle
                    movieListDiv.InnerHtml = htmlContent;

                    // Sayfalama bağlantılarını ekle
                    AddPagination(allMovies.Count);
                }
                catch (Exception ex)
                {
                    movieListDiv.InnerHtml = $"Error loading movies: {ex.Message}";
                }
            }
        }

        private void AddPagination(int totalMovies)
        {
            // Toplam sayfa sayısını hesapla
            int totalPages = (int)Math.Ceiling((double)totalMovies / MoviesPerPage);
            string paginationLinks = "";

            // Önceki sayfa bağlantısı
            if (_currentPage > 1)
            {
                paginationLinks += $"<a href='Top250.aspx?page={_currentPage - 1}'>Previous</a>";
            }

            // Sayfa numaraları
            for (int i = 1; i <= totalPages; i++)
            {
                if (i == _currentPage)
                {
                    paginationLinks += $"<span>{i}</span>"; // Aktif sayfa
                }
                else
                {
                    paginationLinks += $"<a href='Top250.aspx?page={i}'>{i}</a>";
                }
            }

            // Sonraki sayfa bağlantısı
            if (_currentPage < totalPages)
            {
                paginationLinks += $"<a href='Top250.aspx?page={_currentPage + 1}'>Next</a>";
            }

            // Sayfalama bağlantısını ekle
            paginationDiv.InnerHtml = paginationLinks;
        }
    }
}