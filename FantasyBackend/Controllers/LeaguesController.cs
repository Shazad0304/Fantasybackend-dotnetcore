using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class LeaguesController : ControllerBase
    {
        LeagueService rs;

        public LeaguesController(FantasyCon context)
        {
            rs = new LeagueService(context);
        }

        [HttpPost("add")]
        public object AddLeague(League l)
        {
            l.userId = Guid.Parse(GetUserId());
            return Ok(this.rs.Add(l));
        }

        [HttpPost("join/{id}")]
        public object JoinLeague(String id)
        {
            if (this.rs.Exists(GetUserId(), id))
            {
                return Conflict("Already Joined");
            }
            return Ok(this.rs.Join(GetUserId(),id));
        }

        [HttpGet("getmyleagues")]
        public object GetLeague()
        {
      
         return Ok(this.rs.GetAll(GetUserId()));
            
        }
        
        [HttpGet("getPoints/{id}")]
        public object GetScoresByLeague(String id)
        {
            return Ok(this.rs.GetPointsByLeague(id));
        }

        [HttpGet("getleagues")]
        public object GetAllLeague()
        {

            return Ok(this.rs.Get());

        }

        [HttpGet("getjoinedleagues")]
        public object GetJoinedLeague()
        {

            return Ok(this.rs.GetJoinedLeagues(GetUserId()));

        }

        [NonAction]
        public string GetUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
              return identity.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            }
            else
            {
                throw new Exception("Id not found");
            }
        }
    }
}
