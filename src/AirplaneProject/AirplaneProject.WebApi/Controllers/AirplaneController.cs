using AirplaneProject.Application.Dtos;
using AirplaneProject.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirplaneProject.WebApi.Controllers
{
    [Authorize]
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
        [Route("Airplane-management")]
        public async Task<IActionResult> Get()
        {
            var result = await _AirplaneAppService.Listar();
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Airplane-management/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _AirplaneAppService.Obter(id);
            return Ok(result);
        }     

        [HttpPost]
        [Authorize(Policy = "CanWriteAirplaneData")]
        [Route("Airplane-management")]
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
        [Authorize(Policy = "CanWriteAirplaneData")]
        [Route("Airplane-management")]
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
        [Authorize(Policy = "CanRemoveAirplaneData")]
        [Route("Airplane-management")]
        public IActionResult Delete([FromBody]AirplaneExcluirDto AirplaneDto)
        {
            _AirplaneAppService.Excluir(AirplaneDto);
            
            return Ok();
        }
    }
}
