using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserGameBadge: Entity
    {
        [Required]
        public int UserGame { get; set; }
        [Required]
        public int Badge { get; set; }
        [Required]
        public int TimesBadgeGotten { get; set; }
    }
}
