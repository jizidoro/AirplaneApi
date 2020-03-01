using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using AirplaneProject.Domain.Enums;
using System.Reflection;

namespace AirplaneProject.Core.Services
{
    public class MaterialEstocadoService : Service, IMaterialEstocadoService
    {
        private readonly IMaterialEstocadoRepository repository;
        private readonly IMrpRegraEstoqueRepository mrpRegraEstoqueRepository;
        private readonly IMaterialEstocadoValidation validator;

        public MaterialEstocadoService(IMaterialEstocadoRepository repository, IMrpRegraEstoqueRepository mrpRegraEstoqueRepository, IMaterialEstocadoValidation validator, IUnitOfWork uow)
            : base(uow)
        {
            this.repository = repository;
            this.mrpRegraEstoqueRepository = mrpRegraEstoqueRepository;
            this.validator = validator;
        }

        public async Task<ISingleResult<MaterialEstocado>> Incluir(MaterialEstocado entity)
        {
            try
            {
                var validacao = await validator.ValidarInclusao(entity);
                if (!validacao.Sucesso)
                {
                    return validacao;
                }

                entity.DataRegistro = DateTime.Now;
                await repository.Add(entity);
                CalcularSituacao(entity);
                var sucesso = await Commit();
            }
            catch (Exception ex)
            {
                return new SingleResult<MaterialEstocado>(MensagensNegocio.MSG07);
            }

            return new InclusaoResult<MaterialEstocado>(entity);
        }

        public async Task<ISingleResult<MaterialEstocado>> IncluirLista(List<MaterialEstocado> listEntity)
        {
            try
            {
                foreach (var entity in listEntity)
                {
                    if (entity.Id > 0)
                    {
                        var validacao = await validator.ValidarEdicao(entity);
                        if (!validacao.Sucesso)
                        {
                            return validacao;
                        }

                        var obj = validacao.Data;

                        HydrateValues(obj, entity);
                        CalcularSituacao(obj);
                        repository.Update(obj);
                    }
                    else
                    {
                        var result = await validator.ValidarInclusao(entity);
                        if (!result.Sucesso)
                        {
                            return result;
                        }
                        CalcularSituacao(entity);
                        await repository.Add(entity);
                    }
                }
                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<MaterialEstocado>(MensagensNegocio.MSG16);
            }

            return new InclusaoResult<MaterialEstocado>(new MaterialEstocado());
        }


        public async Task<ISingleResult<MaterialEstocado>> Editar(MaterialEstocado entity)
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
                CalcularSituacao(obj);
                repository.Update(obj);

                var sucesso = await Commit();
            }
            catch (Exception ex)
            {
                return new SingleResult<MaterialEstocado>(ex);
            }

            return new EdicaoResult<MaterialEstocado>();
        }

        public async Task<ISingleResult<MaterialEstocado>> Excluir(int id)
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
                return new SingleResult<MaterialEstocado>(MensagensNegocio.MSG07);
            }

            return new ExclusaoResult<MaterialEstocado>();
        }

        private void HydrateValues(MaterialEstocado target, MaterialEstocado source)
        {
            target.MaterialFornecidoId = source.MaterialFornecidoId;
            target.AlmoxarifadoId = source.AlmoxarifadoId;
            target.MrpId = source.MrpId;

            target.QuantidadeEstoque = source.QuantidadeEstoque;
            target.Minimo = source.Minimo;
            target.Maximo = source.Maximo;
        }

        private void CalcularSituacao(MaterialEstocado entity)
        {
            entity.SituacaoMaterialId = 1;

            var regras = mrpRegraEstoqueRepository.ObterMrpRegraEstoque(entity.MrpId);
            var regrasDinamicas = new List<Expression<Func<MaterialEstocado, bool>>>();
            foreach (var item in regras)
            {
                var parameter = Expression.Parameter(typeof(MaterialEstocado));
                BinaryExpression comparacao;

                switch (item.Operador)
                {
                    case EnumOperador.Igual:
                        comparacao = Expression.Equal(
                            Expression.Property(parameter, typeof(MaterialEstocado).GetProperty(item.Campo.ToString()) ??
                            throw new InvalidOperationException()), Expression.Constant(item.Quantidade));
                        break;
                    case EnumOperador.Diferente:
                        comparacao = Expression.NotEqual(
                            Expression.Property(parameter, typeof(MaterialEstocado).GetProperty(item.Campo.ToString()) ??
                            throw new InvalidOperationException()), Expression.Constant(item.Quantidade));
                        break;
                    case EnumOperador.Maior:
                        comparacao = Expression.GreaterThan(
                            Expression.Property(parameter, typeof(MaterialEstocado).GetProperty(item.Campo.ToString()) ??
                            throw new InvalidOperationException()), Expression.Constant(item.Quantidade));
                        break;
                    case EnumOperador.Menor:
                        comparacao = Expression.LessThan(
                            Expression.Property(parameter, typeof(MaterialEstocado).GetProperty(item.Campo.ToString()) ??
                            throw new InvalidOperationException()), Expression.Constant(item.Quantidade));
                        break;
                    case EnumOperador.MaiorOuIgual:
                        comparacao = Expression.GreaterThanOrEqual(
                            Expression.Property(parameter, typeof(MaterialEstocado).GetProperty(item.Campo.ToString()) ??
                            throw new InvalidOperationException()), Expression.Constant(item.Quantidade));
                        break;
                    case EnumOperador.MenorOuIgual:
                        comparacao = Expression.LessThanOrEqual(
                            Expression.Property(parameter, typeof(MaterialEstocado).GetProperty(item.Campo.ToString()) ??
                            throw new InvalidOperationException()), Expression.Constant(item.Quantidade));
                        break;
                    default:
                        comparacao = null;
                        break;
                }

                Expression<Func<MaterialEstocado, bool>> expressionAssociados = Expression.Lambda<Func<MaterialEstocado, bool>>(comparacao, parameter);

                regrasDinamicas.Add(expressionAssociados);
                var teste = repository.CalculaMrpRegraEstoque(entity, expressionAssociados).Result;

            }
        }
    }
}
