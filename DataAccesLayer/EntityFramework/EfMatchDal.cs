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
    public class EfMatchDal :GenericRepository<Match> ,IMatchDal
    {
        public EfMatchDal(PremierLeagueContext context) : base(context)
        {
        }
    }
}
