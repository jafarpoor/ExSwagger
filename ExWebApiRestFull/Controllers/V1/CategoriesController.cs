using ExWebApiRestFull.Model.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace V1.ExWebApiRestFull.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly CategoryRepository categoryRepository;
        public CategoriesController(CategoryRepository category)
        {
            categoryRepository = category;
        }
        // GET: api/<CategoriesController>
        /// <summary>
        /// لیست دسته بندی ها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(categoryRepository.GetAll());
        }

        // GET api/<CategoriesController>/5
        /// <summary>
        /// پیدا کردن دسته بندی مورد نظر با ای دی
        /// </summary>
        /// <param name="id">شناسه دسته بندی</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            return Ok(categoryRepository.Find(id));
        }

        // POST api/<CategoriesController>
        /// <summary>
        /// اضافه کردن دسته بندی
        /// </summary>
        /// <param name="Name">نام دسته بندی</param>
        /// <returns></returns>
        [HttpPost]
       
        public virtual IActionResult Post(string Name)
        {
            var Result = categoryRepository.Add(Name);
            return Created(Url.Action(nameof(Get), "Categories", new { Id = Result }, Request.Scheme ), true);
        }

        // PUT api/<CategoriesController>/5
        /// <summary>
        /// ویرایش کردن دسته بندی
        /// </summary>
        /// <param name="categoryDto">نام و شناه دسته بندی</param>
        /// <returns></returns>
        [HttpPut]
        public virtual IActionResult Put([FromBody]CategoryDto categoryDto)
        {
            return Ok(categoryRepository.Edit(categoryDto));
        }

        // DELETE api/<CategoriesController>/5
        /// <summary>
        /// حذف کردن دسته بندی
        /// </summary>
        /// <param name="id">شناسه دسته بندی</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            return Ok(categoryRepository.Delet(id));
        }
    }
}
