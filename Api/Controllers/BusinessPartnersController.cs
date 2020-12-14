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
        [HttpGet("GetAll")]
        public async Task<BusinessPartnersDto> GetAsync()
        {
            var res = await _hanaSerivce.GetBusinessPartners();          
            return res;
        }

        // GET api/<BusinessPartnersController>/5
        [HttpGet("{id}")]
        public async Task<BPDetails> Get(string id)
        {
            var res = await _hanaSerivce.GetBusinessPartnersById(id);
            return res;
        }

        // POST api/<BusinessPartnersController>
        [HttpPost("createBP")]
        public async Task<bool> Post([FromBody]BPDetails value)
        {
            var res = await _hanaSerivce.CreateBusinessPartners(value);
            return res;

        }

        // PATCH api/<BusinessPartnersController>/5
        [HttpPatch("{id}")]
        public async Task<bool> Patch([FromBody]BPDetails value)
        {
            var res = await _hanaSerivce.UpdateBusinessPartners(value);

            return res;

        }

        // DELETE api/<BusinessPartnersController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            var res = await _hanaSerivce.DeleteBusinessPartners(id);
            return res;
        }
    }
}
