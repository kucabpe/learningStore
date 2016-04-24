using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using learningStore.database.proxy;
using learningStore.database.mssql;

namespace learningStore.function
{
    public class Function
    {
        private Database db;

        private static string SQL_LIST_MATERIAL = "SELECT p.nazev, p.zkratka, p.zakonceni, m.* FROM uzivatel u JOIN material m ON u.uzID = m.uzID JOIN predmet p ON m.pID = p.pID WHERE u.uzID = $idUser AND m.overeny = 1 ORDER BY u.datum DESC;";
        private static string SQL_LIST_BEST_RATING = "SELECT p.nazev, p.zkratka, showRating(h.hodnoceni) as [Stars], h.popis FROM uzivatel u JOIN hodnoceni h ON u.uzID = h.uzID JOIN predmet p ON h.pID = p.pID WHERE u.uzID = $idUser AND h.hodnoceni >= 4;";

        /// <summary>
        /// Dotaz 4.2 - Seznam materiálů
        /// </summary>
        public string SeznamMaterialu(int uzID, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_LIST_MATERIAL);
            command.Parameters.AddWithValue("$idUser", uzID);

            SqlDataReader reader = db.Select(command);

            StringBuilder result = new StringBuilder("");

            while (reader.Read())
            {
                int i = -1;

                result.Append(reader.GetString(++i));
                result.Append(reader.GetString(++i));
                result.Append(reader.GetString(++i));
                result.Append(reader.GetInt32(++i));
                result.Append(reader.GetString(++i));
                result.Append(reader.GetString(++i));
                result.Append(reader.GetDateTime(++i));
                result.Append(reader.GetString(++i));
                result.Append(reader.GetInt32(++i));
                result.Append(reader.GetInt32(++i));
                result.Append(reader.GetInt32(++i));
                result.Append("\n");
            }

            Disconnecting(pDb);

            return result.ToString();
        }

        /// <summary>
        /// Dotaz 2.4 - Výpis nejlepších hodnocení
        /// </summary>
        /// <param name="uzID"></param>
        /// <param name="pDb"></param>
        /// <returns></returns>
        public string VypisNejlepsichHodnoceni(int uzID, DatabaseProxy pDb = null)
        {
            Connecting(pDb);

            SqlCommand command = db.CreateCommand(SQL_LIST_BEST_RATING);
            command.Parameters.AddWithValue("$idUser", uzID);

            SqlDataReader reader = db.Select(command);

            StringBuilder result = new StringBuilder("");

            while (reader.Read())
            {
                int i = -1;

                result.Append(reader.GetString(++i));
                result.Append(reader.GetString(++i));
                result.Append(reader.GetString(++i));
                result.Append(reader.GetString(++i));
                result.Append("\n");
            }

            Disconnecting(pDb);

            return result.ToString();

        }

        #region Connect/Disconnect
        private void Connecting(DatabaseProxy pDb)
        {
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
        }

        private void Disconnecting(DatabaseProxy pDb)
        {
            if (pDb == null)
            {
                db.Close();
            }
        }
        #endregion

    }
}
