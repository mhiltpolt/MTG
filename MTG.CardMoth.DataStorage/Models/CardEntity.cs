using System;
using System.Collections.Generic;
using System.Text;

namespace MTG.CardMoth.DataStorage.Models
{
    public class CardEntity
    {
        #region Properties
        public string CardID { get; set; }
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public int CMC { get; set; }
        public string TypeLine { get; set; }
        public string OracleText { get; set; }
        public string FlavorText { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Rarity { get; set; }
        public bool Reserved { get; set; }
        public string Artist { get; set; }
        public byte[] Image { get; set; }
        public byte[] Artwork { get; set; }
        public string URI { get; set; }
        #endregion

        #region Relational
        public SetEntity Set { get; set; }
        public List<CardsDecksEntity> Decks { get; set; }
        #endregion
    }
}
