using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSaglikProjesi.DataModel;

namespace webSaglikProjesi
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        SaglikUrunleriEntities ent = new SaglikUrunleriEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KategoriDoldur();
            }
        }

        private void KategoriDoldur()
        {
            var categories = (from k in ent.Kategoriler
                         where k.silindi == false
                         select k).ToList();

            

            foreach (var kategori in categories)
            {
                MenuItem yine = new MenuItem();
                yine.Text = kategori.kategoriad;
                yine.Value = (kategori.id).ToString();
                mnuKategoriler.Items.Add(yine);

                        var altcategories = (from a in ent.AltKategoriler
                              where a.silindi == false && a.kategorino==kategori.id
                              select a).ToList();
                foreach (var altkategori in altcategories)
                {
                    MenuItem yeni = new MenuItem();
                    yeni.Text = altkategori.altkategoriad;
                    yeni.Value = (altkategori.id).ToString();
                    yine.ChildItems.Add(yeni);
                }
            }
            
           
           
        }

        protected void mnuKategoriler_MenuItemClick(object sender, MenuEventArgs e)
        {

            string[] deger = e.Item.ValuePath.Split('/');
         Response.Write(e.Item.ValuePath);

            //int altkno = 0;
            //if (deger.Length>1)
            //{
            //    altkno = Convert.ToInt32(deger[1]);

            //}
            //Response.Redirect("Products.aspx?kno=" + deger[0] + "&akno=" +altkno );


            if (deger.Length <= 1)
            {
                Response.Redirect("Products.aspx?kno=" + deger[0]);
            }
            else
            {
                Response.Redirect("Products.aspx?kno=" +deger[0] + "&altkno=" +deger[1]);
            }

        }
    }
}