using BOTTGIngSoft2021.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BOTTGIngSoft2021.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuisController : ControllerBase
    {
        private IConfiguration config;
        public LuisController(IConfiguration Config)
        {
            config = Config;
        }
        // POST api/<UserController>
        [HttpPost]
        [Route("Train")]
        public async Task<IActionResult> Train()
        {
            string result = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    string endpointLuis = config.GetValue<string>("endpointLuis");
                    string LuisAppId = config.GetValue<string>("LuisAppId");


                    string url = $"{endpointLuis}{LuisAppId}/versions/0.1/train";
                    string LuisApiKey = config.GetValue<string>("LuisApiKey");

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                    string objetoSerializado = string.Empty;
                    StringContent contenido = new StringContent(objetoSerializado, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, contenido);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
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
            return Ok(result);
        }
        [HttpPost]
        [Route("Publish/Production")]

        public async Task<IActionResult> PublishProduction()
        {
            string result = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    string endpointLuis = config.GetValue<string>("endpointLuis");
                    string LuisAppId = config.GetValue<string>("LuisAppId");


                    string url = $"{endpointLuis}{LuisAppId}/publish";
                    string LuisApiKey = config.GetValue<string>("LuisApiKey");

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                    PublishViewModel publish = new PublishViewModel();


                    string objetoSerializado = JsonConvert.SerializeObject(publish);
                    StringContent contenido = new StringContent(objetoSerializado, Encoding.UTF8, "application/json");


                    HttpResponseMessage response = await client.PostAsync(url, contenido);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
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
            return Ok(result);
        }
        [HttpPost]
        [Route("Publish/Slot")]
        public async Task<IActionResult> PublishSlot()
        {
            string result = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    string endpointLuis = config.GetValue<string>("endpointLuis");
                    string LuisAppId = config.GetValue<string>("LuisAppId");


                    string url = $"{endpointLuis}{LuisAppId}/publish";
                    string LuisApiKey = config.GetValue<string>("LuisApiKey");

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", LuisApiKey);

                    PublishViewModel publish = new PublishViewModel();
                    publish.IsStaging = true;

                    string objetoSerializado = JsonConvert.SerializeObject(publish);
                    StringContent contenido = new StringContent(objetoSerializado, Encoding.UTF8, "application/json");


                    HttpResponseMessage response = await client.PostAsync(url, contenido);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
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
            return Ok(result);
        }
    }
}
