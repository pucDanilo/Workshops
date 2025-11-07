 

using Danps.Core.My.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Danps.My.Data
{
    public static class MyBancoDados
    {
        /// <summary>
        /// using var db = new MyApplicationContext();
        /// </summary>
        /// <param name="db"></param>
        public static void HealthCheck(DbContext db)
        {
            var canConnect = db.Database.CanConnect();
            if (canConnect)
            {
                db.Database.ExecuteSqlRaw(MyScripts.DROP_ALL_MY_TABLES);

                db.Database.ExecuteSqlRaw(MyDefaultName.DROP);
                db.Database.ExecuteSqlRaw(MySqlObject.DROP);
                db.Database.ExecuteSqlRaw(MyTypeCSharp.DROP);
                db.Database.ExecuteSqlRaw(MyDefaulDb.DROP);
                var databaseCreator = db.GetService<IRelationalDatabaseCreator>();
                databaseCreator.CreateTables();
                db.Database.ExecuteSqlRaw(MyDefaultName.SQL);
                db.Database.ExecuteSqlRaw(MySqlObject.SQL);
                db.Database.ExecuteSqlRaw(MyTypeCSharp.SQL);
                db.Database.ExecuteSqlRaw(MyDefaulDb.SQL);
                db.Database.ExecuteSqlRaw(MyDefaulDb.INIT);
                Console.WriteLine("OK");
            }
            else
                Console.WriteLine("NOK");
        }
        /*
        public static void TemplateHealthCheck(DbContext db)
        {
            var canConnect = db.Database.CanConnect();
            if (canConnect)
            {
                db.Database.ExecuteSqlRaw(Danps.Core.Templates.Scripts.MyScripts.DROP_ALL_MY_TABLES);
                var databaseCreator = db.GetService<IRelationalDatabaseCreator>();
                databaseCreator.CreateTables();
                Console.WriteLine("OK");
            }
            else
                Console.WriteLine("NOK");
        }
        */
        public static void EnsureDeleted(DbContext db)
        {
            db.Database.EnsureDeleted();
        }

        public static void EnsureCreated(DbContext db)
        {
            db.Database.EnsureCreated();
        }

        public static void GapDoEnsureCreated(DbContext db)
        {
            try
            {
                db.Database.EnsureCreated();
                var databaseCreator = db.GetService<IRelationalDatabaseCreator>();
                databaseCreator.CreateTables();
            }
            catch (Exception e)
            {
            }
            /*
            using var db1 = new MyApplicationContext();
            db1.Database.EnsureCreated();
            using var db2 = new CatalogoContext();
            using var db3 = new ModeloContext();
            db2.Database.EnsureCreated();
            db3.Database.EnsureCreated();
            var databaseCreator = db1.GetService<IRelationalDatabaseCreator>();
            databaseCreator.CreateTables();
            */
        }
    }
}