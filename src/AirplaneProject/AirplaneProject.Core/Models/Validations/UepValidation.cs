using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class UepValidation : EntityValidation<Uep>, IUepValidation
	{
		private readonly IUepRepository repository;

		public UepValidation(IUepRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<Uep>> ValidarSeExisteMesmoNome(Uep entity)
		{
			var result = await RegistroComMesmoNome(entity.Id, entity.Nome);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<Uep>();
		}

		public async Task<ISingleResult<Uep>> ValidarInclusao(Uep entity)
		{
			return await ValidarSeExisteMesmoNome(entity);
		}

		public async Task<ISingleResult<Uep>> ValidarEdicao(Uep entity)
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

		public async Task<ISingleResult<Uep>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var existeAssociacao = await RegistroComAssociacao(id, p => p.Esds.Any());
			if (!existeAssociacao.Sucesso)
			{
				return existeAssociacao;
			}

			return new SingleResult<Uep>();
		}
	}
}
