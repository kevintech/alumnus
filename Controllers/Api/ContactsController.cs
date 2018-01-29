using System.Linq;
using Microsoft.AspNetCore.Mvc;
using alumnus.Models.Contacts;
using alumnus.Data;

namespace alumnus.Controllers.Api
{
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        private readonly AlumnusContext _context;

        public ContactsController(AlumnusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _context.Contacts.ToList();
            return new ObjectResult(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.Contacts.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contacts contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return CreatedAtAction("Get", new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contacts contact)
        {
            if (contact == null || contact.Id != id)
            {
                return BadRequest();
            }

            var itemToUpdate = _context.Contacts.FirstOrDefault(i => i.Id == id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }

            itemToUpdate.FirstName = contact.FirstName;
            itemToUpdate.LastName = contact.LastName;
            itemToUpdate.BirthDay = contact.BirthDay;
            itemToUpdate.Email = contact.Email;
            itemToUpdate.Address = contact.Address;
            itemToUpdate.GraduationDate = contact.GraduationDate;
            itemToUpdate.CurrentJob = contact.CurrentJob;
            itemToUpdate.CurrentPosition = contact.CurrentPosition;
            _context.Contacts.Update(itemToUpdate);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itemToRemove = _context.Contacts.FirstOrDefault(i => i.Id == id);
            if (itemToRemove == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(itemToRemove);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}