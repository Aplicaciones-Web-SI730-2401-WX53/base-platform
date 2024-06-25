using BasePlatform.API.Operation.Domain.Models.Comands;
using BasePlatform.API.Operation.Domain.Services.Comands;
using BasePlatform.API.Operation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasePlatform.API.Operation.Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianCommandService _guardianCommandService;
        
        public GuardianController(IGuardianCommandService guardianCommandService)
        {
            _guardianCommandService = guardianCommandService;
        }
        
        // GET: api/<GuardianController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GuardianController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GuardianController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGuardianCommand command)
        {
            await _guardianCommandService.HandleAsync(command);    
            return Ok();
        }

        // PUT api/<GuardianController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GuardianController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
