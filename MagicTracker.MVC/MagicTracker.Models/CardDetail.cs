using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;

namespace MagicTracker.Models
{
    public class CardDetail
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public CardType CardType { get; set; }
        public int ManaValue { get; set; }

        public int? DeckId { get; set; }
        public int? SideboardId { get; set; }
    }
}
