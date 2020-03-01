using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class AirplaneValidation : EntityValidation<Airplane>, IAirplaneValidation
	{
		private readonly IAirplaneRepository repository;

		public AirplaneValidation(IAirplaneRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<Airplane>> ValidarSeExisteMesmoCodigo(Airplane entity)
		{
			var result = await RegistroComMesmoCodigo(entity.Id, entity.Codigo);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<Airplane>();
		}

		public async Task<ISingleResult<Airplane>> ValidarInclusao(Airplane entity)
		{
			return await ValidarSeExisteMesmoCodigo(entity);
		}

		public async Task<ISingleResult<Airplane>> ValidarEdicao(Airplane entity)
		{
			var registroExiste = await RegistroExiste(entity.Id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var registroExisteMesmoCodigo = await ValidarSeExisteMesmoCodigo(entity);
			if (!registroExisteMesmoCodigo.Sucesso)
			{
				return registroExisteMesmoCodigo;
			}

			registroExisteMesmoCodigo.Data = registroExiste.Data;

			return registroExisteMesmoCodigo;
		}

		public async Task<ISingleResult<Airplane>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}


			return new SingleResult<Airplane>();
		}
	}
}
