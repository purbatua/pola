using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolaC4._5_MetroUI
{
    class C45
    {
        public string[] JenisKelamin = { "Laki-laki", "Perempuan" };
        public string[] Umur = { "Muda", "Paruh Baya", "Tua" };
        public string[] Pinjaman = { "Kecil", "Sedang", "Besar" };
        public string[] Waktu = { "Lambat", "Sedang", "Cepat" };
        public string[] Anggunam = { "Tanpa Penjamin", "Perorangan", "Perusahaan" };
        public string[] Angsuran = { "Kecil", "Sedang", "Besar" };
        public string[] Target = { "Lancar", "Macet" };

        TransformasiNasabah trnasabah = new TransformasiNasabah();
        Database DB = new Database();






        public bool Training()
        {
            Initial();
            CalcAttribute();

            return true;
        }






        public double Entropy()
        {
            double hasil = 0.0;

            double total = i2d(trnasabah.count());
            double lancar = i2d(trnasabah.count("target='Lancar'"));
            double macet = i2d(trnasabah.count("target='Macet'"));

            hasil = (-1 * ((lancar / total) * Math.Log(lancar / total, 2)) ) + (-1 * ((macet / total) * Math.Log(macet / total, 2)) );


            if(Double.IsNaN(hasil)) { hasil = 0.0; }

            return hasil;
        }


        public double Entropy(string atribut, string label)
        {
            double hasil = 0.0;

            double total  = i2d(labelTotal(atribut, label));
            double lancar = i2d(T1(atribut, label));
            double macet  = i2d(T2(atribut, label));

            hasil = (-1 * ((lancar / total) * Math.Log(lancar / total, 2))) + (-1 * ((macet / total) * Math.Log(macet / total, 2)));

            if (Double.IsNaN(hasil)) { hasil = 0.0; }

            return hasil;
        }

        public double Gain(double EntropyTotal,string atribut, double entropy)
        {
            double hasil = 0.0;

            double total = trnasabah.count();

            Atribut atr = new Atribut();
            string[] label = atr.getLabel(atribut);


            for (int i = 0; i < label.Length; i++)
            {
                double lancar = trnasabah.count("" + atribut + "=" + label[i] + " AND target='Lancar'");
                double macet  = trnasabah.count("" + atribut + "=" + label[i] + " AND target='Macet'");

                // TO DO
            }


            return hasil;
        }


        public void Initial()
        {
            string query = "" + DB.id("training")  + ", 1, 'Total', '', " + trnasabah.count() + ", " + trnasabah.count("target='Lancar'")  + ", " + trnasabah.count("target='Macet'") + ", " + Entropy() + ",''";

            DB.insert("training", query);
        }

        public void CalcAttribute()
        {
            Atribut atr = new Atribut();

            for(int i = 0; i < atr.attributes.Length; i++)
            {
                string[] labels = atr.getLabel(atr.attributes[i]);
                string atribut = atr.attributes[i];

                for(int j = 0; j < labels.Length; j++)
                {
                    string label = labels[j];

                    if(j == (label.Length - 1))
                    {

                    }else
                    {
                        string query = DB.id("training") + ", 1, '" + atribut + "', '" + label + "'," + labelTotal(atribut, label) + "," + T1(atribut, label) + ", " + T2(atribut, label) + ", " + Entropy(atribut, label) + ", 0";

                        DB.insert("training", query);
                    }

                    
                }
            }
        }


        public int labelTotal(string atribut, string label)
        {
            return DB.count("nasabah_trans", "" + atribut + "='" + label + "'");
        }

        public int T1(string atribut, string label) // Target 1: Lancar
        {
            Console.WriteLine(DB.count("nasabah_trans", "" + atribut + "='" + label + "' AND target='Lancar'"));
            return DB.count("nasabah_trans", "" + atribut + "='" + label + "' AND target='Lancar'");
        }

        public int T2(string atribut, string label) // Target 2: Macet
        {
            Console.WriteLine(DB.count("nasabah_trans", "" + atribut + "='" + label + "' AND target='Macet'"));

            return DB.count("nasabah_trans", "" + atribut + "='" + label + "' AND target='Macet'");
        }

        public double i2d(int v) // integer to double
        {
            return Convert.ToDouble(v);
        }
    }
}
