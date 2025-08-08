using Microsoft.AspNetCore.Mvc;
using final_project.Models;
using final_project.Data;
using final_project.Controllers;
using System.Runtime.InteropServices;

namespace final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {

        public required ContactContextDAO _context;

        public ContactController(ContactContextDAO context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int? id)
        {
            if (id is null or 0)
                return Ok(_context.First5Contacts());

            var result = _context.GetContact(id);

            if (result == null)
                return NotFound(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            var result = _context.AddContact(contact);

            if (result == null)
                return StatusCode(500, "Contact already exists");

            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request.");

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.DeleteContact(id);

            if (result == null)
                return NotFound();

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request.");

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Contact contact)
        {
            var result = _context.UpdateContact(contact);

            if (result == null)
                return NotFound(contact.Id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }

        [HttpPatch]
        public IActionResult Update(Contact contact)
        {
            var result = _context.UpdateContact(contact);

            if (result == null)
                return NotFound(contact.Id);

            if (result == 0)
                return StatusCode(500, "An error occured while processing your request");

            return Ok();
        }
    }
}
