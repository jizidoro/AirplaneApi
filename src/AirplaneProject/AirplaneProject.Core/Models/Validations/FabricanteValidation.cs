using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class FabricanteValidation : EntityValidation<Fabricante>, IFabricanteValidation
	{
		private readonly IFabricanteRepository repository;

		public FabricanteValidation(IFabricanteRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<Fabricante>> ValidarRegistro(Fabricante entity)
		{
			var result = await repository.ExisteMesmoCodigoSap(entity.Id, entity.CodigoSAP);
			if (!result.Sucesso)
			{
				return result;
			}

			result = await RegistroComMesmoNome(entity.Id, entity.Nome);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<Fabricante>();
		}

		public async Task<ISingleResult<Fabricante>> ValidarInclusao(Fabricante entity)
		{
			return await ValidarRegistro(entity);
		}

		public async Task<ISingleResult<Fabricante>> ValidarEdicao(Fabricante entity)
		{
			var registroExiste = await RegistroExiste(entity.Id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var registroExisteMesmoNome = await ValidarRegistro(entity);
			if (!registroExisteMesmoNome.Sucesso)
			{
				return registroExisteMesmoNome;
			}

			registroExisteMesmoNome.Data = registroExiste.Data;

			return registroExisteMesmoNome;
		}

		public async Task<ISingleResult<Fabricante>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			return new SingleResult<Fabricante>();
		}
	}
}
