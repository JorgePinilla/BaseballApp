using AutoMapper;

public class StatMappingProfile : Profile{
    public StatMappingProfile(){
        CreateMap<Stat, StatModel>().ReverseMap();
    }
}