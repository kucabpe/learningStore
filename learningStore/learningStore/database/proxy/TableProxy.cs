using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using learningStore.database.mssql;
using learningStore.database.proxy;

namespace learningStore.tables
{
    public abstract class TableProxy<T>
    {
        protected Database db;

        #region SQL
        protected abstract static String SQL_SELECT;
        protected static String SQL_INSERT;
        protected static String SQL_UPDATE;
        protected static String SQL_DELETE;
        #endregion

        #region CRUD
        public abstract int Insert(T t, DatabaseProxy pDb = null);

        public abstract int Update(T t, DatabaseProxy pDb = null);

        public abstract Collection<T> Select(DatabaseProxy pDb = null);

        public abstract int Delete(T t, DatabaseProxy pDb = null);
       
        #endregion

        #region Operations
        protected abstract void PrepareCommand(SqlCommand command, T t);

        protected abstract Collection<T> Read(SqlDataReader reader);
        #endregion

        #region Connect/Disconnect
        protected void Connect(DatabaseProxy pDb = null)
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

        protected void Disconnect(DatabaseProxy pDb = null)
        {
            if (pDb == null)
            {
                pDb.Close();
            }
        }
        #endregion

    }
}   
