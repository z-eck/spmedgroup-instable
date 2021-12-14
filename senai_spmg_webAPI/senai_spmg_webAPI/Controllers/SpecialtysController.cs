using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using senai_spmg_webAPI.Repositories;

namespace senai_spmg_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtysController : ControllerBase
    {
        private ISpecialtyRepository spcltyRepository { get; set; }
        public SpecialtysController()
        {
            spcltyRepository = new SpecialtyRepository();
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(spcltyRepository.ReadAll());
        }

        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(spcltyRepository.SearchByID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Create(Specialty newSpecialty)
        {
            spcltyRepository.Create(newSpecialty);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, Specialty updatedSpecialty)
        {
            spcltyRepository.UpdateURL(id, updatedSpecialty);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            spcltyRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
