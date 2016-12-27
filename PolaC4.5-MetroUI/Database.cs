using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace PolaC4._5_MetroUI
{
    class Database
    {
        public MySqlConnection connect = new MySqlConnection("Server=localhost;Uid=root;Database=pola_c45;Password=;");

        public bool openConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("Tidak dapat terhubung ke server");
                        break;
                    case 1045:
                        MessageBox.Show("Username atau Password database anda salah");
                        break;
                    default:
                        MessageBox.Show("Connection Failed");
                        break;
                }
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                connect.Close();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool LoadToDataGrid(string tabel, DataGridView dgv)
        {
            string query = "SELECT * FROM " + tabel + ";";
            bool status = false;

            try
            {
                if (openConnection())
                {
                    MySqlDataAdapter data = new MySqlDataAdapter(query, connect);
                    DataSet ds = new DataSet();
                    data.Fill(ds, "lala");
                    dgv.DataSource = ds.Tables["lala"];

                    status = true;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            finally
            {
                closeConnection();
            }

            return status;

        }

        public bool insert(string tabel, string nilai)
        {
            string query = "INSERT INTO " + tabel + " VALUES (" + nilai + ");";
            bool status = false;

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    status = true;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            finally
            {
                closeConnection();
            }

            return status;

        }

        public bool delete(string tabel, string where)
        {
            string query = "DELETE FROM " + tabel + " WHERE " + where;
            bool status = false;

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    status = true;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            finally
            {
                closeConnection();
            }

            return status;

        }

        public bool update(string tabel, string nilai, string where)
        {
            string query = "UPDATE " + tabel + " SET " + nilai + " WHERE " + where;
            bool status = false;

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    status = true;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            finally
            {
                closeConnection();
            }

            return status;

        }

        public string[] find(int id, string table)
        {
            string query = "SELECT * FROM " + table + " WHERE id=" + id + "";
            string[] result = new string[12];

            Console.WriteLine(query);

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    MySqlDataReader reader = command.ExecuteReader();

                    int i = 0;
                    while (reader.Read())
                    {

                        result[0] = GetDBString("id", reader);
                        result[1] = GetDBString("nama", reader);
                        result[2] = GetDBString("jenis_kelamin", reader);
                        result[3] = GetDBString("umur", reader);
                        result[4] = GetDBString("pinjaman", reader);
                        result[5] = GetDBString("waktu", reader);
                        result[6] = GetDBString("anggunan", reader);
                        result[7] = GetDBString("angsuran", reader);
                        result[8] = GetDBString("saldo", reader);
                        result[9] = GetDBString("tunggakan_pokok", reader);
                        result[10] = GetDBString("tunggakan_bunga", reader);
                        result[11] = GetDBString("target", reader);
                        i++;
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                closeConnection();
            }

            return result;
        }

        private string GetDBString(string SqlFieldName, MySqlDataReader Reader)
        {
            return Reader[SqlFieldName].Equals(DBNull.Value) ? String.Empty : Reader.GetString(SqlFieldName);
        }


        public string selectField(string selection, string tabel, string where)
        {
            string query = "SELECT " + selection + " FROM " + tabel + " WHERE " + where + ";";
            string nilai = "";

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        nilai = reader.GetString(0);
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                closeConnection();
            }

            return nilai;
        }

        public string[] selectColumn(string column, string table)
        {
            string query = "SELECT " + column + " FROM " + table;
            string[] result = new string[this.count(table)];

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    MySqlDataReader reader = command.ExecuteReader();

                    int i = 0;
                    while (reader.Read())
                    {
                        result[i] = reader.GetString(0);

                        i++;
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Query gagal di eksekusi");
            }

            closeConnection();
            return result;
        }

        public string[] SelectAllField(string selection, string tabel)
        {
            string query = "SELECT " + selection + " FROM " + tabel;
            string[] hasil = new string[this.count(tabel)];
            int i = 0;

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        hasil[i] = reader.GetString(0);
                        i++;
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Query gagal di eksekusi");
            }

            closeConnection();
            return hasil;
        }

        public int count(string tabel)
        {
            string query = "SELECT COUNT(*) FROM " + tabel + ";";
            int count = 0;

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    count = int.Parse(command.ExecuteScalar().ToString());
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                count = 0;
            }
            finally
            {
                closeConnection();
            }

            return count;
        }

        public int count(string tabel, string where)
        {
            string query = "SELECT COUNT(*) FROM " + tabel + " WHERE " + where;
            int count = 0;

            try
            {
                if (openConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connect);
                    count = int.Parse(command.ExecuteScalar().ToString());
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                count = 0;
            }
            finally
            {
                closeConnection();
            }

            return count;
        }

        public int id(string tabel)
        {
            int id = 1;
            string query = "SELECT id FROM " + tabel;

            try
            {
                if(openConnection()) {
                    MySqlCommand countCMD = new MySqlCommand("SELECT COUNT(*) FROM " + tabel, connect);
                    int count = int.Parse(countCMD.ExecuteScalar().ToString());

                    if(count != null)
                    {
                        MySqlCommand command = new MySqlCommand("SELECT id FROM " + tabel + " WHERE id=" + count, connect);
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            id = int.Parse(reader.GetString(0)) + 1;
                        }
                    }

                    // select count tabel
                    // select last row
                    // take column 1 (id) value
                }
            } catch (MySqlException) {
                MessageBox.Show("Query gagal di eksekusi");
                return 0;
            }

            closeConnection();

            return id;
        }

    }
}
