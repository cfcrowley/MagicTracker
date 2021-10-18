using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        [Display(Name = "Mana Value")]
        public int ManaValue { get; set; }
        [ForeignKey(nameof(Deck))]
        public int DeckId { get; set; }
        [ForeignKey(nameof(Sideboard))]
        public int SideboardId { get; set; }

        public virtual Deck Deck { get; set; }
        public virtual Sideboard Sideboard { get; set; }

    }
}
