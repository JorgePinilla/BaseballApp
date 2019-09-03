using AutoMapper;

public class LeagueMappingProfile : Profile{
    public LeagueMappingProfile(){
        CreateMap<League, LeagueModel>().ReverseMap();
    }
}