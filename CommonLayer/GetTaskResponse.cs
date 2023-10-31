using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class GetTaskResponse : BasicResponse
    {
        public List<TaskDetails>? data {  get; set; } = new List<TaskDetails>();
    }
}
