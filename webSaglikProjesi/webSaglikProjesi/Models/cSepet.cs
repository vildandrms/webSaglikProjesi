using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace webSaglikProjesi.Models
{
    public class cSepet
    {
        public DataTable YeniSepet()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sepetID");
            dt.Columns["sepetID"].DataType = typeof(int);
            dt.Columns["sepetID"].AutoIncrement = true;// ıd olugu için 1 er 1er artması için
            dt.Columns["sepetID"].AutoIncrementSeed = 1;
            dt.Columns["sepetID"].AutoIncrementStep = 1;

            dt.Columns.Add("urunID");
            dt.Columns["urunID"].DataType = typeof(int);

            dt.Columns.Add("UrunAd");
            dt.Columns["UrunAd"].DataType = typeof(string);

            dt.Columns.Add("Adet");
            dt.Columns["Adet"].DataType = typeof(int);
            dt.Columns["Adet"].DefaultValue = 1;

            dt.Columns.Add("Fiyat");
            dt.Columns["Fiyat"].DataType = typeof(decimal);
            dt.Columns["Fiyat"].DefaultValue = 0;

            dt.Columns.Add("Tutar");
            dt.Columns["Tutar"].DataType = typeof(decimal);
            dt.Columns["Tutar"].DefaultValue = 0;


            return dt;
        }
    }
}