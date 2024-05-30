using AutoMapper;
using School.Data.Entities.Concrete.Schools;
using School.Dto;
using EntitySchool = School.Data.Entities.Concrete.Schools.School;

namespace School.Service;

public static class Mapping {
	private static readonly Lazy<IMapper> Lazy = new(() => {
		MapperConfiguration config = new(cfg => {
			cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
			cfg.AddProfile<MappingProfile>();
		});
		IMapper mapper = config.CreateMapper();
		return mapper;
	});

	public static IMapper Mapper => Lazy.Value;
}
public class MappingProfile : Profile {
	public MappingProfile() {
		CreateMap<Student, StudentDTO>().ReverseMap();
		CreateMap<EntitySchool, SchoolDTO>().ReverseMap();
		CreateMap<Class, ClassDTO>().ReverseMap();
		CreateMap<Teacher, TeacherDTO>().ReverseMap();
		CreateMap<ClassTeacher, ClassTeacherDTO>().ReverseMap();
		CreateMap<City, CityDTO>().ReverseMap();
		CreateMap<District, DistrictDTO>().ReverseMap();
		CreateMap<Admin, AdminDTO>().ReverseMap();
	}
}
