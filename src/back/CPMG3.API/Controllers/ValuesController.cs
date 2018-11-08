using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPMG3.API.Filter;
using CPMG3.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace CPMG3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGithubAPIService _service;

        public ValuesController(IGithubAPIService service)
        {
            _service = service;
        }

        [FeatureToggleFilter(ApplicationConstants.FeatureToggle.ACAO_EXCLUIR)]
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            //return new string[] { "value1", "value2" };

            return await _service.GetRepositories();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
