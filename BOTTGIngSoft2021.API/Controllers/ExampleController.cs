using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BOTTGIngSoft2021.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;
        private IConfiguration config;
        public ExampleController(IExampleService exampleService, IConfiguration Config)
        {
            _exampleService = exampleService;
            config = Config;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Example> reg = _exampleService.Get();
            return Ok(reg);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {

            Example reg = _exampleService.Get(id);
            if (reg == null)
            {
                return NotFound();
            }
            return Ok(reg);
        }

        [HttpGet]
        [Route("NameIntent/{value}")]
        public IActionResult Get(string value)
        {

            Example reg = _exampleService.Get(value);
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
            List<Example> ret = new List<Example>();
            try
            {
                ret = await GetLuisMethodAsync();
                if (ret.Count == 0)
                {
                    BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(ret);
        }

        private async Task<List<Example>> GetLuisMethodAsync()
        {
            List<Example> ret = new List<Example>();
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                string endpointLuis = config.GetValue<string>("endpointLuis");
                string LuisAppId = config.GetValue<string>("LuisAppId");


                string url = $"{endpointLuis}{LuisAppId}/versions/0.1/examples?skip=0&take=200";
                string LuisApiKey = config.GetValue<string>("LuisApiKey");

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    string result = await response.Content.ReadAsStringAsync();
                    ret = JsonConvert.DeserializeObject<List<Example>>(result);
                }
            }
            return ret;
        }

        [HttpGet]
        [Route("luis/{nameIntent}")]
        public async Task<IActionResult> GetLuis(string nameIntent)
        {
            IEnumerable<Example> ret = new List<Example>();
            try
            {
                ret = await GetLuisMethodAsync();
                ret = ret.Where(e => e.IntentLabel == nameIntent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(ret);
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(Example reg)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    string endpointLuis = config.GetValue<string>("endpointLuis");
                    string LuisAppId = config.GetValue<string>("LuisAppId");


                    string url = $"{endpointLuis}{LuisAppId}/versions/0.1/examples";
                    string LuisApiKey = config.GetValue<string>("LuisApiKey");

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                    Models.ExampleViewModel exampleViewModel = new Models.ExampleViewModel(reg.Text, reg.IntentLabel);
                    List<Models.ExampleViewModel> listExamples = new List<Models.ExampleViewModel>();
                    listExamples.Add(exampleViewModel);
                    string objetoSerializado = JsonConvert.SerializeObject(listExamples);
                    StringContent contenido = new StringContent(objetoSerializado, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, contenido);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        result = result.Replace("\"", string.Empty);
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
      

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            Example reg = _exampleService.Get(id);

            if (reg == null)
            {
                return NotFound();
            }

            _exampleService.Delete(id);

            return Ok(reg);
        }

    }
}
