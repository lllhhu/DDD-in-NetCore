using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameId.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GameId.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IOrderAppService orderAppService;
        IBizofferAppService bizofferAppService;
        public ValuesController(IOrderAppService orderAppService,IBizofferAppService bizofferAppService)
        {
            this.orderAppService = orderAppService;
            this.bizofferAppService = bizofferAppService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            this.bizofferAppService.CreateBizoffer("测试发布单1", 100, "G1452233", "暗黑", "US00021", "tianka21");
            this.orderAppService.PlaceOrder("fds", "us001", "us002");

            return new string[] { "value1", "value2" };
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
