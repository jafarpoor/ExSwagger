using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiRestFull.Model.Entites
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime InsertTime { get; set; }
        public bool IsRemove { get; set; }
        public ICollection<Category> Categoties { get; set; }
      
    }
}
