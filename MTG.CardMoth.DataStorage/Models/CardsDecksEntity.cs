using System;
using System.Collections.Generic;
using System.Text;

namespace MTG.CardMoth.DataStorage.Models
{
    public class CardsDecksEntity
    {
        public CardEntity Card { get; set; }
        public DeckEntity Deck { get; set; }
        public int Quantity { get; set; }
    }
}
