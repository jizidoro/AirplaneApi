using System;
using System.Threading.Tasks;
using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Usecases.AirplaneUsecase
{
	public class EditarAirplaneUsecase : Service
	{
		private readonly IAirplaneRepository _repository;		
		private readonly IAirplaneValidation _validator;

		public EditarAirplaneUsecase(IAirplaneRepository repository, IAirplaneValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this._repository = repository;
			this._validator = validator;
		}

		public async Task<ISingleResult<Airplane>> Execute(Airplane entity)
		{
			try
			{
				var result = await _validator.ValidarEdicao(entity);
				if (!result.Sucesso)
				{
					return result;
				}

				var obj = result.Data;

				HydrateValues(obj, entity);

				_repository.Update(obj);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<Airplane>(ex);
			}

			return new EdicaoResult<Airplane>();
		}
		  
		private void HydrateValues(Airplane target, Airplane source)
		{
			target.Codigo = source.Codigo;
			target.QuantidadePassageiros = source.QuantidadePassageiros;
			target.Modelo = source.Modelo;
		}
	}
}
