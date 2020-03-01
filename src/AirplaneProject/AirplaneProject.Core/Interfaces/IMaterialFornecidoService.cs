using AirplaneProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
    public interface IMaterialFornecidoService
    {
        Task<ISingleResult<MaterialFornecido>> Incluir(MaterialFornecido evento);

        Task<ISingleResult<MaterialFornecido>> Editar(MaterialFornecido evento);

        Task<ISingleResult<MaterialFornecido>> Excluir(int id);
    }
}
