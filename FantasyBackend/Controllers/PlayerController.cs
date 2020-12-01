using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using FantasyBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        PlayerService ps;

        public PlayerController(FantasyCon context)
        {
            ps = new PlayerService(context);
        }


        [HttpPost("add")]
        public object AddPlayer([FromBody] Players ps)
        {
            object resp = this.ps.AddPlayer(ps);
            return resp == null ? Conflict() : resp;
        }

        [HttpGet("getbyteam/{team}")]
        public object GetPlayerByTeam(string team)
        {
            return this.ps.GetPlayerByTeam(team);
        }

        [HttpGet("getall")]
        public object GetPlayers()
        {
            return this.ps.All();
        }
    }
}
