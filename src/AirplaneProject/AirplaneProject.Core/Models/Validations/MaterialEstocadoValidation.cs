using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
    public class MaterialEstocadoValidation : EntityValidation<MaterialEstocado>, IMaterialEstocadoValidation
    {
        private readonly IMaterialEstocadoRepository _repository;


        public MaterialEstocadoValidation(IMaterialEstocadoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<MaterialEstocado>> ValidarEdicao(MaterialEstocado materialEstocado)
        {
            var registroExiste = await RegistroExiste(materialEstocado.Id);

            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            return registroExiste;
        }

        public async Task<ISingleResult<MaterialEstocado>> ValidarExclusao(int id)
        {
            return new SingleResult<MaterialEstocado>();
        }

        public async Task<ISingleResult<MaterialEstocado>> ValidarInclusao(MaterialEstocado materialEstocado)
        {
            return new SingleResult<MaterialEstocado>();
        }

    }
}
