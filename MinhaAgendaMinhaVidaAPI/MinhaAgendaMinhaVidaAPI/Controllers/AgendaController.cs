using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaAgendaMinhaVidaAPI.Models;
using MinhaAgendaMinhaVidaAPI.Services;

namespace MinhaAgendaMinhaVidaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Agenda>>> GetAgendas()
        {
            try
            {
                var agendas = await _agendaService.GetAgendas();

                return Ok(agendas);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting 'agendas'");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Agenda>> GetAgenda(int id)
        {
            try
            {
                var agenda = await _agendaService.GetAgenda(id);

                if (agenda == null)
                {
                    return NotFound();
                }

                return Ok(agenda);

            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid Request : {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("AgendaByTitle")]
        public async Task<ActionResult<Agenda>> GetAgendaByTitle(string title)
        {
            try
            {
                var agendas = await _agendaService.GetAgendaByTitle(title);

                if (agendas == null)
                {
                    return NotFound();
                }

                return Ok(agendas);
            }
            catch(Exception ex)
            {
                return BadRequest($"Invalid Request : {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> EditAgenda(int id, [FromBody] Agenda agenda)
        {
            try
            {
                if (agenda.AgendaId == id)
                {
                    await _agendaService.UpdateAgenda(agenda);
                    return Ok($"Agenda with Id : {id}, sucessfully updated.");
                }
                else 
                {
                    return BadRequest("Not valid data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid Request : {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Agenda>> CreateAgenda(Agenda agenda)
        {
            try
            {
                await _agendaService.CreateAgenda(agenda);
                return CreatedAtRoute(nameof(GetAgenda), new { id = agenda.AgendaId }, agenda);
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid Request : {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgenda(int id)
        {
            try
            {
                var agenda = await _agendaService.GetAgenda(id);

                if (agenda != null)
                {
                    await _agendaService.DeleteAgenda(agenda);
                    return Ok($"Agenda with Id : {id}, sucessfully deleted.");
                }
                else
                {
                    return NotFound($"Agenda with Id: {id}, not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid Request : {ex}");
            }
        }
    }
}
