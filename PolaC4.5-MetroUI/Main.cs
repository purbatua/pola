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
            MainTab.SelectedIndex = 0;

            if (!db.LoadToDataGrid("nasabah", DataGridNasabah))
                MessageBox.Show("Gagal menampilkan data nasabah di data grid");
        }

        //private void btnTambah_Click(object sender, EventArgs e)
        //{
        //    NasabahForm formCreate = new NasabahForm();
        //    formCreate.ShowDialog();
        //    formCreate.Dispose();
        //}

        private void DataGridNasabah_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridNasabah_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit
        }

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    int index = DataGridNasabah.SelectedCells[0].RowIndex;
        //    int id = int.Parse(DataGridNasabah.Rows[index].Cells[0].Value.ToString());
        //    //string clausa = "id=" + DataGridNasabah.Rows[index].Cells[0].Value.ToString();

        //    string[] nasabah = db.find(id, "nasabah");

        //    //for(int i = 0; i < nasabah.Length; i++)
        //    //{
        //    //    Console.WriteLine(nasabah[i]);

        //    //}

        //    NasabahForm formCreate = new NasabahForm(this);
        //    formCreate.Edit(nasabah);

        //    formCreate.ShowDialog();
        //    formCreate.Dispose();



        //    //Console.WriteLine("index: " + clausa);
        //}

        private void linkAdd_Click(object sender, EventArgs e)
        {
            NasabahForm formNasabah = new NasabahForm(this);
            formNasabah.ShowDialog();
            formNasabah.Dispose();
        }

        

        private void linkEdit_Click(object sender, EventArgs e)
        {
            int index = DataGridNasabah.SelectedCells[0].RowIndex;
            int id    = int.Parse(DataGridNasabah.Rows[index].Cells[0].Value.ToString());

            string[] nasabah = db.find(id, "nasabah");

            NasabahForm formNasabah = new NasabahForm(this);
            formNasabah.Edit(nasabah);

            formNasabah.ShowDialog();
            formNasabah.Dispose();
        }

        private void linkDelete_Click(object sender, EventArgs e)
        {

        }

        public void RefreshDataGrid()
        {
            //Console.Write("REFRESH");
            db.LoadToDataGrid("nasabah", DataGridNasabah);
        }

        private void tabTransformasi_Click(object sender, EventArgs e)
        {
            db.LoadToDataGrid("nasabah_trans", DataGridNasabahTransformasi);
        }

        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkAdd.Visible = false;
            linkEdit.Visible = false;
            linkDelete.Visible = false;

            int index = MainTab.SelectedIndex;

            switch (index)
            {
                case 0:
                        linkAdd.Visible = true;
                        linkEdit.Visible = true;
                        linkDelete.Visible = true;
                    break;
                case 1:
                    //MetroFramework.MetroMessageBox.Show(this, "TEST");
                    db.LoadToDataGrid("nasabah_trans", DataGridNasabahTransformasi);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        private void checkTrainingAcak_CheckedChanged(object sender, EventArgs e)
        {
            if(checkTrainingAcak.Checked)
            {
                tbDataTraining.Enabled = false;
                btnSimpanTraining.Enabled = false;
            }
            else
            {
                tbDataTraining.Enabled = true;
                btnSimpanTraining.Enabled = true;
            }
        }

        private void checkTestingAcak_CheckedChanged(object sender, EventArgs e)
        {
            if(checkTestingAcak.Checked)
            {
                tbDataTesting.Enabled = false;
                btnSimpanTesting.Enabled = false;
            }
            else
            {
                tbDataTesting.Enabled = true;
                btnSimpanTesting.Enabled = true;
            }
        }
    }
}
