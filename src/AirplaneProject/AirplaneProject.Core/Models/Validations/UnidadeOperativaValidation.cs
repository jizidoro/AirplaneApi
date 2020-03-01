using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class UnidadeOperativaValidation : EntityValidation<UnidadeOperativa>, IUnidadeOperativaValidation
	{
		private readonly IUnidadeOperativaRepository repository;

		public UnidadeOperativaValidation(IUnidadeOperativaRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<UnidadeOperativa>> ValidarSeExisteMesmoNome(UnidadeOperativa entity)
		{
			var result = await RegistroComMesmoNome(entity.Id, entity.Nome);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<UnidadeOperativa>();
		}

		public async Task<ISingleResult<UnidadeOperativa>> ValidarInclusao(UnidadeOperativa entity)
		{
			return await ValidarSeExisteMesmoNome(entity);
		}

		public async Task<ISingleResult<UnidadeOperativa>> ValidarEdicao(UnidadeOperativa entity)
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

		public async Task<ISingleResult<UnidadeOperativa>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var existeAssociacao = await RegistroComAssociacao(id, p => p.Ativos.Any());
			if (!existeAssociacao.Sucesso)
			{
				return existeAssociacao;
			}

			return new SingleResult<UnidadeOperativa>();
		}
	}
}
