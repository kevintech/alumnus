using System.Linq;
using Microsoft.AspNetCore.Mvc;
using alumnus.Models.Resources;
using alumnus.Data;

namespace alumnus.Controllers.Api
{
    [Route("api/resources")]
    public class ResourcesApiController : Controller
    {
        public readonly AlumnusContext _context;

        public ResourcesApiController(AlumnusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _context.Resources.ToList();
            return new ObjectResult(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.Resources.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Resources resource)
        {
            if (resource == null)
            {
                return BadRequest();
            }

            _context.Resources.Add(resource);
            _context.SaveChanges();
            return CreatedAtAction("Get", new { id = resource.Id }, resource);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Resources resource)
        {
            if (resource == null || resource.Id != id)
            {
                return BadRequest();
            }

            var itemToUpdate = _context.Resources.FirstOrDefault(i => i.Id == id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }

            itemToUpdate.Title = resource.Title;
            itemToUpdate.Description = resource.Description;
            itemToUpdate.Url = resource.Url;
            itemToUpdate.Type = resource.Type;
            _context.Resources.Update(itemToUpdate);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itemToRemove = _context.Resources.FirstOrDefault(i => i.Id == id);
            if (itemToRemove == null)
            {
                return NotFound();
            }

            _context.Resources.Remove(itemToRemove);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}