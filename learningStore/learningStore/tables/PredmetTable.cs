using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using learningStore.database.mssql;
using learningStore.database.proxy;

namespace learningStore.tables
{
    public class PredmetTable
    {
        #region SQL
        private static String SQL_SELECT = "SELECT * FROM predmet;";
        private static String SQL_SELECT_BYID = "SELECT * FROM predmet WHERE pID=@pID;";
        private static String SQL_INSERT =
            "INSERT INTO predmet (pID, nazev, zkratka, popis, zakonceni, uzID) VALUES (@pID, @nazev, @zkratka, @popis, @zakonceni, @uzID);";
        private static String SQL_UPDATE =
            "UPDATE predmet SET pID=@pID, nazev=@nazev, zkratka=@zkratka, popis=@popis, zakonceni=@zakonceni, uzID=@uzID WHERE pID=@pID;";
        private static String SQL_DELETE =
            "DELETE FROM predmet WHERE pID=@pID;";
        #endregion

        #region CRUD
        public int Insert(Predmet predmet, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, predmet);
            int row = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                pDb.Close();
            }

            return row;
        }

        public int Update(Predmet predmet, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, predmet);
            int row = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                pDb.Close();
            }

            return row;
        }

        public Collection<Predmet> Select(DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Predmet> predmety = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return predmety;
        }

        public int Delete(Predmet predmet, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_DELETE);

            command.Parameters.AddWithValue("@pID", predmet.PId);

            int row = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return row;
        }
        #endregion

        public Predmet SelectByID(int pID, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_BYID);
            
            command.Parameters.AddWithValue("@pID", pID);
            SqlDataReader reader = db.Select(command);

            Collection<Predmet> predmety = Read(reader);
            Predmet predmet = null;
            reader.Close();

            if (predmety.Count == 1)
            {
                predmet = predmety[0];
            }

            if (pDb == null)
            {
                db.Close();
            }

            return predmet;
        }

        private void PrepareCommand(SqlCommand command, Predmet predmet)
        {
            command.Parameters.AddWithValue("@pID,",predmet.PId);
            command.Parameters.AddWithValue("@nazev,",predmet.Nazev);
            command.Parameters.AddWithValue("@zkratka,",predmet.Zkratka);
            command.Parameters.AddWithValue("@popis,",predmet.Popis);
            command.Parameters.AddWithValue("@zakonceni,",predmet.Zakonceni);
            command.Parameters.AddWithValue("@uzID",predmet.Spravce.UzId);
        }

        private Collection<Predmet> Read(SqlDataReader reader)
        {
            Collection<Predmet> predmety= new Collection<Predmet>();

            while (reader.Read())
            {
                int i = -1;

                Predmet predmet = new Predmet();
                predmet.PId = reader.GetInt32(++i);
                predmet.Nazev = reader.GetString(++i);
                predmet.Zkratka = reader.GetString(++i);
                predmet.Popis = reader.GetString(++i);
                predmet.Zakonceni = reader.GetString(++i);
                
                int uzID = reader.GetInt32(++i);

                predmet.Spravce = new UzivatelTable().SelectByID(uzID);
            }

            return predmety;
        }
    }
}
