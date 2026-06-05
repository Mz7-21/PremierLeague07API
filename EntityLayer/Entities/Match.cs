using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Match
    {
        public int MatchId { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }
        public int Week { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public MatchStatus Status { get; set; }

        public MatchStatistic MatchStatistic { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
    }
}
