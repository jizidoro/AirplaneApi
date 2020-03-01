using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class ProfissionalValidation : EntityValidation<Profissional>, IProfissionalValidation
	{
		private readonly IProfissionalRepository repository;

		public ProfissionalValidation(IProfissionalRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<Profissional>> ValidarSeExisteMesmaChave(Profissional entity)
		{
			var result = await repository.ExisteMesmaChave(entity.Id, entity.Chave);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<Profissional>();
		}

		public async Task<ISingleResult<Profissional>> ValidarInclusao(Profissional entity)
		{
			return await ValidarSeExisteMesmaChave(entity);
		}

		public async Task<ISingleResult<Profissional>> ValidarEdicao(Profissional entity)
		{
			var registroExiste = await RegistroExiste(entity.Id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var registroExisteMesmoNome = await ValidarSeExisteMesmaChave(entity);
			if (!registroExisteMesmoNome.Sucesso)
			{
				return registroExisteMesmoNome;
			}

			registroExisteMesmoNome.Data = registroExiste.Data;

			return registroExisteMesmoNome;
		}

		public async Task<ISingleResult<Profissional>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			return new SingleResult<Profissional>();
		}
	}
}
