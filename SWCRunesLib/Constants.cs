using System;
namespace SWCRunesLib
{
    public class Constants
    {
        public Constants()
        {
        }

        public const string DatabaseFilename = "SWCRunes.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;


    }
}

