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
    public class UzivatelTable
    {
        #region SQL
        private static String SQL_SELECT = "SELECT * FROM uzivatel;";
        private static String SQL_SELECT_BYID = "SELECT * FROM uzivatel WHERE uzID=@id;";
        private static String SQL_INSERT =
            "INSERT INTO uzivatel (uzID, login, jmeno, prijmeni, email, registrace, role) VALUES (@id, @login, @jmeno, @prijmeni, @email, @registrace, @role);";
        private static String SQL_UPDATE =
            "UPDATE uzivatel SET login=@login, jmeno=@jmeno, prijmeni=@primeni, email=@email, role=@role WHERE uzID=@id;";
        private static String SQL_DELETE =
            "DELETE FROM uzivatel WHERE uzID=@id;";
        #endregion

        #region CRUD
        public int Insert(Uzivatel uzivatel, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, uzivatel);
            int row = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                pDb.Close();
            }

            return row;
        }

        public int Update(Uzivatel uzivatel, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, uzivatel);
            int row = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                pDb.Close();
            }

            return row;
        }

        public Collection<Uzivatel> Select(DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Uzivatel> uzivatele = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return uzivatele;
        }

        public int Delete(Uzivatel uzivatel, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_DELETE);

            command.Parameters.AddWithValue("@id", uzivatel.UzId);
            int row = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return row;
        }
        #endregion

        #region Detail uživatele
        public Uzivatel SelectByID(int id, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_BYID);
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = db.Select(command);

            Collection<Uzivatel> uzivatele = Read(reader);
            Uzivatel uzivatel = null;

            if (uzivatele.Count == 1)
            {
                uzivatel = uzivatele[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return uzivatel;
        }
        #endregion

        private void PrepareCommand(SqlCommand command, Uzivatel uzivatel)
        {
            command.Parameters.AddWithValue("@id", uzivatel.UzId);
            command.Parameters.AddWithValue("@login", uzivatel.Login);
            command.Parameters.AddWithValue("@jmeno", uzivatel.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", uzivatel.Prijmeni);
            command.Parameters.AddWithValue("@email", uzivatel.Email);
            command.Parameters.AddWithValue("@registrace", uzivatel.Registrace.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@role", uzivatel.Role);
        }

        private Collection<Uzivatel> Read(SqlDataReader reader)
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
