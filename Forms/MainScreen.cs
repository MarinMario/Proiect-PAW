using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Forms
{
    public partial class MainScreen : Form
    {

        List<Carte> Books = new List<Carte>();
        List<Cititor> Readers = new List<Cititor>();
        List<Imprumut> Imprumuturi = new List<Imprumut>();

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            LoadDb();
        }

        void LoadDb()
        {

            using (var connection = new SQLiteConnection(Global.ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Carte";
                using (var command = new SQLiteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Books.Add(new Carte
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Titlu = reader["Titlu"].ToString(),
                            Descriere = reader["Descriere"].ToString(),
                            Autor = reader["Autor"].ToString()
                        });
                    }
                }
            }

            using (var connection = new SQLiteConnection(Global.ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Cititor";
                using (var command = new SQLiteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Readers.Add(new Cititor
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nume = reader["Nume"].ToString()
                        });
                    }
                }
            }

            using (var connection = new SQLiteConnection(Global.ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Imprumut";
                using (var command = new SQLiteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Imprumuturi.Add(new Imprumut
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCarte = Convert.ToInt32(reader["IdCarte"]),
                            IdCititor = Convert.ToInt32(reader["IdCititor"]),
                            DataImprumut = reader["DataImprumut"].ToString()
                        });
                    }
                }
            }

            crudCarte1.DataSource = Books;
            crudCarte1.UpdateBookList();
            crudCarte1.StatusLabel = toolStripStatusLabel1;

            crudCititor1.DataSource = Readers;
            crudCititor1.UpdateReaderList();
            crudCititor1.StatusLabel = toolStripStatusLabel1;

            crudImprumut1.DataSource = Imprumuturi;
            crudImprumut1.UpdateReaderList();
            crudImprumut1.StatusLabel = toolStripStatusLabel1;


            toolStripStatusLabel1.Text = "Incarcarea datelor a fost finalizata cu succes.";
        }


        private void printDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintPreviewDialog previewDialog = new PrintPreviewDialog())
            {
                previewDialog.Document = printDocument1;

                try
                {
                    previewDialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Print preview failed: " + ex.Message);
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            float left = e.MarginBounds.Left;
            float top = e.MarginBounds.Top;
            float lineHeight = font.GetHeight(e.Graphics);
            float currentY = top;

            e.Graphics.DrawString("Lista Carti", font, Brushes.Black, left, currentY);
            currentY += lineHeight;
            foreach (var book in Books)
            {
                e.Graphics.DrawString(book.ToString(), font, Brushes.Black, left, currentY);
                currentY += lineHeight;
            }

            currentY += lineHeight;
            e.Graphics.DrawString("Lista Cititori", font, Brushes.Black, left, currentY);
            currentY += lineHeight;
            foreach (var reader in Readers)
            {
                e.Graphics.DrawString(reader.ToString(), font, Brushes.Black, left, currentY);
                currentY += lineHeight;
            }

            currentY += lineHeight;
            e.Graphics.DrawString("Lista Imprumuturi", font, Brushes.Black, left, currentY);
            currentY += lineHeight;
            foreach (var imprumut in Imprumuturi)
            {
                e.Graphics.DrawString(imprumut.ToString(), font, Brushes.Black, left, currentY);
                currentY += lineHeight;
            }
        }


        private void exportToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Lista Carti");
                foreach (var item in Books)
                {
                    writer.WriteLine(item.ToString());
                }
                writer.WriteLine("");

                writer.WriteLine("Lista Cititori");
                foreach (var item in Readers)
                {
                    writer.WriteLine(item.ToString());
                }
                writer.WriteLine("");

                writer.WriteLine("Lista Imprumuturi");
                foreach (var item in Imprumuturi)
                {
                    writer.WriteLine(item.ToString());
                }
                writer.WriteLine("");
            }

            MessageBox.Show("Fisierul a fost salvat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void exportTXTFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.Title = "Salveaza intr-un fisier text.";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                exportToFile(saveFileDialog.FileName);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;

            if(selectedTab.Name == "tabPage4") 
            {
                barChart1.DataSource = new Dictionary<string, int> 
                {
                    {"Carti", Books.Count },
                    {"Cititori", Readers.Count },
                    {"Imprumuturi", Imprumuturi.Count }
                };
            }
        }
    }
}
