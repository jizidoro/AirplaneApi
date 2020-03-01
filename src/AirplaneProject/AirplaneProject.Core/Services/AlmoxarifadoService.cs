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
	public class AlmoxarifadoService : Service, IAlmoxarifadoService
	{
		private readonly IAlmoxarifadoRepository repository;		
		private readonly IAlmoxarifadoValidation validator;

		public AlmoxarifadoService(IAlmoxarifadoRepository repository, IAlmoxarifadoValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<Almoxarifado>> Incluir(Almoxarifado entity)
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
				return new SingleResult<Almoxarifado>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<Almoxarifado>(entity);
		}

		public async Task<ISingleResult<Almoxarifado>> Editar(Almoxarifado entity)
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
				return new SingleResult<Almoxarifado>(ex);
			}

			return new EdicaoResult<Almoxarifado>();
		}

		public async Task<ISingleResult<Almoxarifado>> Excluir(int id)
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
				return new SingleResult<Almoxarifado>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<Almoxarifado>();
		}

		private void HydrateValues(Almoxarifado target, Almoxarifado source)
		{
			target.Nome = source.Nome;
			target.Codigo = source.Codigo;
			target.CodigoCentroMrp = source.CodigoCentroMrp;
			target.CodigoAreaMrp = source.CodigoAreaMrp;
			target.Descricao = source.Descricao;
		}
	}
}
