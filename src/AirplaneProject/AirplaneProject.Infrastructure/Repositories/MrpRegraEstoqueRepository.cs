using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Linq.Expressions;
using System;
using AirplaneProject.Core.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AirplaneProject.Core.Models.Results;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class MrpRegraEstoqueRepository : Repository<MrpRegraEstoque>, IMrpRegraEstoqueRepository
	{
		public MrpRegraEstoqueRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

		public IQueryable<MrpRegraEstoque> ObterMrpRegraEstoque(int mrpId)
		{
			var obj = Db.MrpRegraEstoques.Where(x => x.MrpId == mrpId);

			return obj;
		}
	}
}