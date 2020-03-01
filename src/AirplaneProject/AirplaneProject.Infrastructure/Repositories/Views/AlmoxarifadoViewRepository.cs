using System;
using System.Linq;
using AirplaneProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AirplaneProject.Infrastructure.Bases;
using System.Threading.Tasks;
using AirplaneProject.Core.Repositories.Views;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Domain.Models.Views;
using System.Linq.Expressions;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Infrastructure.Repositories.Views
{
	public class AlmoxarifadoViewRepository : Repository<AlmoxarifadoView>, IAlmoxarifadoViewRepository
	{
		public AlmoxarifadoViewRepository(GestaoEsdContext context)
            : base(context)
        {
		}

    }
}
