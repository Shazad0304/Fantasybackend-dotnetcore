using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using FantasyBackend.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Services
{
    public class TeamsService
    {
        TeamsRepo rp;

        public TeamsService(FantasyCon context)
        {
            rp = new TeamsRepo(context);
        }

        public List<UserTeams> addBatch(Guid id,List<String> Players)
        {
            List<UserTeams> us = new List<UserTeams>();
            foreach (String item in Players)
            {
                us.Add(this.rp.AddTeam(new UserTeams()
                {
                    userId = id,
                    PlayerId = Guid.Parse(item)
                }));
            }
            return us;
        }
    }
}
