using System;
using System.Threading.Tasks;
using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Usecases.AirplaneUsecase
{
	public class ExcluirAirplaneUsecase : Service
	{
		private readonly IAirplaneRepository _repository;		
		private readonly IAirplaneValidation _validator;

		public ExcluirAirplaneUsecase(IAirplaneRepository repository, IAirplaneValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this._repository = repository;
			this._validator = validator;
		}

		public async Task<ISingleResult<Airplane>> Execute(int id)
		{
			try
			{
				var validacao = await _validator.ValidarExclusao(id);
				if (!validacao.Sucesso)
				{
					return validacao;
				}

				_repository.Remove(id);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<Airplane>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<Airplane>();
		}

		private void HydrateValues(Airplane target, Airplane source)
		{
			target.Codigo = source.Codigo;
			target.QuantidadePassageiros = source.QuantidadePassageiros;
			target.Modelo = source.Modelo;
		}
	}
}
