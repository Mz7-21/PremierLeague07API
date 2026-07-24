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
    public class EfMatchEventDal : GenericRepository<MatchEvent>, IMatchEventDal
    {
        private readonly PremierLeagueContext _context;

        public EfMatchEventDal(PremierLeagueContext context) : base(context)
        {
            _context = context;
        }

        public List<MatchEvent> GetEventsByMatchId(int matchId)
        {
            return _context.MatchEvents
                .Include(x => x.Team)
                .Where(x => x.MatchId == matchId)
                .OrderBy(x => x.Minute)
                .ToList();
        }
    }
}
