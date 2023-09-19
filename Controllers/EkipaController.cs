using Azure.Core;
using Lab.Data.General;
using Lab.ViewModal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EkipaController : Controller
    {
        private readonly Lab2Context db;


        public EkipaController(Lab2Context db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ekipa = db.Ekipaa.Select(e=> new
                {
                e.Emri,
                e.Id,
                e.LigaId,
                LigaName= db.Liga.Where(a=>a.Id==e.LigaId).Select(x=>x.Emri).FirstOrDefault()

                });

            return Ok(ekipa);
        }
        //[HttpGet("{id}")]
        //public IActionResult Get(int ligaId)
        //{
        //    var ekipa =  db.Ekipaa.Where(x => x.LigaId == ligaId)
        //        .Include(x => x.LigaId).ToList();

        //  return Ok(ekipa);
        //}

        [HttpPost]
        public async Task<ActionResult<Ekipaa>> Add(EkipaVm ekipa)
        {

          //  var liga = db.Ekipaa.Where(e => e.LigaId == ekipa.Ligaid).Select(e => e.Emri);

            var newCharacter = new Ekipaa
            {
                Emri = ekipa.Emri,
                LigaId = ekipa.Ligaid
            };

            db.Ekipaa.Add(newCharacter);
            await db.SaveChangesAsync();

            return Ok("U Rigjistrua");
        }

        [HttpPut]
        public async Task<ActionResult<List<Ekipaa>>> Update(EkipaVm request)
        {
            var update = await db.Ekipaa.FindAsync(request.Id);
            if (update == null)
                return BadRequest("request not found.");

            update.Emri = request.Emri;
            update.LigaId = request.Ligaid;


            await db.SaveChangesAsync();

            return Ok(await db.Ekipaa.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Ekipaa>>> Delete(int id)
        {
            var delete = await db.Ekipaa.FindAsync(id);
            if (delete == null)
                return BadRequest("request not found.");

            db.Ekipaa.Remove(delete);
            await db.SaveChangesAsync();

            return Ok(await db.Ekipaa.ToListAsync());
        }

    }
}
