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
    [Authorize(Roles = "1")]
    public class UserTypesController : ControllerBase
    {
        private IUserTypeRepository usTpRepository { get; set; }
        public UserTypesController()
        {
            usTpRepository = new UserTypeRepository();
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(usTpRepository.ReadAll());
        }


        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(usTpRepository.SearchByID(id));
        }

        [HttpPost]
        public IActionResult Create(Usertype newUsertype)
        {
            usTpRepository.Create(newUsertype);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, Usertype updatedUserType)
        {
            usTpRepository.UpdateURL(id, updatedUserType);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            usTpRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
