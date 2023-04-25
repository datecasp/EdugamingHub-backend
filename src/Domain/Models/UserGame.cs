using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserGame: Entity
    {
        [Required]
        public int User { get; set; }
        [Required]
        public int Game { get; set; }
        [Required]
        public int Plays { get; set; }
    }
}