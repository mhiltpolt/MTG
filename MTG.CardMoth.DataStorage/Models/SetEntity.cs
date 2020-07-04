using System;
using System.Collections.Generic;
using System.Text;

namespace MTG.CardMoth.DataStorage.Models
{
    public class SetEntity
    {
        #region Properties
        public string SetID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SetType { get; set; }
        public Byte[] Icon { get; set; }
        public string URI { get; set; }
        #endregion

        #region Relational
        public List<CardEntity> Cards { get; set; }
        #endregion

    }
}
