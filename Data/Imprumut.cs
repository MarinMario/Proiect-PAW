using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class Imprumut
    {
        public int Id { get; set; }
        public int IdCititor { get; set; }
        public int IdCarte { get; set; }
        public string DataImprumut { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Id Carte: {IdCarte}, Id Cititor: {IdCititor}, Data Imprumut: {DataImprumut}";
        }
    }
}
