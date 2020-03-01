using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
    public class AssociacaoEntityValidation<TEntity> : EntityValidation<TEntity>, IAssociacaoEntityValidation<TEntity>
        where TEntity : AssociacaoEntity
    {
        private readonly IRepository<TEntity> repository;

        public AssociacaoEntityValidation(IRepository<TEntity> repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public async Task<ISingleResult<TEntity>> ValidarInclusao(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            var result = await repository.IsUnique(predicate);
            if (!result)
            {
                return new SingleResult<TEntity>(MensagensNegocio.MSG10);
            }

            return new SingleResult<TEntity>();
        }

        public async Task<ISingleResult<TEntity>> ValidarExclusao(int id)
        {
            var registroExiste = await RegistroExiste(id, ObterIncludes());
            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            var existeAssociacao = await RegistroComAssociacao(id, p => p.Esds.Any());
            if (!existeAssociacao.Sucesso)
            {
                return existeAssociacao;
            }

            var naoIndentificado = ValidarAssociacaoComNaoIdentificado(registroExiste.Data);
            if (!naoIndentificado.Sucesso)
            {
                return naoIndentificado;
            }


            return new SingleResult<TEntity>();
        }

        private ISingleResult<TEntity> ValidarAssociacaoComNaoIdentificado(TEntity entity)
        {
            var associacaoComNaoIdentificado = false;
            if (entity is EventoIniciador)
            {
                var associacao = (EventoIniciador)(entity as AssociacaoEntity);
                associacaoComNaoIdentificado = associacao.Evento.Nome.Equals("Não identificado", StringComparison.InvariantCultureIgnoreCase)
                    || associacao.Iniciador.Nome.Equals("Não identificado", StringComparison.InvariantCultureIgnoreCase);
            }
            else if (entity is OrigemAgente)
            {
                var associacao = (OrigemAgente)(entity as AssociacaoEntity);
                associacaoComNaoIdentificado = associacao.Origem.Nome.Equals("Não identificado", StringComparison.InvariantCultureIgnoreCase)
                    || associacao.Agente.Nome.Equals("Não identificado", StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                if (entity is MotivoCausa)
                {
                    var associacao = (MotivoCausa)(entity as AssociacaoEntity);
                    associacaoComNaoIdentificado = associacao.Motivo.Nome.Equals("Não identificado", StringComparison.InvariantCultureIgnoreCase)
                        || associacao.Causa.Nome.Equals("Não identificado", StringComparison.InvariantCultureIgnoreCase);
                }
            }

            if (associacaoComNaoIdentificado)
            {
                return new SingleResult<TEntity>(MensagensNegocio.MSG13);
            }

            return new SingleResult<TEntity>();
        }

        private string[] ObterIncludes()
        {
            var includes = new List<string>();
            if (typeof(TEntity) == typeof(EventoIniciador))
            {
                includes.Add(nameof(EventoIniciador.Evento));
                includes.Add(nameof(EventoIniciador.Iniciador));
            }
            else if (typeof(TEntity) == typeof(OrigemAgente))
            {
                includes.Add(nameof(OrigemAgente.Origem));
                includes.Add(nameof(OrigemAgente.Agente));
            }
            else
            {
                if (typeof(TEntity) == typeof(MotivoCausa))
                {
                    includes.Add(nameof(MotivoCausa.Motivo));
                    includes.Add(nameof(MotivoCausa.Causa));
                }
            }

            return includes.ToArray();
        }
    }
}
