using MTG.CardMoth.ApiCaller.APIs.Scryfall.Models;
using MTG.CardMoth.DataStorage.Models;
using MTG.CardMoth.Utils;
using MTG.CardMoth.Utils.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MTG.CardMoth.ApiCaller.APIs.Scryfall
{
    internal class ScryfallModelConverter
    {
        private ScryfallModelFinder _finder => new ScryfallModelFinder();
        private ImageLoader _imageLoader => new ImageLoader();
        internal async Task<CardEntity> ConvertCard(CardJsonModel card)
        {
                return new CardEntity
                {
                    CardID = card.id,
                    Name = card.Name,
                    ManaCost = card.mana_cost,
                    CMC = (int)card.cmc,
                    TypeLine = card.type_line,
                    OracleText = card.oracle_text,
                    FlavorText = card.flavor_text,
                    Power = card.power,
                    Toughness = card.toughness,
                    Rarity = card.rarity,
                    Reserved = card.reserved,
                    Artist = card.artist,
                    URI = card.Uri
                };
        }

        internal async Task<List<CardEntity>> ConvertCardListAsync(List<CardJsonModel> cards, int failCount = 0)
        {
            List<Task<CardEntity>> Tasks = cards.Select(c => { return ConvertCard(c); }).ToList();
            Task<CardEntity[]> resultTask = Task.WhenAll(Tasks);

            return (await resultTask).ToList();
        }

        internal async Task<SetEntity> ConvertSetAsync(SetJsonModel set)
        {
            return new SetEntity
            {
                SetID = set.id,
                Name = set.name,
                Code = set.code,
                ReleaseDate = DateTime.Parse(set.released_at),
                SetType = set.set_type,
                URI = set.uri
            };
        }

        internal async Task<List<SetEntity>> ConvertSetListAsync(List<SetJsonModel> sets)
        {
            IEnumerable<Task<SetEntity>> tasks = sets.Select(s => { return ConvertSetAsync(s); });
            Task<SetEntity[]> resultTask = Task.WhenAll(tasks);

            return (await resultTask).ToList();
        }
    }
}
