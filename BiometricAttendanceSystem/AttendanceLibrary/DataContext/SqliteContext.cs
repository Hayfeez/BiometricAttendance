using System;
using System.Collections.Generic;
//using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace AttendanceLibrary.DataContext
{
    public class SqliteContext : AttendanceContext
    {
        public const string Defaultdbfile = "SchoolAttendanceDb.sqlite";
        private readonly string _dbFile;
        private SqliteConnection _connection;

        private static SqliteConnection InitializeSQLiteConnection(string databaseFile)
        {
            var connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = databaseFile,
                Password = "Password123"// PRAGMA key is being sent from EF Core directly after opening the connection
            };
            return new SqliteConnection(connectionString.ToString());
        }

        public SqliteContext()
        {
            _dbFile = Defaultdbfile;
        }

        public SqliteContext(string databaseFile)
        {
            if (!string.IsNullOrEmpty(databaseFile)) _dbFile = databaseFile;
        }

        public SqliteContext(SqliteConnection sqliteConnection)
        {
            if (!string.IsNullOrEmpty(sqliteConnection?.DataSource)) _dbFile = sqliteConnection.DataSource;
            _connection = sqliteConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _connection ??= InitializeSQLiteConnection(_dbFile);
            optionsBuilder.UseSqlite(_connection);
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_winsqlite3());
          //  SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlcipher());
            //
        }

    }
}
