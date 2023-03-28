using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Game : Entity
    {
        [Required]
        public string QuizzName { get; set; }
        [Required]
        public string QuizzImgUri { get; set; }
        [Required]
        public string QuizzNameValue { get; set; }
    }
}
