using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module4HM4_EF.Context;

namespace Module4HM4_EF.Controllers
{
    [Route("/api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetContext _petContext;

        public PetController(PetContext petContext)
        {
            _petContext = petContext;
        }

        [HttpGet("connection")]
        public async Task<ActionResult> TestConnection()
        {
            if (_petContext.Database.CanConnect()) return Ok(_petContext.Database.ProviderName);
            return BadRequest();
        }


        [HttpGet("pets")]
        public async Task<ActionResult> GetPets()
        {
            var pets = await _petContext.Pets.ToListAsync();
            return Ok(pets);
        }
    }


}
