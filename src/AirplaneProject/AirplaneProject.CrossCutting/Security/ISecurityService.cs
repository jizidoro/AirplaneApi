using System.Threading.Tasks;

namespace AirplaneProject.CrossCutting.Security
{
	public interface ISecurityService
	{
		Task<SecurityResult> Login(string chave, string senha);

        Task<SecurityResult> GetUser(string chave, string sessionId);
    }
}
