using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Result;

namespace School.Service.Abstracts;

public interface IDistrictService : IService<District, DistrictDTO> {
	Result<List<DistrictDTO>> ListWithCity(int cityId);
}
