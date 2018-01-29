using alumnus.Models.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace alumnus.Controllers
{
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var item = new Contacts() {
                FirstName = "Kevin"
            };

            return new ObjectResult(item);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = new Contacts() {
                Id = id,
                FirstName = "Kevin"
            };

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contacts contact)
        {
            var item = new Contacts();
            return BadRequest();
            return CreatedAtAction("Get", new { id = 1 }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contacts contact)
        {
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new NoContentResult();
        }
    }
}