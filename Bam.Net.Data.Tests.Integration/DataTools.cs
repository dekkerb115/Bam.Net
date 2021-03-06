/*
	Copyright © Bryan Apellanes 2015  
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net;
using Bam.Net.Logging;
using Bam.Net.Testing;
using Bam.Net.Incubation;
using Bam.Net.DaoRef;
using Bam.Net.CommandLine;
using Bam.Net.Data.MsSql;
using Bam.Net.Data.SQLite;
using Bam.Net.Data.Oracle;
using Bam.Net.Data.MySql;
using Bam.Net.Data.Npgsql;
using Bam.Net.Testing.Integration;
using Bam.Net.Data.Schema;
using System.Configuration;
using Bam.Net.Data.OleDb;

namespace Bam.Net.Data.Tests.Integration
{
	public static class DataTools
	{
		/// <summary>
		/// Create a set of test databases
		/// </summary>
		/// <returns></returns>
		[ConsoleAction]
		public static HashSet<Database> Setup(Action<Database> initializer = null, string databaseName = "DaoRef")
		{
            if(initializer == null)
            {
                initializer = db => Db.TryEnsureSchema<TestTable>(db);
            }

			HashSet<Database> testDatabases = new HashSet<Database>();

            MsSqlDatabase msDatabase = new MsSqlDatabase("chumsql2", databaseName, new MsSqlCredentials { UserName = "mssqluser", Password = "mssqlP455w0rd" });
            initializer(msDatabase);
            testDatabases.Add(msDatabase);

            SQLiteDatabase sqliteDatabase = new SQLiteDatabase(".\\Chumsql2", databaseName);
            initializer(sqliteDatabase);
            testDatabases.Add(sqliteDatabase);

            OleDbDatabase oleDatabase = new OleDbDatabase("Microsoft.ACE.OLEDB.12.0", databaseName.RandomLetters(4));
            initializer(oleDatabase);
            testDatabases.Add(oleDatabase);

            OracleDatabase oracleDatabase = new OracleDatabase("chumsql2", databaseName, new OracleCredentials { UserId = "C##ORACLEUSER", Password = "oracleP455w0rd" });
            initializer(oracleDatabase);
            testDatabases.Add(oracleDatabase);

            MySqlDatabase mySqlDatabase = new MySqlDatabase("chumsql2", databaseName, new MySqlCredentials { UserId = "mysql", Password = "mysqlP455w0rd" });
            initializer(mySqlDatabase);
            testDatabases.Add(mySqlDatabase);

            NpgsqlDatabase npgsqlDatabase = new NpgsqlDatabase("chumsql2", databaseName, new NpgsqlCredentials { UserId = "postgres", Password = "postgresP455w0rd" });
            initializer(npgsqlDatabase);
            testDatabases.Add(npgsqlDatabase);

            return testDatabases;
		}

		[ConsoleAction]
		public static void Cleanup(HashSet<Database> testDatabases)
		{
			testDatabases.Each(db =>
			{
				SchemaWriter dropper = db.ServiceProvider.Get<SchemaWriter>();
				dropper.EnableDrop = true;
				dropper.DropAllTables<TestTable>();
				db.ExecuteSql(dropper);
			});
		}
        
        public static SchemaExtractor GetMsSqlSmoSchemaExtractor(string connectionName)
        {
            string connString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            Expect.IsNotNullOrEmpty(connString, "The connection string named {0} wasn't found in the config file"._Format(connectionName));

            return new MsSqlSmoSchemaExtractor(connectionName);
        }
        
        public static SchemaExtractor GetMsSqlSchemaExtractor(MsSqlDatabase database)
        {
            return new MsSqlSchemaExtractor(database);
        }
        
		public static TestTable CreateTestTable(string name, Database db)
		{
			return CreateTestTable(name, string.Empty, db);
		}

		public static TestTable CreateTestTable(string name, string description, Database db, bool save = true)
		{
			TestTable table = new TestTable(db);
			table.Name = name;
			table.Description = description;
			if (save)
			{
				table.Save(db);
			}
			return table;
		}

		public static Left CreateLeft(string name, Database db)
		{
			Left left = new Left(db);
			left.Name = name;
			left.Save(db);

			return left;
		}

		public static Right CreateRight(string name, Database db)
		{
			Right right = new Right(db);
			right.Name = name;
			right.Save(db);

			return right;
		}
	}
}
