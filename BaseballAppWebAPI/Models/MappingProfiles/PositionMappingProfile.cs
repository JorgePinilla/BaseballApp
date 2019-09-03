using AutoMapper;

public class PositionMappingProfile : Profile{
    public PositionMappingProfile(){
        CreateMap<Position, PositionModel>().ReverseMap();
    }
}