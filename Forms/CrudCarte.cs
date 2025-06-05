using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Biblioteca.Forms {
    public partial class CrudCarte : UserControl
    {
        public List<Carte> DataSource { get; set; }

        public CrudCarte()
        {
            if (DataSource == null)
            {
                DataSource = new List<Carte>();
            }

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                var parsedId = int.Parse(txtId.Text);
                var idList = DataSource.Select(v => v.Id).ToList();

                Carte book = new Carte
                {
                    Id = parsedId,
                    Titlu = txtTitlu.Text,
                    Descriere = txtDescriere.Text,
                    Autor = txtAutor.Text
                };

                if (idList.Contains(parsedId))
                {
                    var index = idList.FindIndex(id => id == parsedId);
                    DataSource[index] = book;
                    updateItemInDb(book);
                } else
                {
                    DataSource.Add(book);
                    addToDb(book);
                }

                UpdateBookList();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Validation failed: " + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedIndex >= 0)
            {
                var selectedId = (listBoxBooks.SelectedItem as Carte).Id;
                deleteFromDB(selectedId);
                DataSource.RemoveAt(listBoxBooks.SelectedIndex);
                UpdateBookList();
            }
        }

        private void addToDb(Carte carte)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("INSERT INTO Carte (Titlu, Descriere, Autor) VALUES (@titlu, @descriere, @autor)", conn);
            cmd.Parameters.AddWithValue("@titlu", carte.Titlu);
            cmd.Parameters.AddWithValue("@descriere", carte.Descriere);
            cmd.Parameters.AddWithValue("@autor", carte.Autor);

            cmd.ExecuteNonQuery();
        }

        private void updateItemInDb(Carte carte)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("UPDATE Carte SET Titlu = @titlu, Descriere = @descriere, Autor = @autor WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@titlu", carte.Titlu);
            cmd.Parameters.AddWithValue("@descriere", carte.Descriere);
            cmd.Parameters.AddWithValue("@autor", carte.Autor);
            cmd.Parameters.AddWithValue("@id", carte.Id);

            cmd.ExecuteNonQuery();
        }

        private void deleteFromDB(int id)
        {
            using var conn = new SQLiteConnection(Global.ConnectionString);
            conn.Open();

            var cmd = new SQLiteCommand("DELETE FROM Carte WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
        public void UpdateBookList()
        {
            listBoxBooks.DataSource = null;
            listBoxBooks.DataSource = DataSource;
            listBoxBooks.SelectedIndex = -1;
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtTitlu.Clear();
            txtDescriere.Clear();
            txtAutor.Clear();
        }
        private void listBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedItem is Carte selectedBook)
            {
                txtId.Text = selectedBook.Id.ToString();
                txtTitlu.Text = selectedBook.Titlu;
                txtDescriere.Text = selectedBook.Descriere;
                txtAutor.Text = selectedBook.Autor;
            }
        }

        private void CrudCarte_Load(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            foreach (var book in DataSource)
            {
                if(book.Id.ToString() == txtId.Text)
                {
                    btnAdd.Text = "Modifica Carte";
                    return;
                }
            }

            btnAdd.Text = "Adauga Carte";
        }
    }
}