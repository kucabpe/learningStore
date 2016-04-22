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
    public class PredmetOborTable : TableProxy<PredmetObor>
    {
        public PredmetOborTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM predmetObor;";
            SQL_INSERT = "INSERT INTO predmetObor (oID, pID) VALUES (@oID, @pID);";
            SQL_UPDATE = "";
            SQL_DELETE = "DELETE FROM predmetObor WHERE oID=@oID, pID=@pID;";
        }

        #region CRUD
        public override int Insert(PredmetObor t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(PredmetObor t, DatabaseProxy pDb = null)
        {
            return 0;
        }

        public override Collection<PredmetObor> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<PredmetObor> predmetyVOboru = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return predmetyVOboru;
        }

        public override int Delete(PredmetObor t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        protected override void PrepareCommand(SqlCommand command, PredmetObor t)
        {
            command.Parameters.AddWithValue("@oID", t.OId);
            command.Parameters.AddWithValue("@pID", t.PId);
        }

        protected override Collection<PredmetObor> Read(SqlDataReader reader)
        {
            Collection<PredmetObor> predmetyVOboru = new Collection<PredmetObor>();

            while (reader.Read())
            {
                int i = -1;
                PredmetObor po = new PredmetObor()
                {
                    OId = reader.GetInt32(++i),
                    PId = reader.GetInt32(++i)
                };

                predmetyVOboru.Add(po);
            }

            return predmetyVOboru;
        }
    }
}
