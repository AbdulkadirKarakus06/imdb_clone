<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserActions.aspx.cs" Inherits="WebApp_UserControls1.UserActions" %>

<%@ Register Src="~/OrtakUc.ascx" TagPrefix="uc1" TagName="OrtakUc" %>
<%@ Register Src="~/SideBarAdmin.ascx" TagPrefix="uc1" TagName="SideBarAdmin" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <uc1:OrtakUc runat="server" ID="OrtakUc" />
    <link href="SideBar.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
        .auto-style2 {
            width: 490px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:SideBarAdmin runat="server" ID="SideBarAdmin" />
        <div align="center">
            <table class="auto-style1" border="5">
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:GridView ID="GridKullanicilar" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridKullanicilar_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="kullaniciAdi" HeaderText="Kullanıcı Adı ">
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="yetki" HeaderText="Yetkisi">
                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:ButtonField CommandName="select" HeaderText="Seç" Text="Seçiminiz" />
                            </Columns>
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="auto-style2">
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı" BackColor="#FFFF66" BorderStyle="Groove" Font-Bold="True" Width="100px"></asp:Label>
                            <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label2" runat="server" BackColor="#FFFF66" BorderStyle="Groove" Font-Bold="True" Text="Yetkisi" Width="100px"></asp:Label>
                            <asp:DropDownList ID="DdlYetki" runat="server">
                                <asp:ListItem Value="0">--Seçiniz--</asp:ListItem>
                                <asp:ListItem Value="1">Admin</asp:ListItem>
                                <asp:ListItem Value="2">User</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtYetki" runat="server" Width="42px" Visible="False"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnSil" runat="server" Text="Sil     " OnClick="btnSil_Click" />
                            <br />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
