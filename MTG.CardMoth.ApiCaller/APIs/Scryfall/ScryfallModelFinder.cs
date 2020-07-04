using MTG.CardMoth.ApiCaller.APIs.Scryfall.Models;
using MTG.CardMoth.ApiCaller.Tools;
using MTG.CardMoth.DataStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.ApiCaller.APIs.Scryfall
{
    internal class ScryfallModelFinder
    {
        HttpHelper Helper => new HttpHelper();

        internal async Task<CardJsonModel> FindRandomCardAsync()
        {
            string content = await Helper.GetHttpResponseStringAsync(@"https://api.scryfall.com/cards/random");

            return JsonConvert.DeserializeObject<CardJsonModel>(content);
        }

        internal async Task<List<CardJsonModel>> FindCardListAsync(string uri)
        {
            string content = await Helper.GetHttpResponseStringAsync(uri);
            List<CardJsonModel> cards = new List<CardJsonModel>();

            RootObject<CardJsonModel> root = JsonConvert.DeserializeObject<RootObject<CardJsonModel>>(content);
            cards.AddRange(root.data.ToList());
            if (root.has_more)
            {
                cards.AddRange(await FindCardListAsync(root.next_page));
            }
            return cards;
        }

        internal async Task<SetJsonModel> FindSetAsync(string uri = @"https://api.scryfall.com/sets/mmq")
        {
            string content = await Helper.GetHttpResponseStringAsync(uri);

            return JsonConvert.DeserializeObject<SetJsonModel>(content);
        }

        internal async Task<List<SetJsonModel>> FindSetListAsync(string uri)
        {
            string content = await Helper.GetHttpResponseStringAsync(uri);
            List<SetJsonModel> cards = new List<SetJsonModel>();
            
            RootObject<SetJsonModel> root = JsonConvert.DeserializeObject<RootObject<SetJsonModel>>(content);
            cards.AddRange(root.data.ToList());
            if (root.has_more)
            {
                cards.AddRange(await FindSetListAsync(root.next_page));
            }
            return cards;
        }
    }
}
