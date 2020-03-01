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
	public class UepService : Service, IUepService
	{
		private readonly IUepRepository repository;		
		private readonly IUepValidation validator;

		public UepService(IUepRepository repository, IUepValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<Uep>> Incluir(Uep entity)
		{
			try
			{
				entity.Codigo = entity.Nome.ToLower().RemoveDiacritics();
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
				return new SingleResult<Uep>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<Uep>(entity);
		}

		public async Task<ISingleResult<Uep>> Editar(Uep entity)
		{
			try
			{
				entity.Codigo = entity.Nome.ToLower().RemoveDiacritics();
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
				return new SingleResult<Uep>(ex);
			}

			return new EdicaoResult<Uep>();
		}

		public async Task<ISingleResult<Uep>> Excluir(int id)
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
				return new SingleResult<Uep>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<Uep>();
		}

		private void HydrateValues(Uep target, Uep source)
		{
			target.Nome = source.Nome;
			target.AtivoId = source.AtivoId;
			target.OperacaoId = source.OperacaoId;
			target.UepTipoId = source.UepTipoId;
			target.Descricao = source.Descricao;
			target.Codigo = source.Codigo;
		}
	}
}
