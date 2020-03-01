using AirplaneProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
    public interface IMaterialFornecidoValidation
    {
        Task<ISingleResult<MaterialFornecido>> ValidarInclusao(MaterialFornecido evento);

        Task<ISingleResult<MaterialFornecido>> ValidarEdicao(MaterialFornecido evento);

        Task<ISingleResult<MaterialFornecido>> ValidarExclusao(int id);
    }
}
