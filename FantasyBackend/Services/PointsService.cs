using FantasyBackend.DbContextFantasy;
using FantasyBackend.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Services
{
    public class PointsService
    {
        PointsRepo rp;

        public PointsService(FantasyCon context)
        {
            rp = new PointsRepo(context);
        }
    }
}
