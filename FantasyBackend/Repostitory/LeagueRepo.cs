using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Repostitory
{
    public class LeagueRepo
    {
        FantasyCon context;

        public LeagueRepo(FantasyCon context)
        {
            this.context = context;
        }

        public List<League> getAll(Guid id)
        {
            return this.context.Leagues.Where(x => x.userId == id).ToList();
        }

        public List<League> getAllWithoutId()
        {
            return this.context.Leagues.ToList();
        }

        public League addLeague(League l)
        {
            this.context.Leagues.Add(l);
            this.context.SaveChanges();
            return l;
        }

        public UserJoinLeagues joinleague(UserJoinLeagues uj)
        {
            this.context.joinLeagues.Add(uj);
            this.context.SaveChanges();
            return uj;
        }

        public bool Existed(Guid userid,Guid leagueId)
        {
            if(context.joinLeagues
                .Where(x => x.UserId == userid && x.LeagueId == leagueId).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public List<League> getmyjoinleagues(Guid id)
        {
            return (from p in context.joinLeagues
                    join e in context.Leagues
                    on p.LeagueId equals e.Id
                    where p.UserId == id
                    select e).ToList();
        }

        public object getLeagueScores(Guid id)
        {

            object a = (from jl in context.joinLeagues
                        join user in context.Register
                        on jl.UserId equals user.Id
                        join tms in context.UserTeams
                        on user.Id equals tms.userId
                        join players in context.Players
                        on tms.PlayerId equals players.Id
                        join points in context.Points
                        on players.Id equals points.PlayerId
                        where jl.LeagueId == id
                        select new
                        {
                            User = user.FullName,
                            PlayerName = players.Name,
                            point = points.points
                        }
                        )
                        .ToList()
                        .GroupBy(r => r.User)
                        .Select(s => new
                        {
                            userName = s.First().User,
                            totalPoints = s.Sum(p => p.point)
                        });

            return a;
        }
    }
}
