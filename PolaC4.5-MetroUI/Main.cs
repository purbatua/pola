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
            FormNasabah formNasabah = new FormNasabah(this);
            formNasabah.ShowDialog();
            formNasabah.Dispose();
        }

        

        private void linkEdit_Click(object sender, EventArgs e)
        {
            int index = DataGridNasabah.SelectedCells[0].RowIndex;
            int id    = int.Parse(DataGridNasabah.Rows[index].Cells[0].Value.ToString());

            string[] nasabah = db.find(id, "nasabah");

            FormNasabah formNasabah = new FormNasabah(this);
            formNasabah.Edit(nasabah);

            formNasabah.ShowDialog();
            formNasabah.Dispose();
        }

        private void linkDelete_Click(object sender, EventArgs e)
        {
            int index = DataGridNasabah.SelectedCells[0].RowIndex;
            int id = int.Parse(DataGridNasabah.Rows[index].Cells[0].Value.ToString());

            DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "Apakah anda ingin menghapus item ini ?", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);


            if(dr == DialogResult.OK)
            {
                Nasabah nasabah = new Nasabah();
                TransformasiNasabah trnasabah = new TransformasiNasabah();

                if(nasabah.remove(id))
                {
                    if (trnasabah.remove(id))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        RefreshDataGrid();
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Data gagal dihapus", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Data gagal dihapus", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
                case 0: // Nasabah
                        linkAdd.Visible = true;
                        linkEdit.Visible = true;
                        linkDelete.Visible = true;
                    break;
                case 1: // Data Transformasi
                    //MetroFramework.MetroMessageBox.Show(this, "TEST");
                    db.LoadToDataGrid("nasabah_trans", DataGridNasabahTransformasi);
                    break;
                case 2: // Training
                    lvTraining.Clear();
                    lvTraining.BeginUpdate();
                    lvTraining.Items.Clear();

                    lvTraining.View = View.Details;

                    lvTraining.Columns.Add("#");
                    lvTraining.Columns.Add("Jenis Kelamin");
                    lvTraining.Columns.Add("Umur");
                    lvTraining.Columns.Add("Pinjaman");
                    lvTraining.Columns.Add("Waktu");
                    lvTraining.Columns.Add("Anggunan");
                    lvTraining.Columns.Add("Angsuran");
                    lvTraining.Columns.Add("Target");
                    //lvTraining.CheckBoxes = true;

                    TransformasiNasabah trnasabah = new TransformasiNasabah();

                    //for(int i=0; i < trnasabah.attributes.Length; i++)
                    //{
                    //    Console.WriteLine(trnasabah.attributes[i]);
                    //}

                    string[][] listItems = trnasabah.all();


                    for (int i = 0; i < listItems.Length; i++)
                    {
                        string[] data = new string[trnasabah.attributes.Length];

                        for (int j = 0; j < listItems[0].Length; j++)
                        {
                            data[j] = listItems[i][j];
                        }

                        ListViewItem lvi;
                        lvi = new ListViewItem(data);

                        lvTraining.Items.Add(lvi);



                        //for (int j = 0; j < trnasabah.attributes.Length; j++)
                        //{
                        //    Console.Write(listItems[i][j]);
                        //}

                        //Console.WriteLine("");
                    }

                    lvTraining.Items[0].Checked = true;


                    lvTraining.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvTraining.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    lvTraining.EndUpdate();
                    break;
                case 3: // Testing
                    break;
                case 4: // Pengaturan
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

        private void btnTraining_Click(object sender, EventArgs e)
        {
            //FormTraining formTraining = new FormTraining();

            //formTraining.ShowDialog();
            //formTraining.Dispose();

            C45 c45 = new C45();

            if(c45.Training())
            {
                MetroFramework.MetroMessageBox.Show(this, "Sukses");
            }

            //int count = lvTraining.CheckedItems.Count;

            //ListView.CheckedListViewItemCollection collection = lvTraining.CheckedItems;


            //TransformasiNasabah trnasabah = new TransformasiNasabah();


            //string[][] listItems = trnasabah.all();
            //string[] id = new string[collection.Count];

            //for (int i = 0; i < listItems.Length; i++)
            //{
            //    string[] data = new string[trnasabah.attributes.Length];

            //    for (int j = 0; j < listItems[0].Length; j++)
            //    {
            //        data[j] = listItems[i][j];
            //    }

            //    ListViewItem lvi = new ListViewItem(data);

            //    if (collection.Contains(lvi))
            //    {
            //        id[i] = lvi.Text;
            //        Console.WriteLine(id[i]);
            //    }

            //    //lvTraining.Items.Add(lvi);
            //}








            //Console.WriteLine("Checked: " + lvTraining.CheckedItems.ToString());
        }

        private void lvTraining_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItem = lvTraining.CheckedItems;


            string[] aray;

            List<Nasabah> list = new List<Nasabah>();

            ///checkedItem.CopyTo(aray, 1);


            Console.WriteLine();
        }
    }
}
