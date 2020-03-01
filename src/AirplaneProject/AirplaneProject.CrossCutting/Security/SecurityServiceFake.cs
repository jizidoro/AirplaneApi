using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirplaneProject.CrossCutting.Security
{
    public class SecurityServiceFake : ISecurityService
	{
		private Dictionary<string, string> chavesValidas = new Dictionary<string, string> 
		{ 
			{ "bhyw", "Leandro Baêta Lustosa Pontes" },
			{ "b1dw", "Alysson Rian Silva Vilela" },
			{ "c492", "Abraao Luiz Lopes Ribeiro" },
			{ "uq5d", "Breno Kastrup Tiberio" },
			{ "y6lz", "Thiago Brocco Sarcinelli" },
			{ "ac87", "Eduardo Cadete" },
			{ "bzdz", "Jhonatan Izidoro Antunes" }
        };

		private Dictionary<string, string> associacaoPerfil = new Dictionary<string, string>
		{
			{ "bhyw", "AdministradorGeral" },
			{ "b1dw", "AdministradorGeral" },
			{ "c492", "ValidadorAlteracao" },
			{ "uq5d", "Usuario" },
			{ "y6lz", "EditorEsd" },
			{ "ac87", "EditorAlteracao" },
			{ "bzdz", "AdministradorGeral" }
		};

		public static Dictionary<string, IList<string>> perfilRecursos => new Dictionary<string, IList<string>> 
		{ 
			{ "AdministradorGeral", new List<string> { "INSERIR_ESD", "EDITAR_ESD", "RESTAURAR_ESD", "EXCLUIR_ESD", "EDITAR_SITUACAO_ESD" ,
				"INSERIR_ALTERACAO", "EDITAR_ALTERACAO", "RESTAURAR_ALTERACAO", "EXCLUIR_ALTERACAO", "EDITAR_SITUACAO_ALTERACAO" ,
				"ACESSAR_CONFIGURACOES","ACESSAR_CONFIGURACOES_ALTERACAO" ,
				"ACESSAR_CONFIGURACOES_SOBRESSALENTE", "ACESSAR_MATERIAL_FORNECIDO","INSERIR_MATERIAL_FORNECIDO", "EDITAR_MATERIAL_FORNECIDO",
                "EXCLUIR_MATERIAL_FORNECIDO", "ACESSAR_CONFIGURACOES_MATERIAL_FORNECIDO", "ACESSAR_MATERIAL_ESTOCADO","INSERIR_MATERIAL_ESTOCADO", "EDITAR_MATERIAL_ESTOCADO",
                "EXCLUIR_MATERIAL_ESTOCADO", "ACESSAR_CONFIGURACOES_MATERIAL_ESTOCADO" } },
			{ "AdministradorEsd", new List<string> { "INSERIR_ESD", "EDITAR_ESD", "RESTAURAR_ESD", "EXCLUIR_ESD",
				"ACESSAR_CONFIGURACOES"} },
			{ "AdministradorAlteracao", new List<string> {"INSERIR_ALTERACAO", "EDITAR_ALTERACAO", "RESTAURAR_ALTERACAO", "EXCLUIR_ALTERACAO",
				"ACESSAR_CONFIGURACOES_ALTERACAO"} },
            { "AdministradorSobressalente", new List<string> {"ACESSAR_CONFIGURACOES_SOBRESSALENTE"} },
           // { "AdministradorMaterialFornecido", new List<string> {"ACESSAR_CONFIGURACOES_MATERIAL_FORNECIDO"} },
            { "EditorEsd", new List<string> { "INSERIR_ESD", "EDITAR_ESD", "RESTAURAR_ESD", "EXCLUIR_ESD" } },
			{ "EditorAlteracao", new List<string> { "INSERIR_ALTERACAO", "EDITAR_ALTERACAO", "RESTAURAR_ALTERACAO", "EXCLUIR_ALTERACAO" } },
			{ "ValidadorEsd", new List<string>{ "EDITAR_ESD", "EDITAR_SITUACAO_ESD", "RESTAURAR_ESD" } },
			{ "ValidadorAlteracao", new List<string>{"EDITAR_ALTERACAO", "EDITAR_SITUACAO_ALTERACAO", "RESTAURAR_ALTERACAO" } },
			{ "Usuario", new List<string>() }
		};

		public async Task<SecurityResult> Login(string chave, string senha)
		{
			var result = await Task<SecurityResult>.Run(() =>
			{
				var chaveValida = !string.IsNullOrEmpty(chave) && chave.Length >= 4 && chavesValidas.ContainsKey(chave.ToLowerInvariant());
				var senhaValida = !string.IsNullOrEmpty(senha) && senha.Length >= 4;

				if (chaveValida && senhaValida)
				{
					var perfil = associacaoPerfil[chave];
					var recursos = (!string.IsNullOrEmpty(perfil)) ? perfilRecursos[perfil] : null;

					var user = new User
					{
						Chave = chave,
						Nome = chavesValidas[chave.ToLowerInvariant()],
                        SessionId = Guid.NewGuid().ToString(),
                        Roles = new List<string> { perfil },
						Resources = recursos
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

        public async Task<SecurityResult> GetUser(string chave, string sessionId)
        {
            var result = await Task<SecurityResult>.Run(() =>
            {
                try
                {
                    if (!chavesValidas.ContainsKey(chave.ToLowerInvariant()))
                    {
                        return new SecurityResult(404, "Chave de usuário não encontrada.");
                    }

                    var user = new User
                    {
                        Chave = chave,
                        Nome = chavesValidas[chave.ToLowerInvariant()]
                    };

                    return new SecurityResult(user);
                }
                catch (Exception ex)
                {
                    var errorMessage = (ex.InnerException != null) ? ex.InnerException.ToString() : ex.ToString();
                    return new SecurityResult(500, errorMessage);
                }

            });

            return result;
        }
	}
}
