using System;
using System.Threading.Tasks;

namespace AirplaneProject.CrossCutting.Security
{
	public class BasicSecurityService : IBasicSecurityService
	{
		private const string CHAVE = "autbs";
		private const string PASSWORD = "y98t59";
		private const string NOME = "Chave de Serviço";

		public async Task<SecurityResult> Login(string chave, string senha)
		{
			var result = await Task<SecurityResult>.Run(() =>
			{
				var chaveValida = !string.IsNullOrEmpty(chave) && CHAVE.Equals(chave, StringComparison.InvariantCultureIgnoreCase);
				var senhaValida = !string.IsNullOrEmpty(chave) && PASSWORD.Equals(senha);

				if (chaveValida && senhaValida)
				{
					var user = new User
					{
						Chave = chave,
						Nome = NOME
					};

					return new SecurityResult(user);
				}
				else if (!chaveValida)
				{
					return new SecurityResult(101, "Usuário ou senha informado não é válido");
				}
				else
				{
					return new SecurityResult(102, "Senha expirada");
				}
			});

			return result;
		}
	}
}
