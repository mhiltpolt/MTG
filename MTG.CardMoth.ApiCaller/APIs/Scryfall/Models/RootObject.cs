using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTG.CardMoth.ApiCaller.APIs.Scryfall.Models
{
    public class RootObject<T>
    {
        public string _object { get; set; }
        public bool has_more { get; set; }
        public string next_page { get; set; }
        public T[] data { get; set; }
    }

}
