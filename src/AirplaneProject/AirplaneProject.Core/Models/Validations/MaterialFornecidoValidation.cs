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
    public class MaterialFornecidoValidation : EntityValidation<MaterialFornecido>, IMaterialFornecidoValidation
    {
        private readonly IMaterialFornecidoRepository _repository;


        public MaterialFornecidoValidation(IMaterialFornecidoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<MaterialFornecido>> ValidarEdicao(MaterialFornecido evento)
        {
            var registroExiste = await RegistroExiste(evento.Id, ObterIncludes());

            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            var validarNome = await _repository.ExisteMaterialFornecidoComMesmoNM(evento.NM, evento.Id);

            if (validarNome)
            {
                return new SingleResult<MaterialFornecido>(MensagensNegocio.ResourceManager.GetString("MSG08"));
            }

            var validarCodigo = await _repository.ExisteMaterialFornecidoComMesmoCodigo(evento.Codigo, evento.Id);

            if (validarCodigo)
            {
                return new SingleResult<MaterialFornecido>(MensagensNegocio.ResourceManager.GetString("MSG17"));
            }

            return registroExiste;
        }

        public async Task<ISingleResult<MaterialFornecido>> ValidarExclusao(int id)
        {
            var result = await _repository.PossuiMateriaisEstocados(id);

            if (result)
            {
                return new SingleResult<MaterialFornecido>(MensagensNegocio.ResourceManager.GetString("MSG09"));
            }

            return new SingleResult<MaterialFornecido>();
        }

        public async Task<ISingleResult<MaterialFornecido>> ValidarInclusao(MaterialFornecido evento)
        {
            var validarNome = await _repository.ExisteMaterialFornecidoComMesmoNM(evento.NM);

            if (validarNome)
            {
                return new SingleResult<MaterialFornecido>(MensagensNegocio.ResourceManager.GetString("MSG08"));
            }

            var validarCodigo = await _repository.ExisteMaterialFornecidoComMesmoCodigo(evento.Codigo);

            if (validarCodigo)
            {
                return new SingleResult<MaterialFornecido>(MensagensNegocio.ResourceManager.GetString("MSG17"));
            }

            return new SingleResult<MaterialFornecido>();
        }


        private string[] ObterIncludes()
        {
            var includes = new List<string>();

            includes.Add(nameof(MaterialFornecido.ClasseMaterial));
            includes.Add(nameof(MaterialFornecido.Fabricante));

            return includes.ToArray();
        }
    }
}
