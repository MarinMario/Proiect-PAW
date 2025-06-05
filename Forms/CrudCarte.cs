using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

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
                Carte book = new Carte
                {
                    Id = parsedId,
                    Titlu = txtTitlu.Text,
                    Descriere = txtDescriere.Text,
                    Autor = txtAutor.Text
                };

                DataSource.Add(book);
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
                DataSource.RemoveAt(listBoxBooks.SelectedIndex);
                UpdateBookList();
            }
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