using Dapper;
using MTG.CardMoth.DataStorage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.DataStorage.DataAccess.Repos
{
    public class CardRepository
    {
        public static async Task SaveCardAsync(CardEntity card)
        {
            using(IDbConnection con = DbProvider.GetDbConnection())
            {
                try
                {
                    con.Execute(@"insert into Cards 
                                    (CardID, Name, ManaCost, CMC, TypeLine, OracleText, FlavorText, Power, Toughness, Rarity, Reserved, Artist, Image, Artwork)
                                    values
                                    (@CardId, @Name, @ManaCost, @CMC, @TypeLine, @OracleText, @FlavorText, @Power, @Toughness, @Rarity, @Reserved, @Artist, @Image, @Artwork)", card);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }

        public static async Task SaveCardAsync(List<CardEntity> cards)
        {
            cards.ForEach(async c => await SaveCardAsync(c));
        }
    }
}
