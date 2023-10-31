using CommonLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class AddTaskRequest
    {
        [Required]
        public int UsertId { get; set; }
        [Required]
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        [Required]
        public string? Date { get; set; }
        [Required]
        public string? Time { get; set; }
        [Required] public bool? Sunday { get; set; } = false;
        [Required] public bool? Monday { get; set; } = false;
        [Required] public bool? Tuesday { get; set; } = false;
        [Required] public bool? Wednesday { get; set; } = false;
        [Required] public bool? Thurday { get; set; } = false;
        [Required] public bool? Friday { get; set; } = false;
        [Required] public bool? Saturday { get; set; } = false;
        [Required] public Status status { get; set; }
    }
}
