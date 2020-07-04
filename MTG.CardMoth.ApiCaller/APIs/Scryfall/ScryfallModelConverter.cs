using MTG.CardMoth.ApiCaller.APIs.Scryfall.Models;
using MTG.CardMoth.ApiCaller.Tools;
using MTG.CardMoth.DataStorage.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Navigation;

namespace MTG.CardMoth.ApiCaller.APIs.Scryfall
{
    internal class ScryfallModelConverter
    {
        private ScryfallModelFinder _finder => new ScryfallModelFinder();
        private ImageLoader _imageLoader => new ImageLoader();
        internal async Task<CardEntity> ConvertCardAsync(CardJsonModel card)
        {
            HttpHelper helper = new HttpHelper();
            //Task<byte[]> image = _imageLoader.LoadFromUriAsync(card.image_uris?.large);
            //Task<byte[]> artwork = _imageLoader.LoadFromUriAsync(card.image_uris?.art_crop);
            try
            {


            Task<byte[]> image = helper.LoadImage(card.image_uris?.large);
            Task<byte[]> artwork = helper.LoadImage(card.image_uris?.art_crop);
            
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
                Image = await image,
                Artwork = await artwork,
                URI = card.Uri
            };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal async Task<List<CardEntity>> ConvertCardListAsync(List<CardJsonModel> cards)
        {
            IEnumerable<Task<CardEntity>> Tasks = cards.Select(c =>
            {
                Debug.Print(cards.IndexOf(c).ToString());
                return ConvertCardAsync(c);
            });
            Task<CardEntity[]> resultTask = Task.WhenAll(Tasks);
            try
            {
                CardEntity[] result = await resultTask;
                return result.ToList();
            }
            catch (Exception e)
            {
                throw resultTask.Exception;
            }
        }

        internal async Task<SetEntity> ConvertSetAsync(SetJsonModel set)
        {
            Task<byte[]> icon = _imageLoader.LoadFromUriAsync(set.icon_svg_uri);

            return new SetEntity
            {
                SetID = set.id,
                Name = set.name,
                Code = set.code,
                ReleaseDate = DateTime.Parse(set.released_at),
                SetType = set.set_type,
                Icon = await icon,
                URI = set.uri
            };
        }

        internal async Task<List<SetEntity>> ConvertSetListAsync(List<SetJsonModel> sets)
        {
            IEnumerable<Task<SetEntity>> tasks = sets.Select(s =>
            {
                return ConvertSetAsync(s);
            });
            SetEntity[] result = await Task.WhenAll(tasks);

            return result.ToList();
        }
    }
}
