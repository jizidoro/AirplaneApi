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
	public class ClasseMaterialService : Service, IClasseMaterialService
	{
		private readonly IClasseMaterialRepository repository;		
		private readonly IClasseMaterialValidation validator;

		public ClasseMaterialService(IClasseMaterialRepository repository, IClasseMaterialValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<ClasseMaterial>> Incluir(ClasseMaterial entity)
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
				return new SingleResult<ClasseMaterial>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<ClasseMaterial>(entity);
		}

		public async Task<ISingleResult<ClasseMaterial>> Editar(ClasseMaterial entity)
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
				return new SingleResult<ClasseMaterial>(ex);
			}

			return new EdicaoResult<ClasseMaterial>();
		}

		public async Task<ISingleResult<ClasseMaterial>> Excluir(int id)
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
				return new SingleResult<ClasseMaterial>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<ClasseMaterial>();
		}

		private void HydrateValues(ClasseMaterial target, ClasseMaterial source)
		{
			target.Nome = source.Nome;
			target.Codigo = source.Codigo;
			target.Descricao = source.Descricao;
			target.CategoriaMaterialId = source.CategoriaMaterialId;
		}
	}
}
