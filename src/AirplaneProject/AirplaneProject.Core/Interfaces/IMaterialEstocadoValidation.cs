using AirplaneProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
    public interface IMaterialEstocadoValidation
    {
        Task<ISingleResult<MaterialEstocado>> ValidarInclusao(MaterialEstocado evento);

        Task<ISingleResult<MaterialEstocado>> ValidarEdicao(MaterialEstocado evento);

        Task<ISingleResult<MaterialEstocado>> ValidarExclusao(int id);
    }
}
