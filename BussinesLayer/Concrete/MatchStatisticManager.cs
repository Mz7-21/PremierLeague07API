using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class MatchStatisticManager : IMatchStatisticService
    {
        private readonly IMatchStatisticDal _matchStatisticDal;

        public MatchStatisticManager(IMatchStatisticDal matchStatisticDal)
        {
            _matchStatisticDal = matchStatisticDal;
        }

        public void Add(MatchStatistic matchStatistic)
        {
            _matchStatisticDal.Insert(matchStatistic);
        }

        public void Delete(MatchStatistic matchStatistic)
        {
            _matchStatisticDal.Delete(matchStatistic);
        }

        public MatchStatistic GetById(int id)
        {
            return _matchStatisticDal.GetById(id);
        }

        public List<MatchStatistic> GetList()
        {
            return _matchStatisticDal.GetList();
        }
       

        public void Update(MatchStatistic matchStatistic)
        {
            _matchStatisticDal.Update(matchStatistic);
        }
    }
}
