using api1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using weatherForm.DTO;

namespace api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult get(string name)
        {
            HttpClient client = new HttpClient();
            string url = $" http://api.weatherapi.com/v1/current.json?key=cf816923d55440db88580453232712&q={name}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                Weateher data = response.Content.ReadAsAsync<Weateher>().Result;
                return Ok(data);
            }
            else
            {
                return BadRequest("error");
            }
            
        }
      
        
    }
}
