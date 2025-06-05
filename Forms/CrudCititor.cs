using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Forms
{
    public partial class CrudCititor : UserControl
    {

        public List<Cititor> DataSource { get; set; }
        public CrudCititor()
        {
            if (DataSource == null)
            {
                DataSource = new List<Cititor>();
            }

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                var parsedId = int.Parse(textBox1.Text);
                var idList = DataSource.Select(v => v.Id).ToList();

                Cititor reader = new Cititor
                {
                    Id = parsedId,
                    Nume = textBox2.Text
                };

                if (idList.Contains(parsedId))
                {
                    var index = idList.FindIndex(id => id == parsedId);
                    DataSource[index] = reader;
                    updateItemInDb(reader);
                }
                else
                {
                    DataSource.Add(reader);
                    addToDb(reader);
                }

                UpdateReaderList();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Validation failed: " + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateReaderList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = DataSource;
            listBox1.SelectedIndex = -1;
        }

        private void ClearInputs()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var id = (listBox1.SelectedItem as Cititor).Id;
                deleteFromDb(id);
                DataSource.RemoveAt(listBox1.SelectedIndex);
                UpdateReaderList();
            }
        }

        private int addToDb(Cititor cititor)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("INSERT INTO Cititor (Nume) VALUES (@nume); SELECT last_insert_rowid();", conn);
            cmd.Parameters.AddWithValue("@nume", cititor.Nume);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void updateItemInDb(Cititor cititor)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("UPDATE Cititor SET Nume = @nume WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@nume", cititor.Nume);
            cmd.Parameters.AddWithValue("@id", cititor.Id);

            cmd.ExecuteNonQuery();
        }

        private void deleteFromDb(int id)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("DELETE FROM Cititor WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Cititor selectedReader)
            {
                textBox1.Text = selectedReader.Id.ToString();
                textBox2.Text = selectedReader.Nume;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (var reader in DataSource)
            {
                if (reader.Id.ToString() == textBox1.Text)
                {
                    button1.Text = "Modifica Cititor";
                    return;
                }
            }

            button1.Text = "Adauga Cititor";
        }
    }
}
