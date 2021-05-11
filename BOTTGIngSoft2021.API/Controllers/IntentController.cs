using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntentController : ControllerBase
    {
        private readonly IIntentService _intentService;
        public IntentController(IIntentService intentService)
        {
            _intentService = intentService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Intent> reg = _intentService.GetIntents();
            return Ok(reg);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {

            Intent reg = _intentService.GetIntent(id);
            if (reg == null)
            {
                return NotFound();
            }
            return Ok(reg);
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post(Intent reg)
        {
            _intentService.InsertIntent(reg);
            return Ok(reg);
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Intent reg)
        {
            if (id != reg.Id)
            {
                return BadRequest();
            }

            _intentService.UpdateIntent(reg);
            reg = _intentService.GetIntent(id);

            return Ok(reg);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            Intent reg = _intentService.GetIntent(id);

            if (reg == null)
            {
                return NotFound();
            }

            _intentService.DeleteIntent(id);

            return Ok(reg);
        }
    }
}
