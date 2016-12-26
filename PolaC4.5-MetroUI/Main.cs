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
    public partial class Main : MetroForm
    {
        Database db = new Database();

        public Main()
        {
            InitializeComponent();
            if (!db.LoadToDataGrid("nasabah", DataGridNasabah))
                MessageBox.Show("Gagal menampilkan data nasabah di data grid");
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            Create formCreate = new Create();
            //this.Enabled = false;
            formCreate.ShowDialog();
            formCreate.Dispose();
        }

        private void DataGridNasabah_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridNasabah_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit
        }
    }
}
