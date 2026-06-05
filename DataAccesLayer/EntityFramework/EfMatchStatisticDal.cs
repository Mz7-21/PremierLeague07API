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
    public class EfMatchStatisticDal:GenericRepository<MatchStatistic>, IMatchStatisticDal
    {
        public EfMatchStatisticDal(PremierLeagueContext context) : base(context)
        {
        }
    }
}
