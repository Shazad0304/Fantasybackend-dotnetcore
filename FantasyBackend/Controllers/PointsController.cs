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
    public class PointsController : ControllerBase
    {
        PointsService rs;

        public PointsController(FantasyCon context)
        {
            rs = new PointsService(context);
        }

        [HttpPost("addBatch")]
        public object addBatch([FromBody] List<RequestPoints> pay)
        {
            return this.rs.addBatch(pay);
        }
    }
}
