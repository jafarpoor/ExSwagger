using System.Collections.Generic;

namespace ExWebApiRestFull.Model.Services
{
    public partial class ToDoRepository
    {
        public class AddToDoDto
        {
            public ToDoDto MyToDoDto { get; set; }
            public List<int> Categories { get; set; } = new List<int>();
        }
    }
}
