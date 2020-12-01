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
        PointsRepository rp;

        public PointsService(FantasyCon context)
        {
            rp = new PointsRepository(context);
        }

        public List<RequestPoints> AddBatch(List<RequestPoints> players)
        {
            foreach (RequestPoints player in players)
            {
                this.rp.AddPoints(new Points() {
                leagueId = Guid.Parse(player.leagueId),
                PlayerId = Guid.Parse(player.PlayerId),
                points = player.points
                });
            }

            return players;
        }
    }
}
