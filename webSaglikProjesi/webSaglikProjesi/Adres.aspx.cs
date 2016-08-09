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
    public partial class Adres : System.Web.UI.Page
    {
        SaglikUrunleriEntities ent = new SaglikUrunleriEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {


            var sorgu = (from k in ent.Kullanicilar
                         where k.kullaniciad == txtEmail.Text && k.sifre == txtSifre.Text && k.silindi == false
                         select k).FirstOrDefault();

            if (sorgu == null)
            {
                lblMesaj.Text = "Hatalı Kullanıcı yada sifre";
                txtEmail.Focus();
            }
            else
            {
                Session["kullanici"] = sorgu.id;
                lblMesaj.Text = "";
                pnlAdres.Visible = true;
                txtAdres.Text = sorgu.adres;
                txtTelefon.Text = sorgu.telefon;
                txtIl.Text = sorgu.il;
                txtİlce.Text = sorgu.ilce;
            }
        }

        protected void btnAdresOnay_Click(object sender, EventArgs e)
        {
            int did = Convert.ToInt32(Session["kullanici"]);
            var sorgu = (from k in ent.Kullanicilar
                         where k.id == did && k.silindi == false
                         select k).FirstOrDefault();
            if (txtAdres.Text.Trim() != null)
            {
                sorgu.adres = txtAdres.Text;
                sorgu.il = txtIl.Text;
                sorgu.ilce = txtİlce.Text;
                sorgu.telefon = txtTelefon.Text;
                sorgu.id = did;

                ent.SaveChanges();
                lblMesaj.Text = "Güncelleme Başarılı";

            
                Satislar yS = new Satislar();
                yS.kullanicino = Convert.ToInt32(Session["kullanici"]);
                yS.tarih = DateTime.Now;
                yS.tutar = ToplamTutarBul();
                yS.miktar = ToplamAdetBul();
                yS.teslimtarihi = DateTime.Now.AddDays(7);
                yS.durumu = (byte)Models.cEnum.SatisDurumu.siparis;
                ent.Satislar.Add(yS);


                
                DataModel.SatisDetaylari yeni = new DataModel.SatisDetaylari();

                int SonSatisNo = ent.Satislar.Where(s => s.kullanicino == yS.kullanicino).ToList().Last().satisno;

                DataTable dt = (DataTable)Session["sepet"];
                foreach (DataRow drow in dt.Rows)
                {
                    yeni.urunid = Convert.ToInt32(drow["UrunID"]);
                    yeni.adet = Convert.ToInt32(drow["Adet"]);
                    yeni.birimfiyat = Convert.ToDecimal(drow["Fiyat"]);
                    yeni.tutar = Convert.ToInt32(drow["Tutar"]);
                    yeni.satisno = SonSatisNo;
                    ent.SatisDetaylari.Add(yeni);
     ent.SaveChanges();
                }
           
                Response.Redirect("Odeme.aspx");
            }
            else
            {
                lblMesaj.Text = "Güncelleme Başarısız.";
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

        private int ToplamAdetBul()
        {
            int adet = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow dr in dt.Rows)
            {
                adet += Convert.ToInt32(dr["Adet"]);
            }
            return adet;
        }

        protected void cbxUnuttum_CheckedChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim()!="")
            {
                if (KullanıcıKontrol(txtEmail.Text))
                {

                }
            }
        }
        private bool KullanıcıKontrol(string text)
        {
            var Kul = (from k in ent.Kullanicilar
                       where k.kullaniciad == text
                       select k).ToList();


            if (Kul.Any()) ///yada kul!=Null
            {
                return true;
            }

            else
            {
                return false;
            }


        }
    }
}