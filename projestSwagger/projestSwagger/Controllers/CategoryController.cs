using Microsoft.AspNetCore.Mvc;
using projestSwagger.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projestSwagger.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        // רשימת נתונים דמו למחלקת Category
        private static List<Category> categories = new List<Category>
        {
            new Category { categoryId = 1, Name = "עוגות ויטרינה", routingIcon = "cake" },
            new Category { categoryId = 2, Name = "פטיפורים", routingIcon = "icecream" },
            new Category { categoryId = 3, Name = "מאפים", routingIcon = "bakery_dining" }
        };

        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = categories.Find(c => c.categoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category category)
        {
            categories.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.categoryId }, category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var existingCategory = categories.Find(c => c.categoryId == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;
            existingCategory.routingIcon = category.routingIcon;
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoryToRemove = categories.Find(c => c.categoryId == id);
            if (categoryToRemove == null)
            {
                return NotFound();
            }
            categories.Remove(categoryToRemove);
            return NoContent();
        }
    }

}
