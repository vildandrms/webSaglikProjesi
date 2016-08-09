using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi
{
    public partial class Sepet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sepet"] != null)
                {
                    DataTable dt = (DataTable)Session["sepet"];
                    SepetGoster(dt);
                }
                else
                {
                    DataTable dt = new DataTable();
                   
                    gvSepet.DataSource = dt;
                    gvSepet.DataBind();
                }
            }
        }

        private void SepetGoster(DataTable dt)
        {

            gvSepet.Columns[1].FooterText = "Toplam : ";
            gvSepet.Columns[2].FooterText = ToplamAdetBul().ToString();
            gvSepet.Columns[2].FooterStyle.HorizontalAlign = HorizontalAlign.Center;
            gvSepet.Columns[3].FooterText = ToplamTutarBul().ToString();
            gvSepet.Columns[3].FooterStyle.HorizontalAlign = HorizontalAlign.Center;
            gvSepet.DataSource = dt;
            gvSepet.DataBind();
            if (Session["sepet"] != null)
            {
                DataTable dty = (DataTable)Session["sepet"];
                GridView gv = this.Master.FindControl("gvSepetOzet") as GridView;
                gv.Columns[0].FooterText = "Toplam :";
                gv.Columns[1].FooterText = string.Format("{0:C}", ToplamTutarBul());
                gv.DataSource = dty;
                gv.DataBind();

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

        protected void btnDevam_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnSepetiBosalt_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];
            dt.Rows.Clear();
            Session["sepet"] = dt;
            SepetGoster(dt);
        }

        protected void gvSepet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];
            dt.Rows.RemoveAt(e.RowIndex); //secili satırı yakaladık sildik
            Session["sepet"] = dt;
            SepetGoster(dt);
        }

        protected void btnSatınAl_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"]; // nul demedik çünkü içi boşkende gitmesi diye
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Adres.aspx");
            }



        }
    }
}