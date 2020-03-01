using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class AlmoxarifadoValidation : EntityValidation<Almoxarifado>, IAlmoxarifadoValidation
	{
		private readonly IAlmoxarifadoRepository repository;

		public AlmoxarifadoValidation(IAlmoxarifadoRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}


		public async Task<ISingleResult<Almoxarifado>> ValidarRegistro(Almoxarifado entity)
		{
			var result = await repository.ExisteMesmoCodigoCentroMrp(entity.Id, entity.CodigoCentroMrp);
			if (!result.Sucesso)
			{
				return result;
			}

			result = await RegistroComMesmoNome(entity.Id, entity.Nome);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<Almoxarifado>();
		}

		public async Task<ISingleResult<Almoxarifado>> ValidarInclusao(Almoxarifado entity)
		{
			return await ValidarRegistro(entity);
		}

		public async Task<ISingleResult<Almoxarifado>> ValidarEdicao(Almoxarifado entity)
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

		public async Task<ISingleResult<Almoxarifado>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var registroExisteAssociacoes = await repository.ExisteAssociacoes(id);
			if (!registroExisteAssociacoes.Sucesso)
			{
				return registroExisteAssociacoes;
			}

			return new SingleResult<Almoxarifado>();
		}
	}
}
