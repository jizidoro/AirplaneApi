using AirplaneProject.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
    public interface IMaterialEstocadoService
    {
        Task<ISingleResult<MaterialEstocado>> Incluir(MaterialEstocado entity);

        Task<ISingleResult<MaterialEstocado>> IncluirLista(List<MaterialEstocado> listEntity);

        Task<ISingleResult<MaterialEstocado>> Editar(MaterialEstocado entity);

        Task<ISingleResult<MaterialEstocado>> Excluir(int id);
    }
}
