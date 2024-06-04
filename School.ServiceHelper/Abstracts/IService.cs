using School.Service.Result;

namespace School.Service.Abstracts;
public interface IService<T, DTO> where T : class where DTO : class {
    Result<List<DTO>> List();
    Result<DTO> GetById(int id, bool withTracking = false);
    Result<bool> Insert(DTO entity);
    Result<bool> Update(DTO entity);
    Result<bool> Delete(int id);
}
