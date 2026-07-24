using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DashboardDtos
{
    public class FeaturedMatchDto
    {
        public int MatchId { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }

        public string HomeTeamLogoUrl { get; set; }
        public string AwayTeamLogoUrl { get; set; }
        public string Stadium { get; set; }

        public DateTime MatchDate { get; set; }

        public int Week { get; set; }
    }
}

