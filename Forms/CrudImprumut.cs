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
    public partial class CrudImprumut : UserControl
    {

        public List<Imprumut> DataSource { get; set; }
        public ToolStripStatusLabel StatusLabel { get; set; }

        public CrudImprumut()
        {
            if (DataSource == null)
            {
                DataSource = new List<Imprumut>();
            }

            if (StatusLabel == null)
            {
                StatusLabel = new ToolStripStatusLabel();
            }

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                var parsedId = int.Parse(textBox1.Text);
                var idList = DataSource.Select(v => v.Id).ToList();

                Imprumut imprumut = new Imprumut
                {
                    Id = parsedId,
                    IdCarte = int.Parse(textBox2.Text),
                    IdCititor = int.Parse(textBox3.Text),
                    DataImprumut = textBox4.Text
                };

                if (idList.Contains(parsedId))
                {
                    var index = idList.FindIndex(id => id == parsedId);
                    DataSource[index] = imprumut;
                    updateItemInDb(imprumut);
                }
                else
                {
                    DataSource.Add(imprumut);
                    addToDb(imprumut);
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
            textBox3.Clear();
            textBox4.Clear();
        }

        private void addToDb(Imprumut imprumut)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("INSERT INTO Imprumut (IdCititor, IdCarte, DataImprumut) VALUES (@idCititor, @idCarte, @data); SELECT last_insert_rowid();", conn);
            cmd.Parameters.AddWithValue("@idCititor", imprumut.IdCititor);
            cmd.Parameters.AddWithValue("@idCarte", imprumut.IdCarte);
            cmd.Parameters.AddWithValue("@data", imprumut.DataImprumut);

            cmd.ExecuteNonQuery();

            StatusLabel.Text = $"Imprumutul cu ID {imprumut.Id} a fost adaugat cu succes.";
        }

        private void updateItemInDb(Imprumut imprumut)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("UPDATE Imprumut SET IdCititor = @idCititor, IdCarte = @idCarte, DataImprumut = @data WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@idCititor", imprumut.IdCititor);
            cmd.Parameters.AddWithValue("@idCarte", imprumut.IdCarte);
            cmd.Parameters.AddWithValue("@data", imprumut.DataImprumut);
            cmd.Parameters.AddWithValue("@id", imprumut.Id);

            cmd.ExecuteNonQuery();

            StatusLabel.Text = $"Imprumutul cu ID {imprumut.Id} a fost actualizat cu succes.";
        }

        private void removeFromDb(int id)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("DELETE FROM Imprumut WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            StatusLabel.Text = $"Imprumutul cu ID {id} a fost sters cu succes.";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {

                var id = (listBox1.SelectedItem as Imprumut).Id;
                removeFromDb(id);

                DataSource.RemoveAt(listBox1.SelectedIndex);
                UpdateReaderList();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Imprumut selectedImprumut)
            {
                textBox1.Text = selectedImprumut.Id.ToString();
                textBox2.Text = selectedImprumut.IdCititor.ToString();
                textBox3.Text = selectedImprumut.IdCarte.ToString();
                textBox4.Text = selectedImprumut.DataImprumut;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (var reader in DataSource)
            {
                if (reader.Id.ToString() == textBox1.Text)
                {
                    button1.Text = "Modifica Imprumut";
                    return;
                }
            }

            button1.Text = "Adauga Imprumut";
        }
    }
}
