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
    public class MrpService : Service, IMrpService
    {
        private readonly IMrpRepository repository;
        private readonly IMrpRegraEstoqueRepository regraEstoqueRepository;
        private readonly IMrpValidation validator;

        public MrpService(IMrpRepository repository, IMrpRegraEstoqueRepository regraEstoqueRepository, IMrpValidation validator, IUnitOfWork uow)
            : base(uow)
        {
            this.repository = repository;
            this.regraEstoqueRepository = regraEstoqueRepository;
            this.validator = validator;
        }

        public async Task<ISingleResult<Mrp>> Incluir(Mrp entity)
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
                return new SingleResult<Mrp>(MensagensNegocio.MSG07);
            }

            return new InclusaoResult<Mrp>(entity);
        }

        public async Task<ISingleResult<Mrp>> Editar(Mrp entity)
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
                return new SingleResult<Mrp>(ex);
            }

            return new EdicaoResult<Mrp>();
        }

        public async Task<ISingleResult<Mrp>> Excluir(int id)
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
                return new SingleResult<Mrp>(MensagensNegocio.MSG07);
            }

            return new ExclusaoResult<Mrp>();
        }

        private void HydrateValues(Mrp target, Mrp source)
        {
            target.Nome = source.Nome;
            target.Codigo = source.Codigo;
            target.Descricao = source.Descricao;
        }
    }
}
