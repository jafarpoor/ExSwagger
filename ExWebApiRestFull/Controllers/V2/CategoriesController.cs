using ExWebApiRestFull.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiRestFull.Controllers.V2
{
    [ApiVersion("2")]
    // توس تست سوگر برای ورژن 1 کار نمی کنه چونکه یو ار الش متفاوته
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class CategoriesController : V1.ExWebApiRestFull.Controllers.CategoriesController
    {
        private readonly CategoryRepository categoryRepository;
        public CategoriesController(CategoryRepository category) : base(category)
        {
            categoryRepository = category;
        }
        [HttpGet]
        public override IActionResult Get()
        {
            string[] mystring = { "value1", "value2", "value3" };
            return Ok(mystring);
        }
    }
}
