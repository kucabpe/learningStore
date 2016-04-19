using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learningStore
{
    public class Hodnoceni
    {
	    public int Ohodnoceni { get; set;}
	    public string Popis { get; set;}
	    public DateTime Datum { get; set;}
	    public Predmet Predmet { get; set;}
	    public Uzivatel Uzivatel { get; set;}
    }
}
