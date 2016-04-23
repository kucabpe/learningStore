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
    public class MaterialTable : TableProxy<Material>
    {
        private static String SQL_SELECT_BY_NEW = "SELECT * FROM material WHERE datum > @dateBefYear";
        private static String SQL_SELECT_BY_NON_VERIFIED = "SELECT * FROM material WHERE overeny = 0";
        private static String SQL_SELECT_BY_IDMATERIAL = "SELECT * FROM material WHERE mID = @mID";

        public MaterialTable() :
            base()
        {
            SQL_SELECT = "SELECT * FROM material;";
            SQL_INSERT = "INSERT INTO material (mID, typ, dokument, datum, okruh, overeny, pID, uzID) VALUES (@mID, @typ, @dokument, @datum, @okruh, @overeny, @pID, @uzID);";
            SQL_UPDATE = "UPDATE material SET typ=@typ, dokument=@dokument, datum=@datum, okruh=@okruh, overeny=@overeny WHERE mID=@mID;";
            SQL_DELETE = "DELETE FROM material WHERE mID=@mID;";
        }

        #region CRUD
        public override int Insert(Material t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override int Update(Material t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }

        public override Collection<Material> Select(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Material> materialy = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return materialy;
        }

        public override int Delete(Material t, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, t);
            int row = db.ExecuteNonQuery(command);

            Disconnecting(pDb);

            return row;
        }
        #endregion

        /// <summary>
        /// Funkce 4.3 - Seznam nejnovějších materálů
        /// </summary>
        protected Collection<Material> SelectByNew(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BY_NEW);

            DateTime dateBeforeYear = DateTime.Today.AddYears(-1);
            command.Parameters.AddWithValue("@dateBefYear", dateBeforeYear);

            SqlDataReader reader = db.Select(command);

            Collection<Material> materialy = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return materialy;
        }

        /// <summary>
        /// Funkce 4.4 - Seznam neověřených materálů
        /// </summary>
        protected Collection<Material> SelectByNonVerified(DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BY_NON_VERIFIED);
            SqlDataReader reader = db.Select(command);

            Collection<Material> materialy = Read(reader);
            reader.Close();

            Disconnecting(pDb);

            return materialy;
        }

        /// <summary>
        /// Funkce 4.5 - Detail materiálů
        /// </summary>
        public Material SelectByIdMaterial(int mID, DatabaseProxy pDb = null)
        {

            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_SELECT_BY_IDMATERIAL);
            command.Parameters.AddWithValue("@mID", mID);

            SqlDataReader reader = db.Select(command);

            Collection<Material> materialy = Read(reader);
            Material material = null;

            reader.Close();

            if (materialy.Count == 1)
            {
                material = materialy[0];
            }

            Disconnecting(pDb);

            return material;
        }

        protected override void PrepareCommand(SqlCommand command, Material t)
        {
            command.Parameters.AddWithValue("@mID",t.MId);
            command.Parameters.AddWithValue("@typ",t.Typ);
            command.Parameters.AddWithValue("@dokument",t.Dokument);
            command.Parameters.AddWithValue("@datum",t.Datum.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@okruh",t.Okruh);
            command.Parameters.AddWithValue("@overeny",t.Overeny);
            command.Parameters.AddWithValue("@pID ",t.Predmet.PId);
            command.Parameters.AddWithValue("@uzID",t.Uzivatel.UzId);
        }

        protected override Collection<Material> Read(SqlDataReader reader)
        {
            Collection<Material> materialy = new Collection<Material>();
            
            PredmetTable predmetTable = new PredmetTable();
            UzivatelTable uzivatelTable = new UzivatelTable();


            while (reader.Read())
            {
                int i = -1;
                Material material = new Material();

                material.MId = reader.GetInt32(++i);
                material.Typ = reader.GetString(++i);
                material.Dokument = reader.GetString(++i);
                material.Datum = reader.GetDateTime(++i);
                material.Okruh = reader.GetString(++i);
                material.Overeny = reader.GetInt32(++i);

                material.Predmet = predmetTable.SelectByID(reader.GetInt32(++i));
                material.Uzivatel = uzivatelTable.SelectByID(reader.GetInt32(++i));

                materialy.Add(material);
            }

            return materialy;
        }

    }
}
