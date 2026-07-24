using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOLayer.MatchDto
{
    public class MatchStatisticDetailDto
    {
        [JsonPropertyName("matchStatisticId")]
        public int MatchStatisticId { get; set; }

        [JsonPropertyName("matchId")]
        public int MatchId { get; set; }

        [JsonPropertyName("homeFirstHalfGoals")]
        public int HomeFirstHalfGoals { get; set; }

        [JsonPropertyName("awayFirstHalfGoals")]
        public int AwayFirstHalfGoals { get; set; }

        [JsonPropertyName("homeSecondHalfGoals")]
        public int HomeSecondHalfGoals { get; set; }

        [JsonPropertyName("awaySecondHalfGoals")]
        public int AwaySecondHalfGoals { get; set; }

        [JsonPropertyName("homeYellowCards")]
        public int HomeYellowCards { get; set; }

        [JsonPropertyName("awayYellowCards")]
        public int AwayYellowCards { get; set; }

        [JsonPropertyName("homeRedCards")]
        public int HomeRedCards { get; set; }

        [JsonPropertyName("awayRedCards")]
        public int AwayRedCards { get; set; }
    }
}
 
