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
    public partial class MainScreen : Form
    {
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
            var books = new List<Carte>();
            var readers = new List<Cititor>();
            var imprumuturi = new List<Imprumut>();

            using (var connection = new SQLiteConnection(Global.ConnectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Carte";
                using (var command = new SQLiteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Carte
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
                        readers.Add(new Cititor
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
                        imprumuturi.Add(new Imprumut
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCarte = Convert.ToInt32(reader["IdCarte"]),
                            IdCititor = Convert.ToInt32(reader["IdCititor"]),
                            DataImprumut = reader["DataImprumut"].ToString()
                        });
                    }
                }
            }

            crudCarte1.DataSource = books;
            crudCititor1.DataSource = readers;
            crudImprumut1.DataSource = imprumuturi;
            crudCarte1.UpdateBookList();
            crudCititor1.UpdateReaderList();
            crudImprumut1.UpdateReaderList();
        }
    }
}
