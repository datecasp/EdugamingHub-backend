using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Badge: Entity
    {
        [Required]
        public string BadgeName { get; set; }
        [Required]
        public string BadgeImgUri { get; set; }
        [Required]
        public string BadgeNameValue { get; set; }
        [Required]
        public string BadgeDescription { get; set; }
    }
}
