using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class Cititor
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nume: {Nume}";
        }
    }
}
