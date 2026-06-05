using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface ITeamService
    {
        List<Team> GetList();
        void TeamAdd(Team team);
        void TeamDelete(Team team);
        void TeamUpdate(Team team);
        Team GetById(int id);
    }
}
