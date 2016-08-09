using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSaglikProjesi.DataModel;
using webSaglikProjesi.Models;

namespace webSaglikProjesi
{
    public partial class Products : System.Web.UI.Page
    {
        SaglikUrunleriEntities ent = new SaglikUrunleriEntities();
        cSepet yeni = new cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                UrunleriGoster();
        }

        private void UrunleriGoster()
        {
           
            int KId = Convert.ToInt32(Request.QueryString["kno"]);
            int AltKId = Convert.ToInt32(Request.QueryString["altkno"]);
            if (AltKId==0)
            {
   var kategori = (from k in ent.Urunler
                            where k.silindi==false && k.urunaltkategorino == KId
                            select k).ToList();
                dlstUrunler.DataSource = kategori;
                dlstUrunler.DataBind();
            }

            else
            {
                var altkategori = (from k in ent.Urunler
                                where k.silindi == false && k.urunaltkategorino==AltKId
                                select k).ToList();
                dlstUrunler.DataSource = altkategori;
                dlstUrunler.DataBind();
            }
        }
        private decimal ToplamTutarBul()
        {
            decimal toplamtutar = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow dr in dt.Rows)
            {
                toplamtutar += Convert.ToDecimal(dr["Tutar"]);
            }
            return toplamtutar;
        }
        protected void dlstUrunler_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "detay")
            {
                //dlstUrunler.EditItemIndex = e.Item.ItemIndex;    /// id yi cekeriz
                int urunId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Details.aspx?urunid=" + urunId);
            }
            else if (e.CommandName == "sepet")
            {
                if (Session["sepet"] == null)
                {

                    Session["sepet"] = yeni.YeniSepet();
                }

                DataTable dt = (DataTable)Session["sepet"];
                int ıd = Convert.ToInt32(e.CommandArgument);
                Label UAd = (Label)e.Item.FindControl("lblurunAd");
                TextBox UAdet = (TextBox)e.Item.FindControl("txtAdet");
                Label UFiyat = (Label)e.Item.FindControl("lblFiyat");
                bool Varmi = false;
                foreach (DataRow drow in dt.Rows)
                {
                    if (Convert.ToInt32(drow["urunID"]) == ıd)
                    {
                        Varmi = true;
                        drow["Adet"] = Convert.ToInt32(drow["Adet"]) + Convert.ToInt32(UAdet.Text);
                        drow["Tutar"] = Convert.ToDecimal(drow["Tutar"]) + (Convert.ToInt32(UAdet.Text) * Convert.ToDecimal(UFiyat.Text));
                        Response.Redirect("Sepet.aspx");
                        if (Session["sepet"] != null)
                        {
                            DataTable dty = (DataTable)Session["sepet"];
                            GridView gv = this.Master.FindControl("gvSepetOzet") as GridView;
                            gv.Columns[0].FooterText = "Toplam :";
                            gv.Columns[1].FooterText = string.Format("{0:C}", ToplamTutarBul());
                            gv.DataSource = dty;
                            gv.DataBind();

                        }

                        break;
                    }
                }

                if (Varmi == false)
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr["urunID"] = ıd;
                    dr["urunAd"] = UAd.Text;
                    dr["Adet"] = Convert.ToInt32(UAdet.Text);
                    dr["Fiyat"] = Convert.ToDecimal(UFiyat.Text);
                    dr["Tutar"] = Convert.ToInt32(UAdet.Text) * Convert.ToDecimal(UFiyat.Text);

                    dt.Rows.Add(dr);
                    Session["sepet"] = dt;
                    Response.Redirect("Sepet.aspx");

                }
            }
        }
    }
}