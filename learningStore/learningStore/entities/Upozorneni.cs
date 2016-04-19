using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learningStore
{
    public class Upozorneni
    {
	    public int UId { get; set;}
	    public string Predmet { get; set;}
	    public string Zprava { get; set;}
	    public DateTime Datum { get; set;}
	    public Uzivatel Od { get; set;}
	    public Uzivatel Adresat { get; set;}
    }
}
