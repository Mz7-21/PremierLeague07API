using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IMatchEventService
    {
        List<MatchEvent> GetList();
        void Add(MatchEvent matchEvent);
        void Delete(MatchEvent matchEvent);
        void Update(MatchEvent matchEvent);
        MatchEvent GetById(int id);
        List<MatchEvent> GetEventsByMatchId(int matchId);
    }
}
