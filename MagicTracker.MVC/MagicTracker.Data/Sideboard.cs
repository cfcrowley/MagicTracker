using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
