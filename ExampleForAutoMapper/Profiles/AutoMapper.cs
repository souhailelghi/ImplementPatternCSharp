using AutoMapper;
using ExampleForAutoMapper.Dto;
using ExampleForAutoMapper.Model;

namespace ExampleForAutoMapper.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            //Employee to EmployeeDto 
            CreateMap<Employee, EmployeeDto>()
                .ForMember(d=>d.IdDto , src=>src.MapFrom(s=>s.Id))
                .ForMember(d=>d.NameDto , src=>src.MapFrom(s=>s.Name))
                .ForMember(d=>d.AgeDto , src=>src.MapFrom(s=>s.Age))
                .ForMember(d=>d.AmountDto , src=>src.MapFrom(s=>s.Amount))
                .ForMember(d=>d.TypeEmployeeDto , src=>src.MapFrom(s=>s.TypeEmployee))
                .ReverseMap();


            //Product to ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(d=>d.IdDto , src=>src.MapFrom(s=>s.Id))
                .ReverseMap();

            //Customer to CustomerDto
            CreateMap<Customer, CustomerDto>()
                .ForMember(d=>d.IdDto , src=>src.MapFrom(s=>s.Id))
                .ReverseMap();
        }

    }
}
