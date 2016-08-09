<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UyeKayit.aspx.cs" Inherits="webSaglikProjesi.UyeKayit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 327px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float:left"><table style="text-align:left;" class="auto-style1" >
          <tr><td colspan="2">
              <asp:Label ID="lblMesaj" ForeColor="Red" runat="server" ></asp:Label></td></tr>
            <tr>
                <td style="width:120px">
                    <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı(Email)"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="175px" ValidationGroup="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvfEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Giriniz" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rfveEmail" runat="server" ErrorMessage="Email Formatı Yanlış" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="1" ControlToValidate="txtEmail">*</asp:RegularExpressionValidator>
                </td>
            </tr>
           <tr>
                <td style="width:120px">
                    <asp:Label ID="Label8" runat="server" Text="Ad "></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtAd" runat="server" Width="175px" ValidationGroup="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAd" runat="server" ControlToValidate="txtAd" ErrorMessage="Adınızı Giriniz" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
           <tr>
                <td style="width:120px">
                    <asp:Label ID="Label9" runat="server" Text="Soyad"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSoyad" runat="server" Width="175px" ValidationGroup="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvfSoyad" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyad Giriniz" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
           <tr>
                <td style="width:120px">
                    <asp:Label ID="Label10" runat="server" Text="TC No"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtTcNo" runat="server" Width="175px" MaxLength="11" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvfTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="Tc No Giriniz" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
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
          <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Şifre Tekrar"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSifreTekrar" TextMode="Password" runat="server" Width="175px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPasswordTekrar" runat="server" ControlToValidate="txtSifreTekrar" ErrorMessage="Şifreyi Tekrar Giriniz" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtSifre" ControlToValidate="txtSifreTekrar" ErrorMessage="CompareValidator" ValidationGroup="1">*</asp:CompareValidator>
                </td>

            </tr>
            
          <tr>
                    <td style="width:120px">
                    <asp:Label ID="Label3" runat="server" Text="Adres"></asp:Label></td>
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
          <tr><td colspan="2">
              <asp:CheckBox ID="CheckBox1" runat="server" Text="Gizlilik Sözleşmesini  okudum." /></td></tr>
        
            <tr><td></td><td> <asp:Button ID="btnUyeOnay" runat="server" CssClass="bluebutton" Text="Adres Onay" Width="90px" OnClick="btnUyeOnay_Click" ValidationGroup="1"  /></td></tr>
        </table></div> 
    <div style="float:left"> 

       
        
               <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Text="Gizlilik Sözleşmesi:Bilgileriniz 3. sahıs ile paşasılmayacaktır" Height="157px"></asp:TextBox> 
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="1" />
              </div>
</asp:Content>
