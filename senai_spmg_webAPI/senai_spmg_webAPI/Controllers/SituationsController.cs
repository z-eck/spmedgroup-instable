using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_spmg_webAPI.Interfaces;
using senai_spmg_webAPI.Repositories;

namespace senai_spmg_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituationsController : ControllerBase
    {
        private ISituationRepository sttnRepository { get; set; }
        public SituationsController()
        {
            sttnRepository = new SituationRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(sttnRepository.ReadAll());
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(sttnRepository.SearchByID(id));
        }
    }
}
