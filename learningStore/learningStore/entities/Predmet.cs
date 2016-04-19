using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learningStore
{
    public class Predmet
    {
	    public int PId { get; set;}
	    public string Nazev { get; set;}
	    public string Zkratka { get; set;}
	    public string Popis { get; set;}
	    public string Zakonceni { get; set;}
	    public Uzivatel Spravce { get; set;}
    }

}
