using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolaC4._5_MetroUI
{
    class Nasabah
    {
        const string table =  "nasabah";

        int id;
        string nama;
        string jenis_kelamin;
        int umur;
        int pinjaman;
        int jangka_waktu;
        int anggunan;
        int angsuran;
        int saldo;
        int tunggakan_pokok;
        int tunggakan_bunga;
        string target;

        public Nasabah() { }

        public Nasabah(int id, string nama, string jenis_kelamin, int umur,
            int pinjaman, int jangka_waktu, int anggunan, int angsuran,
            int saldo, int tunggakan_pokok, int tunggakan_bunga, string target) {

            this.id = id == 0 ? 0 : id;
            this.nama = nama;
            this.jenis_kelamin = jenis_kelamin;
            this.umur = umur;
            this.pinjaman = pinjaman;
            this.jangka_waktu = jangka_waktu;
            this.anggunan = anggunan;
            this.angsuran = angsuran;
            this.saldo = saldo;
            this.tunggakan_pokok = tunggakan_pokok;
            this.tunggakan_bunga = tunggakan_bunga;
            this.target = target;
        }

        public bool save()
        {
            bool result = false;

            Database db = new Database();
            Normalize normal = new Normalize();

            string nasabah = this.id + ",'" + this.nama + "','" + this.jenis_kelamin + "'," + this.umur + ", " +
                this.pinjaman + ", " + this.jangka_waktu + ", " + this.anggunan + ", " + this.angsuran + ", " +
                this.saldo + ", " + this.tunggakan_pokok + ", " + this.tunggakan_bunga + ",'" + this.target + "'";

            string transNasabah = this.id + ",'" + this.jenis_kelamin + "','" + normal.umur(this.umur) + "', '" +
                normal.pinjaman(this.pinjaman) + "',' " + normal.waktu(this.jangka_waktu) + "', " + normal.anggunan(this.anggunan) + ", '" + normal.angsuran(this.angsuran) + "', '" +
                normal.saldo(this.saldo) + "', '" + normal.tunggakanPokok(this.tunggakan_pokok) + "', '" + normal.tunggakanBunga(this.tunggakan_bunga) + "','" + this.target + "'";



            if (db.insert("nasabah_trans", transNasabah))
            {
                if (db.insert(table, nasabah))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }


        public bool update()
        {
            bool result = false;
            Database db = new Database();
            Normalize normal = new Normalize();


            string DataNasabah =  "nama='" + this.nama + "',jenis_kelamin='" + this.jenis_kelamin + "',umur=" + this.umur + ", pinjaman=" +
                this.pinjaman + ", waktu=" + this.jangka_waktu + ", anggunan=" + this.anggunan + ", angsuran=" + this.angsuran + ", saldo=" +
                this.saldo + ", tunggakan_pokok=" + this.tunggakan_pokok + ", tunggakan_bunga=" + this.tunggakan_bunga + ", target='" + this.target + "'";

            string DataNasabahTrans = "jenis_kelamin='" + this.jenis_kelamin + "',umur='" + normal.umur(this.umur) + "', pinjaman='" +
                normal.pinjaman(this.pinjaman) + "', waktu=' " + normal.waktu(this.jangka_waktu) + "', anggunan='" + normal.anggunan(this.anggunan) + "', angsuran='" + 
                normal.angsuran(this.angsuran) + "', saldo='" + normal.saldo(this.saldo) + "', tunggakan_pokok='" + normal.tunggakanPokok(this.tunggakan_pokok) + "', tunggakan_bunga='" + 
                normal.tunggakanBunga(this.tunggakan_bunga) + "', target='" + this.target + "'";


            if (db.update("nasabah_trans", DataNasabahTrans, "nasabah_id=" + this.id))
            {
                if (db.update("nasabah", DataNasabah, "id=" + this.id))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }



            return result;
        }

        

    }
}
