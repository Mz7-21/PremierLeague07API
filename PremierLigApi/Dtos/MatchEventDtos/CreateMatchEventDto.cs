using EntityLayer.Entities;
using EntityLayer.Enums;

namespace PremierLigApi.Dtos.MatchEventDtos
{
    public class CreateMatchEventDto
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
      
        public int Minute { get; set; }

        public MatchActionType ActionType { get; set; }

        public string Description { get; set; }
    }
}
