using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class PointsRepository
    {
        FantasyCon context;

        public PointsRepository(FantasyCon context)
        {
            this.context = context;
        }

        public Points AddPoints(Points point)
        {
            this.context.Add(point);
            this.context.SaveChanges();
            return point;
        }


    }
}
