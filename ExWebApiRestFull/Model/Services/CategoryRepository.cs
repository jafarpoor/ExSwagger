using ExWebApiRestFull.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiRestFull.Model.Services
{
    public class CategoryRepository
    {
        private readonly Context.Context MyContext;
        public CategoryRepository(Context.Context context)
        {
            MyContext = context;
        }

        public List<CategoryDto> GetAll()
        {
            var Result = MyContext.Categoties.Select(p => new CategoryDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return Result;
        }

        public int Add(string CategoryName)
        {
            Category MyCategory = new Category()
            {
                Name = CategoryName
            };
            MyContext.Categoties.Add(MyCategory);
            MyContext.SaveChanges();
            return MyCategory.Id;
        }

        public int Delet(int id)
        {
            MyContext.Categoties.Remove(new Entites.Category { Id = id });
            return MyContext.SaveChanges();
        }

        public int Edit(CategoryDto categoryDto)
        {
            var Result = MyContext.Categoties.SingleOrDefault(p=>p.Id == categoryDto.Id);
            Result.Name = categoryDto.Name;
            return MyContext.SaveChanges();
        }

        public CategoryDto Find(int id)
        {
            var Result = MyContext.Categoties.Find(id);
            return new CategoryDto
            {
                Id = Result.Id,
                Name = Result.Name
            };
        }

    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
