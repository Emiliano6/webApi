using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/acuario")]
    public class AcuarioController : ControllerBase
    {
        private readonly ApplicationDB dbContext;
        public AcuarioController(ApplicationDB context)
        {
            this.dbContext = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Acuario>>> Get()
        {
            return await dbContext.Acuarios.ToListAsync();
        }
        [HttpGet("/lista")]
        public async Task<ActionResult<List<Acuario>>> GetAll(){
            return await dbContext.Acuarios.Include(x => x.Peceras).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post (Acuario acuario)
        {
            dbContext.Add(acuario);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Acuario acuario, int id)
        {
            if(acuario.AcuarioID != id)
            {
                return BadRequest("El id del acuario no coincide con el id del objeto");
            }
            dbContext.Update(acuario);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Acuarios.AnyAsync(x => x.AcuarioID == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Acuario() { 
                AcuarioID = id 
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
