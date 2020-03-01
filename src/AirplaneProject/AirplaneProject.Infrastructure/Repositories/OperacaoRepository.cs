using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class OperacaoRepository : Repository<Operacao>, IOperacaoRepository
	{
		public OperacaoRepository(GestaoEsdContext context)
			: base(context)
		{
		}
	}
}