using System.Threading.Tasks;

namespace AirplaneProject.CrossCutting.Security
{
	public interface IBasicSecurityService
	{
		Task<SecurityResult> Login(string chave, string senha);
	}
}
