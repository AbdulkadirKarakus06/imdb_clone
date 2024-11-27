<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApp_UserControls1.Register" %>

<%@ Register Src="~/OrtakUc.ascx" TagPrefix="uc1" TagName="OrtakUc" %>
<%@ Register Src="~/NavBarUc.ascx" TagPrefix="uc1" TagName="NavBarUc" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="SignInForm.css" rel="stylesheet" />
    <uc1:OrtakUc runat="server" ID="OrtakUc" />
</head>
<body>
    <uc1:NavBarUc runat="server" ID="NavBarUc" />
    <form id="form1" runat="server">
              <div class="container">
    <h1>Üye Ol</h1>
    <p>Lütfen Üyelik için Formu doldurun.</p>
 

    <label for="email"><b>Kullanıcı Adı</b></label>
    
   <asp:TextBox ID="txtEmail" placeholder="Kullanıcı Adı" runat="server"></asp:TextBox>

    <label for="psw"><b>Şifre</b></label>
    
    <asp:TextBox ID="TxtSifre" placeholder="Şifre" runat="server" TextMode="Password"></asp:TextBox>
    <label for="psw-repeat"><b>Şifre Tekrarı</b></label>
    
    <asp:TextBox ID="txtSifreTekrari" placeholder="Şifre Tekrarı" runat="server" TextMode="Password"></asp:TextBox>
    
   
    
   

                  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtSifre" ControlToValidate="txtSifreTekrari" ErrorMessage="Hatalı Şifre Tekrarı" Font-Bold="True" ForeColor="Red" ValidationGroup="vdg">*</asp:CompareValidator>
    
   
    
   

    <div class="clearfix">
     
        <asp:Button ID="BtnIptal" runat="server" class="cancelbtn" Text="Vazgeç" OnClick="BtnIptal_Click" />
     
        <asp:Button ID="BtnKayit" runat="server" class="signupbtn" Text="Kayıt Ol" OnClick="BtnKayit_Click" ValidationGroup="vdg" />
    </div>
  </div>
              <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="vdg" />
    </form>
</body>
</html>
