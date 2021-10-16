using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTracker.Data
{
    public enum CardType { Creature , Instant, Sorcery, Land, Enchantment, Artifact}
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Card Type")]
        public CardType CardType { get; set; }
        public CardType? CardType2 { get; set; }
        [Required]
        [Display(Name = "Mana Value")]
        public int ManaValue { get; set; }

        public virtual List<Deck> Decks { get; set; }
        public virtual List<Sideboard> Sideboards { get; set; }


    }
}
