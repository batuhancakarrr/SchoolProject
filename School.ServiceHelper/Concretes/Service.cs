using Repository.Abstracts;
using School.ServiceHelper.Abstracts;
using School.ServiceHelper.Result;

namespace School.ServiceHelper.Concretes;
public class Service<T, DTO> : IService<T, DTO> where T : class where DTO : class {
    private readonly IRepository<T> _repository;

    public Service(IRepository<T> repository) {
        _repository = repository;
    }

    public Result<List<DTO>> List() {
        Result<List<DTO>> response = new();
        try {
            List<T> entities = _repository.List();
            List<DTO> dtos = Mapping.Mapper.Map<List<DTO>>(entities);

            response.Data = dtos;
        }
        catch (Exception ex) {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        return response;
    }

    public Result<DTO> GetById(int id, bool withTracking = false) {
        Result<DTO> response = new();
        try {
            T entity = _repository.GetById(id, withTracking);
            DTO dto = Mapping.Mapper.Map<DTO>(entity);
            if (dto == null) return new Result<DTO>(false, "Veri bulunamadı");
            response.Data = dto;
        }
        catch (Exception ex) {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        return response;
    }

    public Result<bool> Insert(DTO entity) {
        Result<bool> response = new();
        try {
            T entityToAdd = Mapping.Mapper.Map<T>(entity);
            _repository.Insert(entityToAdd);
            response.Data = true;
            response.Message = "Veriler başarıyla eklendi.";
        }
        catch (Exception ex) {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        return response;
    }

    public Result<bool> Update(DTO entity) {
        Result<bool> response = new();
        try {
            T entityToUpdate = Mapping.Mapper.Map<T>(entity);
            _repository.Update(entityToUpdate);
            response.Data = true;
            response.Message = "Veriler başarıyla güncellendi.";
        }
        catch (Exception ex) {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        return response;
    }

    public Result<bool> Delete(int id) {
        Result<bool> response = new();
        try {
            T entity = _repository.GetById(id, false);
            if (entity == null) {
                response.Success = false;
                response.ErrorMessage = "Veri bulunamadı";
            }
            else {
                _repository.Delete(entity);
                response.Data = true;
                response.Message = "Veriler başarıyla silindi.";
            }
        }
        catch (Exception ex) {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
