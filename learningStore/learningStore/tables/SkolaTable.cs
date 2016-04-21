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
    public class SkolaTable : TableProxy<Skola>
    {

        public SkolaTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM skola;";
            SQL_INSERT = "INSERT INTO skola (sID, nazev, adresa, rektor) VALUES (@sID, @nazev, @adresa, @rektor);";
            SQL_UPDATE = "UPDATE skola SET nazev=@nazev, adresa=@adresa, rektor=@rektor WHERE sID=@sID;";
            SQL_DELETE = "DELETE FROM skola WHERE sID=@sID;";
        }

        #region CRUD
        public override int Insert(Skola t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(Skola t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override Collection<Skola> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Skola> skoly = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return skoly;
        }

        public override int Delete(Skola t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        protected override void PrepareCommand(SqlCommand command, Skola t)
        {
            command.Parameters.AddWithValue("@sID", t.SId);
            command.Parameters.AddWithValue("@nazev", t.Nazev);
            command.Parameters.AddWithValue("@adresa", t.Adresa);
            command.Parameters.AddWithValue("@rektor", t.Rektor);
        }

        protected override Collection<Skola> Read(SqlDataReader reader)
        {
            Collection<Skola> skoly = new Collection<Skola>();

            while (reader.Read())
            {
                int i = -1;
                Skola skola = new Skola() 
                {
                    SId = reader.GetInt32(++i),
                    Nazev = reader.GetString(++i),
                    Adresa = reader.GetString(++i),
                    Rektor = reader.GetString(++i)
                };

                skoly.Add(skola);
            }

            return skoly;
        }
    }
}
