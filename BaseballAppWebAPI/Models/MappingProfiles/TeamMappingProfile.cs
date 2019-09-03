using AutoMapper;

public class TeamMappingProfile : Profile{
    public TeamMappingProfile(){
        CreateMap<Team, TeamModel>().ReverseMap();
    }
}