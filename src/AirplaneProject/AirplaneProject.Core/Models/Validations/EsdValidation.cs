using System;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class EsdValidation : EntityValidation<Esd>, IEsdValidation
	{
		private readonly IEsdRepository repository;
		private readonly IUser user;

		public EsdValidation(IEsdRepository repository, IUser user)
			: base(repository)
		{
			this.repository = repository;
			this.user = user;
		}

		public async Task<ISingleResult<Esd>> ValidarSeExisteEventoParaUnidadeDataHora(Esd evento)
		{
			var result = await repository.ExisteEventoParaUnidadeDataHora(evento.Id, evento.UepId, evento.DataEvento);
			if (result)
			{
				return new SingleResult<Esd>(MensagensNegocio.ResourceManager.GetString("MSG06"));
			}

			return new SingleResult<Esd>();
		}

		public async Task<ISingleResult<Esd>> ValidarInclusao(Esd evento)
		{
			return await ValidarSeExisteEventoParaUnidadeDataHora(evento);
		}

		public async Task<ISingleResult<Esd>> ValidarEdicao(Esd evento)
		{
			var registroExiste = await RegistroExiste(evento.Id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

			var eventoExisteParaUnidade = await ValidarSeExisteEventoParaUnidadeDataHora(evento);
			eventoExisteParaUnidade.Data = registroExiste.Data;

			return eventoExisteParaUnidade;
		}

		public async Task<ISingleResult<Esd>> ValidarExclusao(int id)
		{
			return await RegistroExiste(id, nameof(Esd.Historicos));
		}

		public bool VerificarMudanca(Esd anterior, Esd atual)
		{
			return anterior.OrigemAgenteId.Equals(atual.OrigemAgenteId) &&
			       anterior.MotivoCausaId.Equals(atual.MotivoCausaId) &&
			       anterior.EventoIniciadorId.Equals(atual.EventoIniciadorId) &&
			       anterior.NivelOperacaoId.Equals(atual.NivelOperacaoId) &&
			       anterior.UepId.Equals(atual.UepId) &&
			       DateTime.Equals(anterior.DataEvento, atual.DataEvento) &&
			       (anterior.Descricao?.Equals(atual.Descricao) ?? anterior.Descricao == atual.Descricao) &&
			       (anterior.Alarme?.Equals(atual.Alarme) ?? anterior.Alarme == atual.Alarme) &&
			       (anterior.LinkRta?.Equals(atual.LinkRta) ?? anterior.LinkRta == atual.LinkRta) &&
			       (anterior.LinkGip?.Equals(atual.LinkGip) ?? anterior.LinkGip == atual.LinkGip) &&
			       (anterior.LinkCadinc?.Equals(atual.LinkCadinc) ?? anterior.LinkCadinc == atual.LinkCadinc) &&
			       (anterior.LinkSitop?.Equals(atual.LinkSitop) ?? anterior.LinkSitop == atual.LinkSitop) &&
				   anterior.SituacaoId.Equals(atual.SituacaoId);
		}
		
		public bool VerificarValidacao(Esd anterior, Esd atual)
		{
			if (user.TemPermissao(Domain.Enums.EnumRecursos.EDITAR_SITUACAO_ESD))
			{
				return false;
			}

			return anterior.SituacaoId.Equals(atual.SituacaoId);
		}
	}
}
