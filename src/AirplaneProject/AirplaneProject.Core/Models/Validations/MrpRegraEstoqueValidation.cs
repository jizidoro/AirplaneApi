using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class MrpRegraEstoqueValidation : EntityValidation<MrpRegraEstoque>, IMrpRegraEstoqueValidation
	{
		private readonly IMrpRegraEstoqueRepository repository;

		public MrpRegraEstoqueValidation(IMrpRegraEstoqueRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<MrpRegraEstoque>> ValidarSeExisteComMesmoNome(MrpRegraEstoque entity)
		{
			return new SingleResult<MrpRegraEstoque>();
		}

		public async Task<ISingleResult<MrpRegraEstoque>> ValidarInclusao(MrpRegraEstoque entity)
		{
			return await ValidarSeExisteComMesmoNome(entity);
		}

		public async Task<ISingleResult<MrpRegraEstoque>> ValidarEdicao(MrpRegraEstoque entity)
		{
			var registroExiste = await RegistroExiste(entity.Id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var registroExisteMesmoNome = await ValidarSeExisteComMesmoNome(entity);
			if (!registroExisteMesmoNome.Sucesso)
			{
				return registroExisteMesmoNome;
			}

			registroExisteMesmoNome.Data = registroExiste.Data;

			return registroExisteMesmoNome;
		}

		public async Task<ISingleResult<MrpRegraEstoque>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			return new SingleResult<MrpRegraEstoque>();
		}
	}
}
