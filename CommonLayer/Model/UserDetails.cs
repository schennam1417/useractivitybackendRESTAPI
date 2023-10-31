using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class UserDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CreatedDate { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
        public string? Username { get; set; }
        public string? EmailID { get; set; }
        public string? Password { get; set; }

    }
}
