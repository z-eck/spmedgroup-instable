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
    public class ClinicsController : ControllerBase
    {
        private IClinicRepository clncRepository { get; set; }
        public ClinicsController()
        {
            clncRepository = new ClinicRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(clncRepository.ReadAll());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(clncRepository.SearchByID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, Clinic updatedClinic)
        {
            clncRepository.UpdateURL(id, updatedClinic);

            return StatusCode(204);
        }
    }
}
