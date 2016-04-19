using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using learningStore.database.proxy;
using learningStore.database.mssql;
using System.Data.SqlClient;

namespace learningStore.tables
{
    public class UzivatelTable :  TableProxy<Uzivatel>
    {
        private static String SQL_SELECT_BYID = "SELECT * FROM uzivatel WHERE uzID=@uzID";

        public UzivatelTable()
            : base()
        {
            SQL_SELECT = "SELECT * FROM uzivatel;";
            SQL_INSERT = "INSERT INTO uzivatel (uzID, login, jmeno, prijmeni, email, registrace, role) VALUES (@id, @login, @jmeno, @prijmeni, @email, @registrace, @role);";
            SQL_UPDATE = "UPDATE uzivatel SET login=@login, jmeno=@jmeno, prijmeni=@prijmeni, email=@email, role=@role WHERE uzID=@uzID;";
            SQL_DELETE = "DELETE FROM uzivatel WHERE uzID=@uzID;";

        }


        #region CRUD
        public override int Insert(Uzivatel t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(Uzivatel t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override Collection<Uzivatel> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Uzivatel> uzivatele = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return uzivatele;
        }

        public override int Delete(Uzivatel t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);

            command.Parameters.AddWithValue("@uzID", t.UzId);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);
            return row;
        }
        #endregion

        public Uzivatel SelectByID(int ID, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BYID);
            command.Parameters.AddWithValue("@uzID", ID);

            SqlDataReader reader = db.Select(command);

            Collection<Uzivatel> uzivatele = Read(reader);
            Uzivatel uzivatel = null;

            reader.Close();

            if (uzivatele.Count == 1)
            {
                uzivatel = uzivatele[0];
            }

            Disconnecting(pDb);

            return uzivatel;
        }

        protected override void PrepareCommand(SqlCommand command, Uzivatel t)
        {
            command.Parameters.AddWithValue("@uzID", t.UzId);
            command.Parameters.AddWithValue("@login", t.Login);
            command.Parameters.AddWithValue("@jmeno", t.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", t.Prijmeni);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@registrace", t.Registrace.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@role", t.Role);
        }

        protected override Collection<Uzivatel> Read(SqlDataReader reader)
        {
            Collection<Uzivatel> uzivatele = new Collection<Uzivatel>();

            while (reader.Read())
            {
                int i = -1;
                Uzivatel uz = new Uzivatel()
                {
                    UzId = reader.GetInt32(++i),
                    Login = reader.GetString(++i),
                    Jmeno = reader.GetString(++i),
                    Prijmeni = reader.GetString(++i),
                    Email = reader.GetString(++i),
                    Registrace = reader.GetDateTime(++i),
                    Role = reader.GetString(++i)
                };

                uzivatele.Add(uz);
            }

            return uzivatele;
        }
    }
}
