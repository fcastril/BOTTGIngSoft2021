using BOTTGIngSoft2021.API.Models;
using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BOTTGIngSoft2021.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntentController : ControllerBase
    {
        private readonly IIntentService _intentService;
        private IConfiguration config;
        public IntentController(IIntentService intentService, IConfiguration Config)
        {
            _intentService = intentService;
            config = Config;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Intent> reg = _intentService.Get();
            return Ok(reg);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {

            Intent reg = _intentService.Get(id);
            if (reg == null)
            {
                return NotFound();
            }
            return Ok(reg);
        }

        [HttpGet]
        [Route("Name/{value}")]
        public IActionResult Get(string value)
        {

           Intent reg = _intentService.GetName(value);
            if (reg == null)
            {
                return NotFound();
            }
            return Ok(reg);
        }
        [HttpGet]
        [Route("luis")]
        public async Task<IActionResult> GetLuis()
        {
            List<Intent> ret = new List<Intent>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    string endpointLuis = config.GetValue<string>("endpointLuis");
                    string LuisAppId = config.GetValue<string>("LuisAppId");


                    string url = $"{endpointLuis}{LuisAppId}/versions/0.1/intents?skip=0&take=200";
                    string LuisApiKey = config.GetValue<string>("LuisApiKey");

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {

                        string result = await response.Content.ReadAsStringAsync();
                        ret = JsonConvert.DeserializeObject<List<Intent>>(result);
                    }
                    else
                    {
                        return BadRequest(response);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(ret);
        }
        [HttpGet]
        [Route("luis/id")]
        public async Task<IActionResult> GetLuis(Guid id)
        {
            Intent ret = new Intent();
            try
            {
                ret = await GetLuisIntent(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(ret);
        }

        private async Task<Intent> GetLuisIntent(Guid id)
        {
            Intent ret = new Intent();
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                string endpointLuis = config.GetValue<string>("endpointLuis");
                string LuisAppId = config.GetValue<string>("LuisAppId");


                string url = $"{endpointLuis}{LuisAppId}/versions/0.1/intents/{id}";
                string LuisApiKey = config.GetValue<string>("LuisApiKey");

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    string result = await response.Content.ReadAsStringAsync();
                    ret = JsonConvert.DeserializeObject<Intent>(result);
                }
            }
            return ret;
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("luis/sync")]
        public async Task<IActionResult> PostSync()
        {
            List<Intent> ret = new List<Intent>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    string endpointLuis = config.GetValue<string>("endpointLuis");
                    string LuisAppId = config.GetValue<string>("LuisAppId");


                    string url = $"{endpointLuis}{LuisAppId}/versions/0.1/intents?skip=0&take=200";
                    string LuisApiKey = config.GetValue<string>("LuisApiKey");

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {

                        string result = await response.Content.ReadAsStringAsync();
                        ret = JsonConvert.DeserializeObject<List<Intent>>(result);
                        Intent intentGet = new Intent();
                        foreach (Intent intent in ret)
                        {
                            intentGet = _intentService.Get(intent.Id);
                            if (intentGet == null)
                            {
                                _intentService.Insert(intent);
                            }
                            else
                            {
                                _intentService.Update(intent);
                            }
                        }
                    }
                    else
                    {
                        return BadRequest(response);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(ret);

        }
        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(IntentViewModel intent)
        {

            Intent reg = new Intent();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    string endpointLuis = config.GetValue<string>("endpointLuis");
                    string LuisAppId = config.GetValue<string>("LuisAppId");


                    string url = $"{endpointLuis}{LuisAppId}/versions/0.1/intents";
                    string LuisApiKey = config.GetValue<string>("LuisApiKey");

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                    IntentViewModel intentViewModel = intent;

                    string objetoSerializado = JsonConvert.SerializeObject(intentViewModel);
                    StringContent contenido = new StringContent(objetoSerializado, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, contenido);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        result = result.Replace("\"", string.Empty) ;
                        reg = await GetLuisIntent(Guid.Parse(result));
                        reg.Answer = intent.Answer;

                        _intentService.Insert(reg);

                    }
                    else
                    {
                        return BadRequest(response);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(reg);
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Intent reg)
        {
            if (id != reg.CodeId)
            {
                return BadRequest();
            }

            _intentService.Update(reg);
            reg = _intentService.Get(id);

            return Ok(reg);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            Intent reg = _intentService.Get(id);

            if (reg == null)
            {
                return NotFound();
            }

            _intentService.Delete(id);

            return Ok(reg);
        }
    }
}
