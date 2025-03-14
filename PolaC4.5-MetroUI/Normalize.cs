﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolaC4._5_MetroUI
{
    class Normalize
    {
        public string umur(int u)
        {
            string umur = "Muda";

            if (u >= 17 && u <= 35)
            {
                umur = "Muda";
            }
            else if (u >= 36 && u <= 50)
            {
                umur = "Paruh Baya";
            }
            else if (u >= 51)
            {
                umur = "Tua";
            }

            return umur;
        }

        public string pinjaman(long p)
        {
            string pinjaman = "Kecil";

            if(p >= 1000000 && p <= 5000000)
            {
                pinjaman = "Kecil";
            }
            else if(p >= 5000001 && p <= 15000000)
            {
                pinjaman = "Sedang";
            }
            else if(p >= 150000001)
            {
                pinjaman = "Besar";
            }

            return pinjaman;
        }

        public string waktu(int w)
        {
            string waktu = "Cepat";

            if(w >= 6 && w <= 12)
            {
                waktu = "Cepat";
            }
            else if (w >= 13 && w <= 24)
            {
                waktu = "Sedang";
            }
            else if (w >= 25)
            {
                waktu = "Lambat";
            }

            return waktu;
        }

        //public string anggunan(int a)
        //{
        //    string anggunan = "Tanpa Penjamin";

        //    if(a == 0)
        //    {
        //        anggunan = "Tanpa Penjamin";
        //    }
        //    else if(a  == 1 )
        //    {
        //        anggunan = "Perorangan";
        //    }
        //    else if (a == 2)
        //    {
        //        anggunan = "Perusahaan";
        //    }

        //    return anggunan;
        //}

        public string angsuran(long a)
        {
            string angsuran = "Kecil";

            if (a <= 300000)
            {
                angsuran = "Kecil";
            }
            else if (a >= 300001 && a <= 1500000)
            {
                angsuran = "Sedang";
            }
            else if (a >= 1500001)
            {
                angsuran = "Besar";
            }

            return angsuran;
        }


        //public string saldo(int s)
        //{
        //    string saldo = "Kecil";

        //    if (s >= 1000000  && s <= 5000000)
        //    {
        //        saldo = "Kecil";
        //    }
        //    else if (s >= 5000001 && s <= 10000000)
        //    {
        //        saldo = "Sedang";
        //    }
        //    else if (s > 10000001)
        //    {
        //        saldo = "Besar";
        //    }

        //    return saldo;
        //}

        //public string tunggakanPokok(int tp)
        //{
        //    string tunggakan = "Kecil";

        //    if (tp <= 500000)
        //    {
        //        tunggakan = "Kecil";
        //    }
        //    else if (tp >= 500001 && tp <= 1000000)
        //    {
        //        tunggakan = "Sedang";
        //    }
        //    else if (tp > 1000001)
        //    {
        //        tunggakan = "Besar";
        //    }

        //    return tunggakan;
        //}

        //public string tunggakanBunga(int tb)
        //{
        //    string tunggakan = "Kecil";

        //    if (tb <= 100000)
        //    {
        //        tunggakan = "Kecil";
        //    }
        //    else if (tb >= 100001 && tb <= 1000000)
        //    {
        //        tunggakan = "Sedang";
        //    }
        //    else if (tb > 1000001)
        //    {
        //        tunggakan = "Besar";
        //    }

        //    return tunggakan;
        //}


    }
}
