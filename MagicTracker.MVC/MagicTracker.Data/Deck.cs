using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTracker.Data
{
    public enum DeckType { Standard, Legacy, Commander, Modern}
    public class Deck
    {
        [Key]
        public int DeckId { get; set; }
        [Required]
        public DeckType DeckType { get; set; }
        [Required]
        [Range(0,100)]
        [Display(Name ="Cards in Deck")]
        public int CardCount { get; set; }
        [Required]
        [Display(Name ="Theme")]
        public string DeckStyle { get; set; }
        public string Commander { get; set; }
        public string Companion { get; set; }
        [ForeignKey(nameof(Sideboard))]
        public int SideboardId { get; set; }
        

        public List<Card> Cards{ get; set; }
        public virtual Sideboard Sideboard { get; set; }
    }
}
