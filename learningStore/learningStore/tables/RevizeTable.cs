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
    public class RevizeTable : TableProxy<Revize>
    {
        private static String SQL_SELECT_BYID = "SELECT * FROM revize WHERE rID=@rID;";
        private static String SQL_SELECT_BYMATERIAL = "SELECT rID [rid] FROM revize WHERE mID=@mID;";

        public RevizeTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM revize;";
            SQL_INSERT = "INSERT INTO revize (rID, popis, mID, url) VALUES (@rID, @popis, @mID, @url);";
            SQL_UPDATE = "UPDATE revize SET popis=@popis, mID=@mID, url=@url WHERE rID=@rID;";
            SQL_DELETE = "DELETE FROM revize WHERE rID=@rID;";
        }

        #region CRUD
        public override int Insert(Revize t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);
            
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(Revize t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override Collection<Revize> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Revize> revize = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return revize;
        }

        public override int Delete(Revize t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        public Revize SelectByID(int rID)
        {
            Connecting(null);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BYID);
            command.Parameters.AddWithValue("@rID", rID);

            SqlDataReader reader = db.Select(command);

            Collection<Revize> revize = Read(reader);
            reader.Close();

            Revize r = null;

            if (revize.Count == 1)
            {
                r = revize[0];
            }

            Disconnecting(null);

            return r;
        }

        public int SelectByMaterial(int mID)
        {
            Connecting(null);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BYMATERIAL);
            command.Parameters.AddWithValue("@mID", mID);

            SqlDataReader reader = db.Select(command);

            int rId = -1;

            if(reader.Read())
                rId = reader.GetInt32(0);

            reader.Close();

            Disconnecting(null);

            return rId;
        }

        /// <summary>
        /// Procedura 5.5 - Pročištění revizí
        /// </summary>
        /// <param name="pDb"></param>
        public void CleaningRevise(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand commandExec = db.CreateCommand("EXEC PROCISTENI_REVIZI");
            
            commandExec.ExecuteNonQuery();

            Disconnecting(pDb);
        }

        protected override void PrepareCommand(SqlCommand command, Revize t)
        {            
            command.Parameters.AddWithValue("@rID", t.RId);
            command.Parameters.AddWithValue("@popis", t.Popis);
            command.Parameters.AddWithValue("@mID", t.Material.MId);
            command.Parameters.AddWithValue("@url", t.Url);
        }

        protected override Collection<Revize> Read(SqlDataReader reader)
        {
            Collection<Revize> revize = new Collection<Revize>();
            MaterialTable materialTable = new MaterialTable();

            while (reader.Read())
            {
                int i = -1;
                Revize r = new Revize();

                r.RId = reader.GetInt32(++i);
                r.Popis = reader.GetString(++i);
                r.Url = reader.GetString(++i);
                r.Material = materialTable.SelectByIdMaterial(reader.GetInt32((++i)));
                
                revize.Add(r);
            }

            return revize;
        }
    }
}
