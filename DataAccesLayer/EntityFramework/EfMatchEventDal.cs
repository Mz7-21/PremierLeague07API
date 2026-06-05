using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMatchEventDal : GenericRepository<MatchEvent>, IMatchEventDal
    {
        public EfMatchEventDal(PremierLeagueContext context) : base(context)
        {
        }
    }
}
