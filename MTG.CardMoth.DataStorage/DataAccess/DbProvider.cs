using System;
using System.Data;
using System.Data.SQLite;

namespace MTG.CardMoth.DataStorage
{
    public class DbProvider
    {
        public static IDbConnection GetDbConnection()
        {
            return new SQLiteConnection(@"Data Source=.\MTG.CardMoth.Data.db; Version=3");
        }
    }
}
