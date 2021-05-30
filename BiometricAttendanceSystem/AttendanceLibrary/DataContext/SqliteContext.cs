using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using AttendanceLibrary.Model;

namespace AttendanceLibrary.DataContext
{
    public class SqliteContext : AttendanceContext
    {
        public DbSet<ServerSetting> ServerSettings { get; set; }

        public readonly string Defaultdbfile = "BiometricClassAttendanceDb.sqlite";
        private readonly string _dbFile;
        private SqliteConnection _connection;

        private static SqliteConnection InitializeSQLiteConnection(string databaseFile)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var index = location.LastIndexOf("\\");
            var path = location.Substring(0, index);
            var connectionString = new SqliteConnectionStringBuilder
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
               //  DataSource =  databaseFile,
              //   DataSource =  $"|DataDirectory|{databaseFile}",
                 DataSource =  $"{AppDomain.CurrentDomain.BaseDirectory}{databaseFile}",
                 //   DataSource = Path.Combine(path, "DB", databaseFile),
           //     DataSource = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DB", databaseFile),
               // DataSource = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\" + databaseFile,
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
            Console.WriteLine($">> CONNECTION STRING: '{_connection.ConnectionString.ToString()}'.");
        }

    }
}
