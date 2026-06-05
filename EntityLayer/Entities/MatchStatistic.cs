using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
        public class MatchStatistic
        {
            public int MatchStatisticId { get; set; }

            public int MatchId { get; set; }
            public Match Match { get; set; }

            public int HomeFirstHalfGoals { get; set; }
            public int AwayFirstHalfGoals { get; set; }

            public int HomeSecondHalfGoals { get; set; }
            public int AwaySecondHalfGoals { get; set; }

            public int HomeYellowCards { get; set; }
            public int AwayYellowCards { get; set; }

            public int HomeRedCards { get; set; }
            public int AwayRedCards { get; set; }
        }
    }


