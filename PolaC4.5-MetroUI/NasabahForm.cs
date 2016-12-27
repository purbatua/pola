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
    public partial class NasabahForm : MetroForm
    {
        Database db = new Database();
        Main main;
        private bool edit = false;

        public NasabahForm(Main _main)
        {
            InitializeComponent();
            main = _main;
        }

        //public NasabahForm()
        //{
            
        //}

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Nasabah nasabah = new Nasabah(
                int.Parse(tbID.Text) == 0 ? db.id("nasabah") : int.Parse(tbID.Text),
                tbNama.Text.ToString(),
                cbJenisKelamin.Text.ToString(),
                int.Parse(tbUmur.Text),
                int.Parse(tbPinjaman.Text),
                int.Parse(tbWaktu.Text),
                int.Parse(cbAnggunan.SelectedIndex.ToString()),
                int.Parse(tbAngsuran.Text),
                int.Parse(tbSaldo.Text),
                int.Parse(tbTunggakanPokok.Text),
                int.Parse(tbTunggakanBunga.Text),
                cbTarget.Text.ToString()
            );

            if (!edit)
            {
                if (nasabah.save())
                {
                    MetroFramework.MetroMessageBox.Show(this, "Data berhasil disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Close(); ;

                }
                else {
                    MetroFramework.MetroMessageBox.Show(this, "Data gagal disimpan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                if (nasabah.update())
                {
                    MetroFramework.MetroMessageBox.Show(this, "Data berhasil diperbaharui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Close(); ;

                }
                else {
                    MetroFramework.MetroMessageBox.Show(this, "Data gagal diperbaharui", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void Edit(string[] args)
        {
            this.edit = true;

            tbID.Text = args[0];
            tbNama.Text = args[1];
            cbJenisKelamin.SelectedIndex = args[2] == "Laki-laki" ? 0 : 1;
            tbUmur.Text = args[3];
            tbPinjaman.Text = args[4];
            tbWaktu.Text = args[5];
            cbAnggunan.SelectedIndex = int.Parse(args[6]);
            tbAngsuran.Text = args[7];
            tbSaldo.Text = args[8];
            tbTunggakanPokok.Text = args[9];
            tbTunggakanBunga.Text = args[10];
            cbTarget.SelectedIndex = args[11] == "Lancar" ? 0 : 1;
        }

        private void NasabahForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.RefreshDataGrid();
        }
    }
}
