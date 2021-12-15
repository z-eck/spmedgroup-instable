using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmg_webAPI.Interfaces;
using senai_spmg_webAPI.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace senai_spmg_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private IUserRepository srRepository { get; set; }
        public ProfilesController()
        {
            srRepository = new UserRepository();
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("image/bd")]
        public IActionResult getbd()
        {
            try
            {

                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = srRepository.SearchProfileDB(idUser);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpGet("image/dir")]
        public IActionResult getDIR()
        {
            try
            {

                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = srRepository.SearchProfileDir(idUser);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpPost("image/bd")]
        public IActionResult postBD(IFormFile archive)
        {
            try
            {
                if (archive.Length > 5000000)
                    return BadRequest(new { Message = "Por favor, selecione uma imagem de tamanho em MegaBytes menor! O sistema não suporta aquivos maior que 5 MB." });

                string extension = archive.FileName.Split('.').Last();

                if (extension != "png" || extension != "jpg" || extension != "jpeg")
                    return BadRequest(new { Message = "Apenas arquivos .png, .jpg e .jpeg são permitidos no sistema." });


                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                srRepository.SaveProfileDB(archive, idUser);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [Authorize(Roles = "1, 2, 3")]
        [HttpPost("image/dir")]
        public IActionResult postDIR(IFormFile archive)
        {
            try
            {
                if (archive.Length > 5000)
                    return BadRequest(new { Message = "Por favor, selecione uma imagem de tamanho em MegaBytes menor! O sistema não suporta aquivos maior que 5 MB." });

                string extension = archive.FileName.Split('.').Last();

                if (extension != "png" || extension != "jpg" || extension != "jpeg")
                    return BadRequest(new { Message = "Apenas arquivos .png, .jpg e .jpeg são permitidos no sistema." });


                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                srRepository.SaveProfilelDir(archive, idUser);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
