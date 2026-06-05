namespace PremierLigApi.Dtos.TeamDtos
{
    public class UpdateTeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LogoUrl { get; set; }
        public string City { get; set; }
        public string StadiumName { get; set; }
    }
}
