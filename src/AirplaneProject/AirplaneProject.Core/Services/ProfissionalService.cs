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
	public class ProfissionalService : Service, IProfissionalService
	{
		private readonly IProfissionalRepository repository;		
		private readonly IProfissionalValidation validator;

		public ProfissionalService(IProfissionalRepository repository, IProfissionalValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<Profissional>> Incluir(Profissional entity)
		{
			try
			{
				var validacao = await validator.ValidarInclusao(entity);
				if (!validacao.Sucesso)
				{
					return validacao;
				}

				await repository.Add(entity);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<Profissional>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<Profissional>(entity);
		}

		public async Task<ISingleResult<Profissional>> Editar(Profissional entity)
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
				return new SingleResult<Profissional>(ex);
			}

			return new EdicaoResult<Profissional>();
		}

		public async Task<ISingleResult<Profissional>> Excluir(int id)
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
				return new SingleResult<Profissional>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<Profissional>();
		}

		private void HydrateValues(Profissional target, Profissional source)
		{
			target.Nome = source.Nome;
			target.Chave = source.Chave;
		}
	}
}
