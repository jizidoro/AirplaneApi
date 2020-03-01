using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using AirplaneProject.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IMaterialEstocadoRepository : IRepository<MaterialEstocado>
	{
        Task<MaterialEstocado> ObterMaterialEstocado(int id);
        Task<MaterialEstocado> ObterMaterialEstocado(int almoxarifadoId, int materialFornecidoId, int mrpId);
        IEnumerable<MaterialEstocadoExportacaoQuery> ObterMaterialEstocado();
        Task<bool> CalculaMrpRegraEstoque(MaterialEstocado entity, Expression<Func<MaterialEstocado, bool>> predicate);
    }
}
