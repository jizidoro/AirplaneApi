using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Enums;
using AirplaneProject.Domain.Interfaces;
using System;

namespace AirplaneProject.Core.Models.Results
{
	public class SingleResult<TEntity> : ISingleResult<TEntity>
		where TEntity : IEntity
	{
		public SingleResult()
		{
			this.Sucesso = true;
		}

		public SingleResult(string mensagem)
		{
			this.Sucesso = false;			
			this.Mensagem = mensagem;
		}

		public SingleResult(Exception ex)
		{
			this.Sucesso = false;
			//this.Mensagem = MensagensNegocio.ResourceManager.GetString("MSG07");
		}

		public SingleResult(TEntity data)
		{
			this.Sucesso = data != null;
			this.Mensagem = (data == null) ? MensagensNegocio.ResourceManager.GetString("MSG04") : string.Empty;
			this.Data = data;
		}

		public bool Sucesso { get; set; }
		public string Mensagem { get; set; }
		public TEntity Data { get; set; }
	}
}
