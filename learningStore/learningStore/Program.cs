using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using learningStore.database;
using learningStore.database.mssql;
using learningStore.database.proxy;
using learningStore.entities;
using learningStore.tables;


namespace learningStore
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseProxy db = new Database();
            db.Connect();

            
            #region Vytvoření uživatelů

            Uzivatel u1 = new Uzivatel()
            {
                UzId = 1,
                Login = "kuc0229",
                Jmeno = "Petr",
                Prijmeni = "Kuča",
                Email = "petr.kuca@vsb.com",
                Registrace = DateTime.Now,
                Role = "admin"
            };

            Uzivatel u2 = new Uzivatel()
            {
                UzId = 2,
                Login = "nov001",
                Jmeno = "Jan",
                Prijmeni = "Novák",
                Email = "jan.novak.st@vsb.com",
                Registrace = DateTime.Now,
                Role = "správce předmětu"
            };

            Uzivatel u3 = new Uzivatel()
            {
                UzId = 3,
                Login = "kat001",
                Jmeno = "Ondřej",
                Prijmeni = "Kat",
                Email = "ondrej.kat.st@vsb.com",
                Registrace = DateTime.Now,
                Role = "student"
            };

            UzivatelTable UzivatelTable = new UzivatelTable();

            try
            {
                UzivatelTable.Insert(u1, db);
                UzivatelTable.Insert(u2, db);
                UzivatelTable.Insert(u3, db);

                Console.WriteLine("Uzivatele byly vytvoreni");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba pri vytvareni uzivatelu " + e);
                db.Close();
                return;
            }
            
            #endregion
            

            #region Vytvoření předmětů

            Predmet p1 = new Predmet()
            {
                PId = 1,
                Nazev = "Matematická analýza",
                Zkratka = "MA1",
                Popis = "V předmětu se nejprve seznámíme  s metodami výpočtu určitých a neurčitých integrálů funkce jedné proměnné a s pojmem nevlastní integrál.  Poté se budeme věnovat diferenciálnímu počtu funkcí více proměnných (pojem funkce více proměnných, parciální derivace, derivace ve směru, gradient, diferenciál, Taylorův polynom, extrémy funkcí více proměnných, aplikace). Nakonec budeme studovat vybrané elementární metody řešení obyčejných diferenciálních rovnic 1. řádu (rovnice se separovanými proměnnými, lineární diferenciální rovnice prvního řádu, aplikace).",
                Zakonceni = "zk.",
                Spravce = u2
            };

            PredmetTable PredmetTable = new PredmetTable();

            try
            {
                PredmetTable.Insert(p1, db);

                Console.WriteLine("Predmety byly vytvoreny");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba pri vytvareni predmetu " + e);
                db.Close();
                return;
            }

            #endregion


            #region Vytvoření hodnocení

            Hodnoceni h1 = new Hodnoceni() 
            {
                Ohodnoceni = 4,
                Popis = "Celkem dorý předmět",
                Datum = DateTime.Now,
                Predmet = p1,
                Uzivatel = u1
            };


            HodnoceniTable HodnoceniTable = new HodnoceniTable();

            try
            {
                HodnoceniTable.Insert(h1, db);

                Console.WriteLine("Hodnoceni bylo pridano");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba pri vkladani hodnoceni " + e);
                db.Close();
                return;
            }

            #endregion


            #region Vložení školy

            Skola s1 = new Skola()
            {
                SId = 1,
                Nazev = "VŠB",
                Adresa = @"17. listopadu 2172/15, 708 00 Ostrava",
                Rektor = "prof. Ing. Ivo Vondrák, CSc."
            };

            SkolaTable SkolaTable = new SkolaTable();

            try
            {
                SkolaTable.Insert(s1, db);

                Console.WriteLine("Skola byla pridana");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba pri vkladani" + e);
                db.Close();
                return;
            }

            #endregion


            #region Vložení oboru

            Obor o = new Obor()
            {
                OId = 1,
                Nazev = "Informatika a výpočetní technika",
                Titul = "Bc.",
                Od = DateTime.Now,
                Do = DateTime.Now.AddYears(1)
            };

            OborTable OborTable = new OborTable();

            try
            {
                OborTable.Insert(o, db);

                Console.WriteLine("Obor byl pridan");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba pri vkladani" + e);
                db.Close();
                return;
            }

            #endregion


            #region Vložení obor do školy

            OborPredmet op1 = new OborPredmet()
            {
                PId = 1,
                OId = 1
            };

            OborPredmetTable OborPredmetTable = new OborPredmetTable();

            OborPredmetTable.Insert(op1, db);

            #endregion


            #region Hroadné upozornění

            UpozorneniTable UpozorneniTable = new UpozorneniTable();

            try
            {
                UpozorneniTable.BulkNotify("Byl vložen nový předmět", "Byl vložen předmět Matematická analýza 1", db);

                Console.WriteLine("Hromadne upozorneni bylo odeslano");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba pri vkladani" + e);
                db.Close();
                return;
                throw;
            }
            #endregion


            db.Close();
            Console.ReadLine();
        }
    }
}
