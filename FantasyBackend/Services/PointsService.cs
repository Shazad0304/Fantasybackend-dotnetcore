using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
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

        public List<Points> addBatch(List<Points> p)
        {
            foreach (Points item in p)
            {
                this.rp.addPoints(item);
            }

            return p;
        }
    }
}
