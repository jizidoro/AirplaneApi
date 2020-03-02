using AirplaneProject.Application.Dtos;
using AirplaneProject.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirplaneProject.WebApi.Controllers
{
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneAppService _AirplaneAppService;

        public AirplaneController(
            IAirplaneAppService AirplaneAppService)
        {
            _AirplaneAppService = AirplaneAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Airplane")]
        public async Task<IActionResult> Get()
        {
            var result = await _AirplaneAppService.Listar();
            return Ok(result.Data);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Airplane/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _AirplaneAppService.Obter(id);
            return Ok(result.Data);
        }     

        [HttpPost]
        //[Authorize(Policy = "CanWriteAirplaneData")]
        [AllowAnonymous]
        [Route("Airplane")]
        public async Task<IActionResult> Post([FromBody]AirplaneIncluirDto AirplaneDto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(AirplaneDto);
            }

            var result = await _AirplaneAppService.Incluir(AirplaneDto);

            return Ok(AirplaneDto);
        }
        
        [HttpPut]
        //[Authorize(Policy = "CanWriteAirplaneData")]
        [AllowAnonymous]
        [Route("Airplane")]
        public async Task<IActionResult> Put([FromBody]AirplaneEditarDto AirplaneDto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(AirplaneDto);
            }

            var result = await _AirplaneAppService.Editar(AirplaneDto);

            return Ok(result);
        }

        [HttpDelete]
        //[Authorize(Policy = "CanRemoveAirplaneData")]
        [AllowAnonymous]
        [Route("Airplane/{id:int}")]
        public IActionResult Delete(int id)
        {
            _AirplaneAppService.Excluir(id);
            
            return Ok();
        }
    }
}
