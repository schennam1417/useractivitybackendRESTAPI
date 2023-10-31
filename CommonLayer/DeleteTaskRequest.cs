using CommonLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class DeleteTaskRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Status status { get; set; }
    }
}
