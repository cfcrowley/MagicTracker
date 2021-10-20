using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTracker.Models
{
    public class SideboardEdit
    {
        public int SideboardId { get; set; }
        public int CardCount { get; set; }
        public string CardStyle { get; set; }
        public int DeckId { get; set; }
    }
}
