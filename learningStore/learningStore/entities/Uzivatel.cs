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

        public override string ToString()
        {
            return String.Format("Uzivatel[{0} {1} {2} {3} {4} {5} {6}]", UzId, Login, Jmeno, Prijmeni, Email, Registrace, Role);
        }
    }
}
