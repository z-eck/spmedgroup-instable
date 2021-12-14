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
    public class LocaladressesController : ControllerBase
    {
        private ILocalAddressRepository lclddrssRepository { get; set; }
        public LocaladressesController()
        {
            lclddrssRepository = new LocalAddressRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(lclddrssRepository.ReadAll());
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(lclddrssRepository.SearchByID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Create(Localaddress newAddress)
        {
            lclddrssRepository.Create(newAddress);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, Localaddress updatedAddress)
        {
            lclddrssRepository.UpdateURL(id, updatedAddress);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            lclddrssRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
