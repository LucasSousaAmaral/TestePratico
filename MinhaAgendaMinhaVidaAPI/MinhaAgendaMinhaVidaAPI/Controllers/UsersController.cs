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
    public class UsersController : ControllerBase
    {
        private readonly IAgendaService _agendaService;
        private readonly IUserService _userService;

        public UsersController(IAgendaService agendaService, IUserService userService)
        {
            _agendaService = agendaService;
            _userService = userService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();

                foreach (var user in users)
                {
                    user.Agendas.Add(await _agendaService.GetAgenda(user.UserId));
                }

                return Ok(users);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting 'users'");
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    user.Agendas.Add(await _agendaService.GetAgenda(user.UserId));
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid Request : {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("UserByName")]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            try
            {
                var users = await _userService.GetUserByName(name);

                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    foreach (var user in users)
                    {
                        user.Agendas.Add(await _agendaService.GetAgenda(user.UserId));
                    }
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid Request : {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> EditUser(int id, [FromBody] User user)
        {
            try
            {
                if (user.UserId == id)
                {
                    await _userService.UpdateUser(user);
                    return Ok($"User with Id : {id}, sucessfully updated.");
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
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                await _userService.CreateUser(user);
                return CreatedAtRoute(nameof(GetUser), new { id = user.UserId }, user);
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);

                if (user != null)
                {
                    await _userService.DeleteUser(user);
                    return Ok($"User with Id : {id}, sucessfully deleted.");
                }
                else
                {
                    return NotFound($"User with Id: {id}, not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid Request : {ex}");
            }
        }
    }
}
