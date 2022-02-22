using AssetManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        // GET: api/<TagController>
        [HttpGet]
        public IEnumerable<Asset> Get()
        {
            using (var context = new AssetManagementContext())
            {

                return context.Assets.ToList();
            }

        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IEnumerable<Asset> Get(int id)
        {
            using (var context = new AssetManagementContext())
            {

                return context.Assets.Where(Asset => Asset.AssetId == id).ToList();
            }
        }

        // POST api/<TagController>
        [HttpPost]
        public async Task<ActionResult<Tag>> Post([FromBody] Asset value)
        {
            using (var context = new AssetManagementContext())
            {

                context.Assets.Add(value);
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = value.AssetId }, value);
            }
        }


        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Asset value)
        {
            using (var context = new AssetManagementContext())
            {
                if (id != value.AssetId)
                {
                    return BadRequest();
                }


                context.Entry(value).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = value.AssetId }, value);
            }
        }


        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asset>> Delete(int id)
        {
            using (var context = new AssetManagementContext())
            {
                Asset asset = await context.Assets.FindAsync(id);

                if (asset == null)
                {
                    return NotFound();
                }
                context.Assets.Remove(asset);
                await context.SaveChangesAsync();
                return NoContent();

            }
        }
    }
}
