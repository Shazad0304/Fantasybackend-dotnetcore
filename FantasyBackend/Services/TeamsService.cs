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
        TeamsRepository rp;

        public TeamsService(FantasyCon context)
        {
            rp = new TeamsRepository(context);
        }

        public List<UserTeams> AddBatch(Guid id,List<String> Players)
        {
            this.rp.DeleteUserTeam(id);
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

        public List<Players> MyTeam(String id)
        {
            return this.rp.getmyTeam(Guid.Parse(id));
        }
    }
}
