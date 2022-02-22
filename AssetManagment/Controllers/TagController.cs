using AssetManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        // GET: api/<TagController>
        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            using (var context = new AssetManagementContext())
            {

                return context.Tags.ToList();
            }

        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IEnumerable<Tag> Get(string id)
        {
            using (var context = new AssetManagementContext())
            {

                return context.Tags.Where(tag => tag.TagMacAddress == id).ToList();
            }
        }

        // POST api/<TagController>
        [HttpPost]
        public async Task<ActionResult<Tag>> Post([FromBody] Tag value)
        {
            using (var context = new AssetManagementContext())
            {

                context.Tags.Add(value);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = value.TagMacAddress }, value);
            }
        }


        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Tag value)
        {
            using (var context = new AssetManagementContext())
            {
                if (id != value.TagMacAddress)
                {
                    return BadRequest();
                }


                context.Entry(value).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = value.TagMacAddress }, value);
            }
        }


        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tag>> Delete(string id)
        {
            using (var context = new AssetManagementContext())
            {
                Tag tag = await context.Tags.FindAsync(id);
                if (tag == null)
                {
                    return NotFound();
                }
                context.Tags.Remove(tag);
                await context.SaveChangesAsync();
                return NoContent();

            }
        }


    }
}
