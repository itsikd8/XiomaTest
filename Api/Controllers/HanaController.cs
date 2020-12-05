using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Serivces;
using Api.Domain.Serivces._Default;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HanaController : ControllerBase
    {
        private IHanaSerivce _hanaSerivce;

        public HanaController(IHanaSerivce hanaSerivce)
        {
            _hanaSerivce = hanaSerivce;
        }

        // POST api/values
        [HttpPost("login")]
        public async Task<Session> LoginAsync([FromBody]LoginDetails user)
        {
            var session = await _hanaSerivce.PostLogin(user);

            return session;
        }

       
    }
}
