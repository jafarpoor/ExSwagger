using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiRestFull.Controllers
{
    [Route("api/ToDo/{ToDoId}/Categories/{CategoryId}")]
    public class ToDoCategoryController : Controller
    {
        [ApiVersion("1")]
        [HttpPost]
        public virtual IActionResult Post(int ToDoId , int CategoryId)
        {
            //find todo
            //find category
            //add category
            return Ok();
        }
    }
}
