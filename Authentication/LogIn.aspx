<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebApp_UserControls1.LogIn" %>

<%@ Register Src="~/OrtakUc.ascx" TagPrefix="uc1" TagName="OrtakUc" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="login.css" rel="stylesheet" />
    <uc1:OrtakUc runat="server" ID="OrtakUc" />
    <style type="text/css">
        .auto-style1 {
            float: left;
            width: 100%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 0;
            padding: 0 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            
<h2>Kullanıcı Giriş Formu</h2>
<p></p>

<div class="container">
 
    <div class="row">
      <h2 style="text-align:center">Sosyal Medya Hesabınızla ya da manuel Giriş Yapınız</h2>
      <div class="vl">
        <span class="vl-innertext">Veya</span>
      </div>

      <div class="col">
        <a href="#" class="fb btn">
          <i class="fa fa-facebook fa-fw"></i> Facebook ile Bağlan
         </a>
        <a href="#" class="twitter btn">
          <i class="fa fa-twitter fa-fw"></i>Twitter ile Bağlan
        </a>
        <a href="#" class="google btn"><i class="fa fa-google fa-fw">
          </i> Google hesabı ile Bağlan
        </a>
      </div>

      <div class="col">
        <div class="hide-md-lg">
          <p>Veya Manuel Bağlan</p>
        </div>

       
          <asp:TextBox ID="txtUserName" placeholder="Kullanıcı Adı" runat="server"></asp:TextBox>
       
          <asp:TextBox ID="txtPassword" placeholder="Şifre"  runat="server" TextMode="Password"></asp:TextBox>
      
          <asp:Button ID="btnLogin" runat="server" Text="Giriş Yap" OnClick="btnLogin_Click" />
      </div>
      
    </div>
 
</div>

<div class="bottom-container">
  <div class="row">
    <div class="auto-style1">
      <a href="https://ankaraka.org.tr/"  target="_blank" style="color:white" class="btn">Ankara Kalkınma Ajansı</a>
    </div>
    <div class="col">
      <a href="https://www.bilisimegitim.com/" target="_blank" style="color:white" class="btn">Bilişim Eğitim Merkezi</a>
    </div>
  </div>
</div>
    </form>
</body>
</html>
