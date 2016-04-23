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
    class OborTable : TableProxy<Obor>
    {
        private static string SQL_SELECT_BY_CURRENT_BRANCH = "SELECT * FROM obor o WHERE o.do = NULL OR o.do >= @currDate";

        public OborTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM obor";
            SQL_INSERT = "INSERT INTO obor (oID, nazev, titul, od, do) VALUES (@oID, @nazev, @titul, @od, @do)";
            SQL_UPDATE = "UPDATE obor SET nazev=@nazev, titul=@titul, od=@od, do=@do WHERE oID=@oID";
            SQL_DELETE = "DELETE FROM obor WHERE oID=@oID";
        }

        #region CRUD
        public override int Insert(Obor t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);

            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(Obor t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, t);

            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        
        public override Collection<Obor> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Obor> obory = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return obory;
        }

        public override int Delete(Obor t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            command.Parameters.AddWithValue("@oID", t.OId);

            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        /// <summary>
        /// Funkce 6.3 - Seznam aktuálních oborů
        /// </summary>
        protected Collection<Obor> SelectByCurrentBranch(DatabaseProxy pDb) 
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BY_CURRENT_BRANCH);
            command.Parameters.AddWithValue("@currDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader reader = db.Select(command);

            Collection<Obor> obory = Read(reader);
            reader.Close();

            Disconnecting(pDb);
            return obory;
        }

        protected override void PrepareCommand(SqlCommand command, Obor t)
        {
            
            command.Parameters.AddWithValue("@oID",t.OId);
            command.Parameters.AddWithValue("@nazev",t.Nazev);
            command.Parameters.AddWithValue("@titul",t.Titul);
            command.Parameters.AddWithValue("@od",t.Od.ToString("yyyy-MM-dd"));
            
            string doAttr = (t.Do.HasValue) ? t.Do.Value.ToString("yyyy-MM-dd") : "NULL";
            command.Parameters.AddWithValue("@do", doAttr);
        }

        protected override Collection<Obor> Read(SqlDataReader reader)
        {
            Collection<Obor> obory = new Collection<Obor>();

            while (reader.Read())
            {
                int i = -1;
                Obor o = new Obor();
                o.OId = reader.GetInt32(++i);
                o.Nazev = reader.GetString(++i);
                o.Titul = reader.GetString(++i);
                o.Od = reader.GetDateTime(++i);
                DateTime? doAttr = ((doAttr = reader.GetDateTime(++i)) != null) ? doAttr : default(DateTime?);
                o.Do = doAttr.Value;

                obory.Add(o);
            }

            return obory;
        }
    }
}
