using EFCoreRepositoryUnitofWork.Entities;
using EFCoreRepositoryUnitofWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRepositoryUnitofWork.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PreguntaController : ControllerBase
    {
        private readonly IRepository<Pregunta> _preguntaReadRepository;
        public PreguntaController(IRepository<Pregunta> PreguntaReadRepository)
        {
            _preguntaReadRepository = PreguntaReadRepository;
        }
        [HttpGet]
        public ActionResult<Pregunta> Get()
        {
            var results = _preguntaReadRepository.GetAll();

            return Ok(results);
        }
        [HttpPost]
        public async Task<ActionResult<Pregunta>> PreguntaAdd([FromForm] Pregunta entity)
        {
            if (entity is null)
                return BadRequest(ModelState);

            _preguntaReadRepository.Add(entity);

            var result = await _preguntaReadRepository.UnitOfWork.SaveChangesAsync();
            if (result <= 0)
                return BadRequest("Your changes have no[t been saved.");

            return CreatedAtAction(nameof(Get), new { id = entity.ID }, entity);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pregunta entity)
        {
            if (entity is null)
                return BadRequest(ModelState);

            if (id != entity.ID)
                return BadRequest("Identifier is not valid or Identifiers don't match.");

            var existEntity = await _preguntaReadRepository.GetByIdAsync(id);

            if (existEntity is null)
                return NotFound($"Entity with Id = {id} not found.");

            var result = await _preguntaReadRepository.UnitOfWork.SaveChangesAsync();
            if (result <= 0)
                return BadRequest("Your changes have not been saved.");

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _preguntaReadRepository.GetByIdAsync(id);

            if (entity is null)
                return NotFound($"Entity with Id = {id} not found");

            _preguntaReadRepository.Delete(entity);

            var result = await _preguntaReadRepository.UnitOfWork.SaveChangesAsync();
            if (result <= 0)
                return BadRequest();

            return NoContent();
        }
    }
}
