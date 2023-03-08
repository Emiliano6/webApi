using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;

namespace webApi.Controllers{
    [ApiController]
    [Route("api/pecera")]
    public class PeceraController : ControllerBase{
        private readonly ApplicationDB dbContext;
        public PeceraController(ApplicationDB context){
            this.dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pecera>>> Get(){
            return await dbContext.Peceras.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pecera>> Get(int id){
            return await dbContext.Peceras.FirstOrDefaultAsync(x => x.PeceraID == id);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Pecera pecera){
            var existeAcuario = await dbContext.Acuarios.AnyAsync(x => x.AcuarioID == pecera.AcuarioID);
            if (!existeAcuario)
            {
                return BadRequest("El acuario no existe");
            }
            dbContext.Add(pecera);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Pecera pecera, int id){
            var existeAcuario = await dbContext.Acuarios.AnyAsync(x => x.AcuarioID == pecera.AcuarioID);
            if (!existeAcuario)
            {
                return BadRequest("El acuario no existe");
            }
            if (pecera.PeceraID != id)
            {
                return BadRequest("El id de la pecera no coincide con el id de la url");
            }
            dbContext.Update(pecera);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id){
            var exists = await dbContext.Peceras.AnyAsync(x => x.PeceraID == id);
            if (!exists)
            {
                return NotFound("no se encontro la pecera");

            }
            dbContext.Remove(new Pecera() 
            { 
                PeceraID = id 
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}