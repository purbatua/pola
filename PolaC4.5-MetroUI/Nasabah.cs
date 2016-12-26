using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolaC4._5_MetroUI
{
    class Nasabah
    {
        const string tabel =  "nasabah";

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
        //Database db = new Database();

        public Nasabah(int id, string nama, string jenis_kelamin, int umur,
            int pinjaman, int jangka_waktu, int anggunan, int angsuran,
            int saldo, int tunggakan_pokok, int tunggakan_bunga) {

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

            /*
            string value = id + ",'" + nama + "','" + jenis_kelamin + "'," + umur + ", " + 
                pinjaman + ", " + jangka_waktu + ", " + anggunan + ", " + angsuran + ", " + 
                saldo + ", " + tunggakan_pokok + ", " + tunggakan_bunga;

            //Console.WriteLine(value);
            /*
            if (db.insert(tabel, value))
            {
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            */
        }

        public bool save()
        {
            bool result = false;

            Database db = new Database();
            Normalize normal = new Normalize();

            /*
            string value = "id=" + this.id + ", nama='" + this.nama + "', jenis_kelamin='" + 
                this.jenis_kelamin + "', umur=" + this.umur + ", pinjaman=" + this.pinjaman + ", jangka_waktu=" +
                this.jangka_waktu + ", jenis_anggunan=" + this.anggunan + ", angsuran_perbulan=" + this.angsuran + ", saldo=" + 
                this.saldo + ", tunggakan_pokok=" + this.tunggakan_pokok + ", tunggakan_bunga=" + this.tunggakan_bunga;
            */

            string nasabah = this.id + ",'" + this.nama + "','" + this.jenis_kelamin + "'," + this.umur + ", " +
                this.pinjaman + ", " + this.jangka_waktu + ", " + this.anggunan + ", " + this.angsuran + ", " +
                this.saldo + ", " + this.tunggakan_pokok + ", " + this.tunggakan_bunga;

            string transNasabah = this.id + ",'" + this.jenis_kelamin + "','" + normal.umur(this.umur) + "', '" +
                normal.pinjaman(this.pinjaman) + "',' " + normal.waktu(this.jangka_waktu) + "', " + this.anggunan + ", '" + normal.angsuran(this.angsuran) + "', '" +
                normal.saldo(this.saldo) + "', '" + normal.tunggakanPokok(this.tunggakan_pokok) + "', '" + normal.tunggakanBunga(this.tunggakan_bunga) + "'";



            if (db.insert("data", transNasabah))
            {
                if (db.insert(tabel, nasabah))
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

        public bool create(Array[] args)
        {
            
            //this.id = id;
            //this.nama = args[0];
            //this.jenis_kelamin = args[1];
            //this.umur = args[2];
            //this.pinjaman = args[3];
            //this.jangka_waktu = jangka_waktu;
            //this.anggunan = anggunan;
            //this.angsuran = angsuran;
            //this.saldo = saldo;
            //this.tunggakan_pokok = tunggakan_pokok;
            //this.tunggakan_bunga = tunggakan_bunga;

            return true;
        }



        

    }
}
