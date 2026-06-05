using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IMatchService
    {
        void Add(Match match);
        void Delete(Match match);
        void Update(Match match);
        List<Match> GetList();
        Match GetById(int id);
    }
}
