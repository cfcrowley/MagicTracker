using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;

namespace MagicTracker.Models
{
    public class DeckListItem
    {
        public int DeckId { get; set; }
        public DeckType DeckType { get; set; }
        [Display(Name ="Cards in Deck")]
        public int CardCount { get; set; }
        [Display(Name = "Theme")]
        public string DeckStyle { get; set; }
    }
}
