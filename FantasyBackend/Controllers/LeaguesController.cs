﻿using System;
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
            this.rs.add(l);
            return Ok(new Response() {Message="League Created",Status="200" });
        }

        [HttpGet("getAll")]
        public object getLeague()
        {
      
         return Ok(this.rs.getAll(getUserId()));
            
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
