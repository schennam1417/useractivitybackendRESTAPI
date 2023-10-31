using CommonLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class TaskDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
        public int UsertId { get; set; }    
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public string? Date {  get; set; }
        public string? Time { get; set; }
        public bool? Sunday { get; set; } = false;
        public bool? Monday { get; set; } = false;
        public bool? Tuesday { get; set; } = false;
        public bool? Wednesday { get; set; } = false;
        public bool? Thurday { get; set; } = false;
        public bool? Friday { get; set; } = false;
        public bool? Saturday { get; set; } = false;
        public Status status { get; set; } = Status.PENDING;
    }
}
