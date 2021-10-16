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
        public string Name { get; set; }
        public CardType CardType { get; set; }
        public int ManaValue { get; set; }
    }
}
