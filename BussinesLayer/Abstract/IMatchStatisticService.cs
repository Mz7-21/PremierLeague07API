using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IMatchStatisticService
    {
        List<MatchStatistic> GetList();
        MatchStatistic GetById(int id);
        void Add(MatchStatistic matchStatistic);
        void Delete(MatchStatistic matchStatistic);
        void Update(MatchStatistic matchStatistic);
    }
}
