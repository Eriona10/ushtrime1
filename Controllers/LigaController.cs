using Lab.Data.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigaController : Controller
    {
        private readonly Lab2Context db;


        public LigaController(Lab2Context db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var liga =  db.Liga.ToList();

            return Ok(liga);
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<Liga>> Get(int id)
        {
            var liga = await db.Liga.FindAsync(id);
            if (liga == null)
                return BadRequest("liga not found.");
            return Ok(liga);
        }
        [HttpPost]
        public async Task<ActionResult<List<Liga>>> Add(Liga liga)
        {
            db.Liga.Add(liga);
            await db.SaveChangesAsync();

            return Ok(await db.Liga.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Liga>>> Update(Liga request)
        {
            var update = await db.Liga.FindAsync(request.Id);
            if (update == null)
                return BadRequest("request not found.");

            update.Emri = request.Emri;


            await db.SaveChangesAsync();

            return Ok(await db.Liga.ToListAsync());
        }

    [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete =  db.Liga.Find(id);
            if (delete == null)
                return BadRequest("request not found.");

            db.Liga.Remove(delete);
             db.SaveChanges();

            return Ok("Eshte fshrire");
        }


    }
}
