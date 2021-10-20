using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTracker.Data
{
    public class Sideboard
    {
        [Key]
        public int SideboardId { get; set; }
        [Required]
        [Range(0,15)]
        [Display(Name ="Card Count")]
        public int CardCount { get; set; }
        [Required]
        [Display(Name ="Sideboard Style")]
        public string CardStyle { get; set; }
        [Required, ForeignKey(nameof(Deck))]
        public int DeckId { get; set; }

        public virtual List<Card> Cards { get; set; }
        public virtual Deck Deck { get; set; }
       
    }
}
