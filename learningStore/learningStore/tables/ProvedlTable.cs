using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using learningStore.database.proxy;
using learningStore.database.mssql;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using learningStore.entities;

namespace learningStore.tables
{
    public class ProvedlTable : TableProxy<Provedl>
    {

        public ProvedlTable()
            : base() 
        {
            SQL_SELECT = "SELECT * FROM provedl;";
            SQL_INSERT = "INSERT INTO provedl (datum, uzID, rID) VALUES (@datum, @uzID, @rID);";
            SQL_UPDATE = "";
            SQL_DELETE = "DELETE FROM provedl WHERE datum=@datum, uzID=@uzID, rID=@rID;";
        }

        #region CRUD
        public override int Insert(Provedl t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        /// <summary>
        /// Není podporováno
        /// </summary>
        /// <param name="t"></param>
        /// <param name="pDb"></param>
        /// <returns>-1</returns>
        public override int Update(Provedl t, DatabaseProxy pDb = null)
        {
            return -1;
        }

        public override Collection<Provedl> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Provedl> zaznamy = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return zaznamy;
        }

        public override int Delete(Provedl t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        public int CleanRevision()
        {
        }

        protected override void PrepareCommand(SqlCommand command, Provedl t)
        {
            command.Parameters.AddWithValue("@datum", t.Datum.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@uzID", t.Uzivatel.UzId);
            command.Parameters.AddWithValue("@rID", t.Revize.Url);
        }

        protected override Collection<Provedl> Read(SqlDataReader reader)
        {
            Collection<Provedl> zaznamy = new Collection<Provedl>();
            
            UzivatelTable uzivatelTable = new UzivatelTable();
            RevizeTable revizeTable = new RevizeTable();

            while (reader.Read())
            {
                int i = -1;

                Provedl p = new Provedl();
                p.Datum = reader.GetDateTime(++i);
                p.Uzivatel = uzivatelTable.SelectByID(reader.GetInt32(++i));
                p.Revize = revizeTable.SelectByID(reader.GetInt32(++i));

                zaznamy.Add(p);
            }

            return zaznamy;
        }
    }
}
