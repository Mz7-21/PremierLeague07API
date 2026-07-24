using AutoMapper;
using EntityLayer.Entities;
using PremierLigApi.Dtos.MatchDtos;
using PremierLigApi.Dtos.MatchEventDtos;
using PremierLigApi.Dtos.MatchStatisticDtos;
using PremierLigApi.Dtos.TeamDtos;



namespace PremierLigApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, ResultTeamDto>().ReverseMap();

            CreateMap<Team, GetByIdTeamDto>().ReverseMap();

            CreateMap<Team, CreateTeamDto>().ReverseMap();

            CreateMap<Team, UpdateTeamDto>().ReverseMap();



            CreateMap<Match, ResultMatchDto>().ReverseMap();

            CreateMap<Match, GetByIdMatchDto>().ReverseMap();

            CreateMap<Match, CreateMatchDto>().ReverseMap();

            CreateMap<Match, UpdateMatchDto>().ReverseMap();



            CreateMap<MatchEvent, CreateMatchEventDto>().ReverseMap();

            CreateMap<MatchEvent, UpdateMatchEventDto>().ReverseMap();

            CreateMap<MatchEvent, ResultMatchEventDto>().ReverseMap();

            CreateMap<MatchEvent, GetByIdMatchEventDto>().ReverseMap();

            CreateMap<MatchStatistic, CreateMatchStatisticDto>().ReverseMap();

            CreateMap<MatchStatistic, UpdateMatchStatisticDto>().ReverseMap();

            CreateMap<MatchStatistic, ResultMatchStatisticDto>().ReverseMap();

            CreateMap<MatchStatistic, GetByIdMatchStatisticDto>().ReverseMap();
        }
    }
}
