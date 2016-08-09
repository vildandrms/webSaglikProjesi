<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sepet.aspx.cs" Inherits="webSaglikProjesi.Sepet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("Baslik");//butun sayfalı dolaş ve id si Baslık olanı bul bunun gibi oluştur bir tane
        baslik.innerText = "Sepet İşlemleri";// bu Baslıgın  texti ne olacak onu yazdık

    </script>
    <center>
    <img src="Content/style/images/sepetonay2.jpg" />
    <br />
    <asp:GridView ID="gvSepet" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="sepetID" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="436px" OnRowDeleting="gvSepet_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="UrunAd" HeaderText="Ürün Adı" >
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Fiyat" HeaderText="Fiyat" >
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Adet" HeaderText="Adet" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Tutar" HeaderText="Tutar" >
            <FooterStyle HorizontalAlign="Right" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:CommandField DeleteText="Sil" ShowDeleteButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <EmptyDataTemplate><h3>Sepetinizde Ürün Bulunmamaktadır</h3></EmptyDataTemplate> <%--Gridview boş oldugunda ne gösterilercek--%>
    </asp:GridView>

        <br />
        <asp:Button ID="btnSepetiBosalt" runat="server" CssClass="bluebutton" Text="Sepeti Boşalt" Width="106px" OnClick="btnSepetiBosalt_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDevam" runat="server" CssClass="bluebutton" Text="Alişverişe Devam" Width="106px" OnClick="btnDevam_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnSatınAl" runat="server" CssClass="bluebutton" Text="Satıl Al" Width="106px" OnClick="btnSatınAl_Click" />
       </center>
</asp:Content>
