using Biblioteca.Data;
using Biblioteca.Forms;
using System.Data.SQLite;

namespace Biblioteca
{

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            CreateDatabase();
            
            ApplicationConfiguration.Initialize();
            Application.Run(new MainScreen());
        }

        private static void CreateDatabase()
        {
            if (!File.Exists("Biblioteca.db"))
            {
                SQLiteConnection.CreateFile("Biblioteca.db");

                using (var connection = new SQLiteConnection(Global.ConnectionString))
                {
                    connection.Open();
                    string createCarte =
                        @"CREATE TABLE Carte (
                            Id INTEGER PRIMARY KEY,
                            Titlu TEXT NOT NULL,
                            Descriere TEXT,
                            Autor TEXT NOT NULL
                        )";

                    string createCititor =
                        @"CREATE TABLE Cititor (
                        Id INTEGER PRIMARY KEY,
                        Nume TEXT NOT NULL
                    )";

                    string createImprumut =
                        @"CREATE TABLE Imprumut (
                        Id INTEGER PRIMARY KEY,
                        IdCititor INTEGER NOT NULL,
                        IdCarte INTEGER NOT NULL,
                        DataImprumut TEXT NOT NULL,

                        FOREIGN KEY (IdCititor) REFERENCES Cititor(Id),
                        FOREIGN KEY (IdCarte) REFERENCES Carte(Id)
                    )";

                    SQLiteCommand command1 = new SQLiteCommand(createCarte, connection);
                    SQLiteCommand command2 = new SQLiteCommand(createCititor, connection);
                    SQLiteCommand command3 = new SQLiteCommand(createImprumut, connection);

                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();

                }
            }
        }
    }
}