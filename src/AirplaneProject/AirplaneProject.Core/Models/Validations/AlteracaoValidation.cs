using System;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
    public class AlteracaoValidation : EntityValidation<Alteracao>, IAlteracaoValidation
    {
        private readonly IAlteracaoRepository repository;
        private readonly IUser user;

        public AlteracaoValidation(IAlteracaoRepository repository, IUser user)
            : base(repository)
        {
            this.repository = repository;
            this.user = user;
        }

        public async Task<ISingleResult<Alteracao>> ValidarSeExisteEventoParaUnidadeDataHora(Alteracao evento)
        {
            var result = await repository.ExisteEventoParaUnidadeDataHora(evento.Id, evento.UepId, evento.DataEvento);
            if (result)
            {
                return new SingleResult<Alteracao>(MensagensNegocio.ResourceManager.GetString("MSG06"));
            }

            return new SingleResult<Alteracao>();
        }

        public async Task<ISingleResult<Alteracao>> ValidarSeExisteEventoParaUnidadeChecksum(Alteracao evento)
        {
            if (!string.IsNullOrWhiteSpace(evento.Checksum))
            {
                var result = await repository.ExisteEventoParaUnidadeChecksum(evento.Id, evento.UepId, evento.Checksum);
                if (result)
                {
                    return new SingleResult<Alteracao>(MensagensNegocio.ResourceManager.GetString("MSG15"));
                }
            }

            return new SingleResult<Alteracao>();
        }

        public async Task<ISingleResult<Alteracao>> ValidarInclusao(Alteracao evento)
        {

            var validaChecksum = await ValidarSeExisteEventoParaUnidadeChecksum(evento);
            if (!validaChecksum.Sucesso)
            {
                return validaChecksum;
            }

            return await ValidarSeExisteEventoParaUnidadeDataHora(evento);
        }

        public async Task<ISingleResult<Alteracao>> ValidarEdicao(Alteracao evento)
        {
            var registroExiste = await RegistroExiste(evento.Id);
            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            var validaChecksum = await ValidarSeExisteEventoParaUnidadeChecksum(evento);
            if (!validaChecksum.Sucesso)
            {
                return validaChecksum;
            }

            var eventoExisteParaUnidade = await ValidarSeExisteEventoParaUnidadeDataHora(evento);
            eventoExisteParaUnidade.Data = registroExiste.Data;

            return eventoExisteParaUnidade;
        }

        public async Task<ISingleResult<Alteracao>> ValidarExclusao(int id)
        {
            return await RegistroExiste(id, nameof(Alteracao.HistoricoAlteracoes));
        }

        public bool VerificarMudanca(Alteracao anterior, Alteracao atual)
        {


            var verificarProfissionais = anterior.AprovadorId == atual.Aprovador?.Id &&
                                         anterior.AutorizadorId == atual.Autorizador?.Id &&
                                         anterior.VerificadorId == atual.Verificador?.Id &&
                                         anterior.ExecutorId.Equals(atual.Executor.Id) &&
                                         anterior.SolicitanteId.Equals(atual.Solicitante.Id);

            var verificarSistema = anterior.CamadaId.Equals(atual.CamadaId) &&
                                   anterior.FinalidadeId.Equals(atual.FinalidadeId) &&
                                   anterior.FuncaoId.Equals(atual.FuncaoId) &&
                                   anterior.SistemaId.Equals(atual.SistemaId) &&
                                   anterior.UepId.Equals(atual.UepId);

            var verificarOutros = (anterior.Checksum?.Equals(atual.Checksum) ?? anterior.Checksum == atual.Checksum) &&
                                  (anterior.Descricao?.Equals(atual.Descricao) ?? anterior.Descricao == atual.Descricao) &&
                                  DateTime.Equals(anterior.DataEvento, atual.DataEvento);

            return verificarProfissionais && verificarSistema && verificarOutros;
        }

        public bool VerificarValidacao(Alteracao anterior, Alteracao atual)
        {
            if (user.TemPermissao(Domain.Enums.EnumRecursos.EDITAR_SITUACAO_ALTERACAO))
            {
                return false;
            }

            return anterior.SituacaoId.Equals(atual.SituacaoId);
        }

    }
}
