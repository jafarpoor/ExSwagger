using System.Collections.Generic;

namespace ExWebApiRestFull.Model.Entites
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToDo> ToDos { get; set; }
    }
}
