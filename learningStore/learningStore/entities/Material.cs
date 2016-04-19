using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learningStore
{
    public class Material
    {
        public int MId { get; set; }
        public string Typ { get; set; }
        public string Dokument { get; set; }
        public DateTime Datum { get; set; }
        public string Okruh { get; set; }
        public int Overeny { get; set; }
        public Predmet Predmet { get; set; }
        public Uzivatel Uzivatel { get; set; }
    }
}
