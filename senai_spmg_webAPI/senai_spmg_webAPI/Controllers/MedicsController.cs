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
    public class MedicsController : ControllerBase
    {
        private IMedicRepository mdcRepository { get; set; }
        public MedicsController()
        {
            mdcRepository = new MedicRepository();
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(mdcRepository.ReadAll());
        }

        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(mdcRepository.SearchByID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Create(Medic newMedic)
        {
            mdcRepository.Create(newMedic);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, Medic updatedMedic)
        {
            mdcRepository.UpdateURL(id, updatedMedic);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            mdcRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
