﻿using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Data
{
	public class GestaoAirplaneContext : DbContext
	{
		private const string JSON_PATH = "Automacao.Infrastructure.SeedData";

		public GestaoAirplaneContext(DbContextOptions<GestaoAirplaneContext> options)
			: base(options)
		{			
		}

		// Tabelas
		public DbSet<Airplane> Airplanes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Tabelas
			modelBuilder.ApplyConfiguration(new AirplaneConfiguration());
		}
	}
}
