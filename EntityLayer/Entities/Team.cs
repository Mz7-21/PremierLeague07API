using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
        public class Team
        {
            public int TeamId { get; set; }
            public string Name { get; set; }
            public string ShortName { get; set; }
            public string LogoUrl { get; set; }
            public string City { get; set; }
            public string StadiumName { get; set; }

        public List<Match> HomeMatches { get; set; } = new List<Match>();
        public List<Match> AwayMatches { get; set; } = new List<Match>();
    }
    }


