<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="webSaglikProjesi.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:DataList ID="dlstUrunler" runat="server" RepeatColumns="1" Width="506px" OnItemCommand="dlstUrunler_ItemCommand">
        <ItemTemplate>
            <div style="text-align:center">
            <asp:Label ID="lblurunAd" runat="server" Text='<%# Eval("urunad") %>'></asp:Label>
                <br>
                </br>
                <br></br>
                <asp:ImageButton runat="server" CommandArgument='<%# Eval("urunid") %>' CommandName="detay" Height="240px" ImageUrl='<%# Eval("urunresimyolu2") %>' Width="220px" />
                <br />
               <asp:Label ID="lblFiyat" runat="server" Text='<%# Eval("urunfiyat", "{0:N}") %>'></asp:Label>
                <asp:TextBox ID="txtAdet" runat="server" Text="1" TextMode="Number" Width="30px"></asp:TextBox>
                <br />
                <asp:ImageButton ID="btnSepeteAt" runat="server" CommandArgument='<%# Eval("urunid") %>' CommandName="sepet" ImageUrl="/Content/style/images/btnSepeteAt.png" />
                <br>
                </br>
              <asp:Label ID="lblUrunBilgisi" runat="server" Text='<%# Eval("urunbilgisi") %>'></asp:Label>
          </div>
           
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
