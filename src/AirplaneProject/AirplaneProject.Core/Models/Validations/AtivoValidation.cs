using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class AtivoValidation : EntityValidation<Ativo>, IAtivoValidation
	{
		private readonly IAtivoRepository repository;

		public AtivoValidation(IAtivoRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<Ativo>> ValidarSeExisteMesmoNome(Ativo entity)
		{
			var result = await RegistroComMesmoNome(entity.Id, entity.Nome);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<Ativo>();
		}

		public async Task<ISingleResult<Ativo>> ValidarInclusao(Ativo entity)
		{
			return await ValidarSeExisteMesmoNome(entity);
		}

		public async Task<ISingleResult<Ativo>> ValidarEdicao(Ativo entity)
		{
			var registroExiste = await RegistroExiste(entity.Id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var registroExisteMesmoNome = await ValidarSeExisteMesmoNome(entity);
			if (!registroExisteMesmoNome.Sucesso)
			{
				return registroExisteMesmoNome;
			}

			registroExisteMesmoNome.Data = registroExiste.Data;

			return registroExisteMesmoNome;
		}

		public async Task<ISingleResult<Ativo>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var existeAssociacao = await RegistroComAssociacao(id, p => p.Ueps.Any());
			if (!existeAssociacao.Sucesso)
			{
				return existeAssociacao;
			}

			return new SingleResult<Ativo>();
		}
	}
}
