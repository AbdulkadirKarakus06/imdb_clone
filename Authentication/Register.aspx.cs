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
    public partial class Register : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnaSayfa.aspx");

        }

        protected void BtnKayit_Click(object sender, EventArgs e)
        {

            Genel gn = new Genel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //1 - Kullanıcının veri tabanında olup olmadığı kontrol ediliyor
                SqlCommand cmdKontrol = new SqlCommand("select KullaniciAdi from Kullanicilar where KullaniciAdi=@kul", conn);
                cmdKontrol.Parameters.Add("@kul", SqlDbType.NVarChar, 50).Value = txtEmail.Text;
                SqlDataReader dr;
                dr = cmdKontrol.ExecuteReader();
                if (dr.HasRows) //Kullanıcı var

                {
                    Response.Write("<script type='text/javascript'>alert('Bu Kullanıcı var...!');</script>");
                    txtEmail.Text = "";
                    TxtSifre.Text = "";
                    txtEmail.Focus();
                    dr.Close();
                    conn.Close();
                    return;
                }
                else {
                dr.Close ();
                }


                //2- Kullanıcı veri tabanında yoksa kayıt işlemi gerçekleşiyor

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                // Kullanıcının veri tabanında olup olmadığı kontrol ediliyor

                // Kullanıcıyı tabloya ekle
                cmd.CommandText = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre) VALUES (@mail, @password)";

                // E-posta parametresi
                cmd.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar, 50)
                {
                    Value = txtEmail.Text // Kullanıcının girdiği e-posta
                });

                // Şifreyi hash'le
                string hashedPassword = Genel.HashPassword(TxtSifre.Text, "SHA256"); // SHA-256 kullanarak hash'le

                // Hashlenmiş şifre parametresi
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 255)
                {
                    Value = hashedPassword // Hashlenmiş şifre
                });

                try
                {
                    // Kullanıcıyı tabloya ekle
                    cmd.ExecuteNonQuery();

                    // 3- logTable a kayıt

                    SqlCommand komut = new SqlCommand("INSERT INTO logTable (kullaniciAdi, islemTarihi,yaptigiIs,isYaptigiEkran,kullaniciIp) VALUES (@ka, @it, @yi,@iye,@kip)", conn);
                    komut.Parameters.Add("@ka", SqlDbType.NVarChar, 20).Value = txtEmail.Text;
                    komut.Parameters.Add("@it", SqlDbType.DateTime).Value = DateTime.Now;
                    komut.Parameters.Add("@yi", SqlDbType.VarChar, 50).Value = "Uyelik";
                    komut.Parameters.Add("@iye", SqlDbType.VarChar, 50).Value = "Uyelik Formu";
                    komut.Parameters.Add("@kip", SqlDbType.VarChar, 20).Value = gn.GetLocalIPAddress();
                    komut.ExecuteNonQuery();//logtable a kayıt yapıldı
                                           
                    Response.Write("<script type='text/javascript'>alert('Kayıt başarılı.Kullanıcı girişinden giriş yaparak işlemlerinizi başlatabilirsiniz..!'); window.location='AnaSayfa.aspx';</script>");
                    conn.Close();
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