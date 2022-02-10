using System.Collections.Generic;

namespace ExWebApiRestFull.Model.Services
{
    public partial class ToDoRepository
    {
        public class EditToDoDto
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public List<int> Categories { get; set; }
        }
    }
}
