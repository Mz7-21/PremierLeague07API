using DTOLayer.DashboardDtos;

namespace PremierLigUi.Models
{
    public class FixtureViewModel
    {
        public int CurrentWeek { get; set; }
        public List<DashboardLatestMatchDto>? Matches { get; set; }
    }
}
