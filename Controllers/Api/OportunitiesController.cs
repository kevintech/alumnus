using System.Linq;
using Microsoft.AspNetCore.Mvc;
using alumnus.Models.Oportunities;
using alumnus.Data;

namespace alumnus.Controllers.Api
{
    [Route("api/oportunities")]
    public class OportunitiesController : Controller
    {
        private readonly AlumnusContext _context;

        public OportunitiesController(AlumnusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _context.Oportunities.ToList();
            return new ObjectResult(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.Oportunities.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Oportunities oportunity)
        {
            if (oportunity == null)
            {
                return BadRequest();
            }

            _context.Oportunities.Add(oportunity);
            _context.SaveChanges();
            return CreatedAtAction("Get", new { id = oportunity.Id }, oportunity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Oportunities oportunity)
        {
            if (oportunity == null || oportunity.Id != id)
            {
                return BadRequest();
            }

            var itemToUpdate = _context.Oportunities.FirstOrDefault(i => i.Id == id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }

            itemToUpdate.Title = oportunity.Title;
            itemToUpdate.Description = oportunity.Description;
            itemToUpdate.EndDate = oportunity.EndDate;
            itemToUpdate.Type = oportunity.Type;
            _context.Oportunities.Update(itemToUpdate);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itemToRemove = _context.Oportunities.FirstOrDefault(i => i.Id == id);
            if (itemToRemove == null)
            {
                return NotFound();
            }

            _context.Oportunities.Remove(itemToRemove);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}