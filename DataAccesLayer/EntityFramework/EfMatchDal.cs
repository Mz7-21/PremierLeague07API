using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMatchDal : GenericRepository<Match>, IMatchDal
    {
        private readonly PremierLeagueContext _context;

        public EfMatchDal(PremierLeagueContext context) : base(context)
        {
            _context = context;
        }

        public Match GetMatchDetails(int id)
        {
            return _context.Matches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                 .Include(x => x.MatchStatistic)
                .Include(x => x.MatchEvents)
                .ThenInclude(x => x.Team)
                .FirstOrDefault(x => x.MatchId == id);

        }

        public List<Match> GetMatchesWithTeams()
        {
            return _context.Matches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .ToList();
        }
    }
}
