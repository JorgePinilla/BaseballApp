using AutoMapper;

public class VenueMappingProfile : Profile{
    public VenueMappingProfile(){
        CreateMap<Venue, VenueModel>().ReverseMap();
    }
}