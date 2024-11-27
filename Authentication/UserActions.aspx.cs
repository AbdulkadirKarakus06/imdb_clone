using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_UserControls1
{
    public partial class UserActions : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Veritabani"].ConnectionString;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullaniciAdi"] is null)
            {
                Response.Write("<script type='text/javascript'>alert('Kullanıcı girişinden giriş yaparak bu sayfaya ulaşabilirsiniz..!'); window.location='AnaSayfa.aspx';</script>");
                return;

            }
           

            grid_doldur();


           
        }
        void grid_doldur()

        {
           SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand komut = new SqlCommand("select ID,KullaniciAdi,Yetki  from Kullanicilar order by KullaniciAdi", conn);
            SqlDataReader dr;
            dr = komut.ExecuteReader();


            GridKullanicilar.DataSource = dr;
            GridKullanicilar.DataBind();
            conn.Close();
            dr.Close();

        }

        protected void GridKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
           TxtUserName.Text = GridKullanicilar.Rows[GridKullanicilar.SelectedIndex].Cells[0].Text;
           // txtYetki.Text = GridKullanicilar.Rows[GridKullanicilar.SelectedIndex].Cells[1].Text;
            if (GridKullanicilar.Rows[GridKullanicilar.SelectedIndex].Cells[1].Text == "1")
            {
                DdlYetki.SelectedValue = "1";
                DdlYetki.SelectedItem.Text = "Admin";

            }
            else
            {
                DdlYetki.SelectedValue = "2";
                DdlYetki.SelectedItem.Text = "User";
            }

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)

        {
            if (DdlYetki.SelectedValue == "0")
            {
                Response.Write("<script type='text/javascript'>alert('Lütfen yetki seçiniz..!');</script>");
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand komut = new SqlCommand("UPDATE Kullanicilar set Yetki=@ytk where KullaniciAdi=@ka", conn);
            komut.Parameters.Add("@ytk", SqlDbType.SmallInt).Value = DdlYetki.SelectedValue;
            komut.Parameters.Add("@ka", SqlDbType.NVarChar,50).Value = TxtUserName.Text;

            komut.ExecuteNonQuery();
            txtYetki.Text = DdlYetki.SelectedValue;
            grid_doldur();
            conn.Close();

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE Kullanicilar  where KullaniciAdi=@ka", conn);
            komut.Parameters.Add("@ka", SqlDbType.NVarChar, 50).Value = TxtUserName.Text;

            komut.ExecuteNonQuery();
            txtYetki.Text = "";
            TxtUserName.Text = "";
            grid_doldur();
            conn.Close();

        }
    }
}