using ExWebApiRestFull.Model.Dto;
using ExWebApiRestFull.Model.Entites;
using ExWebApiRestFull.Model.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ExWebApiRestFull.Model.Services.ToDoRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExWebApiRestFull.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public  class ToDoController : ControllerBase
    {
        private ToDoRepository _toDoRepository;
        public ToDoController(ToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        // GET: api/<ToDoController>
        /// <summary>
        /// لیست کارها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get()
        {
            var ResultList = _toDoRepository.GetAll().Select(p => new ToDoVeiwModel
            {
                Text = p.Text,
                InsertTime = p.InsertTime,

                //Hateosa  in rest full api
                links = new List<Link>() {
                    new Link
                    {
                        URL =Url.Action(nameof(Get),"ToDo" ,new { p.Id},Request.Scheme),
                        Method ="Get" ,
                        Rel ="Self"
                    } ,

                       new Link
                    {
                        URL =Url.Action(nameof(Delete),"ToDo" ,new { p.Id},Request.Scheme),
                        Method ="Delet" ,
                        Rel ="Self"
                    } ,

                          new Link
                    {
                        URL =Url.Action(nameof(Post),"ToDo" ,new { p.Id},Request.Scheme),
                        Method ="Post" ,
                        Rel ="Self"
                    } ,
                             new Link
                    {
                        URL =Url.Action(nameof(Put),"ToDo" ,new { p.Id},Request.Scheme),
                        Method ="Put" ,
                        Rel ="Self"
                    } 
                }
            }
                );
            ; ;
            return Ok(ResultList);
        }

        // GET api/<ToDoController>/5
        /// <summary>
        /// پیدا کردن کار با شناسه
        /// </summary>
        /// <param name="id">شناسه کارموردنظر</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var MyToDo = _toDoRepository.GetAllById(id);
            return Ok(new ToDoVeiwModel { 
                InsertTime = MyToDo.InsertTime,
                Text=MyToDo.Text 
                
            });
        }

        // POST api/<ToDoController>
        /// <summary>
        /// افزودن کار
        /// </summary>
        /// <param name="itemDto">نام کار</param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult Post([FromBody] ItemDto  itemDto)
        {
            var result = _toDoRepository.Add(new ToDoRepository.AddToDoDto
            {
                MyToDoDto = new ToDoRepository.ToDoDto
                {
                    Text = itemDto.Text
                }
            });

          //لینک آیتمی که اضافه شده رو نشون بده
         string url =   Url.Action(nameof(Get), "ToDo", new { id = result.MyToDoDto.Id }, Request.Scheme);

         return Created(url , true);
        }

        // PUT api/<ToDoController>/5
        /// <summary>
        /// ویرایش کردن کار
        /// </summary>
        /// <param name="editToDoDto">نام و شناسه کار  و لیست دسته بندیه ا</param>
        /// <returns></returns>
        [HttpPut()]
        public virtual IActionResult Put([FromBody] EditToDoDto editToDoDto)
        {
            var result = _toDoRepository.Edit(editToDoDto);
            return Ok(result);
        }

        // DELETE api/<ToDoController>/5
        /// <summary>
        /// حذف کردن کار
        /// </summary>
        /// <param name="id">شناسه کار</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            _toDoRepository.Delet(id);
            return Ok();
        }
    }
}
