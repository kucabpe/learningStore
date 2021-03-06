﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using learningStore.database.mssql;
using learningStore.database.proxy;

namespace learningStore.tables
{
    public class HodnoceniTable : TableProxy<Hodnoceni>
    {
        private static String SQL_SELECT_BYSUB = "SELECT * FROM hodnoceni WHERE pID=@pId;";

        public HodnoceniTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM hodnoceni;";
            SQL_INSERT = "INSERT INTO hodnoceni (hodnoceni, popis, datum, pID, uzID) VALUES (@hodnoceni, @popis, @datum, @pID, @uzID);";
            SQL_UPDATE = "UPDATE hodnoceni SET hodnoceni=@hodnoceni, popis=@popis WHERE pID=@pID AND uzID=@uzID;";
            SQL_DELETE = "DELETE FROM hodnoceni WHERE pID=@pID AND uzID=@uzID;";
        }

        #region CRUD
        public override int Insert(Hodnoceni t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(Hodnoceni t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override Collection<Hodnoceni> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Hodnoceni> hodnoceni = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return hodnoceni;
        }

        public override int Delete(Hodnoceni t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);

            command.Parameters.AddWithValue("@pID", t.Predmet.PId);
            command.Parameters.AddWithValue("@uzID", t.Uzivatel.UzId);

            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        /// <summary>
        /// Funkce 2.3 Seznam hodnocení k předmětu
        /// </summary>
        public Collection<Hodnoceni> SelectBySubject(int pID, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BYSUB);

            command.Parameters.AddWithValue("@pID", pID);
            SqlDataReader reader = db.Select(command);

            Collection<Hodnoceni> hodnoceni = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return hodnoceni;
        }

        /// <summary>
        /// Funkce 2.5 - Smazání hodnocení 
        /// </summary>
        public void DeleteRating(int uzID, int pID, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand commandExec = db.CreateCommand("EXEC SMAZANI_HODNOCENI @idUser, @idObject;");
            commandExec.Parameters.AddWithValue("@idUser", uzID);
            commandExec.Parameters.AddWithValue("@idObject", pID);

            commandExec.ExecuteNonQuery();

            Disconnecting(pDb);
        }

        protected override void PrepareCommand(SqlCommand command, Hodnoceni t)
        {
            command.Parameters.AddWithValue("@hodnoceni", t.Ohodnoceni);
            command.Parameters.AddWithValue("@popis", t.Popis);
            command.Parameters.AddWithValue("@datum", t.Datum.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@pID", t.Predmet.PId);
            command.Parameters.AddWithValue("@uzID", t.Uzivatel.UzId);
        }

        protected override Collection<Hodnoceni> Read(SqlDataReader reader)
        {
            Collection<Hodnoceni> hodnoceni = new Collection<Hodnoceni>();

            UzivatelTable uzivatelTable = new UzivatelTable();
            PredmetTable predmetTable = new PredmetTable();

            while (reader.Read())
            {
                int i = -1;

                Hodnoceni h = new Hodnoceni();
                h.Ohodnoceni = reader.GetInt32(++i);
                h.Popis = reader.GetString(++i);
                h.Datum = reader.GetDateTime(++i);
                h.Predmet = predmetTable.SelectByID(reader.GetInt32(++i));
                h.Uzivatel = uzivatelTable.SelectByID(reader.GetInt32(++i));

                hodnoceni.Add(h);
            }

            return hodnoceni;
        }
    }
}
