using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learningStore
{
    public class Uzivatel
    {
	    public int UzId { get; set;}
	    public string Login { get; set;}
	    public string Jmeno { get; set;}
	    public string Prijmeni { get; set;}
	    public string Email { get; set;}
	    public DateTime Registrace { get; set;}
	    public string Role { get; set;}
    }

}
