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
    public class MatchEventManager : IMatchEventService
    {
        private readonly IMatchEventDal _matchEventDal;
        

        public MatchEventManager(IMatchEventDal matchEventDal)
        {
            _matchEventDal = matchEventDal;
        }

        public void Add(MatchEvent matchEvent)
        {
            _matchEventDal.Insert(matchEvent);
        }

        public void Delete(MatchEvent matchEvent)
        {
            _matchEventDal.Delete(matchEvent);
        }

        public MatchEvent GetById(int id)
        {
            return _matchEventDal.GetById(id);
        }

        public List<MatchEvent> GetList()
        {
            return _matchEventDal.GetList();
        }

        public void Update(MatchEvent matchEvent)
        {
            _matchEventDal.Update(matchEvent);
        }
    }
}
