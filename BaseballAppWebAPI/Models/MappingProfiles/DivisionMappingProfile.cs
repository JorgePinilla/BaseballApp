using AutoMapper;

public class DivisionMappingProfile : Profile{
    public DivisionMappingProfile(){
        CreateMap<Division, DivisionModel>().ReverseMap();
    }
}