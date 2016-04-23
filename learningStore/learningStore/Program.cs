using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using learningStore.database;
using learningStore.database.mssql;
using learningStore.database.proxy;
using learningStore.tables;


namespace learningStore
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseProxy db = new Database();
            db.Connect();

            SkolaTable st = new SkolaTable();

            try
            {
                db.BeginTransaction();

            }
            catch (Exception)
            {
                db.Rollback();
            }

            db.Close();
            Console.ReadLine();
        }
    }
}
