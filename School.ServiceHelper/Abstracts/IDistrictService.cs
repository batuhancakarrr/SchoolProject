using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.ServiceHelper.Result;

namespace School.ServiceHelper.Abstracts;

public interface IDistrictService : IService<District, DistrictDTO> {
	Result<List<DistrictDTO>> ListWithCity(int cityId);
}
