using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using learningStore.database;
using learningStore.database.mssql;
using learningStore.database.proxy;


namespace learningStore
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseProxy db = new Database();
            db.Connect();
        }
    }
}
