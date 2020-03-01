using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class UnidadeOperativaRepository : Repository<UnidadeOperativa>, IUnidadeOperativaRepository
	{
		public UnidadeOperativaRepository(GestaoEsdContext context)
			: base(context)
		{
		}

		public IQueryable<UnidadeOperativa> ListarArvoreElementos()
		{
			var x = Db.UnidadesOperativas
					.Include(uo => uo.Ativos)
					.ThenInclude(atv => atv.Ueps)
					.OrderBy(k => k.Nome)
					.Select(k => new UnidadeOperativa
					{
						Id = k.Id,
						Codigo = k.Codigo,
						Nome = k.Nome,
						Descricao = k.Descricao,
						Ativos = k.Ativos
								.OrderBy(a => a.Nome)
								.Select(a => new Ativo
								{
									Id = a.Id,
									Codigo = k.Codigo + "/" + a.Codigo,
									Nome = a.Nome,
									Descricao = a.Descricao,
									Ueps = a.Ueps
										.OrderBy(u => u.Nome)
										.Select(u => new Uep
										{
											Id = u.Id,
											Codigo = k.Codigo + "/" + a.Codigo + "/" + u.Codigo,
											Nome = u.Nome,
											Descricao = u.Descricao
										})
								})
					})
					.AsQueryable();

			return x;
		}
	}
}