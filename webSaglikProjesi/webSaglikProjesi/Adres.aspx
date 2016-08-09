<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Adres.aspx.cs" Inherits="webSaglikProjesi.Adres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("Baslik");//butun sayfalı dolaş ve id si Baslık olanı bul bunun gibi oluştur bir tane
        baslik.innerText = "Üyelik İşlemleri";// bu Baslıgın  texti ne olacak onu yazdık

    </script>
    <div style="text-align:center">
        <img src="Content/style/images/adresonay2.jpg" /><br />
        Sitemizden alışveriş yapabilmeniz için üye olmanız gerekmektedir.Eğer üye değilseniz. <a href="UyeKayit.aspx">Yeni Üye Kaydı İçin Tıklayınız</a><br /><br />
        <table style="text-align:left;width:300px;" >
            <tr>
                <td style="width:120px">
                    <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı(Email)"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="175px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvfEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Giriniz" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>

              <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Şifre "></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSifre" TextMode="Password" runat="server" Width="175px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifre Giriniz" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr><td></td>
                <td>
                    <asp:Button ID="btnGiris" runat="server" CssClass="bluebutton" Text="Giriş" Width="73px" OnClick="btnGiris_Click" ValidationGroup="1" /></td></tr>


        </table>
        <asp:CheckBox ID="cbxUnuttum" Text="şifremi unuttum" runat="server" OnCheckedChanged="cbxUnuttum_CheckedChanged" /> <br />
        <asp:Label ID="lblMesaj" runat="server" ForeColor="Red"></asp:Label>
        <asp:Panel ID="pnlAdres" runat="server" Visible="False">
            <table style="text-align:left">
                <tr>
                    <td style="width:120px">
                    <asp:Label ID="Label3" runat="server" Text="Teslim Adresi"></asp:Label></td>
                <td>
                 <asp:TextBox ID="txtAdres" TextMode="MultiLine" runat="server" Width="175px"></asp:TextBox>
                </td></tr>

                <tr>
                    <td>
                    <asp:Label ID="Label4" runat="server" Text="İlçe"></asp:Label></td>
                <td>
                 <asp:TextBox ID="txtİlce" runat="server" Width="175px"></asp:TextBox>
                </td></tr>

                <tr>
                    <td>
                    <asp:Label ID="Label5" runat="server" Text="İl"></asp:Label></td>
                <td>
                 <asp:TextBox ID="txtIl" runat="server" Width="175px"></asp:TextBox>
                </td></tr>

                <tr>
 <td>
                    <asp:Label ID="Label6" runat="server" Text="Telefon"></asp:Label></td>
                <td>
                 <asp:TextBox ID="txtTelefon" runat="server" Width="175px"></asp:TextBox>
                </td>
                </tr>
                  <tr><td></td>
                <td>
                    <asp:Button ID="btnAdresOnay" runat="server" CssClass="bluebutton" Text="Adres Onay" Width="90px" OnClick="btnAdresOnay_Click" /></td></tr>

            </table>
        </asp:Panel>
    </div>
</asp:Content>
