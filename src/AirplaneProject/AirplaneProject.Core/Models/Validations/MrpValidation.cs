using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class MrpValidation : EntityValidation<Mrp>, IMrpValidation
	{
		private readonly IMrpRepository repository;

		public MrpValidation(IMrpRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<Mrp>> ValidarSeExisteComMesmoNome(Mrp entity)
		{
			var result = await RegistroComMesmoNome(entity.Id, entity.Nome);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<Mrp>();
		}

		public async Task<ISingleResult<Mrp>> ValidarInclusao(Mrp entity)
		{
			return await ValidarSeExisteComMesmoNome(entity);
		}

		public async Task<ISingleResult<Mrp>> ValidarEdicao(Mrp entity)
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

		public async Task<ISingleResult<Mrp>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			return new SingleResult<Mrp>();
		}
	}
}
