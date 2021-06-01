using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOTTGIngSoft2021.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersBotController : ControllerBase
    {
        private readonly IUsersBotService _UsersBotService;
        public UsersBotController(IUsersBotService UsersBotService)
        {
            _UsersBotService = UsersBotService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UsersBot> reg = _UsersBotService.Get();
            return Ok(reg);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {

            UsersBot reg = _UsersBotService.Get(id);
            if (reg == null)
            {
                return NotFound();
            }
            return Ok(reg);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(string name)
        {

            UsersBot reg = new UsersBot();
            try
            {
                _UsersBotService.Insert(reg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(reg);
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UsersBot reg)
        {
            if (id != reg.CodeId)
            {
                return BadRequest();
            }

            _UsersBotService.Update(reg);
            reg = _UsersBotService.Get(id);

            return Ok(reg);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            UsersBot reg = _UsersBotService.Get(id);

            if (reg == null)
            {
                return NotFound();
            }

            _UsersBotService.Delete(id);

            return Ok(reg);
        }
    }
}
