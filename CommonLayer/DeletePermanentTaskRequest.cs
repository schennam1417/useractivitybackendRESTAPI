﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class DeletePermanentTaskRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
