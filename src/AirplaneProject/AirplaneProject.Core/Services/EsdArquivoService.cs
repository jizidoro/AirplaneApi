using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Services
{
	public class EsdArquivoService : Service, IEsdArquivoService
	{
		private readonly IEsdArquivoRepository repository;

		public EsdArquivoService(IEsdArquivoRepository repository, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<EsdArquivo>> Incluir(EsdArquivo evento)
		{
			try
			{
				await repository.Add(evento);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<EsdArquivo>(MensagensNegocio.ResourceManager.GetString("MSG07"));
			}

			return new InclusaoResult<EsdArquivo>(evento);
		}

		public async Task<ISingleResult<EsdArquivo>> Excluir(int id)
		{

			try
			{
				repository.Remove(id);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<EsdArquivo>(MensagensNegocio.ResourceManager.GetString("MSG07"));
			}

			return new ExclusaoResult<EsdArquivo>();
		}
    }
}
