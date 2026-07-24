using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DashboardDtos
{
    public class TopScorerDto
    {
        public string PlayerName { get; set; }
        public string TeamName { get; set; }
        public string TeamLogoUrl { get; set; }
        public int GoalCount { get; set; }
    }
}
