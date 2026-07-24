using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOLayer.MatchDto
{
    public class MatchEventDetailDto
    {


        [JsonPropertyName("matchEventId")]
        public int MatchEventId { get; set; }

        [JsonPropertyName("matchId")]
        public int MatchId { get; set; }

        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        [JsonPropertyName("teamName")]
        public string TeamName { get; set; }

        [JsonPropertyName("teamLogoUrl")]
        public string TeamLogoUrl { get; set; }

        [JsonPropertyName("minute")]
        public int Minute { get; set; }

        [JsonPropertyName("actionType")]
        public int ActionType { get; set; }

        [JsonPropertyName("playerName")]
        public string? PlayerName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
