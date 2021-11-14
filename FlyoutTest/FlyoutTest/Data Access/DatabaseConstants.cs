using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Xamarin.Essentials;

namespace FlyoutTest.Data_Access
{
    public static class DatabaseConstants
    {

        public const string DatabaseFilename = "MoviesSQLite2.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
