using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;

namespace MagicTracker.Models
{
    public class CardCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public CardType CardType { get; set; }
        [Required]
        public int ManaValue { get; set; }
        public int? DeckId { get; set; }
        public int? SideboardId { get; set; }
    }
}
