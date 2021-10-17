using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;

namespace MagicTracker.Models
{
    public class DeckCreate
    {
        [Required]
        public DeckType DeckType { get; set; }
        [Required]
        [Display(Name = "Cards in Deck")]
        public int CardCount { get; set; }
        [Required]
        [Display(Name ="Theme")]
        public string DeckStyle { get; set; }
        public string Commander { get; set; }
        public string Companion { get; set; }
        public int SideboardId { get; set; }
    }
}
