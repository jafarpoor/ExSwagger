using ExWebApiRestFull.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiRestFull.Model.Dto
{
    public class ToDoVeiwModel
    {
        public string Text { get; set; }
        public DateTime InsertTime { get; set; }
        public ICollection<Link> links { get; set; }
    }
}
