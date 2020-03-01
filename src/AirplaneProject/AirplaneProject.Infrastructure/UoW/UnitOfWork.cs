using AirplaneProject.Core.Interfaces;
using AirplaneProject.Infrastructure.Data;
using System.Threading.Tasks;

namespace AirplaneProject.Infrastructure.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly GestaoAirplaneContext context;

		public UnitOfWork(GestaoAirplaneContext context)
		{
			this.context = context;
		}

		public async Task<bool> Commit()
		{
			return await context.SaveChangesAsync() > 0;
		}

		public void Dispose()
		{
			context.Dispose();
		}
	}
}
