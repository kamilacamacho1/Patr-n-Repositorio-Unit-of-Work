using EFCoreRepositoryUnitofWork.Entities;
using EFCoreRepositoryUnitofWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRepositoryUnitofWork.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AspiranteController : ControllerBase
    {
        private readonly IRepository<Aspirante> _aspiranteReadRepository;

        public AspiranteController(IRepository<Aspirante> aspiranteReadRepository)
        {
            _aspiranteReadRepository = aspiranteReadRepository;
        }
        [HttpGet]
        public ActionResult<Aspirante> Get()
        {
            var results = _aspiranteReadRepository.GetAll();

            return Ok(results);
        }
        [HttpPost]
        public async Task<ActionResult<Aspirante>> AspiranteAdd([FromForm] Aspirante entity)
        {
            if (entity is null)
                return BadRequest(ModelState);

            _aspiranteReadRepository.Add(entity);

            var result = await _aspiranteReadRepository.UnitOfWork.SaveChangesAsync();
            if (result <= 0)
                return BadRequest("Your changes have no[t been saved.");

            return CreatedAtAction(nameof(Get), new { id = entity.ID }, entity);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Aspirante entity)
        {
            if (entity is null)
                return BadRequest(ModelState);

            if (id != entity.ID)
                return BadRequest("Identifier is not valid or Identifiers don't match.");

            var existEntity = await _aspiranteReadRepository.GetByIdAsync(id);

            if (existEntity is null)
                return NotFound($"Entity with Id = {id} not found.");

            var result = await _aspiranteReadRepository.UnitOfWork.SaveChangesAsync();
            if (result <= 0)
                return BadRequest("Your changes have not been saved.");

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _aspiranteReadRepository.GetByIdAsync(id);

            if (entity is null)
                return NotFound($"Entity with Id = {id} not found");

            _aspiranteReadRepository.Delete(entity);

            var result = await _aspiranteReadRepository.UnitOfWork.SaveChangesAsync();
            if (result <= 0)
                return BadRequest();

            return NoContent();
        }
    }
}
