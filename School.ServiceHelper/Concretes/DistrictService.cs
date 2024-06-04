using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Repository.Abstracts;
using School.Service.Abstracts;
using School.Service.Result;

namespace School.Service.Concretes;

public class DistrictService : Service<District, DistrictDTO>, IDistrictService {
    private readonly IDistrictRepository _districtRepository;

    public DistrictService(IDistrictRepository districtRepository) : base(districtRepository) {
        _districtRepository = districtRepository;
    }

    public Result<List<DistrictDTO>> ListWithCity(int cityId) {
        Result<List<DistrictDTO>> result = new();
        try {
            List<District> districts = _districtRepository.ListWithCity(cityId);
            result.Data = Mapping.Mapper.Map<List<DistrictDTO>>(districts);
        }
        catch (Exception ex) {
            result.Success = false;
            result.ErrorMessage = ex.Message;
        }
        return result;
    }
}
