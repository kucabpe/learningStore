using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using learningStore.database.proxy;
using learningStore.database.mssql;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace learningStore.tables
{
    public class PredmetTable : TableProxy<Predmet>
    {

        private static String SQL_SELECT_BY_ID = "SELECT * FROM predmet WHERE pID=@pID";

        public PredmetTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM predmet";
            SQL_INSERT = "INSERT INTO predmet (pID, nazev, zkratka, popis, zakonceni, uzID) VALUES (@pID, @nazev, @zkratka, @popis, @zakonceni, @uzID)";
            SQL_UPDATE = "UPDATE predmet SET nazev=@nazev,zkratka=@zkratka,popis=@popis,zakonceni=@zakonceni,uzID=@uzID WHERE pID=@pID";
            SQL_DELETE = "DELETE predmet WHERE pID=@pID";
        }

        #region CRUD
        public override int Insert(Predmet t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(Predmet t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override Collection<Predmet> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Predmet> predmety = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return predmety;
        }

        public override int Delete(Predmet t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);

            command.Parameters.AddWithValue("@pID", t.PId);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);
            return row;
        }
#endregion

        public Predmet SelectByID(int pID)
        {
            Connecting(null);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BY_ID);
            command.Parameters.AddWithValue("@pID", pID);

            SqlDataReader reader = db.Select(command);

            Collection<Predmet> predmety = Read(reader);
            Predmet predmet = null;

            reader.Close();

            if (predmety.Count == 1)
            {
                predmet = predmety[0];
            }

            Disconnecting(null);

            return predmet;
        }

        protected override void PrepareCommand(SqlCommand command, Predmet t)
        {
            command.Parameters.AddWithValue("@pID", t.PId);
            command.Parameters.AddWithValue("@nazev", t.Nazev);
            command.Parameters.AddWithValue("@zkratka", t.Zkratka);
            command.Parameters.AddWithValue("@popis", t.Popis);
            command.Parameters.AddWithValue("@zakonceni", t.Zakonceni);
            command.Parameters.AddWithValue("@uzID", t.Spravce.UzId);
        }

        protected override Collection<Predmet> Read(SqlDataReader reader)
        {
            Collection<Predmet> predmety = new Collection<Predmet>();

            while (reader.Read())
            {
                int i = -1;
                Predmet p = new Predmet()
                {
                    PId = reader.GetInt32(++i),
                    Nazev = reader.GetString(++i),
                    Zkratka = reader.GetString(++i),
                    Popis = reader.GetString(++i),
                    Zakonceni = reader.GetString(++i),
                    Spravce = new Uzivatel() { UzId = reader.GetInt32(++i) }
                };

                predmety.Add(p);
            }

            return predmety;
        }

    }
}
