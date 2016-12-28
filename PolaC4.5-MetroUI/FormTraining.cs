using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace PolaC4._5_MetroUI
{
    public partial class FormTraining : MetroForm
    {
        C45 c45 = new C45();
        TransformasiNasabah trnasabah = new TransformasiNasabah();

        public FormTraining()
        {
            InitializeComponent();

            labelEntropy.Text = c45.Entropy().ToString();


            metroLabel2.Text = c45.Entropy("jenis_kelamin", "Laki-laki").ToString();

            metroLabel3.Text = c45.Entropy("jenis_kelamin", "Perempuan").ToString();

            //Console.WriteLine("Entropy Total: " + C45.EntropyTotal());

            //Console.WriteLine("Total: " + trnasabah.count());
            //Console.WriteLine("Lancar: " + trnasabah.count("Lancar"));
            //Console.WriteLine("Macet: " + trnasabah.count("Macet"));
        }


        public void Calculation()
        {

        }



    }
}
