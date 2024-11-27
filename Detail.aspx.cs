using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web.UI;
using System.Threading.Tasks;
using System.Configuration;
using System.Linq;
using System.Data.SqlClient;
using System.Web;

namespace WebApp_UserControls1
{
    public partial class Detail : System.Web.UI.Page
    {
        private string connectionString = "Data Source=BILGISAYAR\\SQLSERVER;"; // Veritabanı bağlantı dizesi

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string movieId = Request.QueryString["movieId"];
                string tvId = Request.QueryString["series_id"];

                if (!string.IsNullOrEmpty(movieId))
                {
                    await GetDetailsAsync(movieId, "movie");
                }
                else if (!string.IsNullOrEmpty(tvId))
                {
                    await GetDetailsAsync(tvId, "series_id");
                }
                else
                {
                    movieTitle.InnerText = "Error: Content not found.";
                }
            }
        }

        private async Task GetDetailsAsync(string id, string type)
        {
            var apiKey = ConfigurationManager.AppSettings["TmdbApiKey"];
            var detailUrl = $"https://api.themoviedb.org/3/{type}/{id}?api_key={apiKey}&language=tr-TR";
            var imagesUrl = $"https://api.themoviedb.org/3/{type}/{id}/images?api_key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Detayları al
                    var response = await client.GetStringAsync(detailUrl);
                    var content = JObject.Parse(response);

                    // Ortak alanlar
                    var title = type == "movie" ? content["title"] : content["name"];
                    var overview = content["overview"];
                    var releaseDate = type == "movie" ? content["release_date"] : content["first_air_date"];
                    var posterPath = content["poster_path"];

                    movieTitle.InnerText = title?.ToString();
                    movieOverview.InnerText = overview?.ToString();
                    moviereleaseDate.InnerText = type == "movie"
                        ? $"Release Date: {releaseDate}"
                        : $"First Air Date: {releaseDate}";
                    moviePoster.Src = posterPath != null
                        ? $"https://image.tmdb.org/t/p/w500{posterPath}"
                        : "~/Content/no-poster.png";

                    // Fotoğrafları al
                    var imagesResponse = await client.GetStringAsync(imagesUrl);
                    var imagesData = JObject.Parse(imagesResponse);
                    var imageHtml = "";

                    foreach (var image in imagesData["backdrops"].Take(8))
                    {
                        var filePath = image["file_path"];
                        imageHtml += $"<img src='https://image.tmdb.org/t/p/w500{filePath}' class='movie-photo' />";
                    }
                    photoGallery.InnerHtml = imageHtml;

                    // Yorumları yükle
                    LoadComments(id, type);
                }
                catch (Exception ex)
                {
                    movieTitle.InnerText = $"Error: {ex.Message}";
                }
            }
        }

        private void LoadComments(string contentId, string type)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UserName, CommentText, CreatedAt FROM Comments WHERE ContentId = @ContentId AND Type = @Type ORDER BY CreatedAt DESC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContentId", contentId);
                command.Parameters.AddWithValue("@Type", type);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string userName = reader["UserName"].ToString();
                    string commentText = reader["CommentText"].ToString();
                    string createdAt = reader["CreatedAt"].ToString();

                    commentList.InnerHtml += $@"
                        <div class='comment'>
                            <strong>{userName}</strong> ({createdAt})
                            <p>{commentText}</p>
                        </div>";
                }
            }
        }

        protected void SubmitComment(object sender, EventArgs e)
        {
            string userName = txtUserName.Value.Trim();
            string commentText = txtComment.Value.Trim();
            string contentId = Request.QueryString["movieId"] ?? Request.QueryString["series_id"];
            string type = Request.QueryString["movieId"] != null ? "movie" : "series_id";

            if (!IsUserRegistered(userName))
            {
                Response.Redirect("~/Register.aspx");
                return;
            }

            commentText = HttpUtility.HtmlEncode(commentText);

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(commentText))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Comments (ContentId, Type, UserName, CommentText, CreatedAt) VALUES (@ContentId, @Type, @UserName, @CommentText, GETDATE())";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ContentId", contentId);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@CommentText", commentText);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                LoadComments(contentId, type);
            }
        }

        private bool IsUserRegistered(string userName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", userName);

                connection.Open();
                return (int)command.ExecuteScalar() > 0;
            }
        }
    }
}
