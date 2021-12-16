using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using senai_spmg_webAPI.Repositories;
using System;

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
            try
            {
                return Ok(clncRepository.ReadAll());
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    Message = "Não foi possível listar as informações da clínica!",
                    error
                });
            }
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            try
            {
                return Ok(clncRepository.SearchByID(id));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    Message = "Não foi possível achar a clínica pelo ID!",
                    error
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, Clinic updatedClinic)
        {
            try
            {
                clncRepository.UpdateURL(id, updatedClinic);

                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    Message = "Não foi possível atualizar as informações da clínica!",
                    error
                });
            }
            
        }
    }
}
