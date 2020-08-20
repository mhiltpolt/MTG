using MTG.CardMoth.ApiCaller.APIs.Scryfall.Models;
using MTG.CardMoth.DataStorage.Models;
using MTG.CardMoth.Utils;
using MTG.CardMoth.Utils.Enums;
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
        private ImageLoader _imageLoader { get; set; }

        public ScryfallController()
        {
            _finder = new ScryfallModelFinder();
            _converter = new ScryfallModelConverter();
            _imageLoader = new ImageLoader();
        }

        public async Task<CardEntity> GetRandomCard()
        {
            CardJsonModel card = await _finder.FindRandomCardAsync();
            return await _converter.ConvertCard(card);
        }

        public async Task<IList<SetEntity>> GetAllSets()
        {
            List<SetJsonModel> jsets = await _finder.FindSetListAsync(@"https://api.scryfall.com/sets");
            List<SetEntity> sets = await _converter.ConvertSetListAsync(jsets);
            sets.ForEach(async s => await LoadImageAsync(s));
            return sets;
        }

        public async Task<List<CardEntity>> GetCardsFromSet(SetEntity set)
        {
            SetJsonModel jset = await _finder.FindSetAsync(set.URI);
            List<CardJsonModel> jcards = await _finder.FindCardListAsync(jset.search_uri);
            set.Cards = await _converter.ConvertCardListAsync(jcards);
            set.Cards.ForEach(c => c.Set = set);
            set.Cards.ForEach(async c => await LoadImageAsync(c));
            return set.Cards;
        }

        public async Task LoadImageAsync(SetEntity set)
        {
            SetJsonModel jset = await _finder.FindSetAsync(set.URI);
            Task<byte[]> iconTask = _imageLoader.LoadFromUriAsync(jset.icon_svg_uri, EImageType.VectorGraphic);
            set.Icon = (await iconTask).Length > 0 ? ImageConverter.SvgToPng(await iconTask) : null;
        }

        public async Task LoadImageAsync(CardEntity card)
        {
            CardJsonModel jcard = await _finder.FindCardAsync(card.URI);
            Task<byte[]> imageTask = _imageLoader.LoadFromUriAsync(jcard.image_uris.large, EImageType.Image);
            Task<byte[]> artworkTask = _imageLoader.LoadFromUriAsync(jcard.image_uris.art_crop, EImageType.Image);
            card.Image = await imageTask;
            card.Artwork = await artworkTask;
        }
    }
}
