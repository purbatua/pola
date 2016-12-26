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
    public partial class Create : MetroForm
    {
        Database db = new Database();

        public Create()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(int.Parse(cbAnggunan.SelectedIndex.ToString()));
            
            
            Nasabah nasabah = new Nasabah(
                db.id("nasabah"), 
                tbNama.Text.ToString(),
                cbJenisKelamin.Text.ToString(),
                int.Parse(tbUmur.Text),
                int.Parse(tbPinjaman.Text),
                int.Parse(tbWaktu.Text),
                int.Parse(cbAnggunan.SelectedIndex.ToString()),
                int.Parse(tbAngsuran.Text),
                int.Parse(tbSaldo.Text),
                int.Parse(tbTunggakanPokok.Text),
                int.Parse(tbTunggakanBunga.Text)
            );

            if(nasabah.save()) {
                //MessageBox.Show("Data berhasil disimpan");
                MetroFramework.MetroMessageBox.Show(this, "Data berhasil disimpan", "Berhasil");
                this.Close(); ;

            } else {
                MetroFramework.MetroMessageBox.Show(this, "Data gagal disimpan", "Berhasil");
            }


            
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Data berhasil disimpan", "Berhasil");
            this.Close();
        }
    }
}
