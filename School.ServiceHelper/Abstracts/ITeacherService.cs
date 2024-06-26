﻿using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.ServiceHelper.Abstracts;
using School.ServiceHelper.Result;

namespace School.ServiceHelper.Abstracts;

public interface ITeacherService : IService<Teacher, TeacherDTO> {
    Result<List<ClassTeacherDTO>> GetClassesByTeacherId(int teacherId);
    Result<bool> Add(TeacherDTO teacher);
    Result<bool> Update(int id, string name, string branch);
    Task<Result<TeacherDTO>> Login(string username, string password);

}
