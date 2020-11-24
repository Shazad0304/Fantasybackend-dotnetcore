using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using FantasyBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        PlayerService ps;

        public PlayerController(FantasyCon context)
        {
            ps = new PlayerService(context);
        }
        public object addPlayer([FromBody] Players ps)
        {
            object resp = this.ps.AddPlayer(ps);
            return resp == null ? Conflict() : resp;
        }
    }
}
