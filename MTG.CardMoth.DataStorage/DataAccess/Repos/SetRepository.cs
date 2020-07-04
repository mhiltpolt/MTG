using Dapper;
using MTG.CardMoth.DataStorage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.DataStorage.DataAccess.Repos
{
    public class SetRepository
    {
        public static async Task SaveSetAsync(SetEntity set)
        {
            using (IDbConnection con = DbProvider.GetDbConnection())
            {
                try
                {
                    con.Execute(@"insert into Sets 
                                    (SetID, Name, Code, ReleaseDate, SetType, Icon, URI)
                                    values
                                    (@SetID, @Name, @Code, @ReleaseDate, @SetType, @Icon, @Uri)", set);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static async Task SaveSetAsync(List<SetEntity> sets)
        {
            sets.ForEach(s => SaveSetAsync(s));
        }
    }
}
