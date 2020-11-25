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

        public List<RequestPoints> addBatch(List<RequestPoints> p)
        {
            foreach (RequestPoints item in p)
            {
                this.rp.addPoints(new Points() {
                leagueId = Guid.Parse(item.leagueId),
                PlayerId = Guid.Parse(item.PlayerId),
                points = item.points
                });
            }

            return p;
        }
    }
}
