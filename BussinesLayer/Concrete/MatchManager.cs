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
    public class MatchManager : IMatchService
    {
        private readonly IMatchDal _matchDal;

        public MatchManager(IMatchDal matchDal)
        {
            _matchDal = matchDal;
        }

        public void Add(Match match)
        {
            _matchDal.Insert(match);
        }

        public void Delete(Match match)
        {
            _matchDal.Delete(match);
        }

    

        public Match GetById(int id)
        {
            return _matchDal.GetById(id);
        }

        public List<Match> GetList()
        {
            return _matchDal.GetList();
        }

        public Match GetMatchDetails(int id)
        {
            return _matchDal.GetMatchDetails(id);
        }

        public List<Match> GetMatchesWithTeams()
        {
            return _matchDal.GetMatchesWithTeams();
        }

        public void Update(Match match)
        {
            _matchDal.Update(match);
        }
    }
}
