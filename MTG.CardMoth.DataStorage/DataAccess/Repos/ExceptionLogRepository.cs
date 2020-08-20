using Dapper;
using MTG.CardMoth.DataStorage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.DataStorage.DataAccess.Repos
{
    class ExceptionLogRepository
    {
        public async Task SaveExceptionLogAsync(ExceptionLogEntity exceptionLog)
        {
            using (IDbConnection con = DbProvider.GetDbConnection())
            {
                await con.ExecuteAsync(@"Insert Into ExceptionLogs 
                                    (Message)
                                    Values
                                    (@Message)", exceptionLog);
            }
        }
    }
}
