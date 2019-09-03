using AutoMapper;

public class RosterMappingProfile : Profile{
    public RosterMappingProfile(){
        CreateMap<Roster, RosterModel>().ReverseMap();
    }
}