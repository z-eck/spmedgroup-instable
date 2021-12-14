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
    public class PatientsController : ControllerBase
    {
        private IPatientRepository ptntRepository { get; set; }
        public PatientsController()
        {
            ptntRepository = new PatientRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(ptntRepository.ReadAll());
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(ptntRepository.SearchByID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Create(Patient newPatient)
        {
            ptntRepository.Create(newPatient);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, Patient updatedPatient)
        {
            ptntRepository.UpdateURL(id, updatedPatient);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ptntRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
