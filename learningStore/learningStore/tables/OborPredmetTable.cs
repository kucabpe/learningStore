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
    public class OborPredmetTable : TableProxy<OborPredmet>
    {
        public OborPredmetTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM oborPredmet;";
            SQL_INSERT = "INSERT INTO oborPredmet (oID, pID) VALUES (@oID, @pID);";
            SQL_UPDATE = "";
            SQL_DELETE = "DELETE FROM oborPredmet WHERE oID=@oID, pID=@pID;";
        }

        #region CRUD
        public override int Insert(OborPredmet t, DatabaseProxy pDb = null)
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
        public override int Update(OborPredmet t, DatabaseProxy pDb = null)
        {
            return -1;
        }

        public override Collection<OborPredmet> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<OborPredmet> predmetyVOboru = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return predmetyVOboru;
        }

        public override int Delete(OborPredmet t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        protected override void PrepareCommand(SqlCommand command, OborPredmet t)
        {
            command.Parameters.AddWithValue("@oID", t.OId);
            command.Parameters.AddWithValue("@pID", t.PId);
        }

        protected override Collection<OborPredmet> Read(SqlDataReader reader)
        {
            Collection<OborPredmet> predmetyVOboru = new Collection<OborPredmet>();

            while (reader.Read())
            {
                int i = -1;
                OborPredmet po = new OborPredmet()
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
