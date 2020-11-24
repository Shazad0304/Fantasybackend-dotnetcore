using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using FantasyBackend.Repostitory;
using FantasyBackend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FantasyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        RegisterService rs;

        public RegisterController(FantasyCon context)
        {
            rs = new RegisterService(context);
        }
        
        [HttpPost("add")]
        public Dictionary<string, object> addUser([FromBody] Register payload)
        {
            return this.rs.add(payload);
        }
        
        [HttpPost("login")]
        public object Login([FromBody] Register r)
        {
            object resp = rs.Login(r);
            if (resp == null)
            {
                return NotFound("No User Found");
            }
            else
            {
                return resp;
            }
        }
    }
}
