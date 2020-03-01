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
	public class FabricanteService : Service, IFabricanteService
	{
		private readonly IFabricanteRepository repository;		
		private readonly IFabricanteValidation validator;

		public FabricanteService(IFabricanteRepository repository, IFabricanteValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<Fabricante>> Incluir(Fabricante entity)
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
				return new SingleResult<Fabricante>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<Fabricante>(entity);
		}

		public async Task<ISingleResult<Fabricante>> Editar(Fabricante entity)
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
				return new SingleResult<Fabricante>(ex);
			}

			return new EdicaoResult<Fabricante>();
		}

		public async Task<ISingleResult<Fabricante>> Excluir(int id)
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
				return new SingleResult<Fabricante>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<Fabricante>();
		}

		private void HydrateValues(Fabricante target, Fabricante source)
		{
			target.Nome = source.Nome;
			target.Codigo = source.Codigo;
			target.CodigoSAP = source.CodigoSAP;
			target.Descricao = source.Descricao;
		}
	}
}
