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
	public class IncluirAirplaneUsecase : Service
	{
		private readonly IAirplaneRepository _repository;		
		private readonly IAirplaneValidation _validator;

		public IncluirAirplaneUsecase(IAirplaneRepository repository, IAirplaneValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this._repository = repository;
			this._validator = validator;
		}

		public async Task<ISingleResult<Airplane>> Execute(Airplane entity)
		{
			try
			{
				var validacao = await _validator.ValidarInclusao(entity);
				if (!validacao.Sucesso)
				{
					return validacao;
				}
				entity.DataRegistro = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
				await _repository.Add(entity);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<Domain.Models.Airplane>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<Domain.Models.Airplane>(entity);
		}
	}
}
