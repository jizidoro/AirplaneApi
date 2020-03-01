using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Services
{
    public class MaterialFornecidoService : Service, IMaterialFornecidoService
    {
        private readonly IMaterialFornecidoValidation _validator;
        private readonly IMaterialFornecidoRepository _repository;

        public MaterialFornecidoService(IMaterialFornecidoRepository repository, IMaterialFornecidoValidation validator, IUnitOfWork uow)
        : base(uow)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<ISingleResult<MaterialFornecido>> Incluir(MaterialFornecido materialFornecido)
        {
            var validacao = await _validator.ValidarInclusao(materialFornecido);

            if (!validacao.Sucesso)
            {
                return validacao;
            }

            try
            {
                materialFornecido.Codigo = materialFornecido.Nome.ToLower().RemoveDiacritics();

                await _repository.Add(materialFornecido);

                var sucesso = await Commit();
            }
            catch (Exception ex)
            {
                return new SingleResult<MaterialFornecido>(ex);
            }

            return new InclusaoResult<MaterialFornecido>(materialFornecido);
        }

        public async Task<ISingleResult<MaterialFornecido>> Editar(MaterialFornecido materialFornecido)
        {
            var result = await _validator.ValidarEdicao(materialFornecido);
            if (!result.Sucesso)
            {
                return result;
            }

            try
            {
                materialFornecido.Codigo = materialFornecido.Nome.ToLower().RemoveDiacritics();
                var entity = result.Data;

                HydrateValues(entity, materialFornecido);

                _repository.Update(entity);

                var sucesso = await Commit();
            }
            catch (Exception ex)
            {
                return new SingleResult<MaterialFornecido>(ex);
            }

            return new EdicaoResult<MaterialFornecido>();
        }

        public async Task<ISingleResult<MaterialFornecido>> Excluir(int id)
        {
            var validacao = await _validator.ValidarExclusao(id);

            if (!validacao.Sucesso)
            {
                return validacao;
            }

            try
            {
                _repository.Remove(id);

                var sucesso = await Commit();
            }
            catch (Exception ex)
            {
                return new SingleResult<MaterialFornecido>(ex);
            }

            return new ExclusaoResult<MaterialFornecido>();
        }



        private void HydrateValues(MaterialFornecido target, MaterialFornecido source)
        {
            target.FabricanteId = source.FabricanteId;
            target.ClasseMaterialId = source.ClasseMaterialId;
            target.NM = source.NM;
            target.PartNumber = source.PartNumber;
            target.Modelo = source.Modelo;
            target.Nome = source.Nome;
            
            target.Codigo = source.Codigo;
        }

    }
}
