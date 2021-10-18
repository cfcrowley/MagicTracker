using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;

namespace MagicTracker.Models
{
    public class DeckDetail
    {
        public int DeckId { get; set; }
        public DeckType DeckType { get; set; }
        public int CardCount { get; set; }
        public string DeckStyle { get; set; }
        public string Commander { get; set; }
        public string Companion { get; set; }
        public int? SideboardId { get; set; }
     
    }
}
