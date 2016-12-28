using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolaC4._5_MetroUI
{
    class Atribut
    {

        public List<List<String>> atb = new List<List<String>>();

        


        public string[] attributes = new string[] { "jenis_kelamin", "umur", "pinjaman", "waktu", "anggunan", "angsuran" };

        //public string[] jenis_kelamin = new string[] { "Laki-laki", "Perempuan"};
        public string[] JenisKelamin = { "Laki-laki", "Perempuan" };
        public string[] Umur = { "Muda", "Paruh Baya", "Tua" };
        public string[] Pinjaman = { "Kecil", "Sedang", "Besar" };
        public string[] Waktu = { "Lambat", "Sedang", "Cepat" };
        public string[] Anggunan = { "Tanpa Penjamin", "Perorangan", "Perusahaan" };
        public string[] Angsuran = { "Kecil", "Sedang", "Besar" };
        public string[] Target = { "Lancar", "Macet" };

        public Atribut()
        {
            atb.Add(JenisKelamin.ToList());
            atb.Add(Umur.ToList());
            atb.Add(Pinjaman.ToList());
            atb.Add(Waktu.ToList());
            atb.Add(Anggunan.ToList());
            atb.Add(Angsuran.ToList());
        }


        public string[] getLabel(string atrbt)
        {
            string[] result;


            switch(atrbt)
            {
                case "jenis_kelamin":
                    result = this.JenisKelamin;
                    break;
                case "umur":
                    result = this.Umur;
                    break;
                case "pinjaman":
                    result = this.Pinjaman;
                    break;
                case "waktu":
                    result = this.Waktu;
                    break;
                case "anggunan":
                    result = this.Anggunan;
                    break;
                case "angsuran":
                    result = this.Angsuran;
                    break;
                default:
                    result = new string[]{ };
                    break;
            }


            return result;
        }
    }
}
