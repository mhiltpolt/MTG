using MTG.CardMoth.ApiCaller.APIs.Scryfall.Models;
using MTG.CardMoth.DataStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.ApiCaller.APIs.Scryfall
{
    public class ScryfallController
    {
        private ScryfallModelFinder _finder { get; set; }
        private ScryfallModelConverter _converter { get; set; }

        public ScryfallController()
        {
            _finder = new ScryfallModelFinder();
            _converter = new ScryfallModelConverter();
        }

        public async Task<CardEntity> GetRandomCard()
        {
            CardJsonModel card = await _finder.FindRandomCardAsync();
            return await _converter.ConvertCardAsync(card);
        }

        public async Task<IList<SetEntity>> GetAllSets()
        {
            List<SetJsonModel> sets = await _finder.FindSetListAsync(@"https://api.scryfall.com/sets");
            return await _converter.ConvertSetListAsync(sets);
        }

        public async Task<List<CardEntity>> GetCardsFromSet(SetEntity set)
        {
            SetJsonModel jset = await _finder.FindSetAsync(set.URI);
            List<CardJsonModel> jcards = await _finder.FindCardListAsync(jset.search_uri);
            set.Cards = await _converter.ConvertCardListAsync(jcards);
            set.Cards.ForEach(c => c.Set = set);
            return set.Cards;
        }
    }
}
