﻿using UniUti.Application.ValueObjects.Responses;
using UniUti.Application.ValueObjects;

namespace UniUti.Application.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoResponseVO>> FindAll();
        Task<CursoResponseVO> FindById(string id);
        Task Create(CursoCreateVO vo);
        Task Update(CursoResponseVO vo);
        Task<bool> Delete(string id);
    }
}
