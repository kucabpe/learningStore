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
    public class UpozorneniTable : TableProxy<Upozorneni>
    {
        public UpozorneniTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM upozorneni;";
            SQL_INSERT = "INSERT INTO upozorneni (uID, predmet, zprava, datum, od, adresat) VALUES (@uID, @predmet, @zprava, @datum, @od, @adresat);";
//            SQL_UPDATE = "UPDATE uzivatel SET login=@login, jmeno=@jmeno, prijmeni=@prijmeni, email=@email, role=@role WHERE uzID=@uzID;";
            SQL_DELETE = "DELETE FROM uzivatel WHERE uID=@uID;";
        }

        #region CRUD
        public override int Insert(Upozorneni t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(Upozorneni t, DatabaseProxy pDb = null)
        {
            return 0;
        }

        public override Collection<Upozorneni> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Upozorneni> upozorneni = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return upozorneni;
        }

        public override int Delete(Upozorneni t, DatabaseProxy pDb = null)
        {
            throw new NotImplementedException();
        }

        protected override void PrepareCommand(SqlCommand command, Upozorneni t)
        {
            throw new NotImplementedException();
        }

        protected override Collection<Upozorneni> Read(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
