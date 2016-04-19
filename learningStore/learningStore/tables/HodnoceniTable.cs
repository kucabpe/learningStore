using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Collections.ObjectModel;
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
            SQL_INSERT =
             "INSERT INTO hodnoceni (hodnoceni, popis, datum, pID, uzID) VALUES (@hodnoceni, @popis, @datum, @pID, @uzID);";
            SQL_UPDATE =
             "UPDATE hodnoceni SET hodnoceni=@hodnoceni, popis=@popis, datum=@datum WHERE pID=@pID AND uzID=@uzID;";
            SQL_DELETE = "DELETE FROM hodnoceni WHERE pID=@pID AND uzID=@uzID;";
        }

        public override int Insert(Hodnoceni t, DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        public override int Update(Hodnoceni t, DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        public override Collection<Hodnoceni> Select(DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Hodnoceni t, DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        protected override void PrepareCommand(SqlCommand command, Hodnoceni t)
        {
            throw new NotImplementedException();
        }

        protected override Collection<Hodnoceni> Read(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
