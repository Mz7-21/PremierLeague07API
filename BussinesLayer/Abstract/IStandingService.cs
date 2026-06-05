using DTOLayer.StandingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BussinesLayer.Abstract
{
    public interface IStandingService
    {
      List<StandingDto> GetStandings();
    }
}
