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
    public class TeamsController : ControllerBase
    {
        TeamsService rs;

        public TeamsController(FantasyCon context)
        {
            rs = new TeamsService(context);
        }
    }
}
