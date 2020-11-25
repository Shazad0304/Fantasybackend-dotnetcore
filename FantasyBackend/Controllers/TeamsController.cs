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
    public class TeamsController : ControllerBase
    {
        TeamsService rs;

        public TeamsController(FantasyCon context)
        {
            rs = new TeamsService(context);
        }

        [HttpPost("addAll")]
        public object addBatch([FromBody] List<String> playersid)
        {
            if (playersid.Count != 11)
            {
                return BadRequest("Players must be 11");
            }
            return this.rs.addBatch(Guid.Parse(getUserId()),playersid);
        }

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
