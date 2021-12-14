using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using senai_spmg_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace senai_spmg_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingsController : ControllerBase
    {
        private ISchedulingRepository schdlngRepository { get; set; }
        public SchedulingsController()
        {
            schdlngRepository = new SchedulingRepository();
        }

        //[Authorize(Roles = "1, 2, 3")]
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(schdlngRepository.ReadAll());
        }

        //[Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult SearchID(int id)
        {
            return Ok(schdlngRepository.SearchByID(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Create(Scheduling newScheduling)
        {
            schdlngRepository.Create(newScheduling);

            return StatusCode(201);
        }

        [Authorize(Roles = "1, 2")]
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, Scheduling updatedScheduling)
        {
            schdlngRepository.UpdateURL(id, updatedScheduling);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            schdlngRepository.Delete(id);

            return StatusCode(204);
        }

        [Authorize(Roles = "2, 3")]
        [HttpGet("read/mines")]
        public IActionResult ReadMine()
        {
            try
            {

                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(s => s.Type == JwtRegisteredClaimNames.Jti).Value);
                int idTipo = Convert.ToInt32(HttpContext.User.Claims.First(s => s.Type == ClaimTypes.Role).Value);
                List<Scheduling> SchedulingList = schdlngRepository.ReadMine(idUser, idTipo);

                if (SchedulingList.Count == 0)
                {
                    return NotFound(new
                    {
                        Message = "Não possui registros de agendamentos neste usuário."
                    });
                }

                if (idTipo == 2 || idTipo == 3)
                {
                    return Ok(new
                    {
                        Message = $"O usuário possui {schdlngRepository.ReadMine(idUser, idTipo).Count} agendamentos.",
                        SchedulingList
                    });
                }
                return null;

            }
            catch (Exception error)
            {

                return BadRequest(new
                {
                    Message = "Não é possível mostrar os agendamentos se o usuário não estiver logado como médico ou paciente!",
                    error
                });
            }

        }

        [Authorize(Roles = "3")]
        [HttpPatch("ChangeDescription/{id}")]
        public IActionResult ChangeDescription(Scheduling scheduling, int id)
        {
            try
            {
                Scheduling searchScheduling = schdlngRepository.SearchByID(id);
                int idMedic = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                if (scheduling.SchedulingDescription == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "É necessário informar a descrição!"
                    });
                }

                if (schdlngRepository.SearchByID(id) == null || id <= 0)
                {
                    return NotFound(new
                    {
                        Mensagem = "Não há nenhuma consulta com o ID informado!"
                    });
                }

                if (searchScheduling.IdMedic != idMedic)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Apenas o médico designado ao agendamento é capaz de alterar a descrição."
                    });
                }
                schdlngRepository.ChangeDescription(scheduling.SchedulingDescription, id); // <--
                return StatusCode(200, new
                {
                    Mensagem = "A descrição da consulta foi alterada com sucesso!",
                    searchScheduling
                });
            }
            catch (Exception error)
            {

                return BadRequest(new
                {
                    Message = "Não foi possível alterar a descrição do agendamento!",
                    error
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("situation/{idSituation}")]
        public IActionResult ChangeSituation(int id, Scheduling situation)
        {
            try
            {
                if (schdlngRepository.SearchByID(id) == null || id <= 0)
                {
                    return NotFound(new
                    {
                        Mensagem = "Não há nenhum agendamento com o ID informado!"
                    });
                }

                schdlngRepository.ChangeSituation(id, situation.IdSituation.ToString());

                return StatusCode(204, new {

                    Message = "A situação do agendamento foi alterado!"
                    
                    });
            }
            catch (Exception error)
            {

                return BadRequest(new
                {
                    Message = "Não foi possível alterar a situação do agendamento!",
                    error
                });
            }
        }
    }
}
