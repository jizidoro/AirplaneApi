namespace AirplaneProject.IntegrationTests.EntityFrameworkTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AirplaneProject.Application.AutoMapper;
    using AirplaneProject.Application.Dtos;
    using AirplaneProject.Application.Services;
    using AirplaneProject.Core.Models.Validations;
    using AirplaneProject.Core.Services;
    using AirplaneProject.Domain.Models;
    using AirplaneProject.Infrastructure.Data;
    using AirplaneProject.Infrastructure.Repositories;
    using AirplaneProject.Integration.Tests.Helpers;
    using AirplaneProject.IntegrationTests.Helpers;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public sealed class AirplaneRepositoryTests
    {
        private AirplaneAppService ObterAirplaneAppService(AirplaneProjectContext context)
        {
            var uow = new UnitOfWork(context);
            var airplaneRepository = new AirplaneRepository(context);
            var airplaneValidator = new AirplaneValidation(airplaneRepository);
            var airplaneService = new AirplaneService(airplaneRepository, airplaneValidator, uow);
            var mapper = MapperHelper.ConfigMapper();

            return new AirplaneAppService(airplaneRepository, airplaneService, mapper);
        }


        [Fact]
        public async Task Add_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<AirplaneProjectContext>()
                .UseInMemoryDatabase(databaseName: "test_database_change_database")
                .Options;


            var teste = new AirplaneIncluirDto();
            teste.Codigo = "123";
            teste.Modelo = "234";
            teste.QuantidadePassageiros = 456;

            using (var context = new AirplaneProjectContext(options))
            {
                context.Database.EnsureCreated();

                var airplaneAppService = ObterAirplaneAppService(context);

                _ = await airplaneAppService.Incluir(teste);

                Assert.Equal(1, context.Airplanes.Count());
            }
        }

        [Fact]
        public async Task Get_ReturnsAirplane()
        {
            var options = new DbContextOptionsBuilder<AirplaneProjectContext>()
                .UseInMemoryDatabase(databaseName: "test_database_return_airplane")
                .Options;

            Airplane airplane = null;

            using (var context = new AirplaneProjectContext(options))
            {
                context.Database.EnsureCreated();
                Utilities.InitializeDbForTests(context);
                var repository = new AirplaneRepository(context);
                airplane = await repository.GetById(1);
                Assert.NotNull(airplane);
            }
        }
    }
}
