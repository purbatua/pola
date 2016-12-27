using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolaC4._5_MetroUI
{
    class TransformasiNasabah
    {
        public const string table  = "nasabah_trans";
        public string[] attributes = new string[]{ "nasabah_id", "jenis_kelamin", "umur", "pinjaman", "waktu", "anggunan", "angsuran", "target" };

        int id;
        string jenis_kelamin;
        string umur;
        string pinjaman;
        string jangka_waktu;
        string anggunan;
        string angsuran;
        string target;

        Database DB = new Database();

        public TransformasiNasabah() { }

        public TransformasiNasabah(int id, string nama, string jenis_kelamin, string umur, string pinjaman, string jangka_waktu, string anggunan, string angsuran, string target)
        {
            this.id = id == 0 ? 0 : id;
            this.jenis_kelamin = jenis_kelamin;
            this.umur = umur;
            this.pinjaman = pinjaman;
            this.jangka_waktu = jangka_waktu;
            this.anggunan = anggunan;
            this.angsuran = angsuran;
            this.target = target;
        }

        public string[][] all()
        {
            return DB.get(table, attributes);
        }

        public bool remove(int id)
        {
            bool result = false;

            if (DB.delete(table, "nasabah_id=" + id))
                result = true;
            else
                result = false;

            return result;
        }


    }
}
