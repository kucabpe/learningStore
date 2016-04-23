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
    public class OborSkolaTable : TableProxy<OborSkola>
    {
        public OborSkolaTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM oborSkola;";
            SQL_INSERT = "INSERT INTO oborSkola (sID, oID) VALUES (@sID, @oID);";
            SQL_UPDATE = "";
            SQL_DELETE = "DELETE FROM oborSkola WHERE sID=@sID, oID=@oID";
        }

        #region CRUD
        public override int Insert(OborSkola t, DatabaseProxy pDb = null)
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
        public override int Update(OborSkola t, DatabaseProxy pDb = null)
        {
            return -1;
        }

        public override Collection<OborSkola> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<OborSkola> oboryNaSkolach = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return oboryNaSkolach;
        }

        public override int Delete(OborSkola t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        protected override void PrepareCommand(SqlCommand command, OborSkola t)
        {
            command.Parameters.AddWithValue("@sID", t.SId);
            command.Parameters.AddWithValue("@oID", t.OId);
        }

        protected override Collection<OborSkola> Read(SqlDataReader reader)
        {
            Collection<OborSkola> oboryNaSkolach = new Collection<OborSkola>();

            while (reader.Read())
            {
                int i = -1;
                OborSkola os = new OborSkola()
                {
                    SId = reader.GetInt32(++i),
                    OId = reader.GetInt32(++i)
                };

                oboryNaSkolach.Add(os);
            }

            return oboryNaSkolach;
        }
    }
}
