using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace learningStore.tables
{
    public class HodnoceniTable : TableProxy<Hodnoceni>
    {

        public HodnoceniTable()
            : base()
        {
            
        }

        public override int Insert(Hodnoceni t, database.proxy.DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        public override int Update(Hodnoceni t, database.proxy.DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        public override Collection<Hodnoceni> Select(database.proxy.DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Hodnoceni t, database.proxy.DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        protected override void PrepareCommand(System.Data.SqlClient.SqlCommand command, Hodnoceni t)
        {
            throw new NotImplementedException();
        }

        protected override Collection<Hodnoceni> Read(System.Data.SqlClient.SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
