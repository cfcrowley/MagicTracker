using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;

namespace MagicTracker.Models
{
    public class SideboardCreate
    {
        [Required]
        [Range(0, 15)]
        [Display(Name = "Card Count")]
        public int CardCount { get; set; }
        [Required]
        [Display(Name = "Sideboard Style")]
        public string CardStyle { get; set; }
        [Required, ForeignKey(nameof(Deck))]
        public int DeckId { get; set; }
    }
}
