using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class ClasseMaterialValidation : EntityValidation<ClasseMaterial>, IClasseMaterialValidation
	{
		private readonly IClasseMaterialRepository repository;

		public ClasseMaterialValidation(IClasseMaterialRepository repository)
			: base(repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<ClasseMaterial>> ValidarSeExisteMesmoNome(ClasseMaterial entity)
		{
			var result = await RegistroComMesmoNome(entity.Id, entity.Nome);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<ClasseMaterial>();
		}

		public async Task<ISingleResult<ClasseMaterial>> ValidarInclusao(ClasseMaterial entity)
		{
			return await ValidarSeExisteMesmoNome(entity);
		}

		public async Task<ISingleResult<ClasseMaterial>> ValidarEdicao(ClasseMaterial entity)
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

		public async Task<ISingleResult<ClasseMaterial>> ValidarExclusao(int id)
		{
			var registroExiste = await RegistroExiste(id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			return new SingleResult<ClasseMaterial>();
		}
	}
}
