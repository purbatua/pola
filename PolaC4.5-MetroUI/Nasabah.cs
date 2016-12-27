using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolaC4._5_MetroUI
{
    class Nasabah
    {
        public const string table  =  "nasabah";
        public string[] attributes = new string[]{ "id", "nama", "jenis_kelamin", "umur", "pinjaman", "waktu", "anggunan", "angsuran", "target" };

        int id;
        string nama;
        string jenis_kelamin;
        int umur;
        long pinjaman;
        int jangka_waktu;
        string anggunan;
        long angsuran;
        string target;
        Database DB = new Database();

        public Nasabah() { }

        public Nasabah(int id, string nama, string jenis_kelamin, int umur,
            long pinjaman, int jangka_waktu, string anggunan, long angsuran, string target) {

            this.id = id == 0 ? 0 : id;
            this.nama = nama;
            this.jenis_kelamin = jenis_kelamin;
            this.umur = umur;
            this.pinjaman = pinjaman;
            this.jangka_waktu = jangka_waktu;
            this.anggunan = anggunan;
            this.angsuran = angsuran;
            this.target = target;
        }

        public bool save()
        {
            bool result = false;

            Database db = new Database();
            Normalize normal = new Normalize();

            string DataNasabah = this.id + ",'" + this.nama + "','" + this.jenis_kelamin + "'," + this.umur + ", " +
                this.pinjaman + ", " + this.jangka_waktu + ", '" + this.anggunan + "', " + this.angsuran +  ",'" + this.target + "'";

            string DataNasabahTrans = this.id + ",'" + this.jenis_kelamin + "','" + normal.umur(this.umur) + "', '" +
                normal.pinjaman(this.pinjaman) + "','" + normal.waktu(this.jangka_waktu) + "', '" + this.anggunan + "', '" + normal.angsuran(this.angsuran) + "','" + this.target + "'";



            if (db.insert("nasabah_trans", DataNasabahTrans))
            {
                if (db.insert(table, DataNasabah))
                    result = true;
                else
                    result = false;
            }
            else
            {
                result = false;
            }

            Console.WriteLine(DataNasabah);

            return result;
        }


        public bool update()
        {
            bool result = false;
            Database db = new Database();
            Normalize normal = new Normalize();

            string DataNasabah =  "nama='" + this.nama + "',jenis_kelamin='" + this.jenis_kelamin + "',umur=" + this.umur + ", pinjaman=" +
                this.pinjaman + ", waktu=" + this.jangka_waktu + ", anggunan='" + this.anggunan + "', angsuran=" + this.angsuran + ", target='" + this.target + "'";

            string DataNasabahTrans = "jenis_kelamin='" + this.jenis_kelamin + "',umur='" + normal.umur(this.umur) + "', pinjaman='" +
                normal.pinjaman(this.pinjaman) + "', waktu='" + normal.waktu(this.jangka_waktu) + "', anggunan='" + this.anggunan + "', angsuran='" + 
                normal.angsuran(this.angsuran) + "', target='" + this.target + "'";


            if (db.update("nasabah_trans", DataNasabahTrans, "nasabah_id=" + this.id))
            {
                if (db.update("nasabah", DataNasabah, "id=" + this.id))
                    result = true;
                else
                    result = false;
            }
            else
            {
                result = false;
            }



            return result;
        }

        public bool remove(int id)
        {
            bool result = false;

            if (DB.delete(table, "id=" + id))
                result = true;
            else
                result = false;

            return result;
        }

        

    }
}
