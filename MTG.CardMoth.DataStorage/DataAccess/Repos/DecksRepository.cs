using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.DataStorage.DataAccess.Repos
{
    public class DecksRepository
    {
        public async Task SaveDeckAsync()
        {
            using (IDbConnection con = DbProvider.GetDbConnection())
            {
                await con.ExecuteAsync(@"Insert Into Decks 
                                    ()");
            }
        }
    }
}
