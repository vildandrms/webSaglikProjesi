using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSaglikProjesi.DataModel;

namespace webSaglikProjesi
{
    public partial class UyeKayit : System.Web.UI.Page
    {
        SaglikUrunleriEntities ent = new SaglikUrunleriEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUyeOnay_Click(object sender, EventArgs e)
        {


            if (CheckBox1.Checked==true) 
            {

                Kullanicilar k = new Kullanicilar();
           
                k.kullaniciad = txtEmail.Text;
                k.ad = txtAd.Text;
                k.soyad = txtSoyad.Text;
                k.tckno = txtTcNo.Text;
                k.sifre = txtSifre.Text;
                k.telefon = txtTelefon.Text;
                k.adres = txtAdres.Text;
                k.il = txtIl.Text;
                k.ilce = txtİlce.Text;
                ent.Kullanicilar.Add(k);
                try
                {
                    if (KullanıcıKontrol(txtEmail.Text)==false)
                    { ent.SaveChanges();
                        Response.Redirect("Adres.aspx");

                    }
                    else
                    {
                        lblMesaj.Text = "E- Mail Hesabı Var";
                    }
                       
                  

                }
                catch (SqlException ex)
                {

                    string hata = ex.Message;
                }
            }

            else
            {
                lblMesaj.Text = "Sözleşmeyi Okuyunuz";
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
