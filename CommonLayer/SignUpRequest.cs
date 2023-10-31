using CommonLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class SignUpRequest 
    {
        [Required]
        public string? Username { get; set; }
        [Required, EmailAddress]
        public string? EmailId { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
