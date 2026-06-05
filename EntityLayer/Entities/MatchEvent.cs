using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
        public class MatchEvent
        {
            public int MatchEventId { get; set; }

            public int MatchId { get; set; }
            public Match Match { get; set; }

            public int TeamId { get; set; }
            public Team Team { get; set; }

            public MatchActionType ActionType { get; set; }
            public string Description { get; set; }
            public int Minute { get; set; }
        }
    }

