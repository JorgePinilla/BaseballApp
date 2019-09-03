using AutoMapper;

public class PersonMappingProfile : Profile{
    public PersonMappingProfile(){
        CreateMap<Person, PersonModel>().ReverseMap();
    }
}