using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMatchDal : IGenericDal<Match>
    {
        Match GetMatchDetails(int id);
        List<Match> GetMatchesWithTeams();
       
    }
}
