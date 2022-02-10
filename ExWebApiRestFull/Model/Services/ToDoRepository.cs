using ExWebApiRestFull.Model.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ExWebApiRestFull.Model.Services
{
    public partial class ToDoRepository
    {
        private readonly Context.Context MyContext;

        public ToDoRepository(Context.Context context)
        {
            MyContext = context;
        }

        public List<ToDoDto> GetAll()
        {
            return MyContext.ToDos.Select(p => new ToDoDto
            {
                Id = p.Id,
                InsertTime = p.InsertTime,
                IsRemove = p.IsRemove,
                Text = p.Text 

            }).ToList();

        }

        public ToDoDto GetAllById(int id)
        {
            var MyToDoDto = MyContext.ToDos.SingleOrDefault(p => p.Id == id);
            return new ToDoDto
            {
                Id = MyToDoDto.Id,
                InsertTime = MyToDoDto.InsertTime,
                IsRemove = MyToDoDto.IsRemove,
                Text = MyToDoDto.Text
            };
        }

        public AddToDoDto Add(AddToDoDto addToDoDto)
        {
            ToDo MyToDo = new ToDo()
            {
                Id = addToDoDto.MyToDoDto.Id,
                InsertTime = addToDoDto.MyToDoDto.InsertTime,
                IsRemove = addToDoDto.MyToDoDto.IsRemove,
                Text = addToDoDto.MyToDoDto.Text
            };

            List<Category> MyListCategoty = new List<Category>();
            foreach (var item in addToDoDto.Categories)
            {
                Category MyCategory = MyContext.Categoties.Find(item);
                MyListCategoty.Add(MyCategory);
            }

            MyToDo.Categoties = MyListCategoty;
            MyContext.ToDos.Add(MyToDo);
            MyContext.SaveChanges();

            return new AddToDoDto
            {
                Categories = addToDoDto.Categories,
                MyToDoDto = new ToDoDto
                {
                    Id = MyToDo.Id,
                    InsertTime = MyToDo.InsertTime,
                    IsRemove = MyToDo.IsRemove,
                    Text = MyToDo.Text

                }
            };
        }

        public void Delet(int id)
        {
            var MyReult = MyContext.ToDos.Find(id);
            MyReult.IsRemove = true;
            MyContext.SaveChanges();
        }

        public bool Edit(EditToDoDto editToDoDto)
        {
            var MyToDoes = MyContext.ToDos.SingleOrDefault(p => p.Id == editToDoDto.Id);
            MyToDoes.Text = editToDoDto.Text;
            List<Category> categories = new List<Category>();
            foreach (var item in editToDoDto.Categories)
            {
                var Category = MyContext.Categoties.Find(item);
                categories.Add(Category);

            }
            MyContext.ToDos.Update(MyToDoes);
            MyContext.SaveChanges();
            return true;

        }
    }
}
