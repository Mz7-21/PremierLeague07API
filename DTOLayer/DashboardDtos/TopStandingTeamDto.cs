using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DashboardDtos
{
    public class TopStandingTeamDto
    {
        public int Position { get; set; }
        public string TeamName { get; set; }
        public string LogoUrl { get; set; }
        public int Points { get; set; }
    }
}
