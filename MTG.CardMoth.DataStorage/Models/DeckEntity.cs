using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTG.CardMoth.DataStorage.Models
{
    public class DeckEntity
    {
        #region Properties
        public int DeckID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Relational
        public List<CardsDecksEntity> Cards { get; set; }
        #endregion

        public void Sort()
        {
            Cards = Cards.OrderBy(c => c.Card.Name)
                .ThenBy(c => c.Card.TypeLine)
                .ThenBy(c => c.Card.CMC)
                .ToList();
        }
    }
}
