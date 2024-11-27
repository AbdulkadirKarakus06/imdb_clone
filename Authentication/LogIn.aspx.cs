using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace WebApp_UserControls1
{
    public partial class LogIn : System.Web.UI.Page
    {
        Genel gn = new Genel();
        string connectionString = ConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
       

       

using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //illegal karakter kontrolü

                if (Genel.Illegalkarakter(txtUserName.Text) || Genel.Illegalkarakter(txtPassword.Text))
                {
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;

                     Response.Write("<script type='text/javascript'>alert('Geçersiz karakter tespit edildi...!');</script>");
                    return;
                    //string script = "alert('Kullanıcı adı ve şifre yalnızca harf ve rakam içerebilir!');";
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                 
                }



                conn.Open();
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;

    // Kullanıcının girdiği e-posta ve şifreyi kontrol et
    cmd.CommandText = "SELECT KullaniciAdi, Sifre, Yetki FROM kullanicilar WHERE KullaniciAdi = @mail";

    // E-posta parametresi
    cmd.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar, 50)
    {
        Value = txtUserName.Text // Kullanıcının girdiği e-posta
    });

    try
    {
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                // Kullanıcı adı var, şifreyi kontrol et

                string storedPassword = reader["Sifre"].ToString();
                 string hashedPassword = Genel.HashPassword(txtPassword.Text, "SHA256");
                            // SHA-256 kullanarak hash'le

                if (storedPassword == hashedPassword) // Şifre eşleşmesi
                {
                    // Giriş başarılı
                    Session["KullaniciAdi"] = txtUserName.Text; // Kullanıcı adını oturumda sakla

   



                  // Yeki kontrolü
                 int yetki = Convert.ToInt32(reader["Yetki"]);

                                // *********** Herşey yolundaysa Kullanıcıyı log tablosuna kaydet
                                reader.Close();
                              
                                SqlCommand komut = new SqlCommand("INSERT INTO logTable (kullaniciAdi, islemTarihi,yaptigiIs,isYaptigiEkran,kullaniciIp) VALUES (@ka, @it, @yi,@iye,@kip)", conn);
                                komut.Parameters.Add("@ka", SqlDbType.NVarChar, 20).Value = txtUserName.Text;
                                komut.Parameters.Add("@it", SqlDbType.DateTime).Value = DateTime.Now;
                                komut.Parameters.Add("@yi", SqlDbType.VarChar, 50).Value = "login";
                                komut.Parameters.Add("@iye", SqlDbType.VarChar, 50).Value = "login Formu";
                                komut.Parameters.Add("@kip", SqlDbType.VarChar, 20).Value = gn.GetLocalIPAddress();
                                komut.ExecuteNonQuery();//logtable a kayıt yapıldı


                if (yetki == 1) // Admin yetkisi
                    {
                        // Admin Paneline yönlendir
                        Response.Redirect("AdminPanel.aspx");
                    }
                    else
{
    // Kullanıcı Paneline yönlendir
    Response.Redirect("UserPanel.aspx");
}
                }
                else
{
    // Giriş başarısız - yanlış şifre
    Response.Write("<script>alert('Geçersiz şifre');</script>");
}
            }
            else
{
    // Giriş başarısız - kullanıcı bulunamadı
    Response.Write("<script>alert('Geçersiz e-posta veya şifre');</script>");
}
        }
    }
    catch (SqlException ex)
    {
        // Hata mesajını göster
        Response.Write("<script>alert('Hata: " + ex.Message + "');</script>");
    }
}

        }
    }
}