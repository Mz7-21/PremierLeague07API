using EntityLayer.Entities;
using EntityLayer.Enums;

namespace PremierLigApi.Dtos.MatchEventDtos
{
    public class GetByIdMatchEventDto
    {
        public int MatchEventId { get; set; }

        public int MatchId { get; set; }
        public int TeamId { get; set; }
        
        public int Minute { get; set; }

        public MatchActionType ActionTypes { get; set; }

        public string Description { get; set; }
    }
}
