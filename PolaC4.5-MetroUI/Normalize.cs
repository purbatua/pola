using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolaC4._5_MetroUI
{
    class Normalize
    {
        public string umur(int u)
        {
            string umur = "muda";

            if (u >= 17 && u <= 40)
            {
                umur = "muda";
            }
            else if (u >= 41 && u <= 55)
            {
                umur = "paruh baya";
            }
            else if (u > 55)
            {
                umur = "tua";
            }

            return umur;
        }

        public string pinjaman(int p)
        {
            string pinjaman = "kecil";

            if(p >= 1000000 && p <= 5000000)
            {
                pinjaman = "kecil";
            }
            else if(p >= 5000001 && p <= 10000000)
            {
                pinjaman = "sedang";
            }
            else if(p > 100000001)
            {
                pinjaman = "besar";
            }

            return pinjaman;
        }

        public string waktu(int w)
        {
            string waktu = "cepat";

            if(w >= 6 && w <= 12)
            {
                waktu = "cepat";
            }
            else if (w >= 13 && w <= 18)
            {
                waktu = "sedang";
            }
            else if (w > 19)
            {
                waktu = "lambat";
            }

            return waktu;
        }

        public string angsuran(int a)
        {
            string angsuran = "kecil";

            if (a <= 100000)
            {
                angsuran = "kecil";
            }
            else if (a >= 100001 && a <= 1000000)
            {
                angsuran = "sedang";
            }
            else if (a > 1000001)
            {
                angsuran = "besar";
            }

            return angsuran;
        }


        public string saldo(int s)
        {
            string saldo = "kecil";

            if (s >= 1000000  && s <= 5000000)
            {
                saldo = "kecil";
            }
            else if (s >= 5000001 && s <= 10000000)
            {
                saldo = "sedang";
            }
            else if (s > 10000001)
            {
                saldo = "besar";
            }

            return saldo;
        }

        public string tunggakanPokok(int tp)
        {
            string tunggakan = "kecil";

            if (tp <= 500000)
            {
                tunggakan = "kecil";
            }
            else if (tp >= 500001 && tp <= 1000000)
            {
                tunggakan = "sedang";
            }
            else if (tp > 1000001)
            {
                tunggakan = "besar";
            }

            return tunggakan;
        }

        public string tunggakanBunga(int tb)
        {
            string tunggakan = "kecil";

            if (tb <= 100000)
            {
                tunggakan = "kecil";
            }
            else if (tb >= 100001 && tb <= 1000000)
            {
                tunggakan = "sedang";
            }
            else if (tb > 1000001)
            {
                tunggakan = "besar";
            }

            return tunggakan;
        }


    }
}
