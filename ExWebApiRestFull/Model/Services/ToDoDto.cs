using ExWebApiRestFull.Model.Entites;
using System;
using System.Collections.Generic;

namespace ExWebApiRestFull.Model.Services
{
    public partial class ToDoRepository
    {
        public class ToDoDto
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public DateTime InsertTime { get; set; }
            public bool IsRemove { get; set; }
            public ICollection<Category> Categoties { get; set; }

            public ICollection<Link> links { get; set; }
        }
    }
}
