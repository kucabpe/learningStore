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
    public class UpozorneniTable : TableProxy<Upozorneni>
    {
        public UpozorneniTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM upozorneni;";
            SQL_INSERT = "INSERT INTO upozorneni (uID, predmet, zprava, datum, od, adresat) VALUES (@uID, @predmet, @zprava, @datum, @od, @adresat);";
            SQL_UPDATE = "";
            SQL_DELETE = "DELETE FROM upozorneni WHERE uID=@uID;";
        }

        #region CRUD
        public override int Insert(Upozorneni t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        /// <summary>
        /// Není dostupné
        /// </summary>
        /// <returns>-1</returns>
        public override int Update(Upozorneni t, DatabaseProxy pDb = null)
        {
            return -1;
        }

        public override Collection<Upozorneni> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Upozorneni> upozorneni = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return upozorneni;
        }

        public override int Delete(Upozorneni t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);

            command.Parameters.AddWithValue("@uID", t.UId);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);
            return row;
        }
        #endregion

        /// <summary>
        /// Funkce 10.4 - Pročištění upozornění
        /// </summary>
        public void CleaningNotify(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand commandExec = db.CreateCommand("EXEC PROCISTENI_REVIZI");
            commandExec.ExecuteNonQuery();

            Disconnecting(pDb);
        }

        /// <summary>
        /// Funkce 10.5 - Hromadné upozornění
        /// </summary>
        public void BulkNotify(String subject, String text, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand commandExec = db.CreateCommand("EXEC HROMADNE_UPOZORNENI @subject, @text;");
            commandExec.Parameters.AddWithValue("@subject", subject);
            commandExec.Parameters.AddWithValue("@text", text);

            commandExec.ExecuteNonQuery();

            Disconnecting(pDb);
        }

        protected override void PrepareCommand(SqlCommand command, Upozorneni t)
        {
            command.Parameters.AddWithValue("@uID", t.UId);
            command.Parameters.AddWithValue("@predmet", t.Predmet);
            command.Parameters.AddWithValue("@zprava", t.Zprava);
            command.Parameters.AddWithValue("@datum", t.Datum.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@od", t.Od.UzId);
            command.Parameters.AddWithValue("@adresa", t.Adresat.UzId);
        }

        protected override Collection<Upozorneni> Read(SqlDataReader reader)
        {
            Collection<Upozorneni> upozorneni = new Collection<Upozorneni>();
            UzivatelTable UzivatelTable = new UzivatelTable();
            
            while (reader.Read())
            {
                int i = -1;
                Upozorneni u = new Upozorneni();

                u.UId = reader.GetInt32(++i);
                u.Predmet = reader.GetString(++i);
                u.Zprava = reader.GetString(++i);
                u.Datum = reader.GetDateTime(++i);
                u.Od = UzivatelTable.SelectByID(reader.GetInt32(++i));
                u.Adresat = UzivatelTable.SelectByID(reader.GetInt32(++i));

                upozorneni.Add(u);
            }

            return upozorneni;
        }
    }
}
