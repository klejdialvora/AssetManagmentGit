using AssetManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        // GET: api/<TagController>
        [HttpGet]
        public IEnumerable<Group> Get()
        {
            using (var context = new AssetManagementContext())
            {

                return context.Groups.ToList();
            }

        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IEnumerable<Group> Get(int id)
        {
            using (var context = new AssetManagementContext())
            {

                return context.Groups.Where(Group => Group.GroupId == id).ToList();
            }
        }

        // POST api/<TagController>
        [HttpPost]
        public async Task<ActionResult<Group>> Post([FromBody] Group value)
        {
            using (var context = new AssetManagementContext())
            {

                context.Groups.Add(value);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = value.GroupId }, value);
            }
        }


        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Group value)
        {
            using (var context = new AssetManagementContext())
            {
                if (id != value.GroupId)
                {
                    return BadRequest();
                }


                context.Entry(value).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = value.GroupId }, value);
            }
        }


        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Group>> Delete(int id)
        {
            using (var context = new AssetManagementContext())
            {
                Group group = await context.Groups.FindAsync(id);

                if (group == null)
                {
                    return NotFound();
                }
                context.Groups.Remove(group);
                await context.SaveChangesAsync();
                return NoContent();

            }
        }
    }
}
