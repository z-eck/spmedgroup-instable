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
    public class UsersController : ControllerBase
    {
        private IUserRepository srRepository { get; set; }
        public UsersController()
        {
            srRepository = new UserRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(srRepository.ReadAll());
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(srRepository.SearchByID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Create(User newUser)
        {
            srRepository.Create(newUser);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, User updatedUser)
        {
            srRepository.UpdateURL(id, updatedUser);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            srRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
