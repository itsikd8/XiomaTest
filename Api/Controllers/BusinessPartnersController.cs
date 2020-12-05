using Api.Domain.Entities;
using Api.Domain.Serivces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPartnersController : ControllerBase
    {
        private IHanaSerivce _hanaSerivce;

        public BusinessPartnersController(IHanaSerivce hanaSerivce)
        {
            _hanaSerivce = hanaSerivce;
        }
        // GET: api/<BusinessPartnersController>
        [HttpGet]
        public IEnumerable<BusinessPartnersDto> Get()
        {
            var res = _hanaSerivce.GetBusinessPartners(); 
            return null;
        }

        // GET api/<BusinessPartnersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BusinessPartnersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BusinessPartnersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusinessPartnersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
