using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using senai_spmg_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmg_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationsController : ControllerBase
    {
        private ILocalizationRepository lclztnRepository { get; set; }

        public LocalizationsController()
        {
            lclztnRepository = new LocalizationRepository();
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            try
            {
                return Ok(lclztnRepository.ReadAll());
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    Message = "Não foi possível buscar as localizações!",
                    error
                });
            }
        }

        [HttpPost]
        public IActionResult Create(Localization newLocalization)
        {
            try
            {
                lclztnRepository.Create(newLocalization);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    Message = "Não foi possível criar a nova localização!",
                    error
                });
            }
        }
    }
}
