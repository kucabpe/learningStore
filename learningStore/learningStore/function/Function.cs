using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace learningStore.function
{
    public class Function
    {
        private static string SQL_LIST_MATERIAL = "SELECT p.nazev, p.zkratka, p.zakonceni, m.* FROM uzivatel u JOIN material m ON u.uzID = m.uzID JOIN predmet p ON m.pID = p.pID WHERE u.uzID = $idUser AND m.overeny = 1 ORDER BY u.datum DESC;";

        public string SeznamMaterialu(int uID)
        {
            return "";
        }

    }
}
