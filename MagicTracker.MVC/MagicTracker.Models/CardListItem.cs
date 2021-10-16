using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;

namespace MagicTracker.Models
{
    public class CardListItem
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public CardType CardType { get; set; }
        public CardType? CardType2 { get; set; }
        public int ManaValue { get; set; }
    }
}
