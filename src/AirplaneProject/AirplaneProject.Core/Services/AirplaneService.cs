using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Services
{
	public class AirplaneService : Service, IAirplaneService
	{
		private readonly IAirplaneRepository repository;		
		private readonly IAirplaneValidation validator;

		public AirplaneService(IAirplaneRepository repository, IAirplaneValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<Airplane>> Incluir(Airplane entity)
		{
			try
			{
				var validacao = await validator.ValidarInclusao(entity);
				if (!validacao.Sucesso)
				{
					return validacao;
				}
				entity.DataRegistro = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
				await repository.Add(entity);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<Airplane>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<Airplane>(entity);
		}

		public async Task<ISingleResult<Airplane>> Editar(Airplane entity)
		{
			try
			{
				var result = await validator.ValidarEdicao(entity);
				if (!result.Sucesso)
				{
					return result;
				}

				var obj = result.Data;

				HydrateValues(obj, entity);

				repository.Update(obj);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<Airplane>(ex);
			}

			return new EdicaoResult<Airplane>();
		}

		public async Task<ISingleResult<Airplane>> Excluir(int id)
		{
			try
			{
				var validacao = await validator.ValidarExclusao(id);
				if (!validacao.Sucesso)
				{
					return validacao;
				}

				repository.Remove(id);

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
