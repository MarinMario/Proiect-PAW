using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class Carte
    {
        public int Id { get; set; }
        public string Titlu { get; set; }
        public string Descriere { get; set; }
        public string Autor { get; set; }

        override public string ToString()
        {
            return $"Id: {Id}, Titlu: {Titlu}, Descriere: {Descriere}, Autor: {Autor}";
        }
    }
}
