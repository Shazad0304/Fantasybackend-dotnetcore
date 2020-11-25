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
        public object addLeague(League l)
        {
            l.userId = Guid.Parse(getUserId());
            return Ok(this.rs.add(l));
        }

        [HttpPost("join/{id}")]
        public object joinLeague(String id)
        {
            if (this.rs.Exists(getUserId(), id))
            {
                return Conflict("Already Joined");
            }
            return Ok(this.rs.join(getUserId(),id));
        }

        [HttpGet("getmyleagues")]
        public object getLeague()
        {
      
         return Ok(this.rs.getAll(getUserId()));
            
        }
        
        [HttpGet("getPoints/{id}")]
        public object getScoresByLeague(String id)
        {
            return Ok(this.rs.getPointsbyLeague(id));
        }

        [HttpGet("getleagues")]
        public object getAllLeague()
        {

            return Ok(this.rs.get());

        }

        [HttpGet("getjoinedleagues")]
        public object getjoinedLeague()
        {

            return Ok(this.rs.getjoinedleagues(getUserId()));

        }

        [NonAction]
        public string getUserId()
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
