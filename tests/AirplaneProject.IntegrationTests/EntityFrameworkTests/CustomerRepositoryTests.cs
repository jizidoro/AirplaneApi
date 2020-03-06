namespace AirplaneProject.IntegrationTests.EntityFrameworkTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AirplaneProject.Application.Services;
    using AirplaneProject.Core.Models.Validations;
    using AirplaneProject.Core.Services;
    using AirplaneProject.Domain.Models;
    using AirplaneProject.Infrastructure.Data;
    using AirplaneProject.Infrastructure.Repositories;
    using AirplaneProject.Integration.Tests.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public sealed class AirplaneRepositoryTests
    {
        [Fact]
        public async Task Add_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<AirplaneProjectContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;


            var teste = new Airplane();
            teste.Codigo = "123";
            teste.Modelo = "234";
            teste.DataRegistro = new DateTime();
            teste.QuantidadePassageiros = 456;

            using (var context = new AirplaneProjectContext(options))
            {
                context.Database.EnsureCreated();

                var airplaneRepository = new AirplaneRepository(context);
                var uow = new UnitOfWork(context);
                var airplaneValidator = new AirplaneValidation(airplaneRepository);
                var airplaneService = new AirplaneService(airplaneRepository, airplaneValidator, uow);
                await airplaneService.Incluir(teste);

                Assert.Equal(1, context.Airplanes.Count());
            }
        }

        [Fact]
        public async Task Get_ReturnsAirplane()
        {
            var options = new DbContextOptionsBuilder<AirplaneProjectContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
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
