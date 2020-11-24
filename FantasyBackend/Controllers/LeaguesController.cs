using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBackend.DbContextFantasy;
using FantasyBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        LeagueService rs;

        public LeaguesController(FantasyCon context)
        {
            rs = new LeagueService(context);
        }
    }
}
